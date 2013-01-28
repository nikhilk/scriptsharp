// VisibilityBinder.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Html;

namespace Sharpen.Bindings {

    /// <summary>
    /// Binds the visibility of an element to an expression.
    /// </summary>
    internal sealed class VisibilityBinder : PropertyBinder {

        private string _visibleDisplay;
        private bool _useDisplay;

        public VisibilityBinder(Element target, string property, Expression expression)
            : base(target, property, expression) {
            _visibleDisplay = target.Style.Display;
            _useDisplay = String.IsNullOrEmpty(_visibleDisplay) == false;
        }

        protected override void UpdateTarget(object target, string propertyName, object value) {
            if (_useDisplay) {
                string displayValue = (bool)value ? _visibleDisplay : "none";
                base.UpdateTarget(((Element)target).Style, "display", displayValue);
            }
            else {
                string visibilityValue = (bool)value ? "visible" : "hidden";
                base.UpdateTarget(((Element)target).Style, "visibility", visibilityValue);
            }
        }
    }
}
