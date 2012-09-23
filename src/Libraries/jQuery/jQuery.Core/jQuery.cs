// jQuery.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml;

namespace jQueryApi {

    /// <summary>
    /// The global jQuery object.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("$")]
    public sealed class jQuery {

        private jQuery() {
        }

        /// <summary>
        /// Gets or sets the rate (in milliseconds) at which animations fire.
        /// </summary>
        [ScriptName("fx.interval")]
        [ScriptProperty]
        public static int AnimationInterval {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether animations are disabled or not.
        /// </summary>
        [ScriptName("fx.off")]
        [ScriptProperty]
        public static bool AnimationsDisabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets information about the current browser and its version.
        /// </summary>
        [ScriptProperty]
        public static jQueryBrowser Browser {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the current jQueryObject against which a plugin method is invoked.
        /// </summary>
        /// <returns>The jQueryObject represented by 'this' within a plugin.</returns>
        [ScriptAlias("this")]
        [ScriptProperty]
        public static jQueryObject Current {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the current document object wrapped into a jQuery object.
        /// </summary>
        [ScriptAlias("$(document)")]
        [ScriptProperty]
        public static jQueryObject Document {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the element passed in as 'this' within a jQuery callback function.
        /// </summary>
        /// <returns>The element represented by 'this' in a callback.</returns>
        [ScriptAlias("this")]
        [ScriptProperty]
        public static Element Element {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the instance of the global jQuery object.
        /// </summary>
        [ScriptAlias("jQuery")]
        [ScriptProperty]
        public static jQuery Instance {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets information about supported features and browser capabilities.
        /// </summary>
        [ScriptProperty]
        public static jQuerySupport Support {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the element passed in as 'this' within a jQuery callback function,
        /// wrapped into a jQueryObject.
        /// </summary>
        /// <returns>The jQueryObject for the element represented by 'this' in a callback.</returns>
        [ScriptAlias("$(this)")]
        [ScriptProperty]
        public static jQueryObject This {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the current window object wrapped into a jQuery object.
        /// </summary>
        [ScriptAlias("$(window)")]
        [ScriptProperty]
        public static jQueryObject Window {
            get {
                return null;
            }
        }

        /// <summary>
        /// Issues an Ajax request.
        /// </summary>
        /// <param name="url">The endpoint to which the request is issued.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Ajax(string url) {
            return null;
        }

        /// <summary>
        /// Issues an Ajax request.
        /// </summary>
        /// <param name="url">The endpoint to which the request is issued.</param>
        /// <param name="options">The options and settings for the request to invoke.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Ajax(string url, jQueryAjaxOptions options) {
            return null;
        }

        /// <summary>
        /// Issues an Ajax request.
        /// </summary>
        /// <param name="options">The options and settings for the request to invoke.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Ajax(jQueryAjaxOptions options) {
            return null;
        }

        /// <summary>
        /// Issues an Ajax request.
        /// </summary>
        /// <param name="url">The endpoint to which the request is issued.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("ajax")]
        public static jQueryDataHttpRequest<TData> AjaxRequest<TData>(string url) {
            return null;
        }

        /// <summary>
        /// Issues an Ajax request.
        /// </summary>
        /// <param name="url">The endpoint to which the request is issued.</param>
        /// <param name="options">The options and settings for the request to invoke.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("ajax")]
        public static jQueryDataHttpRequest<TData> AjaxRequest<TData>(string url, jQueryAjaxOptions options) {
            return null;
        }

        /// <summary>
        /// Issues an Ajax request.
        /// </summary>
        /// <param name="options">The options and settings for the request to invoke.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("ajax")]
        public static jQueryDataHttpRequest<TData> AjaxRequest<TData>(jQueryAjaxOptions options) {
            return null;
        }

        /// <summary>
        /// Sets up defaults for future Ajax requests.
        /// </summary>
        /// <param name="options">The options and settings for Ajax requests.</param>
        public static void AjaxSetup(jQueryAjaxOptions options) {
        }

        /// <summary>
        /// Creates an instance of a custom jQueryEvent object that contains custom
        /// data members.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <typeparam name="TEvent">The type of the event to create.</typeparam>
        /// <returns>A new jQueryEvent object.</returns>
        [ScriptName("event")]
        public static TEvent CustomEvent<TEvent>(string eventName) where TEvent : jQueryEvent {
            return null;
        }

        /// <summary>
        /// Creates a new instance of a deferred object.
        /// </summary>
        [ScriptName(PreserveCase = true)]
        public static jQueryDeferred Deferred() {
            return null;
        }

        /// <summary>
        /// Creates a new instance of a deferred object.
        /// </summary>
        [ScriptName("Deferred")]
        public static jQueryDeferred<TData> DeferredData<TData>() {
            return null;
        }

        /// <summary>
        /// Creates a new instance of a deferred object.
        /// </summary>
        /// <param name="initializer">An initializer callback to initialize the new deferred object.</param>
        [ScriptName(PreserveCase = true)]
        public static jQueryDeferred Deferred(jQueryDeferredInitializer initializer) {
            return null;
        }

        /// <summary>
        /// Creates a new instance of a deferred object.
        /// </summary>
        /// <param name="initializer">An initializer callback to initialize the new deferred object.</param>
        [ScriptName("Deferred")]
        public static jQueryDeferred<TData> DeferredData<TData>(jQueryDeferredInitializer<TData> initializer) {
            return null;
        }

        /// <summary>
        /// Iterates over items in the specified array and calls the callback
        /// for each item in the array.
        /// </summary>
        /// <param name="items">The array to iterate over.</param>
        /// <param name="callback">The callback to invoke for each item.</param>
        public static void Each(Array items, ArrayIterationCallback callback) {
        }

        /// <summary>
        /// Iterates over items in the specified array and calls the callback
        /// for each item in the array.
        /// </summary>
        /// <param name="items">The array to iterate over.</param>
        /// <param name="callback">The callback to invoke for each item.</param>
        public static void Each<T>(List<T> items, ArrayIterationCallback<T> callback) {
        }

        /// <summary>
        /// Iterates over items in the specified array and calls the callback
        /// for each item in the array. The callback can return false to
        /// break the iteration.
        /// </summary>
        /// <param name="items">The array to iterate over.</param>
        /// <param name="callback">The callback to invoke for each item.</param>
        public static void Each(Array items, ArrayInterruptableIterationCallback callback) {
        }

        /// <summary>
        /// Iterates over items in the specified array and calls the callback
        /// for each item in the array. The callback can return false to
        /// break the iteration.
        /// </summary>
        /// <param name="items">The array to iterate over.</param>
        /// <param name="callback">The callback to invoke for each item.</param>
        public static void Each<T>(List<T> items, ArrayInterruptableIterationCallback<T> callback) {
        }

        /// <summary>
        /// Iterates over properties of the specified object and calls the callback
        /// for each property/value of the object.
        /// </summary>
        /// <param name="obj">The object whose properties are to be iterated over..</param>
        /// <param name="callback">The callback to invoke for each property.</param>
        public static void Each(Object obj, ObjectIterationCallback callback) {
        }

        /// <summary>
        /// Iterates over properties of the specified object and calls the callback
        /// for each property/value of the object. The callback can return false to
        /// break the iteration.
        /// </summary>
        /// <param name="obj">The object whose properties are to be iterated over..</param>
        /// <param name="callback">The callback to invoke for each property.</param>
        public static void Each(Object obj, ObjectInterruptableIterationCallback callback) {
        }

        /// <summary>
        /// Raises an error using the specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void Error(string message) {
        }

        /// <summary>
        /// Creates an instance of a jQueryEvent object.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <returns>A new jQueryEvent object.</returns>
        public static jQueryEvent Event(string eventName) {
            return null;
        }

        /// <summary>
        /// Merge the properties of one or more objects into the target object.
        /// </summary>
        /// <param name="target">The object that will contain the merged values.</param>
        /// <param name="objects">The objects to merge.</param>
        /// <returns>The merged object.</returns>
        public static object Extend(object target, params object[] objects) {
            return null;
        }

        /// <summary>
        /// Merge the properties of one or more objects into the target object.
        /// </summary>
        /// <param name="deep">True if a deep copy is to be performed.</param>
        /// <param name="target">The object that will contain the merged values.</param>
        /// <param name="objects">The objects to merge.</param>
        /// <returns>The merged object.</returns>
        public static object Extend(bool deep, object target, params object[] objects) {
            return null;
        }

        /// <summary>
        /// Merge the properties of one or more objects into the target object.
        /// </summary>
        /// <param name="target">The dictionary that will contain the merged values.</param>
        /// <param name="dictionaries">The dictionary to merge.</param>
        /// <typeparam name="TKey">The type of keys within the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values within the dictionary.</typeparam>
        /// <returns>The merged dictionary.</returns>
        [ScriptName("extend")]
        public static Dictionary<TKey, TValue> ExtendDictionary<TKey, TValue>(Dictionary<TKey, TValue> target, params Dictionary<TKey, TValue>[] dictionaries) {
            return null;
        }

        /// <summary>
        /// Merge the properties of one or more objects into the target object.
        /// </summary>
        /// <param name="deep">True if a deep copy is to be performed.</param>
        /// <param name="target">The dictionary that will contain the merged values.</param>
        /// <param name="dictionaries">The dictionaries to merge.</param>
        /// <typeparam name="TKey">The type of keys within the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values within the dictionary.</typeparam>
        /// <returns>The merged dictionary.</returns>
        [ScriptName("extend")]
        public static Dictionary<TKey, TValue> ExtendDictionary<TKey, TValue>(bool deep, Dictionary<TKey, TValue> target, params Dictionary<TKey, TValue>[] dictionaries) {
            return null;
        }

        /// <summary>
        /// Merge the properties of one or more objects into the target object.
        /// </summary>
        /// <param name="target">The object that will contain the merged values.</param>
        /// <param name="objects">The objects to merge.</param>
        /// <returns>The merged object.</returns>
        [ScriptName("extend")]
        public static T ExtendObject<T>(T target, params T[] objects) {
            return default(T);
        }

        /// <summary>
        /// Merge the properties of one or more objects into the target object.
        /// </summary>
        /// <param name="deep">True if a deep copy is to be performed.</param>
        /// <param name="target">The object that will contain the merged values.</param>
        /// <param name="objects">The objects to merge.</param>
        /// <returns>The merged object.</returns>
        [ScriptName("extend")]
        public static T ExtendObject<T>(bool deep, T target, params T[] objects) {
            return default(T);
        }

        /// <summary>
        /// Wraps an instance of a <see cref="jQueryObject"/> around the specified element.
        /// </summary>
        /// <param name="element">The element to wrap.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject FromElement(Element element) {
            return null;
        }

        /// <summary>
        /// Wraps an instance of a <see cref="jQueryObject"/> around the specified elements.
        /// </summary>
        /// <param name="elements">The elements to wrap.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject FromElements(params Element[] elements) {
            return null;
        }

        /// <summary>
        /// Create DOM elements on-the-fly from the provided string of raw HTML and wraps
        /// them into a <see cref="jQueryObject"/>.
        /// </summary>
        /// <param name="html">The HTML to parse.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject FromHtml(string html) {
            return null;
        }

        /// <summary>
        /// Create DOM elements on-the-fly from the provided string of raw HTML and wraps
        /// them into a <see cref="jQueryObject"/>.
        /// </summary>
        /// <param name="html">The HTML to parse.</param>
        /// <param name="document">The document in which the elements will be created.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject FromHtml(string html, DocumentInstance document) {
            return null;
        }

