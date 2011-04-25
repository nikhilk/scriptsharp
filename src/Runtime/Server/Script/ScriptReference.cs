// ScriptReference.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using ScriptSharp.Web.Configuration;

namespace ScriptSharp.Web.Script {

    internal sealed class ScriptReference {

        private string _name;
        private string _path;
        private ScriptMode _mode;
        private string[] _dependencies;
        private string _version;

        public ScriptReference(string name, string path, ScriptMode mode, string[] dependencies, string version) {
            _name = name;
            _path = path;
            _mode = mode;
            _dependencies = dependencies;
            _version = version;
        }

        public string[] Dependencies {
            get {
                return _dependencies;
            }
        }

        public ScriptMode Mode {
            get {
                return _mode;
            }
            set {
                _mode = value;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Path {
            get {
                return _path;
            }
        }

        public string Version {
            get {
                return _version;
            }
        }
    }
}
