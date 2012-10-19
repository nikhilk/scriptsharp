// DocumentInstance.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Html.Editing;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DocumentInstance {

        private DocumentInstance() {
        }

        [ScriptField]
        public Element ActiveElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element Body {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Cookie {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string DesignMode {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Doctype {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element DocumentElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Domain {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public DocumentImplementation Implementation {
            get {
                return null;
            }
        }

        [ScriptField]
        public WindowInstance ParentWindow {
            get {
                return null;
            }
        }

        [ScriptField]
        public string ReadyState {
            get {
                return null;
            }
        }
        
        [ScriptField]
        public string Referrer {
            get {
                return null;
            }
        }

        [ScriptField]
        public Selection Selection {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Title {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string URL {
            get {
                return null;
            }
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        public void AddEventListener(string eventName, ElementEventListener listener) {
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void AddEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        public void AttachEvent(string eventName, ElementEventHandler handler) {
        }

        public void Close() {
        }

        public ElementAttribute CreateAttribute(string name) {
            return null;
        }

        public DocumentFragment CreateDocumentFragment() {
            return null;
        }

        public Element CreateElement(string tagName) {
            return null;
        }

        public MutableEvent CreateEvent(string eventType) {
            return null;
        }

        public Element CreateTextNode(string tagName) {
            return null;
        }

        public void DetachEvent(string eventName, ElementEventHandler handler) {
        }

        public bool DispatchEvent(MutableEvent eventObject) {
            return false;
        }

        public Element ElementFromPoint(int x, int y) {
            return null;
        }

        public bool ExecCommand(string command, bool displayUserInterface, object value) {
            return false;
        }

        public void Focus() {
        }

        public Element GetElementById(string id) {
            return null;
        }

        public TElement GetElementById<TElement>(string id) where TElement : Element {
            return null;
        }

        public ElementCollection GetElementsByClassName(string className) {
            return null;
        }

        public ElementCollection GetElementsByName(string name) {
            return null;
        }

        public ElementCollection GetElementsByTagName(string tagName) {
            return null;
        }

        public bool HasFocus() {
            return false;
        }

        public void Open() {
        }

        public bool QueryCommandEnabled(string command) {
            return false;
        }

        public bool QueryCommandIndeterm(string command) {
            return false;
        }

        public bool QueryCommandState(string command) {
            return false;
        }

        public bool QueryCommandSupported(string command) {
            return false;
        }

        public object QueryCommandValue(string command) {
            return null;
        }

        public Element QuerySelector(string selector) {
            return null;
        }

        public ElementCollection QuerySelectorAll(string selector) {
            return null;
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        public void RemoveEventListener(string eventName, ElementEventListener listener) {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void RemoveEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        public void Write(string text) {
        }

        public void Writeln(string text) {
        }
    }
}
