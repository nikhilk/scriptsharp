// DOMDocumentFragment.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DocumentFragment {

        protected internal DocumentFragment() {
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
        public Element FirstChild {
            get {
                return null;
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
        public int NodeType {
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

        public Element AppendChild(Element child) {
            return null;
        }

        public DocumentFragment CloneNode() {
            return null;
        }

        public Element CloneNode(bool deep) {
            return null;
        }

        public bool Contains(Element element) {
            return false;
        }

        public Element GetElementById(string id) {
            return null;
        }

        public ElementCollection GetElementsByTagName(string tagName) {
            return null;
        }

        public bool HasAttributes() {
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

        public Element RemoveChild(Element child) {
            return null;
        }

        public Element ReplaceChild(Element newChild, Element oldChild) {
            return null;
        }
    }
}
