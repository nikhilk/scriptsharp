// EnumerationSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class EnumerationSymbol : TypeSymbol {

        private bool _flags;

        private bool _numericValues;
        private bool _namedValues;

        private int _transformationCookie;

        public EnumerationSymbol(string name, NamespaceSymbol parent, bool flags)
            : base(SymbolType.Enumeration, name, parent) {
            _flags = flags;
            _transformationCookie = -1;
        }

        public bool Constants {
            get {
                return _namedValues || _numericValues;
            }
        }

        public bool Flags {
            get {
                return _flags;
            }
        }

        public int TransformationCookie {
            get {
                return _transformationCookie;
            }
            set {
                _transformationCookie = value;
            }
        }

        public bool UseNamedValues {
            get {
                return _namedValues;
            }
        }

        public bool UseNumericValues {
            get {
                return _numericValues;
            }
        }

        public string CreateNamedValue(EnumerationFieldSymbol field) {
            Debug.Assert(_namedValues);
            Debug.Assert(field.Parent == this);

            if (field.IsTransformed) {
                return field.GeneratedName;
            }

            string name = field.Name;
            if (field.IsCasePreserved == false) {
                name = Utility.CreateCamelCaseName(name);
            }
            return name;
        }

        public void SetNamedValues() {
            Debug.Assert(_numericValues == false);

            _namedValues = true;
        }

        public void SetNumericValues() {
            Debug.Assert(_namedValues == false);

            _numericValues = true;
        }
    }
}
