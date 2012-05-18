// Document.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;
using System.Html.Editing;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("document")]
    public static class Document {

        [IntrinsicProperty]
        public static Element ActiveElement {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Element Body {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string Cookie {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static string Doctype {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Element DocumentElement {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string DesignMode {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static string Domain {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static DocumentImplementation Implementation {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static WindowInstance ParentWindow {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string ReadyState {
            get {
                return null;
            }
        }
        
        [IntrinsicProperty]
        public static string Referrer {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static Selection Selection {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public static string Title {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static string URL {
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

        public static ElementAttribute CreateAttribute(string name) {
            return null;
        }

        public static DocumentFragment CreateDocumentFragment() {
            return null;
        }

        public static Element CreateElement(string tagName) {
            return null;
        }

        public static MutableEvent CreateEvent(string eventType) {
            return null;
        }

        public static Element CreateTextNode(string data) {
            return null;
        }

        public static void DetachEvent(string eventName, ElementEventHandler handler) {
        }

        public static bool DispatchEvent(MutableEvent eventObject) {
            return false;
        }

        public static Element ElementFromPoint(int x, int y) {
            return null;
        }

        public static bool ExecCommand(string command, bool displayUserInterface, object value) {
            return false;
        }

        public static void Focus() {
        }

        public static Element GetElementById(string id) {
            return null;
        }

        public static ElementCollection GetElementsByClassName(string className) {
            return null;
        }

        public static ElementCollection GetElementsByName(string name) {
            return null;
        }

        public static ElementCollection GetElementsByTagName(string tagName) {
            return null;
        }

        public static bool HasFocus() {
            return false;
        }

        public static bool QueryCommandEnabled(string command) {
            return false;
        }

        public static bool QueryCommandIndeterm(string command) {
            return false;
        }

        public static bool QueryCommandState(string command) {
            return false;
        }

        public static bool QueryCommandSupported(string command) {
            return false;
        }

        public static object QueryCommandValue(string command) {
            return null;
        }

        public static Element QuerySelector(string selector) {
            return null;
        }

        public static ElementCollection QuerySelectorAll(string selector) {
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
    }
}
