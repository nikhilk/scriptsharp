// Observable.cs
// Script#/Libraries/Knockout
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace KnockoutApi {

    /// <summary>
    /// Represents an object containing an observable value.
    /// </summary>
    /// <typeparam name="T">The type of the contained value.</typeparam>
    [Imported]
    [IgnoreNamespace]
    public class Observable<T> : Subscribable<T> {

        protected Observable() : base() { }

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
        /// <param name="value">The new value.</param>
        /// <returns>Specification Supports chaining</returns>
        [ScriptName("")]
        public Observable<T> SetValue(T value) {
            return null;
        }

        /// <summary>
        /// Notifies All Subscribers that the Value has Changed
        /// Called internally with SetValue
        /// </summary>
        public void ValueHasMutated() { }


        /// <summary>
        /// Notifies All Subscribers BEFORE the Value has Changed
        /// Called internally with SetValue
        /// </summary>
        public void ValueWillMutated() { }

        /// <summary>
        /// For Primitive Types ko will handle Equality internally
        /// For complex types a supplied function can be assigned to improve 
        /// change (mutation) detection
        /// </summary>
        [IntrinsicProperty]
        public Func<T, T, bool> EqualityComparer { get; set; }

        /// <summary>
        /// For dependent observables, we throttle *evaluations* so that, no matter how fast its dependencies        
        /// notify updates, the target doesn't re-evaluate (and hence doesn't notify) faster than a certain rate
        /// For writable targets (observables, or writable dependent observables), we throttle *writes*        
        /// so the target cannot change value synchronously or faster than a certain rate
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Extend is Chainable</returns>
        public new Observable<T> Extend(Dictionary options) { return null; }
    }
}
