// AnonymousMethodSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal sealed class AnonymousMethodSymbol : MethodSymbol {

        private CodeMemberSymbol _containingMember;
        private ISymbolTable _stackContext;

        public AnonymousMethodSymbol(CodeMemberSymbol containingMember, ISymbolTable stackContext, TypeSymbol returnType, bool isStatic)
            : base(SymbolType.AnonymousMethod, /* name */ String.Empty, (TypeSymbol)containingMember.Parent, returnType) {
            SetVisibility(isStatic ? MemberVisibility.Public | MemberVisibility.Static : MemberVisibility.Public);
            _containingMember = containingMember;
            _stackContext = stackContext;

            _containingMember.AddAnonymousMethod(this);
        }

        public CodeMemberSymbol ContainingMember {
            get {
                return _containingMember;
            }
        }

        public int Depth {
            get {
                int depth = 1;
                if (_containingMember is AnonymousMethodSymbol) {
                    depth += ((AnonymousMethodSymbol)_containingMember).Depth;
                }
                return depth;
            }
        }

        public ISymbolTable StackContext {
            get {
                return _stackContext;
            }
        }

        public override void AddAnonymousMethod(AnonymousMethodSymbol anonymousMethod) {
            _containingMember.AddAnonymousMethod(anonymousMethod);
        }
    }
}
