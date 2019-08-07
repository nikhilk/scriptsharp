// Document.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Html.StyleSheets;
using System.Html.Editing;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("document")]
    public static class Document {

        [ScriptField]
        public static Element ActiveElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Element Body {
            get {
                return null;
            }
        }

        [ScriptField]
        public static string Cookie {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public static string Doctype {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Element DocumentElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public static string DesignMode {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public static string Domain {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public static DocumentImplementation Implementation {
            get {
                return null;
            }
        }

        [ScriptField]
        public static WindowInstance ParentWindow {
            get {
                return null;
            }
        }

        [ScriptField]
        public static string ReadyState {
            get {
                return null;
            }
        }

        [ScriptField]
        public static string Referrer {
            get {
                return null;
            }
        }

        [ScriptField]
        public static Selection Selection {
            get {
                return null;
            }
        }

        [ScriptField]
        public static StyleSheetList StyleSheets {
            get {
                return null;
            }
        }

        [ScriptField]
        public static string Title {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
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

        /// <summary>
        /// Creates an Attr of the given name. Note that the Attr instance can then be set on an 
        /// Element using the setAttributeNode method. To create an attribute with a qualified name 
        /// and namespace URI, use the CreateAttributeNS method.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>A new Attr object with the nodeName attribute set to name, and localName, prefix, 
        /// and namespaceURI set to null. The value of the attribute is the empty string.</returns>
        public static ElementAttribute CreateAttribute(string name) {
            return null;
        }

        /// <summary>
        /// Creates an attribute of the given qualified name and namespace URI.
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the attribute to create.</param>
        /// <param name="qualifiedName">The qualified name of the attribute to instantiate.</param>
        /// <returns>A new Attr object with the given namespace and qualified name.</returns>
        public static ElementAttribute CreateAttributeNS(string namespaceURI, string qualifiedName) {
            return null;
        }

        public static DocumentFragment CreateDocumentFragment() {
            return null;
        }

        /// <summary>
        /// Creates an element of the type specified. 
        /// To create an element with a qualified name and namespace URI, use the CreateElementNS method.
        /// </summary>
        /// <param name="tagName">The name of the element type to instantiate.</param>
        /// <returns>A new Element object with the nodeName attribute set to tagName, and localName, 
        /// prefix, and namespaceURI set to null.</returns>
        public static Element CreateElement(string tagName) {
            return null;
        }

        /// <summary>
        /// Creates an element of the given qualified name and namespace URI. 
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element to create.</param>
        /// <param name="qualifiedName">The qualified name of the element type to instantiate.</param>
        /// <returns>A new Element object with the given namespace and qualified name.</returns>
        public static Element CreateElementNS(string namespaceURI, string qualifiedName) {
            return null;
        }

        public static MutableEvent CreateEvent(string eventType) {
            return null;
        }

        public static Element CreateTextNode(string data) {
            return null;
        }

        public static Element ImportNode(Element imporedNode, bool deep) {
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

        public static TElement GetElementById<TElement>(string id) where TElement : Element {
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

        /// <summary>
        /// Returns a NodeList of all the Elements with a given local name and namespace URI in the order in which they are encountered in a preorder traversal of the Document tree.
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the elements to match on. The special value "*" matches all namespaces.</param>
        /// <param name="localName">The local name of the elements to match on. The special value "*" matches all local names.</param>
        /// <returns>A new NodeList object containing all the matched Elements.</returns>
        public static ElementCollection GetElementsByTagNameNS(string namespaceURI, string localName) {
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
