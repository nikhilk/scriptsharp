// Observable.cs
// Script#/Libraries/Knockout
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    /// <summary>
    /// Represents an object containing an observable value.
    /// </summary>
    /// <typeparam name="T">The type of the contained value.</typeparam>
    [Imported]
    [IgnoreNamespace]
    public sealed class Observable<T> {

        private Observable() {
        }

        /// <summary>
        /// Gets the current value within the observable object.
        /// </summary>
        /// <returns>The current value.</returns>
        [ScriptName("")]
        public T GetValue() {
            return default(T);
        }

        /// <summary>
        /// Sets the value within the observable object.
        /// </summary>
        [ScriptName("")]
        public void SetValue(T value) {
        }

        /// <summary>
        /// Subscribes to change notifications raised when the value changes.
        /// </summary>
        /// <param name="changeCallback">The callback to invoke.</param>
        /// <returns>A subscription cookie that can be disposed to unsubscribe.</returns>
        public IDisposable Subscribe(Action<T> changeCallback) {
            return null;
        }
    }
}
