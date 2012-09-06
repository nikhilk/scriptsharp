// ClassSymbol.cs
// Script#/Core/ScriptSharp
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class GenericTypeSymbol : TypeSymbol {

        private int _genericArgumentIndex;

        public GenericTypeSymbol(int genericArgumentIndex, NamespaceSymbol parent)
            : base(SymbolType.GenericParameter, "<T>", parent) {
            _genericArgumentIndex = genericArgumentIndex;
        }

        public int GenericArgumentIndex {
            get {
                return _genericArgumentIndex;
            }
        }
    }
}
