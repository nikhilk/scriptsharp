// XmlNode.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [Imported]
    public class XmlNode {

        internal XmlNode() {
        }

        [ScriptProperty]
        public XmlNamedNodeMap Attributes {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string BaseName {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNodeList ChildNodes {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNode FirstChild {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNode LastChild {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNode NextSibling {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("nodeName")]
        public virtual string Name {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNodeType NodeType {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        [ScriptName("nodeValue")]
        public virtual string Value {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public XmlDocument OwnerDocument {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNode ParentNode {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Prefix {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public XmlNode PreviousSibling {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("text")]
        public string InnerText {
            get {
                return null;
            }
        }

        [ScriptProperty]
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

        public bool HasChildNodes() {
            return false;
        }

        public XmlNode InsertBefore(XmlNode child, XmlNode refChild) {
            return null;
        }

        public XmlNode RemoveChild(XmlNode child) {
            return null;
        }

        public XmlNode ReplaceChild(XmlNode child, XmlNode oldChild) {
            return null;
        }

        public XmlNodeList SelectNodes(string xpath) {
            return null;
        }

        public XmlNode SelectSingleNode(string xpath) {
            return null;
        }

        public string TransformNode(XmlDocument stylesheet) {
            return null;
        }
    }
}
