// jQueryObject.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents a jQuery result that wraps a set of elements.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public class jQueryObject {

        /// <summary>
        /// Initializes an instance of a jQueryObject.
        /// </summary>
        protected jQueryObject() {
        }

        /// <summary>
        /// Gets the Document or DOM element used as the context to match
        /// this set of elements.
        /// </summary>
        [IntrinsicProperty]
        public object Context {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the number of elements in this <see cref="jQueryObject" />.
        /// </summary>
        [IntrinsicProperty]
        public int Length {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the selector used to match this set of elements.
        /// </summary>
        [IntrinsicProperty]
        public string Selector {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the matched element at the specified index.
        /// </summary>
        /// <param name="index">The index to lookup.</param>
        /// <returns>The DOM element at the specified index.</returns>
        [IntrinsicProperty]
        public Element this[int index] {
            get {
                return null;
            }
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject Add(Element element) {
            return null;
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="elements">The elements to add.</param>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject Add(params Element[] elements) {
            return null;
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="selector">The set of elements to select and add.</param>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject Add([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="selector">The set of elements to select and add.</param>
        /// <param name="context">The document to select elements from.</param>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject Add([SyntaxValidation("cssSelector")] string selector, DocumentInstance context) {
            return null;
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="selector">The set of elements to select and add.</param>
        /// <param name="context">The root element to select elements from.</param>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject Add([SyntaxValidation("cssSelector")] string selector, Element context) {
            return null;
        }

        /// <summary>
        /// Adds the specified class(es) to each of the set of matched elements.
        /// </summary>
        /// <param name="className">The class or classes to add.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AddClass(string className) {
            return null;
        }

        /// <summary>
        /// Adds the CSS class returned by the specified function.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to add.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AddClass(StringFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Adds the CSS class returned by the specified function.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to add.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AddClass(StringReplaceFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="markup">The HTML fragment to add.</param>
        /// <returns>The new jQueryObject with added elements.</returns>
        [ScriptName("add")]
        public jQueryObject AddHtml(string markup) {
            return null;
        }

        /// <summary>
        /// Insert content after each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to insert.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject After(string content) {
            return null;
        }

        /// <summary>
        /// Insert content after each element of the matching elements.
        /// </summary>
        /// <param name="content">The jQueryObject containing the content.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject After(jQueryObject content) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function after each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to insert.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject After(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Registers the event handler to be invoked when an Ajax request is
        /// completed.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AjaxComplete(AjaxEventHandler<object> handler) {
            return null;
        }

        /// <summary>
        /// Registers the event handler to be invoked when there is an error
        /// completing an Ajax request.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AjaxError(AjaxErrorEventHandler<object> handler) {
            return null;
        }

        /// <summary>
        /// Registers the event handler to be invoked when an Ajax request is
        /// being sent.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AjaxSend(AjaxEventHandler<object> handler) {
            return null;
        }

        /// <summary>
        /// Registers the event handler to be invoked when an Ajax request is
        /// completed successfully.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AjaxSuccess(AjaxEventHandler<object> handler) {
            return null;
        }

        /// <summary>
        /// Registers the callback to be invoked when there the first
        /// Ajax request is started.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AjaxStart(Action callback) {
            return null;
        }

        /// <summary>
        /// Registers the callback to be invoked when there are no more
        /// outstanding Ajax requests.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject AjaxStop(Action callback) {
            return null;
        }

        /// <summary>
        /// Add the previous set of elements on the stack to the current set.
        /// </summary>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject AndSelf() {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties using the default duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties over the specified duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="duration">The duration in milliseconds for the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, int duration) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties over the specified duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="duration">The duration in milliseconds for the animation.</param>
        /// <param name="easing">The easing to apply to the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, int duration, EffectEasing easing) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties over the specified duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="duration">The duration in milliseconds for the animation.</param>
        /// <param name="easing">The easing to apply to the animation.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties over the specified duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="duration">The duration in milliseconds for the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties over the specified duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="duration">The duration in milliseconds for the animation.</param>
        /// <param name="easing">The easing to apply to the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, EffectDuration duration, EffectEasing easing) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties over the specified duration.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="duration">The duration in milliseconds for the animation.</param>
        /// <param name="easing">The easing to apply to the animation.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Animates a set of CSS properties using the specified options.
        /// </summary>
        /// <param name="propertiesToAnimate">The properties to animate with their target values.</param>
        /// <param name="options">Animation options.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Animate(Dictionary propertiesToAnimate, Dictionary options) {
            return null;
        }

        /// <summary>
        /// Insert content to the end of each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to append.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Append(string content) {
            return null;
        }

        /// <summary>
        /// Insert content to the end of each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM element to append.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Append(Element content) {
            return null;
        }

        /// <summary>
        /// Insert content to the end of each element of the matching elements.
        /// </summary>
        /// <param name="content">The jQueryObject containing the content.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Append(jQueryObject content) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function to end end of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to append.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Append(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function to end end of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to append.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Append(StringReplaceFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Appends every element of the matching set to the end of the specified element.
        /// </summary>
        /// <param name="element">The element to append to.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject AppendTo(Element element) {
            return null;
        }

        /// <summary>
        /// Appends every element of the matching set to the end of the elements matching
        /// the specified selector.
        /// </summary>
        /// <param name="selector">The elements to append to.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject AppendTo([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Appends every element of the matching set to the end of the specified matched elements.
        /// </summary>
        /// <param name="jQueryObject">The elements to append to.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject AppendTo(jQueryObject jQueryObject) {
            return null;
        }

        /// <summary>
        /// Sets the specified attribute value to the specified value on
        /// the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("attr")]
        public jQueryObject Attribute(string attributeName, string value) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the set of matched elements.
        /// </summary>
        /// <param name="nameValueMap">The list of names and values of the attributes to set.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("attr")]
        public jQueryObject Attribute(Dictionary nameValueMap) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the value returned from the specified function.
        /// </summary>
        /// <param name="attrFunction">The function returning the attribute values.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("attr")]
        public jQueryObject Attribute(StringFunction attrFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the value returned from the specified function.
        /// </summary>
        /// <param name="attrFunction">The function returning the attribute values.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("attr")]
        public jQueryObject Attribute(StringReplaceFunction attrFunction) {
            return null;
        }

        /// <summary>
        /// Insert content before each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to insert.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Before(string content) {
            return null;
        }

        /// <summary>
        /// Insert content before each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM element to insert.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Before(Element content) {
            return null;
        }

        /// <summary>
        /// Insert content before each element of the matching elements.
        /// </summary>
        /// <param name="content">The jQueryObject containing the content.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Before(jQueryObject content) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function before each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to insert.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Before(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Bind(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Bind(string eventName, Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler that prevents default behavior and stops event bubbling for
        /// the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="result">Should be false.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Bind(string eventName, bool result) {
            return null;
        }

        /// <summary>
        /// Triggers the blur event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Blur() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the blur event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Blur(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the blur event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Blur(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Triggers the change event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Change() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the change event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Change(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the change event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Change(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the children of the matched set of elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Children() {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the children of the matched set of elements.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Children([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Triggers the click event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Click() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the click event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Click(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the click event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Click(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Creates a clone of the current jQueryObject and the matching elements it
        /// represents.
        /// </summary>
        /// <returns>The cloned jQueryObject.</returns>
        public jQueryObject Clone() {
            return null;
        }

        /// <summary>
        /// Creates a clone of the current jQueryObject and the matching elements it
        /// represents.
        /// </summary>
        /// <param name="withDataAndEvents">Whether event handlers and element data should be copied over.</param>
        /// <returns>The cloned jQueryObject.</returns>
        public jQueryObject Clone(bool withDataAndEvents) {
            return null;
        }

        /// <summary>
        /// Creates a clone of the current jQueryObject and the matching elements it
        /// represents.
        /// </summary>
        /// <param name="withDataAndEvents">Whether event handlers and element data should be copied over.</param>
        /// <param name="deepWithDataAndEvents">Whether event handlers and element data for all children should be copied over.</param>
        /// <returns>The cloned jQueryObject.</returns>
        public jQueryObject Clone(bool withDataAndEvents, bool deepWithDataAndEvents) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the closest ancestor matching
        /// the specified element.
        /// </summary>
        /// <param name="element">The element to match against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Closest(Element element) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the closest ancestor matching
        /// the specified set of elements.
        /// </summary>
        /// <param name="elements">The matched set of elements to lookup.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Closest(jQueryObject elements) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the closest ancestor matching
        /// the specified selector.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Closest([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the closest ancestor matching
        /// the specified selector.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <param name="context">The element within which to search.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Closest([SyntaxValidation("cssSelector")] string selector, Element context) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the content of the matched set of elements
        /// including text nodes.
        /// </summary>
        /// <returns>The new jQueryObject with added elements.</returns>
        public jQueryObject Contents() {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the specified value on
        /// the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="value">The value of the CSS attribute.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("css")]
        public jQueryObject CSS(string attributeName, string value) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the values returned by the
        /// specified function on the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="valueFunction">The function returning attribute values.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("css")]
        public jQueryObject CSS(string attributeName, StringFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the values returned by the
        /// specified function on the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="valueFunction">The function returning attribute values.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("css")]
        public jQueryObject CSS(string attributeName, StringReplaceFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attributes to the set of matched elements.
        /// </summary>
        /// <param name="nameValueMap">The list of names and values of the CSS attributes to set.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("css")]
        public jQueryObject CSS(Dictionary nameValueMap) {
            return null;
        }

        /// <summary>
        /// Sets the specified value as data on the matching set of elements.
        /// </summary>
        /// <param name="key">The key used to store value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Data(string key, object value) {
            return null;
        }

        /// <summary>
        /// Sets the specified name/value pairs as data on the matching set of elements.
        /// This extends any existing data on the element.
        /// </summary>
        /// <param name="data">The set of name/value pairs to set.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Data(Dictionary data) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event on elements matching the
        /// specified selector within the matched set of elements, now or in the future.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jQueryObject Delegate([SyntaxValidation("cssSelector")] string selector, string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event on elements matching the
        /// specified selector within the matched set of elements, now or in the future.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jQueryObject Delegate([SyntaxValidation("cssSelector")] string selector, string eventName, Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Removes the matching elements from the DOM, but keeps jQuery data on elements
        /// intact.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Detach() {
            return null;
        }

        /// <summary>
        /// Removes the matching elements from the DOM, but keeps jQuery data on elements
        /// intact.
        /// </summary>
        /// <param name="selector">The selector to use to filter the elements to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Detach([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Triggers the dblclick event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("dblclick")]
        public jQueryObject DoubleClick() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the dblclick event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("dblclick")]
        public jQueryObject DoubleClick(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the dblclick event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("dblclick")]
        public jQueryObject DoubleClick(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Detaches all handlers attached using Live from the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Die() {
            return null;
        }

        /// <summary>
        /// Detaches all handlers attached using Live for the specified event on the
        /// matched set of elements.
        /// </summary>
        /// <param name="eventName">The event to detach handlers for.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Die(string eventName) {
            return null;
        }

        /// <summary>
        /// Detaches the specified handler attached using Live for the specified event on the
        /// matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be detached.</param>
        /// <returns></returns>
        public jQueryObject Die(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Execute a function within for every matched element.
        /// part way through.
        /// </summary>
        /// <param name="callback">The callback to call.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Each(ElementIterationCallback callback) {
            return null;
        }

        /// <summary>
        /// Execute a function within for every matched element. If the callback
        /// returns false, the iteration is interrupted.
        /// </summary>
        /// <param name="callback">The callback to call.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Each(ElementInterruptibleIterationCallback callback) {
            return null;
        }

        /// <summary>
        /// Removes all child elements of the matching set of elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Empty() {
            return null;
        }

        /// <summary>
        /// Add the most recent filtering operation and return the previous set of
        /// matching elements.
        /// </summary>
        /// <returns>The jQueryObject containing the previous element set.</returns>
        public jQueryObject End() {
            return null;
        }

        /// <summary>
        /// Reduce the set of matched elements to a single element.
        /// </summary>
        /// <param name="index">The index of the element. Use negative to count backwards.</param>
        /// <returns>A new jQueryObject wrapping the specified element.</returns>
        public jQueryObject Eq(int index) {
            return null;
        }

        /// <summary>
        /// Triggers the error event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Error() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the error event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Error(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the error event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Error(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a default duration of 400ms.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn() {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn(int duration) {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades in the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeIn(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a default duration of 400ms.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut() {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut(int duration) {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades out the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeOut(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades the matching set of elements using a the specified duration to the
        /// specified opacity.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="opacity">The opacity level between 0 and 1.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeTo(int duration, double opacity) {
            return null;
        }

        /// <summary>
        /// Fades the matching set of elements using a the specified duration to
        /// the specified opacity.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="opacity">The opacity level between 0 and 1.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeTo(int duration, double opacity, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades the matching set of elements using a the specified duration to
        /// the specified opacity.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="opacity">The opacity level between 0 and 1.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeTo(int duration, double opacity, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades the matching set of elements using a the specified duration to the
        /// specified opacity.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="opacity">The opacity level between 0 and 1.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeTo(EffectDuration duration, double opacity) {
            return null;
        }

        /// <summary>
        /// Fades the matching set of elements using a the specified duration to
        /// the specified opacity.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="opacity">The opacity level between 0 and 1.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeTo(EffectDuration duration, double opacity, Action callback) {
            return null;
        }

        /// <summary>
        /// Fades the matching set of elements using a the specified duration to
        /// the specified opacity.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="opacity">The opacity level between 0 and 1.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeTo(EffectDuration duration, double opacity, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by fading them
        /// using a default duration of 400ms.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeToggle() {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by fading them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeToggle(int duration) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by fading them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeToggle(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by fading them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeToggle(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by fading them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeToggle(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by fading them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject FadeToggle(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with elements matching the specified selector.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Filter([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with elements for which the specified filter
        /// function return true.
        /// </summary>
        /// <param name="filterFunction">The function used to filter elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Filter(ElementFilterCallback filterFunction) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with descendents of each matched element filtered
        /// by the specified element.
        /// This traverses down multiple levels of the tree.
        /// </summary>
        /// <param name="element">The element to match against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Find(Element element) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with descendents of each matched element filtered
        /// by the specified matched set of elements.
        /// This traverses down multiple levels of the tree.
        /// </summary>
        /// <param name="elements">The matched set of elements to lookup.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Find(jQueryObject elements) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with descendents of each matched element filtered
        /// by the specified selector. This traverses down multiple levels of the tree.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Find([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the first matching element.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject First() {
            return null;
        }

        /// <summary>
        /// Triggers the focus event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Focus() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the focus event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Focus(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the focus event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Focus(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the focusin event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("focusin")]
        public jQueryObject FocusIn(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the focusin event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("focusin")]
        public jQueryObject FocusIn(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the focusout event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("focusout")]
        public jQueryObject FocusOut(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the focusout event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("focusout")]
        public jQueryObject FocusOut(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Gets the value of the specified attribute.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The value of the specified attribute.</returns>
        [ScriptName("attr")]
        public string GetAttribute(string attributeName) {
            return null;
        }

        /// <summary>
        /// Gets the value of the specified CSS attribute.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The value of the specified CSS attribute.</returns>
        [ScriptName("css")]
        public string GetCSS(string attributeName) {
            return null;
        }

        /// <summary>
        /// Retrieves all data values associated with the element.
        /// </summary>
        /// <returns>All the data as name/value pairs.</returns>
        [ScriptName("data")]
        public Dictionary GetData() {
            return null;
        }

        /// <summary>
        /// Retrieves the specific data value associated with the element.
        /// </summary>
        /// <param name="key">The key to lookup.</param>
        /// <returns>The value set for the specified key.</returns>
        [ScriptName("data")]
        public object GetDataValue(string key) {
            return null;
        }

        /// <summary>
        /// Returns the wrapped element at the specified index.
        /// </summary>
        /// <param name="index">The index to lookup.</param>
        /// <returns>The element being wrapped.</returns>
        [ScriptName("get")]
        public Element GetElement(int index) {
            return null;
        }

        /// <summary>
        /// Returns the wrapped elements.
        /// </summary>
        /// <returns>An array containing the elements being wrapped.</returns>
        [ScriptName("get")]
        public Element[] GetElements() {
            return null;
        }

        /// <summary>
        /// Gets the height of the first matched element.
        /// </summary>
        /// <returns>The current computed height of the element.</returns>
        [ScriptName("height")]
        public int GetHeight() {
            return 0;
        }

        /// <summary>
        /// Gets the HTML content of the first matched element.
        /// </summary>
        /// <returns>The HTML content within the element.</returns>
        [ScriptName("html")]
        public string GetHtml() {
            return null;
        }

        /// <summary>
        /// Gets the height of the first matched element excluding borders.
        /// </summary>
        /// <returns>The current computed height of the element.</returns>
        [ScriptName("innerHeight")]
        public int GetInnerHeight() {
            return 0;
        }

        /// <summary>
        /// Gets the width of the first matched element excluding borders.
        /// </summary>
        /// <returns>The current computed width of the element.</returns>
        [ScriptName("innerWidth")]
        public int GetInnerWidth() {
            return 0;
        }

        /// <summary>
        /// Returns the wrapped items at the specified index.
        /// </summary>
        /// <param name="index">The index to lookup.</param>
        /// <returns>The item being wrapped.</returns>
        [ScriptName("get")]
        public object GetItem(int index) {
            return null;
        }

        /// <summary>
        /// Returns the wrapped items.
        /// </summary>
        /// <returns>An array containing the items being wrapped.</returns>
        [ScriptName("get")]
        public object[] GetItems() {
            return null;
        }

        /// <summary>
        /// Gets the position of the first matched element relative to the document.
        /// </summary>
        /// <returns>The position of the element.</returns>
        [ScriptName("offset")]
        public jQueryPosition GetOffset() {
            return null;
        }

        /// <summary>
        /// Gets the height of the first matched element including borders.
        /// </summary>
        /// <returns>The current computed height of the element.</returns>
        [ScriptName("outerHeight")]
        public int GetOuterHeight() {
            return 0;
        }

        /// <summary>
        /// Gets the height of the first matched element including borders.
        /// </summary>
        /// <param name="includeMargins">Whether to include the margins.</param>
        /// <returns>The current computed height of the element.</returns>
        [ScriptName("outerHeight")]
        public int GetOuterHeight(bool includeMargins) {
            return 0;
        }

        /// <summary>
        /// Gets the width of the first matched element including borders.
        /// </summary>
        /// <returns>The current computed width of the element.</returns>
        [ScriptName("outerWidth")]
        public int GetOuterWidth() {
            return 0;
        }

        /// <summary>
        /// Gets the width of the first matched element including borders.
        /// </summary>
        /// <param name="includeMargins">Whether to include the margins.</param>
        /// <returns>The current computed width of the element.</returns>
        [ScriptName("outerWidth")]
        public int GetOuterWidth(bool includeMargins) {
            return 0;
        }

        /// <summary>
        /// Gets the value of the specified property from the first of the matched
        /// set of elements.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the specified property.</returns>
        [ScriptName("prop")]
        public string GetProperty(string propertyName) {
            return null;
        }

        /// <summary>
        /// Gets the value of the specified property from the first of the matched
        /// set of elements.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the specified property.</returns>
        [ScriptName("prop")]
        public TValue GetProperty<TValue>(string propertyName) {
            return default(TValue);
        }

        /// <summary>
        /// Gets the current horizontal scrollbar position of the first matched element.
        /// </summary>
        /// <returns>The horizontal scroll position of the element.</returns>
        [ScriptName("scrollLeft")]
        public int GetScrollLeft() {
            return 0;
        }

        /// <summary>
        /// Gets the current vertical scrollbar position of the first matched element.
        /// </summary>
        /// <returns>The vertical scroll position of the element.</returns>
        [ScriptName("scrollTop")]
        public int GetScrollTop() {
            return 0;
        }

        /// <summary>
        /// Gets the text content of the first matched element.
        /// </summary>
        /// <returns>The text content within the element.</returns>
        [ScriptName("text")]
        public string GetText() {
            return null;
        }

        /// <summary>
        /// Gets the value attribute of the first matched element.
        /// </summary>
        /// <returns>The value attribute of the element.</returns>
        [ScriptName("val")]
        public string GetValue() {
            return null;
        }

        /// <summary>
        /// Gets the width of the first matched element.
        /// </summary>
        /// <returns>The current computed width of the element.</returns>
        [ScriptName("width")]
        public int GetWidth() {
            return 0;
        }

        /// <summary>
        /// Returns a new jQueryObject with elements that have a descendant matching
        /// the specified selector.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Has([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with elements that have the specified element
        /// as a descendant.
        /// </summary>
        /// <param name="element">The element to check for.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Has(Element element) {
            return null;
        }

        /// <summary>
        /// Determine whether any of the matched elements are assigned the given class.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>true if the class name is found; false otherwise.</returns>
        public bool HasClass(string className) {
            return false;
        }

        /// <summary>
        /// Sets the height of each of the matched elements.
        /// </summary>
        /// <param name="height">Thew new height.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Height(int height) {
            return null;
        }

        /// <summary>
        /// Sets the height of each of the matched elements.
        /// </summary>
        /// <param name="height">Thew new height.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Height(string height) {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide() {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide(int duration) {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Hide the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Hide(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements.
        /// </summary>
        /// <param name="html">The new HTML to set.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Html(string html) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements to the markup represented
        /// by the specified element.
        /// </summary>
        /// <param name="html">The new HTML to set.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Html(jQueryObject html) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="htmlFunction">The function that returns the HTML content.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Html(StringFunction htmlFunction) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="htmlFunction">The function that returns the HTML content.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Html(StringReplaceFunction htmlFunction) {
            return null;
        }

        /// <summary>
        /// Gets the index of the first element in the matched set of elements relative to
        /// its sibling elements.
        /// </summary>
        /// <returns>The index of the first matching element.</returns>
        public int Index() {
            return 0;
        }

        /// <summary>
        /// Searches every matched element for the object and returns its 0-based index if found.
        /// Returns -1 if the object wasn't found.
        /// </summary>
        /// <param name="element">The element to lookup.</param>
        /// <returns>The index of the elment.</returns>
        public int Index(Element element) {
            return 0;
        }

        /// <summary>
        /// Gets the index of the first element in the matched set of elements relative to
        /// the set of elements matching the specified selector.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <returns>The index of the first matching element.</returns>
        public int Index([SyntaxValidation("cssSelector")] string selector) {
            return 0;
        }

        /// <summary>
        /// Insert every element of the matching set after the specified element.
        /// </summary>
        /// <param name="element">The element to insert after.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject InsertAfter(Element element) {
            return null;
        }

        /// <summary>
        /// Insert every element of the matching set after the elements matching
        /// the specified selector.
        /// </summary>
        /// <param name="selector">The elements to insert after.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject InsertAfter([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Insert every element of the matching set after the specified matched elements.
        /// </summary>
        /// <param name="jQueryObject">The elements to insert after.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject InsertAfter(jQueryObject jQueryObject) {
            return null;
        }

        /// <summary>
        /// Insert every element of the matching set before the specified element.
        /// </summary>
        /// <param name="element">The element to insert before.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject InsertBefore(Element element) {
            return null;
        }

        /// <summary>
        /// Insert every element of the matching set before the elements matching
        /// the specified selector.
        /// </summary>
        /// <param name="selector">The elements to insert before.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject InsertBefore([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Insert every element of the matching set before the specified matched elements.
        /// </summary>
        /// <param name="jQueryObject">The elements to insert before.</param>
        /// <returns>The resulting jQuery object</returns>
        public jQueryObject InsertBefore(jQueryObject jQueryObject) {
            return null;
        }

        /// <summary>
        /// Gets whether the at least one of the matched set of elements matches the specified
        /// filter function.
        /// </summary>
        /// <param name="filter">The filter function to invoke for each element.</param>
        /// <returns>True if there is a matching element; false otherwise.</returns>
        public bool Is(BooleanFunction filter) {
            return false;
        }

        /// <summary>
        /// Gets whether the at least one of the matched set of elements matches the specified
        /// element.
        /// </summary>
        /// <param name="element">The element to compare against.</param>
        /// <returns>True if there is a matching element; false otherwise.</returns>
        public bool Is(Element element) {
            return false;
        }

        /// <summary>
        /// Gets whether the at least one of the matched set of elements matches the specified
        /// matched set of elements.
        /// </summary>
        /// <param name="elements">The matched set of elements to compare against.</param>
        /// <returns>True if there is a matching element; false otherwise.</returns>
        public bool Is(jQueryObject elements) {
            return false;
        }

        /// <summary>
        /// Gets whether the at least one of the matched set of elements matches the specified
        /// selector.
        /// </summary>
        /// <param name="selector">The selector to check for.</param>
        /// <returns>True if there is a matching element; false otherwise.</returns>
        public bool Is([SyntaxValidation("cssSelector")] string selector) {
            return false;
        }

        /// <summary>
        /// Triggers the keydown event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keydown() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the keydown event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keydown(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the keydown event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keydown(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Triggers the keypress event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keypress() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the keypress event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keypress(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the keypress event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keypress(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Triggers the keyup event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keyup() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the keyup event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keyup(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the keyup event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Keyup(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the last matching element.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Last() {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event on the matched set of elements,
        /// as well as other elements matching the current selector in the future.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jQueryObject Live(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for the specified event on the matched set of elements,
        /// as well as other elements matching the current selector in the future.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jQueryObject Live(string eventName, Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the load event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Load(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the load event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Load(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Load data from the specified URL and place the returned HTML into the matched
        /// elements.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Load(string url) {
            return null;
        }

        /// <summary>
        /// Load data from the specified URL and place the returned HTML into the matched
        /// elements.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">The data to send with the request.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Load(string url, object data) {
            return null;
        }

        /// <summary>
        /// Load data from the specified URL and place the returned HTML into the matched
        /// elements.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">The data to send with the request.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Load(string url, object data, AjaxCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Load data from the specified URL and place the returned HTML into the matched
        /// elements.
        /// </summary>
        /// <param name="url">The URL to request.</param>
        /// <param name="data">The data to send with the request.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Load(string url, object data, AjaxRequestCallback<object> callback) {
            return null;
        }

        /// <summary>
        /// Maps each element of the matching set using the specified callback.
        /// </summary>
        /// <param name="callback">The callback that performs the mapping.</param>
        /// <returns>A new jQueryObject containing the mapped results.</returns>
        public jQueryObject Map(ElementMapCallback callback) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mousedown event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mousedown")]
        public jQueryObject MouseDown(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mousedown event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mousedown")]
        public jQueryObject MouseDown(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseenter event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseenter")]
        public jQueryObject MouseEnter(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseenter event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseenter")]
        public jQueryObject MouseEnter(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseleave event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseleave")]
        public jQueryObject MouseLeave(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseleave event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseleave")]
        public jQueryObject MouseLeave(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mousemove event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mousemove")]
        public jQueryObject MouseMove(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mousemove event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mousemove")]
        public jQueryObject MouseMove(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseout event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseout")]
        public jQueryObject MouseOut(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseout event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseout")]
        public jQueryObject MouseOut(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseover event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseover")]
        public jQueryObject MouseOver(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseover event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseover")]
        public jQueryObject MouseOver(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseup event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseup")]
        public jQueryObject MouseUp(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the mouseup event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        [ScriptName("mouseup")]
        public jQueryObject MouseUp(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the immediate following sibling
        /// element of the matched set of elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Next() {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the immediate following sibling
        /// element of the matched set of elements filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Next([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing all the following sibling elements
        /// of the matched set of elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject NextAll() {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing all the following sibling elements
        /// of the matched set of elements filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject NextAll([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing all the following sibling elements
        /// of the matched set of elements while they match the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject NextUntil([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the specified element removed from the
        /// current set of matching elements.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Not(Element element) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the specified elements removed from the
        /// current set of matching elements.
        /// </summary>
        /// <param name="elements">The element to remove.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Not(params Element[] elements) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with elements matching the specified selector
        /// removed from the current set of matching elements.
        /// </summary>
        /// <param name="selector">The selector used to match elements to remove.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Not([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with elements for which the specified filter
        /// function return true removed from the matching set of elements.
        /// </summary>
        /// <param name="filterFunction">The function used to filter elements to remove.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Not(ElementFilterCallback filterFunction) {
            return null;
        }

        /// <summary>
        /// Sets the position of the matched elements relative to the document.
        /// </summary>
        /// <param name="position">The coordinates to position the elements at.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Offset(jQueryPosition position) {
            return null;
        }

        /// <summary>
        /// Sets the position of the matched elements relative to the document using values
        /// returned from the specified function.
        /// </summary>
        /// <param name="positionFunction">The function returning the position for an element.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Offset(PositionFunction positionFunction) {
            return null;
        }

        /// <summary>
        /// Sets the position of the matched elements relative to the document using values
        /// returned from the specified function.
        /// </summary>
        /// <param name="positionFunction">The function returning the position for an element.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Offset(PositionReplaceFunction positionFunction) {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the closest ancestor element that is positioned.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject OffsetParent() {
            return null;
        }

        /// <summary>
        /// Attaches a handler for the handling the specified event once on the matched
        /// set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jQueryObject One(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event once on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jQueryObject One(string eventName, Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the parents of each of the matched elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Parent() {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the parents of each of the matched elements,
        /// filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Parent([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the ancestors of each of the matched elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Parents() {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the ancestors of each of the matched elements,
        /// filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Parents([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the ancestors of each of the matched elements,
        /// up to but not including the element that matches the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject ParentsUntil([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Casts this jQueryObject to a derived jQueryObject to enable using
        /// APIs defined on the jQuery object through an external jQuery plugin.
        /// </summary>
        /// <typeparam name="T">The type of jQueryObject that contains additional plugin APIs mixed in.</typeparam>
        /// <returns>The specified type of jQueryObject.</returns>
        [ScriptSkip]
        public T Plugin<T>() where T : jQueryObject {
            return null;
        }

        /// <summary>
        /// Gets the position of the first matched element relative to the first offset parent.
        /// </summary>
        /// <returns>The position of the element.</returns>
        public jQueryPosition Position() {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to prepend.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Prepend(string content) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM element to prepend.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Prepend(Element content) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM elements to prepend.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Prepend(Element[] content) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The jQueryObject containing the content.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Prepend(jQueryObject content) {
            return null;
        }

        /// <summary>
        /// Prepend content returned from the specified function to the beginning of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to prepend.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Prepend(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Prepend content returned from the specified function to the beginning of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to prepend.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Prepend(StringReplaceFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Prepends every element of the matching set to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="target">The target to prepend to.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject PrependTo(string target) {
            return null;
        }

        /// <summary>
        /// Prepends every element of the matching set to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="target">The DOM element to prepend to.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject PrependTo(Element target) {
            return null;
        }

        /// <summary>
        /// Prepends every element of the matching set to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="target">The jQueryObject to prepend to.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject PrependTo(jQueryObject target) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the immediate preceeding sibling
        /// element of the matched set of elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Prev() {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing the immediate preceeding sibling
        /// element of the matched set of elements filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Prev([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing all the preceeding sibling elements
        /// of the matched set of elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject PrevAll() {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing all the preceeding sibling elements
        /// of the matched set of elements filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject PrevAll([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets a jQueryObject representing all the preceeding sibling elements
        /// of the matched set of elements while they match the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject PrevUntil([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Creates a deferred object to observe when all animations are completed.
        /// </summary>
        /// <returns>A deferred object.</returns>
        public jQueryDeferred Promise() {
            return null;
        }

        /// <summary>
        /// Creates a deferred object to observe when all actions of the specified
        /// type are completed.
        /// </summary>
        /// <param name="type">The type of actions to observe.</param>
        /// <returns>A deferred object.</returns>
        public jQueryDeferred Promise(string type) {
            return null;
        }

        /// <summary>
        /// Creates a deferred object to observe when all actions of the specified
        /// type are completed. The specified target object is modified to contain
        /// the deferred methods.
        /// </summary>
        /// <param name="type">The type of actions to observe.</param>
        /// <param name="target">The target object to modify.</param>
        /// <returns>The target object.</returns>
        public jQueryDeferred Promise(string type, object target) {
            return null;
        }

        /// <summary>
        /// Sets the value of the specified property to the specified value on
        /// the matched set of elements.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set the property to.</param>
        /// <returns>The value of the specified property.</returns>
        [ScriptName("prop")]
        public string Property(string propertyName, object value) {
            return null;
        }

        /// <summary>
        /// Removes the matched elements from the DOM, and removes jQuery data from elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Remove() {
            return null;
        }

        /// <summary>
        /// Removes the matching elements from the DOM, and removes jQuery data from elements.
        /// </summary>
        /// <param name="selector">The selector to use to filter the elements to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Remove([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Removes the specified attribute from each of the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The attribute to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveAttr(string attributeName) {
            return null;
        }

        /// <summary>
        /// Removes all classes from each of the set of matched elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveClass() {
            return null;
        }

        /// <summary>
        /// Removes the CSS class returned by the specified function.
        /// </summary>
        /// <param name="className">The class or classes to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveClass(string className) {
            return null;
        }

        /// <summary>
        /// Removes the class returned from the specified function for each of the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveClass(StringFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Removes the class returned from the specified function for each of the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveClass(StringReplaceFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Removes all the data from the matching set of elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveData() {
            return null;
        }

        /// <summary>
        /// Removes the specified data from the matching set of elements.
        /// </summary>
        /// <param name="key">The name of the value to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject RemoveData(string key) {
            return null;
        }

        /// <summary>
        /// Removes the specified property from the matching set of elements.
        /// </summary>
        /// <param name="propertyName">The name of the property to remove.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("removeProp")]
        public jQueryObject RemoveProperty(string propertyName) {
            return null;
        }

        /// <summary>
        /// Replace each element matching the specified selector with the set of matched elements.
        /// </summary>
        /// <param name="selector">The selector to match elements to be replaced.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ReplaceAll([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the provided new content.
        /// </summary>
        /// <param name="content">The HTML to wrap with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ReplaceWith(string content) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the new content provided
        /// by the specified element.
        /// </summary>
        /// <param name="content">The element containing the HTML to use.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ReplaceWith(Element content) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the new content provided
        /// by the specified set of matched elements.
        /// </summary>
        /// <param name="content">The object containing the HTML to use.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ReplaceWith(jQueryObject content) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the content returned from
        /// the specified function.
        /// </summary>
        /// <param name="contetntFunction">The functio returning the HTML to replace with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ReplaceWith(StringFunction contetntFunction) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the resize event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Resize(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the resize event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Resize(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the scroll event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Scroll(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the scroll event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed in into the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Scroll(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Sets the current horizontal scrollbar position of the matched elements.
        /// </summary>
        /// <param name="position">The horizontal scroll position.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ScrollLeft(int position) {
            return null;
        }

        /// <summary>
        /// Sets the current vertical scrollbar position of the matched elements.
        /// </summary>
        /// <param name="position">The vertical scroll position.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ScrollTop(int position) {
            return null;
        }

        /// <summary>
        /// Triggers the select event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Select() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the select event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Select(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the select event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Select(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Serializes the name/value pairs for the matching set of form elements into
        /// a URL-encoded string suitable for posting/submitting.
        /// </summary>
        /// <returns>The serialized representation of form name/value pairs.</returns>
        public string Serialize() {
            return null;
        }

        /// <summary>
        /// Serializes the name/value pairs for the matching set of form elements.
        /// </summary>
        /// <returns>The form name/value pairs.</returns>
        public jQueryNameValuePair[] SerializeArray() {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show() {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show(int duration) {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Show the matched set of elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Show(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the siblings of each of the matched elements.
        /// </summary>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Siblings() {
            return null;
        }

        /// <summary>
        /// Gets a new jQueryObject containing the siblings of each of the matched elements,
        /// filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Siblings([SyntaxValidation("cssSelector")] string selector) {
            return null;
        }

        /// <summary>
        /// Gets the number of matched elements. <seealso cref="Length" /> is slightly faster.
        /// </summary>
        /// <returns>The number of elements represented by this jQueryObject.</returns>
        public int Size() {
            return 0;
        }

        /// <summary>
        /// Returns a new jQueryObject with the specified range of elements within the
        /// matching set of elements.
        /// </summary>
        /// <param name="startIndex">The index of starting point of the range. Negative to indicate offset from end.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Slice(int startIndex) {
            return null;
        }

        /// <summary>
        /// Returns a new jQueryObject with the specified range of elements within the
        /// matching set of elements.
        /// </summary>
        /// <param name="startIndex">The index of starting point of the range. Negative to indicate offset from end.</param>
        /// <param name="endIndex">The index of ending point of the range. Negative to indicate offset from end.</param>
        /// <returns>The new jQueryObject.</returns>
        public jQueryObject Slice(int startIndex, int endIndex) {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a default duration of 400ms.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown() {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown(int duration) {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides down the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideDown(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by sliding them
        /// using a default duration of 400ms.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideToggle() {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by sliding them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideToggle(int duration) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by sliding them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideToggle(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by sliding them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideToggle(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by sliding them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideToggle(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Toggles the visibility of the matching set of elements by sliding them
        /// using the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideToggle(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a default duration of 400ms.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp() {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp(int duration) {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration in milliseconds for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Slides up the matching set of elements using a the specified duration.
        /// </summary>
        /// <param name="duration">The duration for the effect.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke upon completion.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject SlideUp(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Stops the current animation associated with the matched elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Stop() {
            return null;
        }

        /// <summary>
        /// Stops the current animation associated with the matched elements.
        /// </summary>
        /// <param name="clearQueue">Whether to clear the queue of animations not started yet.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Stop(bool clearQueue) {
            return null;
        }

        /// <summary>
        /// Stops the current animation associated with the matched elements.
        /// </summary>
        /// <param name="clearQueue">Whether to clear the queue of animations not started yet.</param>
        /// <param name="gotoEnd">Whether to immediately complete the current animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Stop(bool clearQueue, bool gotoEnd) {
            return null;
        }

        /// <summary>
        /// Triggers the submit event on each of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Submit() {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the submit event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Submit(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the submit event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Submit(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Adds or removes the specified class from each of the set of matched elements.
        /// </summary>
        /// <param name="className">The class to toggle.</param>
        /// <param name="add">true if the class should be added; false otherwise.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("toggleClass")]
        public jQueryObject SwitchClass(string className, bool add) {
            return null;
        }

        /// <summary>
        /// Adds or removes the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <param name="add">true if the class should be added; false otherwise.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("toggleClass")]
        public jQueryObject SwitchClass(StringFunction cssFunction, bool add) {
            return null;
        }

        /// <summary>
        /// Adds or removes the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <param name="add">true if the class should be added; false otherwise.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("toggleClass")]
        public jQueryObject SwitchClass(StringReplaceFunction cssFunction, bool add) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements.
        /// </summary>
        /// <param name="text">The new text to set.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Text(string text) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="textFunction">The function that returns the text content.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Text(StringFunction textFunction) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="textFunction">The function that returns the text content.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Text(StringReplaceFunction textFunction) {
            return null;
        }

        /// <summary>
        /// Returns the matching set of elements as an array.
        /// </summary>
        /// <returns>An array containing the matched elements.</returns>
        public Element[] ToArray() {
            return null;
        }

        /// <summary>
        /// Toggles visibility of the matched set of elements.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle() {
            return null;
        }

        /// <summary>
        /// Toggles visibility of the matched set of elements.
        /// </summary>
        /// <param name="showOrHide">True to show; false to hide.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(bool showOrHide) {
            return null;
        }

        /// <summary>
        /// Toggle the visibility of the set of matched elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(int duration) {
            return null;
        }

        /// <summary>
        /// Toggle the visibility of the set of matched elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(int duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggle the visibility of the set of matched elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration in milliseconds of the animation.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(int duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggle the visibility of the set of matched elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(EffectDuration duration) {
            return null;
        }

        /// <summary>
        /// Toggle the visibility of the set of matched elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(EffectDuration duration, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggle the visibility of the set of matched elements in an animated manner.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="easing">The easing to use.</param>
        /// <param name="callback">The callback to invoke once the animation is completed.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Toggle(EffectDuration duration, EffectEasing easing, Action callback) {
            return null;
        }

        /// <summary>
        /// Toggles the specified class from each of the set of matched elements.
        /// </summary>
        /// <param name="className">The class to toggle.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ToggleClass(string className) {
            return null;
        }

        /// <summary>
        /// Toggles the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ToggleClass(StringFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Toggles the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject ToggleClass(StringReplaceFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Triggers the event handlers attached for the specified event on the
        /// matched set of elements.
        /// </summary>
        /// <param name="eventName">The event to trigger.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Trigger(string eventName) {
            return null;
        }

        /// <summary>
        /// Triggers the event handlers attached for the specified event on the
        /// matched set of elements.
        /// </summary>
        /// <param name="eventName">The event to trigger.</param>
        /// <param name="eventParameters">Additional parameters for the event handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Trigger(string eventName, object[] eventParameters) {
            return null;
        }

        /// <summary>
        /// Triggers the first event handler attached for the first matched element.
        /// This does not trigger the default DOM behavior of the event.
        /// </summary>
        /// <param name="eventName">The event to trigger.</param>
        /// <returns>The result of the event handler.</returns>
        public object TriggerHandler(string eventName) {
            return null;
        }

        /// <summary>
        /// Triggers the first event handler attached for the first matched element.
        /// This does not trigger the default DOM behavior of the event.
        /// </summary>
        /// <param name="eventName">The event to trigger.</param>
        /// <param name="eventParameters">Additional parameters for the event handler.</param>
        /// <returns>The result of the event handler.</returns>
        public object TriggerHandler(string eventName, object[] eventParameters) {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The event to detach handlers for.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Unbind(string eventName) {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="e">The event passed in into an event handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Unbind(jQueryEvent e) {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be detached.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Unbind(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Detaches the "return false" handler that was bound earlier.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="result">Should be false.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Unbind(string eventName, bool result) {
            return null;
        }

        /// <summary>
        /// Detaches all handlers from matching the specified namespace
        /// from the matched set of elements.
        /// </summary>
        /// <param name="namespaceName">The namespace of the handler.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Undelegate(string namespaceName) {
            return null;
        }

        /// <summary>
        /// Detaches all handlers from handling the specified event on elements matching the
        /// specified selector within the matched set of elements.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Undelegate([SyntaxValidation("cssSelector")] string selector, string eventName) {
            return null;
        }

        /// <summary>
        /// Detaches the specified handler from handling the specified event on elements matching the
        /// specified selector within the matched set of elements.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Undelegate([SyntaxValidation("cssSelector")] string selector, string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the unload event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Unload(jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler to the unload event on each of the matched set of elements.
        /// </summary>
        /// <param name="eventData">Data to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jQueryObject</returns>
        public jQueryObject Unload(Dictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Remove the parents of the set of matched elements from the DOM, leaving the
        /// matched elements in their place.
        /// </summary>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Unwrap() {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements.
        /// </summary>
        /// <param name="value">The new value to set.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("val")]
        public jQueryObject Value(string value) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements using values returned
        /// from the specified function.
        /// </summary>
        /// <param name="valueFunction">The function returning the values to set.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("val")]
        public jQueryObject Value(StringFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements using values returned
        /// from the specified function.
        /// </summary>
        /// <param name="valueFunction">The function returning the values to set.</param>
        /// <returns>The current jQueryObject.</returns>
        [ScriptName("val")]
        public jQueryObject Value(StringReplaceFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the width of each of the matched elements.
        /// </summary>
        /// <param name="width">Thew new width.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Width(int width) {
            return null;
        }

        /// <summary>
        /// Sets the width of each of the matched elements.
        /// </summary>
        /// <param name="width">Thew new width.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Width(string width) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around each of the matched set of elements.
        /// </summary>
        /// <param name="htmlSnippet">The HTML to wrap with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Wrap(string htmlSnippet) {
            return null;
        }

        /// <summary>
        /// Wraps a DOM element around each of the matched set of elements.
        /// </summary>
        /// <param name="element">A DOM element specifying the structure.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Wrap(Element element) {
            return null;
        }

        /// <summary>
        /// Wraps a jQueryObject around each of the matched set of elements.
        /// </summary>
        /// <param name="element">A jQueryObject specifying the structure.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Wrap(jQueryObject element) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around each of the matched set of elements as
        /// returned from the specified wrapping function.
        /// </summary>
        /// <param name="wrappingFunction">The functio returning the HTML to wrap with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject Wrap(StringFunction wrappingFunction) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around all elements in the set of matched elements.
        /// </summary>
        /// <param name="htmlSnippet">The HTML to wrap with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapAll(string htmlSnippet) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around all elements in the set of matched elements.
        /// </summary>
        /// <param name="element">A DOM element specifying the structure.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapAll(Element element) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around all elements in the set of matched elements.
        /// </summary>
        /// <param name="element">A jQueryObject specifying the structure.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapAll(jQueryObject element) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around the content of each of the matched set of elements.
        /// </summary>
        /// <param name="htmlSnippet">The HTML to wrap with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapInner(string htmlSnippet) {
            return null;
        }

        /// <summary>
        /// Wraps a DOM element around the content of each of the matched set of elements.
        /// </summary>
        /// <param name="element">A DOM element specifying the structure.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapInner(Element element) {
            return null;
        }

        /// <summary>
        /// Wraps a jQueryObject around the content of each of the matched set of elements.
        /// </summary>
        /// <param name="element">A jQueryObject specifying the structure.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapInner(jQueryObject element) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around the content of each of the matched set of elements as
        /// returned from the specified wrapping function.
        /// </summary>
        /// <param name="wrappingFunction">The functio returning the HTML to wrap with.</param>
        /// <returns>The current jQueryObject.</returns>
        public jQueryObject WrapInner(StringFunction wrappingFunction) {
            return null;
        }
    }
}
