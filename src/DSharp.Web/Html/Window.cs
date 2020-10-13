// Window.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html.Data;
using System.Html.Data.Files;
using System.Html.Data.IndexedDB;
using System.Html.Data.Sql;
using System.Html.Editing;
using System.Runtime.CompilerServices;

namespace System.Html {

    /// <summary>
    /// The window object represents the current browser window, and is the top-level
    /// scripting object.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("window")]
    public sealed class Window {

        private Window() {
        }

        [ScriptField]
        public static ApplicationCache ApplicationCache {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Blob Blob {
            get {
                return null;
            }
        }

        /// <summary>
        /// IE only.
        /// </summary>
        [ScriptField]
        public static DataTransfer ClipboardData {
            get {
                return null;
            }
        }

        [ScriptField]
        public static bool Closed {
            get {
                return false;
            }
        }

        [ScriptField]
        public static string DefaultStatus {
            get { 
                return null; 
            }
            set { 
            }
        }

        [ScriptField]
        public static object DialogArguments {
            get { 
                return null; 
            }
        }

        [ScriptField]
        public static DocumentInstance Document {
            get {
                return null;
            }
        }

        /// <summary>
        /// Provides information about the current event being handled.
        /// </summary>
        [ScriptField]
        public static ElementEvent Event {
            get {
                return null;
            }
        }

        [ScriptField]
        public static File File {
            get {
                return null;
            }
        }

        [ScriptField]
        public static FileList FileList {
            get {
                return null;
            }
        }

        [ScriptField]
        public static FileReader FileReader {
            get {
                return null;
            }
        }

        [ScriptField]
        public static IFrameElement FrameElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public static History History {
            get {
                return null;
            }
        }

        [ScriptField]
        public static int InnerHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static int InnerWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static Storage LocalStorage {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Location Location {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Navigator Navigator {
            get {
                return null;
            }
        }

        [ScriptField]
        public static WindowInstance Parent {
            get {
                return null;
            }
        }

        [ScriptField]
        public static ErrorHandler Onerror {
            get { 
                return null; 
            }
            set { 
            } 
        }

        [ScriptField]
        public static WindowInstance Opener {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Orientation Orientation {
            get {
                return Orientation.Portrait;
            }
        }

        [ScriptField]
        public static int OuterHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static int OuterWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static int PageXOffset {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static int PageYOffset {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static Screen Screen {
            get {
                return null;
            }
        }

        [ScriptField]
        public static WindowInstance Self {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Storage SessionStorage {
            get {
                return null;
            }
        }

        [ScriptField]
        public static string Status {
            get { 
                return null; 
            }
            set { 
            }
        }

        [ScriptField]
        public static WindowInstance Top {
            get {
                return null;
            }
        }

        [ScriptField]
        public static WindowInstance[] Frames {
            get {
                return null;
            }
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        public static void AddEventListener(string eventName, ElementEventListener listener) {
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public static void AddEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        /// <summary>
        /// Displays a message box containing the specified message text.
        /// </summary>
        /// <param name="message">The text of the message.</param>
        [ScriptAlias("alert")]
        public static void Alert(string message) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="b">The boolean to display.</param>
        [ScriptAlias("alert")]
        public static void Alert(bool b) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="d">The date to display.</param>
        [ScriptAlias("alert")]
        public static void Alert(Date d) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="n">The number to display.</param>
        [ScriptAlias("alert")]
        public static void Alert(Number n) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="o">The object to display.</param>
        [ScriptAlias("alert")]
        public static void Alert(object o) {
        }

        public static void AttachEvent(string eventName, ElementEventHandler handler) {
        }

        /// <summary>
        /// Decodes a string of data which has been encoded using base-64 encoding.
        /// For use with Unicode or UTF-8 strings.
        /// </summary>
        /// <param name="base64EncodedData">Base64 encoded string</param>
        /// <returns>String of Binary data</returns>
        [ScriptName("atob")]
        public static string Base64ToBinary(string base64EncodedData) {
            return null;
        }

        /// <summary>
        /// Creates a base-64 encoded ASCII string from a "string" of binary data.
        /// Please note that this is not suitable for raw Unicode strings!
        /// </summary>
        /// <param name="stringToEncode">String of binary data</param>
        /// <returns>Base64 string</returns>
        [ScriptName("btoa")]
        public static string BinaryToBase64(string stringToEncode) {
            return null;
        }

        public static void Close() {
        }

        /// <summary>
        /// Prompts the user with a yes/no question.
        /// </summary>
        /// <param name="message">The text of the question.</param>
        /// <returns>true if the user chooses yes; false otherwise.</returns>
        [ScriptAlias("confirm")]
        public static bool Confirm(string message) {
            return false;
        }

        public static void DetachEvent(string eventName, ElementEventHandler handler) {
        }

        public static bool DispatchEvent(MutableEvent eventObject) {
            return false;
        }

        public static void Navigate(string url) {
        }

        public static WindowInstance Open(string url) {
            return null;
        }

        public static WindowInstance Open(string url, string targetName) {
            return null;
        }

        public static WindowInstance Open(string url, string targetName, string features) {
            return null;
        }

        public static WindowInstance Open(string url, string targetName, string features, bool replace) {
            return null;
        }

        public static void Print() {
        }

        /// <summary>
        /// Prompts the user to enter a value.
        /// </summary>
        /// <param name="message">The text of the prompt.</param>
        /// <returns>The value entered by the user.</returns>
        [ScriptAlias("prompt")]
        public static string Prompt(string message) {
            return null;
        }

        /// <summary>
        /// Prompts the user to enter a value.
        /// </summary>
        /// <param name="message">The text of the prompt.</param>
        /// <param name="defaultValue">The default value for the prompt.</param>
        /// <returns>The value entered by the user.</returns>
        [ScriptAlias("prompt")]
        public static string Prompt(string message, string defaultValue) {
            return null;
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        public static void RemoveEventListener(string eventName, ElementEventListener listener) {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public static void RemoveEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        [ScriptAlias("require")]
        public static void Require(string[] names, Action callback) {
        }

        [ScriptAlias("require")]
        public static void Require<T>(string name, Action<T> callback) {
        }

        [ScriptAlias("require")]
        public static void Require(string name, Action callback) {
        }

        public static void Scroll(int x, int y) {
        }

        public static void ScrollBy(int x, int y) {
        }

        public static void ScrollTo(int x, int y) {
        }

        public static SqlDatabase OpenDatabase(string name, string version) {
            return null;
        }

        public static SqlDatabase OpenDatabase(string name, string version, string displayName) {
            return null;
        }

        public static SqlDatabase OpenDatabase(string name, string version, string displayName, int estimatedSize) {
            return null;
        }

        public static SqlDatabase OpenDatabase(string name, string version, string displayName, int estimatedSize, SqlDatabaseCallback creationCallback) {
            return null;
        }

        [ScriptField]
        public static DBFactory IndexedDB {
            get {
                return null;
            }
        }


        public static void PostMessage(string message, string targetOrigin) {
        }

        public static extern void PostMessage(object message, string targetOrigin);

        /// <summary>
        /// Delegate that indicates the ability of the browser
        /// to show a modal dialog.
        /// </summary>
        /// <remarks>
        /// Not all browsers support this function, so code using
        /// this needs to check for existence of the feature or the browser.
        /// </remarks>
        public static WindowInstance ShowModalDialog(string url, object dialogArguments, string features) {
            return null; 
        }

        [ScriptField]
        public static extern Html5Performance Performance { get; }

        public static int RequestAnimationFrame(Action<int> action)
        {
            return 0;
        }

        public static void CancelAnimationFrame(int request)
        {
        }

        public static int RequestIdleCallback(Action<object> callback)
        {
            return 0;
        }

        public static Style GetComputedStyle(Element element) { return null; }

        public static Selection GetSelection() { return null; }
    }
}
