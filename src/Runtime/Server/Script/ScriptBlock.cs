// ScriptBlock.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;

namespace ScriptSharp.Web.Script {

    internal sealed class ScriptBlock {

        private string _code;
        private string[] _dependencies;

        public ScriptBlock(string code, string[] dependencies) {
            _code = code;
            _dependencies = dependencies;
        }

        public string Code {
            get {
                return _code;
            }
        }

        public string[] Dependencies {
            get {
                return _dependencies;
            }
        }
    }
}
