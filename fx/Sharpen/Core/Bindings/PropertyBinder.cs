// PropertyBinder.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;

namespace Sharpen.Html.Bindings {

    /// <summary>
    /// This binds the property of an object to the value of an expression, and
    /// updates the object as the expression's value changes.
    /// </summary>
    internal class PropertyBinder : Binder {

        private object _target;
        private string _propertyName;
        private Expression _expression;

        internal PropertyBinder(object target, string propertyName, Expression expression) {
            _target = target;
            _propertyName = propertyName;
            _expression = expression;

            if (_expression.CanChange) {
                _expression.Subscribe(Update);
            }
        }

        public override void Dispose() {
            _target = null;
        }

        internal override void Update() {
            if (_target != null) {
                UpdateTarget(_target, _propertyName, _expression.GetValue());
            }
        }

        protected void UpdateSource(object value) {
            _expression.SetValue(value);
        }

        protected virtual void UpdateTarget(object target, string propertyName, object value) {
            Script.SetField(target, propertyName, value);
        }
    }
}