        /// <summary>
        /// Creates a DOM element from the provided string defining a single tag and wraps
        /// it into a <see cref="jQueryObject"/>.
        /// </summary>
        /// <param name="html">The HTML to parse.</param>
        /// <param name="properties">The attributes and events to set on the element.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject FromHtml(string html, Dictionary properties) {
            return null;
        }

        /// <summary>
        /// Creates a jQueryObject from the specified object.
        /// </summary>
        /// <param name="o">The object to wrap.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject FromObject(object o) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Get(string url) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Get(string url, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Get(string url, object data, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Get(string url, object data, AjaxRequestCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Get(string url, object data, AjaxCallback<object> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Get(string url, object data, AjaxRequestCallback<object> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("get")]
        public static jQueryDataHttpRequest<TData> GetData<TData>(string url) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("get")]
        public static jQueryDataHttpRequest<TData> GetData<TData>(string url, AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("get")]
        public static jQueryDataHttpRequest<TData> GetData<TData>(string url, object data, AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("get")]
        public static jQueryDataHttpRequest<TData> GetData<TData>(string url, object data, AjaxRequestCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("get")]
        public static jQueryDataHttpRequest<TData> GetData<TData>(string url, object data, AjaxCallback<TData> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("get")]
        public static jQueryDataHttpRequest<TData> GetData<TData>(string url, object data, AjaxRequestCallback<TData> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Load JSON data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("getJSON")]
        public static jQueryXmlHttpRequest GetJson(string url) {
            return null;
        }

        /// <summary>
        /// Load JSON data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("getJSON")]
        public static jQueryXmlHttpRequest GetJson(string url, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Load JSON data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("getJSON")]
        public static jQueryXmlHttpRequest GetJson(string url, object data, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Load JSON data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("getJSON")]
        public static jQueryDataHttpRequest<TData> GetJsonData<TData>(string url) {
            return null;
        }

        /// <summary>
        /// Load JSON data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("getJSON")]
        public static jQueryDataHttpRequest<TData> GetJsonData<TData>(string url, AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Load JSON data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("getJSON")]
        public static jQueryDataHttpRequest<TData> GetJsonData<TData>(string url, object data, AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Load script from the server using a HTTP GET request and execute it.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest GetScript(string url) {
            return null;
        }

        /// <summary>
        /// Load script from the server using a HTTP GET request and execute it.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest GetScript(string url, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Filters the specified array using the provided callback, and returns the
        /// matching items.
        /// </summary>
        /// <param name="a">The array to be filtered.</param>
        /// <param name="callback">The callback to filter the items.</param>
        /// <returns>The matching items.</returns>
        public static Array Grep(Array a, ArrayFilterCallback callback) {
            return null;
        }

        /// <summary>
        /// Filters the specified array using the provided callback, and returns the
        /// matching items.
        /// </summary>
        /// <param name="a">The array to be filtered.</param>
        /// <param name="callback">The callback to filter the items.</param>
        /// <param name="invert">If true, the items not matching are returned.</param>
        /// <returns>The matching items.</returns>
        public static Array Grep(Array a, ArrayFilterCallback callback, bool invert) {
            return null;
        }

        // TODO: Add generic version of Grep

        /// <summary>
        /// Holds or releases the execution of jQuery's ready event.
        /// </summary>
        /// <param name="hold">Indicates whether the ready hold is being requested or released.</param>
        public static void HoldReady(bool hold) {
        }

        /// <summary>
        /// Gets the index of the specified value within the specified array.
        /// </summary>
        /// <param name="value">The value to look for.</param>
        /// <param name="a">The array to look in.</param>
        /// <returns>The index of value if it is found; -1 if it is not.</returns>
        public static int InArray(object value, Array a) {
            return 0;
        }

        /// <summary>
        /// Gets the index of the specified value within the specified list.
        /// </summary>
        /// <param name="value">The value to look for.</param>
        /// <param name="list">The list to look in.</param>
        /// <returns>The index of value if it is found; -1 if it is not.</returns>
        [ScriptName("inArray")]
        public static int InList<T>(T value, List<T> list) {
            return 0;
        }

        /// <summary>
        /// Checks if the specified object is an array.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is an array; false otherwise.</returns>
        public static bool IsArray(object o) {
            return false;
        }

        /// <summary>
        /// Checks if the specified object is a function.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a function; false otherwise.</returns>
        public static bool IsFunction(object o) {
            return false;
        }

        /// <summary>
        /// Checks if the specified object is a window.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a window instance; false otherwise.</returns>
        public static bool IsWindow(object o) {
            return false;
        }

        /// <summary>
        /// Turns anything into a true array.
        /// </summary>
        /// <param name="o">The object to turn into an array.</param>
        /// <returns>The resulting array.</returns>
        public static Array MakeArray(object o) {
            return null;
        }

        /// <summary>
        /// Returns a new object by mapping each item in the specified object
        /// using the provided callback.
        /// </summary>
        /// <param name="o">The object to map.</param>
        /// <param name="callback">The function that performs the mapping.</param>
        /// <returns>The array of mapped values.</returns>
        public static object Map(object o, ObjectMapCallback callback) {
            return null;
        }

        /// <summary>
        /// Returns a new array by mapping each item in the specified array
        /// using the provided callback.
        /// </summary>
        /// <param name="a">The array of items to map.</param>
        /// <param name="callback">The function that performs the mapping.</param>
        /// <returns>The array of mapped values.</returns>
        public static Array Map(Array a, ArrayMapCallback callback) {
            return null;
        }

        /* TODO
        /// <summary>
        /// Returns a new list by mapping each item in the specified list
        /// using the provided callback.
        /// </summary>
        /// <param name="list">The list of items to map.</param>
        /// <param name="callback">The function that performs the mapping.</param>
        /// <returns>The list of mapped values.</returns>
        [ScriptName("map")]
        public static List<TTarget> MapList<TSource, TTarget>(List<TSource> list, ListMapCallback<TSource, TTarget> callback) {
            return null;
        }
        */

        /// <summary>
        /// Merges the specified arrays into a single array.
        /// </summary>
        /// <param name="firstArray">The first array to merge.</param>
        /// <param name="secondArray">The second array to merge.</param>
        /// <returns>The new array containing merged set of items.</returns>
        public static Array Merge(Array firstArray, Array secondArray) {
            return null;
        }

        /// <summary>
        /// Merges the specified lists into a single list.
        /// </summary>
        /// <param name="firstList">The first list to merge.</param>
        /// <param name="secondList">The second list to merge.</param>
        /// <returns>The new list containing merged set of items.</returns>
        [ScriptName("merge")]
        public static List<T> MergeLists<T>(List<T> firstList, List<T> secondList) {
            return null;
        }

        /// <summary>
        /// Calls the specified function when the document is ready. This is equivalent to
        /// jQuery(document).ready(callback).
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject OnDocumentReady(Action callback) {
            return null;
        }

        /// <summary>
        /// Serializes an object for use in URL query string for an Ajax request.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <returns>The serialized representation of the object.</returns>
        public static string Param(object o) {
            return null;
        }

        /// <summary>
        /// Parses the specified well-formed json string into an object.
        /// </summary>
        /// <param name="json">The json string.</param>
        /// <returns>The parsed document.</returns>
        [ScriptName("parseJSON")]
        public static object ParseJson(string json) {
            return null;
        }

        /// <summary>
        /// Parses the specified well-formed json string into an object.
        /// </summary>
        /// <param name="json">The json string.</param>
        /// <returns>The parsed document.</returns>
        [ScriptName("parseJSON")]
        public static TData ParseJsonData<TData>(string json) {
            return default(TData);
        }

        /// <summary>
        /// Parses the specified well-formed xml data into an XML document.
        /// </summary>
        /// <param name="data">The xml markup.</param>
        /// <returns>The parsed document.</returns>
        [ScriptName("parseXML")]
        public static XmlDocument ParseXml(string data) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url, object data) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url, object data, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url, object data, AjaxRequestCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url, object data, AjaxCallback<object> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        public static jQueryXmlHttpRequest Post(string url, object data, AjaxRequestCallback<object> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("post")]
        public static jQueryDataHttpRequest<TData> PostRequest<TData>(string url) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("post")]
        public static jQueryDataHttpRequest<TData> PostRequest<TData>(string url, AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("post")]
        public static jQueryDataHttpRequest<TData> PostRequest<TData>(string url, object data, AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("post")]
        public static jQueryDataHttpRequest<TData> PostRequest<TData>(string url, object data, AjaxRequestCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("post")]
        public static jQueryDataHttpRequest<TData> PostRequest<TData>(string url, object data, AjaxCallback<TData> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Post data to the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">A string or dictionary containing the data sent with the request.</param>
        /// <param name="callback">The callback to invoke with the response.</param>
        /// <param name="dataType">The type of data expected in the response.</param>
        /// <returns>The jQueryXmlHttpRequest object.</returns>
        [ScriptName("post")]
        public static jQueryDataHttpRequest<TData> PostRequest<TData>(string url, object data, AjaxRequestCallback<TData> callback, string dataType) {
            return null;
        }

        /// <summary>
        /// Finds one or more DOM elements matching a CSS selector and wraps them into a
        /// <see cref="jQueryObject"/> instance.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject Select([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Finds one or more DOM elements matching a CSS selector and wraps them into a
        /// <see cref="jQueryObject"/> instance. The elements are scoped to those contained
        /// within the specified document.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="document">The document to search within.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject Select([SyntaxValidation("cssSelector")] string selector, DocumentInstance document) {
            return null;
        }

        /// <summary>
        /// Finds one or more DOM elements matching a CSS selector and wraps them into a
        /// <see cref="jQueryObject"/> instance. The elements are scoped to those contained
        /// within the specified root element.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="rootElement">The root element to begin the search at.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject Select([SyntaxValidation("cssSelector")] string selector, Element rootElement) {
            return null;
        }

        /// <summary>
        /// Finds one or more DOM elements matching a CSS selector and wraps them into a
        /// <see cref="jQueryObject"/> instance. The elements are scoped to those contained
        /// within the specified jQueryObject context.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="context">The context to scope the selection.</param>
        /// <returns>The resulting jQueryObject instance.</returns>
        [ScriptAlias("$")]
        public static jQueryObject Select([SyntaxValidation("cssSelector")] string selector, jQueryObject context) {
            return null;
        }

        /// <summary>
        /// Removes whitespace from the beginning and end of the string.
        /// </summary>
        /// <param name="s">The string to trim.</param>
        /// <returns>The trimmed string.</returns>
        public static string Trim(string s) {
            return null;
        }

        /// <summary>
        /// Gets the type of the specified object.
        /// </summary>
        /// <param name="o">The object whose type is to be looked up.</param>
        /// <returns>The type name of the object.</returns>
        public static string Type(object o) {
            return null;
        }

        /// <summary>
        /// Creates a deferred object representing the aggregate of the specified
        /// deferred objects.
        /// </summary>
        /// <param name="deferreds">The set of deferred objects.</param>
        /// <returns>A deferred object representing the individual deferred objects.</returns>
        public static IDeferred When(params IDeferred[] deferreds) {
            return null;
        }

        /// <summary>
        /// Creates a deferred object representing the aggregate of the specified
        /// deferred objects. If any of the objects are not deferred objects, then they
        /// are considered as pre-resolved deferred objects.
        /// </summary>
        /// <param name="deferreds">The set of deferred objects.</param>
        /// <returns>A deferred object representing the individual deferred objects.</returns>
        public static IDeferred When(params object[] deferreds) {
            return null;
        }

        /// <summary>
        /// Creates a deferred object representing the aggregate of the specified
        /// deferred objects.
        /// </summary>
        /// <param name="deferreds">The set of deferred objects.</param>
        /// <returns>A deferred object representing the individual deferred objects.</returns>
        [ScriptName("when")]
        public static IDeferred<TData> WhenData<TData>(params IDeferred<TData>[] deferreds) {
            return null;
        }
    }
}
