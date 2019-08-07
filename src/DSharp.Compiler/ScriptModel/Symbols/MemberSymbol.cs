// MemberSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal abstract class MemberSymbol : Symbol
    {
        private string generatedName;

        protected MemberSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol associatedType)
            : base(type, name, parent)
        {
            AssociatedType = associatedType;
        }

        public TypeSymbol AssociatedType { get; }

        public string GeneratedMemberName
        {
            get
            {
                if (InterfaceMember != null)
                {
                    return InterfaceMember.GeneratedMemberName;
                }

                // ScriptName
                if (this is MethodSymbol methodSymbol
                    && methodSymbol.TransformName == null
                    && IsTransformed)
                {
                    return base.GeneratedName;
                }

                if (IsCasePreserved)
                {
                    generatedName = Name;
                }
                else
                {
                    generatedName = Utility.CreateCamelCaseName(Name);
                }

                return generatedName;
            }
        }

        public override string GeneratedName
        {
            get
            {
                if (InterfaceMember != null)
                {
                    // If this member is implementing an interface,
                    // defer to the interface for our generated name.
                    return InterfaceMember.GeneratedName;
                }

                if (IsTransformed)
                {
                    return base.GeneratedName;
                }

                if (generatedName == null)
                {
                    if (IsCasePreserved)
                    {
                        generatedName = Name;
                    }
                    else
                    {
                        generatedName = Utility.CreateCamelCaseName(Name);
                    }
                }

                return generatedName;
            }
        }

        public MemberSymbol InterfaceMember { get; private set; }

        public bool IsCasePreserved { get; private set; }

        public bool IsPublic
        {
            get
            {
                if (((TypeSymbol) Parent).IsPublic == false)
                {
                    return false;
                }

                if ((Visibility & (MemberVisibility.Public | MemberVisibility.Protected)) != 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsInternal => Visibility.HasFlag(MemberVisibility.Internal);

        public MemberVisibility Visibility { get; private set; }

        public override bool MatchFilter(SymbolFilter filter)
        {
            if ((filter & SymbolFilter.Members) == 0)
            {
                return false;
            }

            SymbolFilter memberTypeFilter = filter & SymbolFilter.AnyMember;

            if (memberTypeFilter == SymbolFilter.InstanceMembers &&
                (Visibility & MemberVisibility.Static) != 0)
            {
                // Filter specifies member should be an instance member;
                // Visibility of member indicates it is a static member.
                return false;
            }

            if (memberTypeFilter == SymbolFilter.StaticMembers &&
                (Visibility & MemberVisibility.Static) == 0)
            {
                // Filter specifies member should be a static member;
                // Visibility of member indicates it is an instance member.
                return false;
            }

            SymbolFilter visibilityFilter = filter & SymbolFilter.AnyVisibility;

            if (visibilityFilter == SymbolFilter.Public &&
                (Visibility & (MemberVisibility.Public | MemberVisibility.Internal)) == 0)
            {
                // Filter specifies member should be public;
                // Visibility of member indicates it is not public or internal
                return false;
            }

            if (visibilityFilter == (SymbolFilter.Public | SymbolFilter.Protected) &&
                (Visibility & (MemberVisibility.Public | MemberVisibility.Internal | MemberVisibility.Protected)) == 0)
            {
                // Filter specifies member should be public or protected;
                // Visibility of member indicates it is not public, internal or protected
                return false;
            }

            return true;
        }

        public void SetInterfaceMember(MemberSymbol memberSymbol)
        {
            Debug.Assert(InterfaceMember == null);
            Debug.Assert(memberSymbol != null);

            InterfaceMember = memberSymbol;
        }

        public void SetNameCasing(bool preserveCase)
        {
            IsCasePreserved = preserveCase;
        }

        public void SetVisibility(MemberVisibility visibility)
        {
            Visibility = visibility;
        }
    }
}
