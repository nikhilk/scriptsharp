// IJsonSerializable.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.IO;

namespace ScriptSharp.Web {

    internal interface IJsonSerializable {

        void Write(TextWriter writer);
    }
}
