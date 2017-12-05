// Element.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Html.Media.Filters;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName(PreserveCase = true)]
    public class Element {

        protected internal Element() {
        }

        [ScriptField]
        public string AccessKey {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public ElementAttributeCollection Attributes {
            get {
                return null;
            }
        }

        [ScriptField]
        public ElementCollection ChildNodes {
            get {
                return null;
            }
        }

        [ScriptField]
        public ElementCollection Children {
            get {
                return null;
            }
        }

        [ScriptField]
        public string ClassName {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public TokenList ClassList {
            get {
                return null;
            }
        }

        [ScriptField]
        public int ClientHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ClientLeft {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ClientTop {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ClientWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public Style CurrentStyle {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Dir {
            get {
                return null;
            }
            set {
            }
        }

        // TODO: Is this on Element or just some types of elements?
        [ScriptField]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public VisualFilterCollection Filters {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element FirstChild {
            get {
                return null;
            }
        }

        [ScriptField]
        public string ID {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string InnerHTML {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string InnerText {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Element LastChild {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element NextSibling {
            get {
                return null;
            }
        }

        [ScriptField]
        public string NodeName {
            get {
                return null;
            }
        }

        [ScriptField]
        public ElementType NodeType {
            get {
                return 0;
            }
        }

        [ScriptField]
        public string NodeValue {
            get {
                return null;
            }
        }

        [ScriptField]
        public int OffsetHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int OffsetLeft {
            get {
                return 0;
            }
        }

        [ScriptField]
        public Element OffsetParent {
            get {
                return null;
            }
        }

        [ScriptField]
        public int OffsetTop {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int OffsetWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public DocumentInstance OwnerDocument {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element ParentNode {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element PreviousSibling {
            get {
                return null;
            }
        }

        [ScriptField]
        public Style RuntimeStyle {
            get {
                return null;
            }
        }

        [ScriptField]
        public int ScrollHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int ScrollLeft {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public int ScrollTop {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public int ScrollWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public Style Style {
            get {
                return null;
            }
        }

        [ScriptField]
        public int TabIndex {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public string TagName {
            get {
                return null;
            }
        }

        [ScriptField]
        public string TextContent {
            get {
                return null;
            }
            set {
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

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void AddEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="handler">The handler to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the handler wants to initiate capturing the event.</param>
        public void AddEventListener(string eventName, IElementEventHandler handler, bool useCapture) {
        }

        public Element AppendChild(Element child) {
            return null;
        }

        public Element AppendChild(DocumentFragment child) {
            return null;
        }

        [ScriptSkip]
        public TElement As<TElement>() where TElement : Element {
            return null;
        }

        public void AttachEvent(string eventName, ElementEventHandler handler) {
        }

        public void Blur() {
        }

        public void Click() {
        }

        public Element CloneNode() {
            return null;
        }

        public Element CloneNode(bool deep) {
            return null;
        }

        public bool Contains(Element element) {
            return false;
        }

        public void DetachEvent(string eventName, ElementEventHandler handler) {
        }

        public bool DispatchEvent(MutableEvent eventObject) {
            return false;
        }

        public bool DragDrop() {
            return false;
        }

        public void Focus() {
        }

        public object GetAttribute(string name) {
            return null;
        }

        public object GetAttribute(ElementAttributeName name) {
            return null;
        }

        public ElementAttribute GetAttributeNode(string name) {
            return null;
        }

        public ElementAttribute GetAttributeNode(ElementAttributeName name) {
            return null;
        }

        public ClientRectList GetClientRects() {
            return null;
        }

        public ClientRect GetBoundingClientRect()
        {
            return null;
        }

        public ElementCollection GetElementsByClassName(string className) {
            return null;
        }

        public ElementCollection GetElementsByTagName(string tagName) {
            return null;
        }

        public bool HasAttribute(string name) {
            return false;
        }

        public bool HasAttribute(ElementAttributeName name) {
            return false;
        }

        public bool HasChildNodes() {
            return false;
        }

        public Element InsertBefore(Element newChild) {
            return null;
        }

        public Element InsertBefore(Element newChild, Element referenceChild) {
            return null;
        }

        public Element QuerySelector(string selector) {
            return null;
        }

        public ElementCollection QuerySelectorAll(string selector) {
            return null;
        }

        public bool RemoveAttribute(string name) {
            return false;
        }

        public bool RemoveAttribute(ElementAttributeName name) {
            return false;
        }

        public ElementAttribute RemoveAttributeNode(ElementAttribute attribute) {
            return null;
        }

        public Element RemoveChild(Element child) {
            return null;
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void RemoveEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="handler">The handler to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the handler wants to initiate capturing the event.</param>
        public void RemoveEventListener(string eventName, IElementEventHandler handler, bool useCapture) {
        }

        public Element ReplaceChild(Element newChild, Element oldChild) {
            return null;
        }

        public void ScrollIntoView() {
        }

        public void ScrollIntoView(bool alignTop) {
        }

        public void SetActive() {
        }

        public void SetAttribute(string name, object value) {
        }

        public void SetAttribute(ElementAttributeName name, object value) {
        }

        public ElementAttribute SetAttributeNode(ElementAttribute attribute) {
            return null;
        }
    }
}
