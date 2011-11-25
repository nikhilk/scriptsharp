// Knockout.cs
// Script#/Libraries/Knockout
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
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
        /// Provides access to the currently registered binding handlers.
        /// </summary>
        [IntrinsicProperty]
        public static Dictionary<string, BindingHandler> BindingHandlers {
            get {
                return null;
            }
        }

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
        /// Gets the current model.
        /// </summary>
        /// <returns>The object represented by 'this' within a handler.</returns>
        [ScriptAlias("this")]
        [IntrinsicProperty]
        public static object Model {
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
        /// Set up bindings on a single node without binding any of its descendents.
        /// </summary>
        /// <param name="node">The node to bind to.</param>
        /// <param name="bindings">An optional dictionary of bindings, pass null to let Knockout gather them from the element.</param>
        /// <param name="viewModel">The view model instance.</param>
        public static void ApplyBindingsToNode(Element node, Dictionary bindings, object viewModel) {
        }

        /// <summary>
        /// Set up bindings on a single node without binding any of its descendents.
        /// </summary>
        /// <param name="node">The node to bind to.</param>
        /// <param name="bindings">An optional dictionary of bindings, pass null to let Knockout gather them from the element.</param>
        /// <param name="viewModel">The view model instance.</param>
        /// <param name="bindingAttributeName">The name of the attribute which has the binding definitions.</param>
        public static void ApplyBindingsToNode(Element node, Dictionary bindings, object viewModel, string bindingAttributeName) {
        }

        /// <summary>
        /// Set up bindings on a single node without binding any of its descendents.
        /// </summary>
        /// <param name="rootNode">The root node to bind to.</param>
        /// <param name="bindings">An optional dictionary of bindings, pass null to let Knockout gather them from the element.</param>
        /// <param name="viewModel">The view model instance.</param>
        /// <param name="bindingAttributeName">The name of the attribute which has the binding definitions.</param>
        public static void ApplyBindingsToDescendants(Element rootNode, Dictionary bindings, object viewModel, string bindingAttributeName) {
        }

        /// <summary>
        /// Returns the entire binding context associated with the DOM element
        /// </summary>
        /// <param name="node"></param>
        public static BindingContext<TRoot, TParent, T> ContextFor<TRoot, TParent, T>(Element node) {
            return null;
        }

        /// <summary>
        /// Returns the data item associated with a particular DOM element 
        /// </summary>
        /// <param name="node"></param>
        public static T DataFor<T>(Element node) {
            return default(T);
        }

        /// <summary>
        /// Creates an observable with a value computed from one or more other values.
        /// </summary>
        /// <typeparam name="T">The type of the observable value.</typeparam>
        /// <param name="function">A function to compute the value.</param>
        /// <returns>A new dependent observable instance.</returns>
        public static DependentObservable<T> DependentObservable<T>(Func<T> function) {
            return null;
        }

        /// <summary>
        /// Creates an observable with a value computed from one or more other values.
        /// </summary>
        /// <typeparam name="T">The type of the observable value.</typeparam>
        /// <param name="options">Options for the dependent observable.</param>
        public static DependentObservable<T> DependentObservable<T>(DependentObservableOptions<T> options) {
            return null;
        }

        /// <summary>
        /// Returns true if the value is subscribable, false otherwise.
        /// </summary>
        /// <param name="value">The value to check.</param>
        public static bool IsSubscribable(object value) {
            return false;
        }

        /// <summary>
        /// Returns true if the value is an observable, false otherwise.
        /// </summary>
        /// <param name="value">The value to check.</param>
        public static bool IsObservable(object value) {
            return false;
        }

        /// <summary>
        /// Returns true if the value is an writable observable, false otherwise.
        /// </summary>
        /// <param name="value">The value to check.</param>
        public static bool IsWriteableObservable(object value) {
            return false;
        }

        /// <summary>
        /// Creates an subscribable value.
        /// </summary>
        /// <typeparam name="T">The type of the subscribable.</typeparam>
        /// <returns>A new subscribable value instance.</returns>
        public static Subscribable<T> Subscribable<T>() {
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

        /// <summary>
        /// If the provided value is an observable, return its value, otherwise just pass it through.
        /// </summary>
        /// <param name="value">The value to unwrap.</param>
        [ScriptAlias("ko.utils.unwrapObservable")]
        public static T UnwrapObservable<T>(object value) {
            return default(T);
        }
    }
}
