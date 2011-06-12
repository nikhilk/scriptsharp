// Knockout.cs
// Script#/Libraries/Knockout
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    /// <summary>
    /// Provides Knockout functionality.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("ko")]
    public static class Knockout {

        /// <summary>
        /// Gets the mapping plugin which allows converting models to plain
        /// objects and JSON and vice-versa.
        /// </summary>
        [IntrinsicProperty]
        public static KnockoutMapping Mapping {
            get {
                return null;
            }
        }

        /// <summary>
        /// Sets up bindings using the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public static void ApplyBindings(object model) {
        }

        /// <summary>
        /// Sets up bindings within the specified root element using the specified the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="rootElement">The element to bind to.</param>
        public static void ApplyBindings(object model, Element rootElement) {
        }

        /// <summary>
        /// Creates an observable with a value computed from one or more other values.
        /// </summary>
        /// <param name="function">A function to compute the value.</param>
        /// <returns>A new dependent observable instance.</returns>
        /// <typeparam name="T">The type of the observable value/</typeparam>
        public static DependentObservable<T> DependentObservable<T>(Func<T> function) {
            return null;
        }
        
        /// <summary>
        /// Creates an observable value.
        /// </summary>
        /// <typeparam name="T">The type of the observable.</typeparam>
        /// <returns>A new observable value instance.</returns>
        public static Observable<T> Observable<T>() {
            return null;
        }

        /// <summary>
        /// Creates an observable with an initial value.
        /// </summary>
        /// <typeparam name="T">The type of the observable.</typeparam>
        /// <param name="initialValue">The initial value.</param>
        /// <returns>A new observable value instance.</returns>
        public static Observable<T> Observable<T>(T initialValue) {
            return null;
        }

        /// <summary>
        /// Creates an empty observable array.
        /// </summary>
        /// <returns>A new observable array.</returns>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        public static ObservableArray<T> ObservableArray<T>() {
            return null;
        }

        /// <summary>
        /// Creates an observable array with some initial items.
        /// </summary>
        /// <param name="initialItems">A sequence of initial items.</param>
        /// <returns>A new observable array.</returns>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        public static ObservableArray<T> ObservableArray<T>(IEnumerable<T> initialItems) {
            return null;
        }
    }
}
