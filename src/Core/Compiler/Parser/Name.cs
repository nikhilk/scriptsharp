// Name.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    /// <summary>
    /// An identifier or keyword. Symbols are stored in a shared NameTable
    /// so there is only one instance of a given Name around at a time.
    /// You can use the == operator to test if two names from the same
    /// NameTable are equal.
    /// </summary>
    internal sealed class Name {

        private string _value;
        private int _hashValue;

        internal Name(string value) {
            _value = value;
            _hashValue = NameTable.NameHasher.Hash(_value);
        }

        internal Name(StringBuilder value)
            : this(value.ToString()) {
        }

        public int Length {
            get {
                return _value.Length;
            }
        }

        public string Text {
            get {
                return _value;
            }
        }

        public override int GetHashCode() {
            return _hashValue;
        }

        public override string ToString() {
            return _value;
        }
    }
}
