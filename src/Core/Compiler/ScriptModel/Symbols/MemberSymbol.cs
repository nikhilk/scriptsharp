// MemberSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal abstract class MemberSymbol : Symbol {

        private MemberVisibility _visibility;
        private TypeSymbol _associatedType;
        private bool _preserveCase;
        private MemberSymbol _interfaceMember;

        private string _generatedName;

        protected MemberSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol associatedType)
            : base(type, name, parent) {
            _associatedType = associatedType;
        }

        public TypeSymbol AssociatedType {
            get {
                return _associatedType;
            }
        }

        public override string GeneratedName {
            get {
                if (_interfaceMember != null) {
                    // If this member is implementing an interface,
                    // defer to the interface for our generated name.
                    return _interfaceMember.GeneratedName;
                }
                if (IsTransformed) {
                    return base.GeneratedName;
                }

                if (_generatedName == null) {
                    if (_preserveCase) {
                        _generatedName = Name;
                    }
                    else {
                        _generatedName = Utility.CreateCamelCaseName(Name);
                    }
                }

                return _generatedName;
            }
        }

        public MemberSymbol InterfaceMember {
            get {
                return _interfaceMember;
            }
        }

        public bool IsCasePreserved {
            get {
                return _preserveCase;
            }
        }

        public bool IsPublic {
            get {
                if (((TypeSymbol)Parent).IsPublic == false) {
                    return false;
                }                
                if ((_visibility & (MemberVisibility.Public | MemberVisibility.Protected)) != 0) {
                    return true;
                }
                return false;
            }
        }

        public MemberVisibility Visibility {
            get {
                return _visibility;
            }
        }

        public override bool MatchFilter(SymbolFilter filter) {
            if ((filter & SymbolFilter.Members) == 0) {
                return false;
            }

            SymbolFilter memberTypeFilter = (filter & SymbolFilter.AnyMember);
            if ((memberTypeFilter == SymbolFilter.InstanceMembers) &&
                ((_visibility & MemberVisibility.Static) != 0)) {
                // Filter specifies member should be an instance member;
                // Visibility of member indicates it is a static member.
                return false;
            }
            if ((memberTypeFilter == SymbolFilter.StaticMembers) &&
                ((_visibility & MemberVisibility.Static) == 0)) {
                // Filter specifies member should be a static member;
                // Visibility of member indicates it is an instance member.
                return false;
            }
            SymbolFilter visibilityFilter = (filter & SymbolFilter.AnyVisibility);
            if ((visibilityFilter == SymbolFilter.Public) &&
                ((_visibility & (MemberVisibility.Public | MemberVisibility.Internal)) == 0)) {
                // Filter specifies member should be public;
                // Visibility of member indicates it is not public or internal
                return false;
            }
            if ((visibilityFilter == (SymbolFilter.Public | SymbolFilter.Protected)) &&
                ((_visibility & (MemberVisibility.Public | MemberVisibility.Internal | MemberVisibility.Protected)) == 0)) {
                // Filter specifies member should be public or protected;
                // Visibility of member indicates it is not public, internal or protected
                return false;
            }

            return true;
        }

        public void SetInterfaceMember(MemberSymbol memberSymbol) {
            Debug.Assert(_interfaceMember == null);
            Debug.Assert(memberSymbol != null);

            _interfaceMember = memberSymbol;
        }

        public void SetNameCasing(bool preserveCase) {
            _preserveCase = preserveCase;
        }

        public void SetVisibility(MemberVisibility visibility) {
            _visibility = visibility;
        }
    }
}
