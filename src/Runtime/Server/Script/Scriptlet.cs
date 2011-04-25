// Scriptlet.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;

namespace ScriptSharp.Web.Script {

    internal sealed class Scriptlet {

        private string _scriptletType;
        private object _parameters;

        public Scriptlet(string scriptletType, object parameters) {
            _scriptletType = scriptletType;
            _parameters = parameters;
        }

        public object Parameters {
            get {
                return _parameters;
            }
        }

        public string ScriptletType {
            get {
                return _scriptletType;
            }
        }
    }
}
