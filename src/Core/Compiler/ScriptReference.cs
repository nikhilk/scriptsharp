// ScriptReference.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp {

    public sealed class ScriptReference {

        private string _name;
        private string _identifier;

        private string _path;
        private bool _delayLoaded;

        public ScriptReference(string name, string identifier) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert((identifier == null) || (identifier.Length != 0));

            _name = name;
            _identifier = identifier;
        }

        public bool DelayLoaded {
            get {
                return _delayLoaded;
            }
            set {
                _delayLoaded = value;
            }
        }

        public bool HasIdentifier {
            get {
                return _identifier != null;
            }
        }

        public string Identifier {
            get {
                return _identifier ?? _name;
            }
            set {
                _identifier = value;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Path {
            get {
                return _path ?? _name;
            }
            set {
                _path = value;
            }
        }
    }
}
