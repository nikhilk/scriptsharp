// ValueBinder.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;

namespace Sharpen.Bindings {

    /// <summary>
    /// Binds the value property of an input element to an expression.
    /// This binder supports two-way binding.
    /// </summary>
    internal sealed class ValueBinder : PropertyBinder {

        private InputElement _target;
        private ElementEventListener _changeListener;

        public ValueBinder(InputElement target, Expression expression)
            : base(target, "value", expression) {
            _target = target;
            _changeListener = OnChanged;
            target.AddEventListener("change", _changeListener, false);
        }

        public override void Dispose() {
            if (_target != null) {
                _target.RemoveEventListener("change", _changeListener, false);
                _target = null;
            }
        }

        private void OnChanged(ElementEvent e) {
            UpdateSource(_target.Value);
        }
    }
}
