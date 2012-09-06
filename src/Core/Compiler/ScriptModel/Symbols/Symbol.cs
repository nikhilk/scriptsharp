// Symbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal abstract class Symbol {

        private SymbolType _type;
        private string _name;
        private string _transformedName;
        private bool _transformAllowed;
        private Symbol _parent;
        private object _parseContext;

        protected Symbol(SymbolType type, string name, Symbol parent) {
            _type = type;
            _name = name;
            _parent = parent;
            _transformAllowed = true;
        }

        public virtual string Documentation {
            get {
                return SymbolSet.GetSummaryDocumentation(DocumentationID);
            }
        }

        public virtual string DocumentationID {
            get {
                Debug.Fail("Documentation is not supported for this symbol type.");
                return null;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public virtual string GeneratedName {
            get {
                if (IsTransformed) {
                    return _transformedName;
                }
                return Name;
            }
        }

        public bool IsTransformAllowed {
            get {
                return _transformAllowed;
            }
        }

        public bool IsTransformed {
            get {
                return (_transformedName != null);
            }
        }

        public Symbol Parent {
            get {
                return _parent;
            }
        }

        public object ParseContext {
            get {
                Debug.Assert(_parseContext != null);
                return _parseContext;
            }
        }

        public virtual SymbolSet SymbolSet {
            get {
                return Parent.SymbolSet;
            }
        }

        public SymbolType Type {
            get {
                return _type;
            }
        }

        public void DisableNameTransformation() {
            Debug.Assert(IsTransformAllowed);

            _transformAllowed = false;
        }

        public abstract bool MatchFilter(SymbolFilter filter);

        public void SetTransformedName(string name) {
            Debug.Assert(IsTransformed == false);
            Debug.Assert(IsTransformAllowed);

            _transformedName = name;
            _transformAllowed = false;
        }

        public void SetParseContext(object parseContext) {
            Debug.Assert(_parseContext == null);
            Debug.Assert(parseContext != null);
            _parseContext = parseContext;
        }

        public override string ToString() {
            return Name;
        }
    }
}
