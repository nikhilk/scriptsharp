// SyntaxValidationAttribute.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.CodeAnalysis {

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = true)]
    [NonScriptable]
    [Imported]
    public sealed class SyntaxValidationAttribute : Attribute {

        private string _syntax;

        public SyntaxValidationAttribute(string syntax) {
            _syntax = syntax;
        }

        public string Syntax {
            get {
                return _syntax;
            }
        }
    }
}
