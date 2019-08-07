// TypeSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DSharp.Compiler.Extensions;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal abstract class TypeSymbol : Symbol, ISymbolTable
    {
        private readonly List<MemberSymbol> members;
        private readonly Dictionary<string, MemberSymbol> memberTable;

        private object metadataReference;

        private ISymbolTable parentSymbolTable;

        protected TypeSymbol(SymbolType type, string name, NamespaceSymbol parent)
            : base(type, name, parent)
        {
            Debug.Assert(parent != null);

            memberTable = new Dictionary<string, MemberSymbol>();
            members = new List<MemberSymbol>();
            IsApplicationType = true;
        }

        public IDictionary<string, string> Aliases { get; private set; }

        public ScriptReference Dependency { get; private set; }

        public override string DocumentationId
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("T:");
                sb.Append(Namespace);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public string FullGeneratedName
        {
            get
            {
                if (IsApplicationType == false && IgnoreNamespace == false)
                {
                    string namespaceName = GeneratedNamespace;

                    if (namespaceName.Length != 0)
                    {
                        return namespaceName + "." + GeneratedName;
                    }
                }

                return GeneratedName;
            }
        }

        public string FullName
        {
            get
            {
                string namespaceName = Namespace;

                if (namespaceName.Length != 0)
                {
                    return namespaceName + "." + Name;
                }

                return Name;
            }
        }

        public string GeneratedNamespace
        {
            get
            {
                if (IsApplicationType)
                {
                    return Namespace.Replace(".", "$");
                }

                return ScriptNamespace != null ? ScriptNamespace : string.Empty;
            }
        }

        public override string GeneratedName => base.GeneratedName.Replace("`", "_$");

        public ICollection<TypeSymbol> GenericArguments { get; private set; }

        public ICollection<GenericParameterSymbol> GenericParameters { get; private set; }

        public TypeSymbol GenericType { get; private set; }

        public bool IgnoreNamespace { get; private set; }

        public ICollection<string> Imports { get; private set; }

        private bool isNativeArray = false;

        public bool IsNativeArray
        {
            get
            {
                if (this.isNativeArray)
                {
                    return true;
                }

                if (this.IsArgumentsType())
                {
                    SetNativeArray(); // add to cache

                    return true;
                }

                return false;
            }
        }

        public bool IsApplicationType { get; private set; }

        public bool IsCoreType { get; private set; }

        public bool IsGeneric => GenericParameters != null &&
                                 GenericParameters.Count != 0;

        public bool IsPublic { get; set; }

        public bool IsInternal { get; set; }

        public ICollection<MemberSymbol> Members => members;

        public object MetadataReference
        {
            get
            {
                Debug.Assert(metadataReference != null);

                return metadataReference;
            }
        }

        public string Namespace
        {
            get
            {
                Debug.Assert(Parent is NamespaceSymbol);

                return ((NamespaceSymbol) Parent).Name;
            }
        }

        public string ScriptNamespace { get; set; }

        public virtual void AddMember(MemberSymbol memberSymbol)
        {
            Debug.Assert(memberSymbol != null);
            Debug.Assert(string.IsNullOrEmpty(memberSymbol.Name) == false);
            Debug.Assert(memberTable.ContainsKey(memberSymbol.Name) == false);

            members.Add(memberSymbol);
            memberTable[memberSymbol.Name] = memberSymbol;
        }

        public void AddGenericArguments(TypeSymbol genericType, ICollection<TypeSymbol> genericArguments)
        {
            Debug.Assert(genericType != null);
            Debug.Assert(GenericType == null);

            Debug.Assert(GenericParameters != null);

            Debug.Assert(GenericArguments == null);
            Debug.Assert(genericArguments != null);
            Debug.Assert(genericArguments.Count == GenericParameters.Count);

            GenericType = genericType;
            GenericArguments = genericArguments;
        }

        public void AddGenericParameters(ICollection<GenericParameterSymbol> genericParameters)
        {
            Debug.Assert(GenericParameters == null);
            Debug.Assert(genericParameters != null);
            Debug.Assert(genericParameters.Count != 0);

            GenericParameters = genericParameters;
        }

        public virtual TypeSymbol GetBaseType()
        {
            return null;
        }

        public virtual MemberSymbol GetMember(string name)
        {
            if (memberTable.ContainsKey(name))
            {
                return memberTable[name];
            }

            return null;
        }

        public void SetMetadataToken(object metadataReference, bool coreType)
        {
            Debug.Assert(metadataReference != null);
            Debug.Assert(this.metadataReference == null);

            this.metadataReference = metadataReference;
            IsCoreType = coreType;
        }

        public void SetAliases(IDictionary<string, string> aliases)
        {
            Debug.Assert(Aliases == null);
            Debug.Assert(aliases != null);
            Aliases = aliases;
        }

        public void SetIgnoreNamespace()
        {
            IgnoreNamespace = true;
        }

        public void SetImported(ScriptReference dependency)
        {
            Debug.Assert(IsApplicationType);

            IsApplicationType = false;
            Dependency = dependency;
        }

        public void SetNativeArray()
        {
            this.isNativeArray = true;
        }

        public void SetImports(ICollection<string> imports)
        {
            Debug.Assert(Imports == null);
            Debug.Assert(imports != null);
            Imports = imports;
        }

        public override bool MatchFilter(SymbolFilter filter)
        {
            if ((filter & SymbolFilter.Types) == 0)
            {
                return false;
            }

            return true;
        }

        public void SetParentSymbolTable(ISymbolTable symbolTable)
        {
            Debug.Assert(parentSymbolTable == null);
            Debug.Assert(symbolTable != null);

            parentSymbolTable = symbolTable;
        }

        #region ISymbolTable Members

        ICollection ISymbolTable.Symbols => members;

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            Debug.Assert(string.IsNullOrEmpty(name) == false);
            Debug.Assert(context != null);

            Symbol symbol = null;

            if ((filter & SymbolFilter.Members) != 0)
            {
                SymbolFilter baseFilter = filter | SymbolFilter.ExcludeParent;

                symbol = GetMember(name);

                if (symbol == null)
                {
                    TypeSymbol baseType = GetBaseType();
                    TypeSymbol objectType =
                        (TypeSymbol) ((ISymbolTable) SymbolSet.SystemNamespace).FindSymbol("Object", null,
                            SymbolFilter.Types);

                    if (baseType == null && this != objectType)
                    {
                        baseType = objectType;
                    }

                    if (baseType != null)
                    {
                        symbol = ((ISymbolTable) baseType).FindSymbol(name, context, baseFilter);
                    }
                }

                if (symbol != null && symbol.MatchFilter(filter) == false)
                {
                    symbol = null;
                }
            }

            if (symbol == null && parentSymbolTable != null &&
                (filter & SymbolFilter.ExcludeParent) == 0)
            {
                symbol = parentSymbolTable.FindSymbol(name, context, filter);
            }

            return symbol;
        }

        #endregion
    }
}
