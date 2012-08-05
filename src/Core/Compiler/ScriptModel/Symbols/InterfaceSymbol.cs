// InterfaceSymbol.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class InterfaceSymbol : TypeSymbol {

        private IndexerSymbol _indexer;

        public InterfaceSymbol(string name, NamespaceSymbol parent)
            : base(SymbolType.Interface, name, parent) {
        }

        public IndexerSymbol Indexer {
            get {
                return _indexer;
            }
        }

        public override void AddMember(MemberSymbol memberSymbol) {
            Debug.Assert(memberSymbol != null);

            if (memberSymbol.Type == SymbolType.Indexer) {
                Debug.Assert(_indexer == null);
                _indexer = (IndexerSymbol)memberSymbol;
            }
            else {
                base.AddMember(memberSymbol);
            }
        }
    }
}
