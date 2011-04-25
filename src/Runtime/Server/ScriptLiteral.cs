// ScriptLiteral.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.IO;

namespace ScriptSharp.Web {

    public sealed class ScriptLiteral : IJsonSerializable {

        private string _script;

        public ScriptLiteral(string script) {
            _script = script;
        }

        #region Implementation of IJsonSerializable
        void IJsonSerializable.Write(TextWriter writer) {
            writer.Write(_script);
        }
        #endregion
    }
}
