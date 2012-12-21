// Expression.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace Sharpen.Html {

    /// <summary>
    /// Represents the base class for all expressions. Expressions represent
    /// a value, and optionally a value that can change after being read (in which
    /// case, it provides a mechanism to subscribe for changes)
    /// </summary>
    public class Expression {

        private bool _canChange;
        private Action _changeCallback;
        private object _value;

        /// <summary>
        /// Initializes and instance of an Expression.
        /// </summary>
        /// <param name="value">The initial value of the expression.</param>
        /// <param name="canChange">Whether the expression represents a value that can change.</param>
        public Expression(object value, bool canChange) {
            _value = value;
            _canChange = canChange;
        }

        /// <summary>
        /// Gets whether the expression represents a value that can change.
        /// </summary>
        public bool CanChange {
            get {
                return _canChange;
            }
        }

        /// <summary>
        /// Gets the current value of the expression.
        /// </summary>
        /// <returns>The current value.</returns>
        public object GetValue() {
            return _value;
        }

        /// <summary>
        /// Sets the value of the expression. Most expressions are read-only and ignore
        /// this call, but some expressions do support the ability to write back.
        /// </summary>
        /// <param name="value">The new value of the expression.</param>
        public virtual void SetValue(object value) {
            // By default expressions are read-only, so they ignore SetValue calls
            // TODO: Should there be a IsReadOnly property?
        }

        /// <summary>
        /// Allows a consumer of the expression to subscribe to change notifications.
        /// </summary>
        /// <param name="changeCallback">The callback to be invoked.</param>
        public void Subscribe(Action changeCallback) {
            if (_canChange) {
                _changeCallback = changeCallback;
            }
        }

        /// <summary>
        /// Updates the value represented by the expression.
        /// </summary>
        /// <param name="value">The new value of the expression.</param>
        /// <param name="notify">Whether to notify the subscriber of the change.</param>
        protected void UpdateValue(object value, bool notify) {
            _value = value;
            if (notify && (_changeCallback != null)) {
                _changeCallback();
            }
        }
    }
}
