// Window.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Html.Data;
using System.Runtime.CompilerServices;

namespace System.Html {

    /// <summary>
    /// The window object represents the current browser window, and is the top-level
    /// scripting object.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("window")]
    public sealed class Window {

        private Window() {
        }

        [IntrinsicProperty]
        public static ApplicationCache ApplicationCache {
            get {
                return null;
            }
        }

        /// <summary>
        /// IE only.
        /// </summary>
        [IntrinsicProperty]
        public static DataTransfer ClipboardData {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static bool Closed {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public static string DefaultStatus {
            get { 
                return null; 
            }
            set { 
            }
        }

        [IntrinsicProperty]
        public static object DialogArguments {
            get { 
                return null; 
            }
        }

        [IntrinsicProperty]
        public static DocumentInstance Document {
            get {
                return null;
            }
        }

        /// <summary>
        /// Provides information about the current event being handled.
        /// </summary>
        [IntrinsicProperty]
        public static ElementEvent Event {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static IFrameElement FrameElement {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static History History {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static int InnerHeight {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static int InnerWidth {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static Storage LocalStorage {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Location Location {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Navigator Navigator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static WindowInstance Parent {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static ErrorHandler Onerror {
            get { 
                return null; 
            }
            set { 
            } 
        }

        [IntrinsicProperty]
        public static WindowInstance Opener {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Orientation Orientation {
            get {
                return Orientation.Portrait;
            }
        }

        [IntrinsicProperty]
        public static int OuterHeight {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static int OuterWidth {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static int PageXOffset {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static int PageYOffset {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public static Screen Screen {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static WindowInstance Self {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Storage SessionStorage {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string Status {
            get { 
                return null; 
            }
            set { 
            }
        }

        [IntrinsicProperty]
        public static WindowInstance Top {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
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

        public static void AttachEvent(string eventName, ElementEventHandler handler) {
        }

        public static void ClearInterval(int intervalID) {
        }

        public static void ClearTimeout(int timeoutID) {
        }

        public static void Close() {
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

        public static void Scroll(int x, int y) {
        }

        public static void ScrollBy(int x, int y) {
        }

        public static void ScrollTo(int x, int y) {
        }

        public static int SetInterval(string code, int milliseconds) {
            return 0;
        }

        public static int SetInterval(Action callback, int milliseconds) {
            return 0;
        }

        public static int SetInterval(Delegate d, int milliseconds) {
            return 0;
        }

        public static int SetTimeout(string code, int milliseconds) {
            return 0;
        }

        public static int SetTimeout(Action callback, int milliseconds) {
            return 0;
        }

        public static int SetTimeout(Delegate d, int milliseconds) {
            return 0;
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

        public static void PostMessage(string message, string targetOrigin) {
        }

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
    }
}
