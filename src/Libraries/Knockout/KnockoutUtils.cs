// KnockoutApi.cs
// Script#/Libraries/Knockout
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Html;

namespace KnockoutApi
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("ko.utils")]
    public static class KnockoutUtils
    {
        /// <summary>
        /// Applies the Action to each item in the given array
        /// </summary>
        public static void ArrayForEach<T>(IEnumerable<T> array, Action<T> action) {
        }

        /// <summary>
        /// Returns the First Matching Item (predicate function) from the given array
        /// </summary>
        public static void ArrayFirst<T>(IEnumerable<T> array, Func<T, bool> predicate, object owner) {
        }

        /// <summary>
        /// Applies the predicate filter to the given array
        /// Returns the matching items as a new array
        /// </summary>
        public static T[] ArrayFilter<T>(IEnumerable<T> array, Func<T, bool> predicate) {
            return null;
        }

        /// <summary>
        /// Returns a new array containing distinct values only
        /// </summary>
        public static T[] ArrayGetDistinctValues<T>(IEnumerable<T> array) {
            return null;
        }

        /// <summary>
        /// Finds and Returns the Index of the item in the given array
        /// </summary>
        /// <returns>Returns the Index number of -1 if not found</returns>
        public static int ArrayIndexOf<T>(IEnumerable<T> array, T item) {
            return -1;
        }

        /// <summary>
        /// Processes each item in the given array and applies the mapping function
        /// Returns the Mapping Results
        /// </summary>
        public static TOut[] ArrayMap<T, TOut>(IEnumerable<T> array, Func<T, TOut> mapping) {
            return null;
        }

        /// <summary>
        /// Pushes each item into the given array
        /// </summary>
        public static void ArrayPushAll<T>(IEnumerable<T> array, params T[] items) {
        }

        /// <summary>
        /// Removes the Specified item from the given array
        /// </summary>
        public static void ArrayRemoveItem<T>(IEnumerable<T> array, T item) {
        }

        /// <summary>
        /// Compares the changes between two arrays
        /// </summary>
        public static CompareResult<T>[] CompareArrays<T>(IEnumerable<T> oldArray, IEnumerable<T> newArray) {
            return null;
        }

        /// <summary>
        /// Compares the changes between two arrays
        /// </summary>
        public static CompareResult<T>[] CompareArrays<T>(IEnumerable<T> oldArray, IEnumerable<T> newArray, int maxEditsToConsider) {
            return null;
        }

        public static T Extend<T>(T target, object source) {
            return default(T);
        }

        /// <summary>
        /// Finds the Matching Field Elements (input) in the given Form Element and the given fieldName
        /// </summary>
        public static Element[] GetFormFields(Element form, string fieldName) {
            return null;
        }

        /// <summary>
        /// Finds the Matching Field Elements (input) in the given Form Element and the given regular expression
        /// </summary>
        public static Element[] GetFormFields(Element form, RegularExpression match) {
            return null;
        }

        /// <summary>
        /// Makes a Post Request to the specified url or using the specified Form element
        /// </summary>
        /// <param name="urlOrForm"></param>
        /// <param name="data"></param>
        /// <param name="options">{ "params": [], "includeFields": [], "submitter": [] }</param>
        public static void PostJson(object urlOrForm, object data, Dictionary options) {
        }

        /// <summary>
        /// Parses the Json String into a native javascript object
        /// </summary>
        /// <param name="jsonString"></param>
        public static T ParseJson<T>(string jsonString) {
            return default(T);
        }

        /// <summary>
        /// Registers an Event Handler for the given element
        /// </summary>
        public static void RegisterEventHandler(Element element, string eventType, EventHandler handler) {
        }

        /// <summary>
        /// Returns a json string from the specified object
        /// Requires Native JSON support or json2.js
        /// </summary>
        public static string StringifyJson(object obj) {
            return null;
        }

        /// <summary>
        /// Returns an Array of numbers starting from the specified minimum to the maximum
        /// </summary>
        public static int[] Range(int min, int max) {
            return null;
        }

        /// <summary>
        /// Returns an Array of numbers starting from the specified minimum to the maximum
        /// </summary>
        public static int[] Range(Observable<int> min, Observable<int> max) {
            return null;
        }

        /// <summary>
        /// Triggers the specified event on the given element
        /// i.e. produce a 'click' event on a input element
        /// </summary>
        public static void TriggerEvent(Element element, string eventType) {
        }

        /// <summary>
        /// If the provided value is an observable, return its value, otherwise just pass it through.
        /// </summary>
        /// <param name="value">The value to unwrap.</param>
        public static T UnwrapObservable<T>(T value) {
            return default(T);
        }

        /// <summary>
        /// If the provided value is an observable, return its value, otherwise just pass it through.
        /// </summary>
        /// <param name="value">The value to unwrap.</param>
        public static T UnwrapObservable<T>(Observable<T> value) { 
            return default(T); 
        }

        /// <summary>
        /// If the provided value is an observable, return its value, otherwise just pass it through.
        /// </summary>
        /// <param name="value">The value to unwrap.</param>
        public static T[] UnwrapObservable<T>(ObservableArray<T> value) {
            return null;
        }
    }
}