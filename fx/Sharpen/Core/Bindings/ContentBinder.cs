// ContentBinder.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;

namespace Sharpen.Html.Bindings {

    /// <summary>
    /// Binds the content (textContent/innerHTML) of element to an expression.
    /// </summary>
    internal sealed class ContentBinder : PropertyBinder {

        public ContentBinder(Element target, string property, Expression expression)
            : base(target, property, expression) {
        }

        protected override void UpdateTarget(object target, string propertyName, object value) {
            Element targetElement = (Element)target;

            // Convert the value into a string if it isn't already... do this with a template
            // if one is specified, or resort to ToString as a fallback.
            string content = null;
            if (value is string) {
                content = (string)value;
            }
            else {
                string templateName = (string)targetElement.GetAttribute("data-template");
                if (String.IsNullOrEmpty(templateName) == false) {
                    Template template = Application.Current.GetTemplate(templateName);
                    if (template != null) {
                        content = template(value, /* index */ 0, /* context */ null);
                    }
                }
                else {
                    content = value.ToString();
                }
            }

            // Raise contentUpdating event, so it allows any behaviors attached to this
            // element to be notified
            MutableEvent updatingEvent = Document.CreateEvent("Custom");
            updatingEvent.InitCustomEvent("contentUpdating", /* canBubble */ false, /* canCancel */ false, null);
            targetElement.DispatchEvent(updatingEvent);

            // Deactivate the content, in case current content has attached behaviors or bindings.
            Application.Current.DeactivateFragment(targetElement, /* contentOnly */ true);

            // Update the element with the new value.
            base.UpdateTarget(targetElement, propertyName, content);

            // If the property that was updated was the innerHTML, then activate any
            // binding expressions or behaviors that might have been specified within the
            // new markup.
            if ((String.IsNullOrEmpty(content) == false) && (propertyName == "innerHTML")) {
                BinderManager binderManager = (BinderManager)Behavior.GetBehavior(targetElement, typeof(BinderManager));
                if (binderManager != null) {
                    Application.Current.ActivateFragment(targetElement, /* contentOnly */ true, binderManager.Model);
                }
            }

            // Raise contentUpdated event, so it allows any behaviors attached to this
            // element to be notified
            MutableEvent updatedEvent = Document.CreateEvent("Custom");
            updatedEvent.InitCustomEvent("contentUpdated", /* canBubble */ false, /* canCancel */ false, null);
            targetElement.DispatchEvent(updatedEvent);
        }
    }
}
