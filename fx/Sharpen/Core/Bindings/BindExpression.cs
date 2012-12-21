// BindExpression.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.ComponentModel;

namespace Sharpen.Html.Bindings {

    /// <summary>
    /// Implementation of an expression that binds to a value off the model and
    /// tracks changes by virtue of being an observer.
    /// </summary>
    internal sealed class BindExpression : Expression, IObserver {

        private object _model;
        private Func<object, object> _getter;
        private Action<object, object> _setter;

        public BindExpression(object model, Func<object, object> getter, Action<object, object> setter)
            : base(null, /* canChange */ true) {
            _model = model;
            _getter = getter;
            _setter = setter;

            RetrieveValue(/* notify */ false);
        }

        public void InvalidateObserver() {
            RetrieveValue(/* notify */ true);
        }

        private void RetrieveValue(bool notify) {
            object value;

            IDisposable observation = ObserverManager.RegisterObserver(this);
            try {
                value = _getter(_model);
                UpdateValue(value, notify);
            }
            catch {
                // TODO: Error handling (logging + breakpoint if debugger attached)
            }
            finally {
                observation.Dispose();
            }
        }

        public override void SetValue(object value) {
            if (_setter != null) {
                try {
                    _setter(_model, value);
                }
                catch {
                    // TODO: Error handling (logging + breakpoint if debugger attached)
                }
            }
        }
    }
}
