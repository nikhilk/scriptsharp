// SyntaxValidationAttribute.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
