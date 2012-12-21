// Application.Bindings.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using Sharpen.Bindings;

namespace Sharpen {

    public sealed partial class Application {

        private static Binder BindContent(Element element, string property, Expression expression) {
            property = (property == "text") ? "textContent" : "innerHTML";
            return new ContentBinder(element, property, expression);
        }

        private static Binder BindValue(Element element, string property, Expression expression) {
            Debug.Assert((element.TagName.ToLowerCase() == "input") ||
                         (element.TagName.ToLowerCase() == "textarea") ||
                         (element.TagName.ToLowerCase() == "select"),
                         "Value can only be bound on user input elements.");

            return new ValueBinder((InputElement)element, expression);
        }

        private static Binder BindVisibility(Element element, string property, Expression expression) {
            return new VisibilityBinder(element, property, expression);
        }

        private static Expression ProcessModelExpression(object model, string expressionType, string value) {
            Debug.Assert(Script.GetField(model, value) != null, "The model does not have a member named '" + value + '"');

            if (expressionType == "exec") {
                // TODO: Support scenarios where value is parent.method, or root.method (for invoking
                //       a method on the parent model or root model... useful in templating scenarios
                //       where items are not bound to view model but an object retrieved from the
                //       view model.

                // When the expression is exec, the value is interpreted as a reference to a method
                // on the model. An invoker function is created that when called invokes the referenced
                // method in context of the model instance. The expression itself contains a delegate
                // to this dynamically created invoker function.

                // function _(e) {
                //   var result = this.modelMethod(e, this);
                //   if (result) { e.preventDefault(); }
                // }

                // TODO: If bound to parent/root, generated this instead:
                // function _(e) {
                //   var model = Application.Current.GetModel(element.parentElement);
                //   var result = this.modelMethod(e, model);
                //   if (result) { e.preventDefault(); }
                // }

                string invokerCode = "var result = this." + value + "(e, this); if (result) { e.preventDefault(); }";
                return new Expression(Delegate.Create(new Function(invokerCode, "e", "model"), model), /* canChange */ false);
            }

            // TODO: Eventually stop with the () business if we can switch over to true properties
            //       with getter/setter accessors in javascript.

            // Check if the value is something like A.B.C, where A, B and C are identifiers.
            bool propertyPathExpression = PropertyPathRegex.Test(value);

            // The value represents a string that contains a script expression for properties off
            // the model.
            string getterCode;
            if (propertyPathExpression) {
                // If its a simple property path, then we parenthesize since in script, the
                // properties are represented as functions.
                value = value.Replace(".", "().");
                getterCode = "return model." + value + "();";
            }
            else {
                // If its not a simple property path, we're going to assume that the developer
                // has referenced the property functions themselves, and we use as-is.
                getterCode = "with(model) { return " + value + "; }";
            }

            Func<object, object> getter = (Func<object, object>)(object)new Function(getterCode, "model");

            if (expressionType == "init") {
                // Read-only, one-time binder... so execute the getter, and create
                // an expression with the current value.
                return new Expression(getter(model), /* canChange */ false);
            }
            else if (expressionType == "link") {
                // Read-only, bound binder... create a BindExpression that tracks the
                // value by observing any observables representing the property.
                return new BindExpression(model, getter, null);
            }
            else {
                // Read-write, bound binder ... must be a simple property path.

                if (propertyPathExpression == false) {
                    Debug.Fail("A bind expression's value must be a property path. The expression '" + value + "' is invalid.");
                }

                string setterCode = "model." + value + "(value);";
                Action<object, object> setter = (Action<object, object>)(object)new Function(setterCode, "model", "value");

                return new BindExpression(model, getter, setter);
            }
        }

        /// <summary>
        /// Registers a binder factory. The supplied name prefixed with "data-" is used
        /// as the attribute name in markup to create a binder.
        /// </summary>
        /// <param name="name">The name of the expression handler.</param>
        /// <param name="factory">The factory being registered.</param>
        public void RegisterBinder(string name, BinderFactory factory) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(factory != null);
            Debug.Assert(_registeredBinders.ContainsKey(name) == false, "A binder with name '" + name + "' was already registered.");

            _registeredBinders[name] = factory;
        }

        /// <summary>
        /// Registers an expression factory. The supplied name is used in markup to represent
        /// an instance of the associated expression.
        /// </summary>
        /// <param name="name">The name of expression.</param>
        /// <param name="factory">The factory to be used to handle the supplied name.</param>
        public void RegisterExpression(string name, ExpressionFactory factory) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(factory != null);
            Debug.Assert(_registeredExpressions.ContainsKey(name) == false, "An expression factory with name '" + name + "' was already registered.");

            _registeredExpressions[name] = factory;
        }

        private void SetupBindings(Element element, object model) {
            Debug.Assert(element != null);

            string bindings = (string)element.GetAttribute(Application.BindingsAttribute);
            bindings.ReplaceRegex(Application.BindingsRegex, delegate(string match /*, string binderType, string expressionType, string expressionValue */) {
                string binderType = (string)Arguments.GetArgument(1);
                string expressionType = (string)Arguments.GetArgument(2);
                string expressionValue = (string)Arguments.GetArgument(3);

                ExpressionFactory expressionFactory = _registeredExpressions[expressionType];
                Debug.Assert(expressionFactory != null, "Unknown expression of type '" + expressionType + "' found.");

                if (expressionFactory != null) {
                    Expression expression = expressionFactory(model, expressionType, expressionValue);
                    Binder binder = null;

                    // TODO: Add support for binding attributes - @xxx

                    if (binderType.StartsWith("on.")) {
                        Debug.Assert(expression.CanChange == false, "Events cannot be bound to dynamic expressions.");
                        Debug.Assert(expression.GetValue() is Action);

                        binder = new EventBinder(element, binderType.Substr(3), (ElementEventListener)expression.GetValue());
                    }
                    else if (binderType.StartsWith("style.")) {
                        object style = element.Style;
                        binder = new PropertyBinder(style, binderType.Substr(6), expression);
                    }
                    else {
                        BinderFactory binderFactory = _registeredBinders[binderType];
                        if (binderFactory == null) {
                            binder = new PropertyBinder(element, binderType, expression);
                        }
                        else {
                            binder = binderFactory(element, binderType, expression);
                        }
                    }

                    if (binder != null) {
                        binder.Update();
                        if (expression.CanChange == false) {
                            // Since the expression value cannot change, there isn't a whole lot of need
                            // to keep the binder alive and manage it.
                            binder = null;
                        }
                    }

                    if (binder != null) {
                        // The binder is managed using a behavior that is attached to the element.
                        // This allows stashing the model for later retrieval, as well as a way to
                        // dispose bindings (the behavior disposes all binders it is managing).

                        BinderManager binderManager = (BinderManager)Behavior.GetBehavior(element, typeof(BinderManager));
                        if (binderManager == null) {
                            binderManager = new BinderManager();
                            binderManager.Initialize(element, null);
                            binderManager.Model = model;
                        }

                        binderManager.AddBinder(binder);
                    }
                }

                return String.Empty;
            });
        }
    }
}
