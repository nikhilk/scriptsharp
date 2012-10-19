// Observable.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace KnockoutApi {

    /// <summary>
    /// Represents an object containing an observable value.
    /// </summary>
    /// <typeparam name="T">The type of the contained value.</typeparam>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class Observable<T> : Subscribable<T> {

        internal Observable() {
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
        /// <param name="value">The new value.</param>
        [ScriptName("")]
        public void SetValue(T value) {
        }

        /// <summary>
        /// Notifies All Subscribers that the Value has Changed
        /// Called internally with SetValue
        /// </summary>
        public void ValueHasMutated() {
        }

        /// <summary>
        /// Notifies All Subscribers BEFORE the Value has Changed
        /// Called internally with SetValue
        /// </summary>
        public void ValueWillMutate() {
        }

        /// <summary>
        /// For Primitive Types ko will handle Equality internally
        /// For complex types a supplied function can be assigned to improve
        /// change (mutation) detection
        /// </summary>
        [ScriptField]
        public Func<T, T, bool> EqualityComparer {
            get;
            set;
        }

        /// <summary>
        /// For dependent observables, we throttle *evaluations* so that, no matter how fast its dependencies        
        /// notify updates, the target doesn't re-evaluate (and hence doesn't notify) faster than a certain rate
        /// For writable targets (observables, or writable dependent observables), we throttle *writes*        
        /// so the target cannot change value synchronously or faster than a certain rate
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Returns 'this' inorder to support chaining methods</returns>
        public new Observable<T> Extend(Dictionary options) {
            return null;
        }
    }
}
