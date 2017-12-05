// XmlNode.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName(Object.NAME_DEFINITION)]
    public class XmlNode {

        internal XmlNode() {
        }

        [ScriptField]
        public XmlNamedNodeMap Attributes {
            get {
                return null;
            }
        }

        [ScriptField]
        public string BaseName {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNodeList ChildNodes {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNode FirstChild {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNode LastChild {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNode NextSibling {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("nodeName")]
        public virtual string Name {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNodeType NodeType {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("nodeValue")]
        public virtual string Value {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public XmlDocument OwnerDocument {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNode ParentNode {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Prefix {
            get {
                return null;
            }
        }

        [ScriptField]
        public XmlNode PreviousSibling {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("text")]
        public string InnerText {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("xml")]
        public string OuterXml {
            get {
                return null;
            }
        }

        public XmlNode AppendChild(XmlNode child) {
            return null;
        }

        public XmlNode CloneNode(bool deepClone) {
            return null;
        }

        public XmlNodeList GetElementsByTagName(string tagName) {
            return null;
        }

        public bool HasAttributes() {
            return false;
        }

        public bool HasChildNodes() {
            return false;
        }

        public XmlNode InsertBefore(XmlNode child, XmlNode refChild) {
            return null;
        }

        public XmlNode QuerySelector(string selector) {
            return null;
        }

        public XmlNodeList QuerySelectorAll(string selector) {
            return null;
        }

        public XmlNode RemoveChild(XmlNode child) {
            return null;
        }

        public XmlNode ReplaceChild(XmlNode child, XmlNode oldChild) {
            return null;
        }
    }
}
