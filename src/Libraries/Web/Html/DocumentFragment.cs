// DOMDocumentFragment.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public class DocumentFragment {

        protected internal DocumentFragment() {
        }

        [IntrinsicProperty]
        public ElementAttributeCollection Attributes {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public ElementCollection ChildNodes {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element FirstChild {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element LastChild {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element NextSibling {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string NodeName {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int NodeType {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string NodeValue {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public DocumentInstance OwnerDocument {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element ParentNode {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
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
