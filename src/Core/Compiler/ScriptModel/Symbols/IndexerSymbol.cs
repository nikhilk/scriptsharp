// IndexerSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {

    internal sealed class IndexerSymbol : PropertySymbol {

        private bool _scriptIndexer;

        public IndexerSymbol(TypeSymbol parent, TypeSymbol propertyType)
            : base(SymbolType.Indexer, "Item", parent, propertyType) {
        }

        public IndexerSymbol(TypeSymbol parent, TypeSymbol propertyType, MemberVisibility visibility)
            : this(parent, propertyType) {
            SetVisibility(visibility);
        }

        public override string DocumentationID {
            get {
                TypeSymbol parent = (TypeSymbol)Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("P:");
                sb.Append(parent.Namespace);
                sb.Append(".");

                // Only include the first parameter.
                sb.Append(parent.Name);
                sb.Append(".Item(");
                sb.Append(Parameters[0].DocumentationID);
                sb.Append(")");

                return sb.ToString();
            }
        }

        public bool UseScriptIndexer {
            get {
                return _scriptIndexer;
            }
        }

        public void SetScriptIndexer() {
            Debug.Assert(_scriptIndexer == false);
            _scriptIndexer = true;
        }
    }
}
