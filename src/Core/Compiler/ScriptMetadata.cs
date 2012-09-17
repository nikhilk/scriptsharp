// ScriptMetadata.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp {

    public sealed class ScriptMetadata {

        private string _name;
        private string _header;
        private string _footer;

        public string Footer {
            get {
                return _footer;
            }
            set {
                _footer = value;
            }
        }

        public string Header {
            get {
                return _header;
            }
            set {
                _header = value;
            }
        }

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        private string ExpandContent(string content) {
            return content.Trim().Replace("{name}", Name);
        }

        public string GetOutputHeader() {
            if (String.IsNullOrEmpty(_header)) {
                return String.Empty;
            }

            return ExpandContent(_header) + Environment.NewLine;
        }

        public string GetOutputFooter() {
            if (String.IsNullOrEmpty(_footer)) {
                return String.Empty;
            }

            return Environment.NewLine + ExpandContent(_footer) + Environment.NewLine;
        }
    }
}
