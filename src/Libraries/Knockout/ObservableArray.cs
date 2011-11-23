// ObservableArray.cs
// Script#/Libraries/Knockout
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections;

namespace KnockoutApi {

    /// <summary>
    /// Represents an array of items that can be observed for changes to the set of
    /// contained items.
    /// </summary>
    /// <typeparam name="T">The type of the contained values.</typeparam>
    [Imported]
    [IgnoreNamespace]
    public sealed class ObservableArray<T> : Observable<T[]> {

        protected ObservableArray() : base() {
        }

        /// <summary>
        /// Marks all values that match the given parameter as deleted.
        /// </summary>
        /// <param name="value">The value to mark as deleted.</param>
        public void Destroy(T value) {
        }

        /// <summary>
        /// Marks all values that satisfy the predicate as deleted.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public void Destroy(Func<T, bool> predicate) {
        }

        /// <summary>
        /// Marks all values that satisfy the given parameters as deleted.
        /// </summary>
        /// <param name="values">An array of items to destroy.</param>
        public void DestroyAll(params T[] values) {
        }

        /// <summary>
        /// Gets the underlying items within the observable array.
        /// This is a Copy of the Values in the Observable
        /// </summary>
        /// <returns>The collection of items.</returns>
        [ScriptName("")]
        public T[] GetItems() {
            return null;
        }

        /// <summary>
        /// Sets the underlying items within the observable array.
        /// </summary>
        [ScriptName("")]
        public void SetItems(T[] values) {
        }

        /// <summary>
        /// Returns the index of the first array item that equals the value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The index of the matching item; -1 if there is no match.</returns>
        public int IndexOf(T value) {
            return 0;
        }

        /// <summary>
        /// Removes the last value from the array and returns it.
        /// </summary>
        /// <returns>The last value.</returns>
        public T Pop() {
            return default(T);
        }

        /// <summary>
        /// Adds the value and notifies observers.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void Push(T value) {
        }

        /// <summary>
        /// Replaces the Specified Item with the NewItem
        /// </summary>
        public void Replace(T oldItem, T newItem) {
        }

        /// <summary>
        /// Removes all values that match the given parameter and returns them.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        /// <returns>The removed values.</returns>
        public T[] Remove(T value) {
            return null;
        }

        /// <summary>
        /// Removes all values that satisfy the predicate and returns them.
        /// </summary>
        /// <param name="predicate">The removal predicate.</param>
        /// <returns>The removed values.</returns>
        public T[] Remove(Func<T, bool> predicate) {
            return null;
        }

        /// <summary>
        /// Removes all values that satisfy the given parameters and returns them.
        /// </summary>
        /// <param name="values">An array of items to remove.</param>
        /// <returns>The removed values.</returns>
        public T[] RemoveAll(params T[] values) {
            return null;
        }

        /// <summary>
        /// Reverses the order of the array.
        /// </summary>
        public void Reverse() {
        }

        /// <summary>
        /// Removes the first value from the array and returns it
        /// </summary>
        /// <returns>The removed value.</returns>
        public T Shift() {
            return default(T);
        }

        /// <summary>
        /// Native Javascript Splice Function
        /// Modifies the Existing Sequence
        /// </summary>
        /// <param name="index">Required. An integer that specifies at what position to add/remove elements</param>
        /// <param name="howmany">Required. The number of elements to be removed. If set to 0, no elements will be removed</param>
        /// <param name="args">Optional. The new element(s) to be added to the array</param>
        public void Splice(int index, int howmany, params T[] args) {
        }

        /// <summary>
        /// Returns elements from start index to the end of the array.
        /// </summary>
        /// <param name="start">Starting point of the sequence, if negative then it starts from the end.</param>
        /// <returns>The matched items.</returns>
        public T[] Slice(int start) {
            return null;
        }

        /// <summary>
        /// Returns elements from start index to end index.
        /// </summary>
        /// <param name="start">Starting point of the sequence, if negative then it starts from the end.</param>
        /// <param name="end">End point of the sequence.</param>
        /// <returns>The matched items.</returns>
        public T[] Slice(int start, int end) {
            return null;
        }

        /// <summary>
        /// Performs a default alphanumeric sort on the elements of the array.
        /// </summary>
        public void Sort() {
        }

        /// <summary>
        /// Performs a sort using the comparator function.
        /// </summary>
        /// <param name="comparator">The comparing function.</param>
        public void Sort(Func<T, T, int> comparator) {
        }

        /// <summary>
        /// Inserts the value at the beginning of the array.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        public void Unshift(T value) {
        }

        /// <summary>
        /// For dependent observables, we throttle *evaluations* so that, no matter how fast its dependencies        
        /// notify updates, the target doesn't re-evaluate (and hence doesn't notify) faster than a certain rate
        /// For writable targets (observables, or writable dependent observables), we throttle *writes*        
        /// so the target cannot change value synchronously or faster than a certain rate
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Extend is Chainable</returns>
        public new ObservableArray<T> Extend(Dictionary options) {
            return null;
        }
    }
}
