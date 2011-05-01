// ElementQuery.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.IO;

namespace ScriptSharp.Web {

    public sealed class ElementQuery : IJsonSerializable {

        private string _selector;

        public ElementQuery(string selector) {
            _selector = selector;
        }

        #region Implementation of IJsonSerializable
        void IJsonSerializable.Write(TextWriter writer) {
            writer.Write("document.querySelector('" + _selector + ")");
        }
        #endregion
    }
}
