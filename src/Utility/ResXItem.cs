// ResXItem.cs
// Script#/Common
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp {

    internal sealed class ResXItem {

        private string _name;
        private string _value;
        private string _comment;

        public ResXItem(string name, string value, string comment) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);

            _name = name;
            _value = value;
            _comment = comment;
        }

        public string Comment {
            get {
                if (_comment == null) {
                    return String.Empty;
                }
                return _comment;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Value {
            get {
                if (_value == null) {
                    return String.Empty;
                }
                return _value;
            }
        }
    }
}
