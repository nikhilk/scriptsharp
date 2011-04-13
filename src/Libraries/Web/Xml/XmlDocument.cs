// XmlDocument.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    /// <summary>
    /// Represents the hierarchy of node objects parsed from XML markup.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class XmlDocument : XmlNode {

        internal XmlDocument() {
        }

        [IntrinsicProperty]
        public string Doctype {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public XmlNode DocumentElement {
            get {
                return null;
            }
        }

        public XmlAttribute CreateAttribute(string name) {
            return null;
        }

        [ScriptName("createCDATASection")]
        public XmlNode CreateCDataSection(string data) {
            return null;
        }

        public XmlNode CreateComment(string text) {
            return null;
        }

        public XmlNode CreateElement(string tagName) {
            return null;
        }

        public XmlNode CreateEntityReference(string name) {
            return null;
        }

        public XmlNode CreateProcessingInstruction(string target, string data) {
            return null;
        }

        public XmlText CreateTextNode(string text) {
            return null;
        }
    }
}
