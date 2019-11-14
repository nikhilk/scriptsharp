// TypeSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DSharp.Compiler.Extensions;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal abstract class TypeSymbol : Symbol, ISymbolTable
    {
        private readonly List<MemberSymbol> members;
        private readonly Dictionary<string, MemberSymbol> memberTable;

        private readonly Dictionary<string, TypeSymbol> typeMap;
        private readonly List<TypeSymbol> types;

        private object metadataReference;

        private ISymbolTable parentSymbolTable;

        protected TypeSymbol(SymbolType type, string name, NamespaceSymbol parent)
            : base(type, name, parent)
        {
            Debug.Assert(parent != null);

            memberTable = new Dictionary<string, MemberSymbol>();
            members = new List<MemberSymbol>();

            types = new List<TypeSymbol>();
            typeMap = new Dictionary<string, TypeSymbol>();

            IsApplicationType = true;
        }

        public IDictionary<string, string> Aliases { get; private set; }

        public ScriptReference Dependency { get; private set; }

        public ScriptReference Source { get; private set; }

        public bool HasNestedTypes => types.Any();

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

        public IList<TypeSymbol> GenericArguments { get; private set; }

        public IList<GenericParameterSymbol> GenericParameters { get; private set; }

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

                return ((NamespaceSymbol)Parent).Name;
            }
        }

        public string ScriptNamespace { get; set; }

        public ICollection Symbols => members;

        public virtual void AddMember(MemberSymbol memberSymbol)
        {
            Debug.Assert(memberSymbol != null);
            Debug.Assert(string.IsNullOrEmpty(memberSymbol.Name) == false);
            Debug.Assert(memberTable.ContainsKey(memberSymbol.Name) == false);

            members.Add(memberSymbol);
            memberTable[memberSymbol.Name] = memberSymbol;
        }

        public void AddGenericArguments(TypeSymbol genericType, IList<TypeSymbol> genericArguments)
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

        public void AddGenericParameters(IList<GenericParameterSymbol> genericParameters)
        {
            Debug.Assert(GenericParameters == null);
            Debug.Assert(genericParameters != null);
            Debug.Assert(genericParameters.Count != 0);

            GenericParameters = genericParameters;
            AssignGenericArgumentOwner(genericParameters);
        }

        private void AssignGenericArgumentOwner(IEnumerable<GenericParameterSymbol> genericArguments)
        {
            foreach (var argument in genericArguments)
            {
                argument.Owner = this;
            }
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

            if(GenericType?.memberTable.ContainsKey(name) ?? false)
            {
                return GenericType.memberTable[name];
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

        public void SetSource(ScriptReference source)
        {
            Source = source;
        }

        public void IncrementReferenceCount()
        {
            if (isNativeArray)
            {
                IncrementReferenceCountForNativeArray();
                return;
            }

            if (IsGeneric)
            {
                IncrementReferenceCountForGenericType();
            }

            if (Source == null)
            {
                return;
            }

            Source.IncrementTypeReferenceCount();
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

        public Symbol FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            Debug.Assert(string.IsNullOrEmpty(name) == false);

            Symbol symbol = null;

            if ((filter & SymbolFilter.Types) != 0)
            {
                symbol = GetNestedType(name, context, filter);
            }

            if (symbol == null && (filter & SymbolFilter.Members) != 0)
            {
                SymbolFilter baseFilter = filter | SymbolFilter.ExcludeParent;

                symbol = GetMember(name)
                    ?? FindSymbolFromBase(name, context, symbol, baseFilter);

                if (symbol != null && symbol.MatchFilter(filter) == false)
                {
                    symbol = null;
                }
            }

            if (symbol == null && !filter.HasFlag(SymbolFilter.ExcludeParent))
            {
                if (parentSymbolTable != null)
                {
                    symbol = parentSymbolTable.FindSymbol(name, context, filter);
                }
                else if (context?.Parent is ISymbolTable symbolTable)
                {
                    symbolTable.FindSymbol(name, context, filter);
                }
            }

            return symbol;
        }

        private Symbol FindSymbolFromBase(string name, Symbol context, Symbol symbol, SymbolFilter baseFilter)
        {
            TypeSymbol baseType = GetBaseType();
            TypeSymbol objectType =
                (TypeSymbol)((ISymbolTable)SymbolSet.SystemNamespace).FindSymbol("Object", null,
                    SymbolFilter.Types);

            if (baseType == null && this != objectType)
            {
                baseType = objectType;
            }

            if (baseType != null)
            {
                symbol = ((ISymbolTable)baseType).FindSymbol(name, context, baseFilter);
            }

            return symbol;
        }

        private Symbol GetNestedType(string name, Symbol context, SymbolFilter filter)
        {
            string nestedName = name.Substring(name.LastIndexOf('$') + 1);

            if (typeMap.ContainsKey(nestedName))
            {
                return typeMap[nestedName];
            }
            else
            {
                foreach (var nestedType in types)
                {
                    if (((ISymbolTable)nestedType).FindSymbol(name, context, filter | SymbolFilter.ExcludeParent) is Symbol symbol)
                    {
                        return symbol;
                    }
                }
            }

            return null;
        }

        public void AddType(TypeSymbol typeSymbol)
        {
            Debug.Assert(typeSymbol != null);
            Debug.Assert(string.IsNullOrEmpty(typeSymbol.Name) == false);

            string nestedName = typeSymbol.Name.Substring(typeSymbol.Name.LastIndexOf('$') + 1);

            types.Add(typeSymbol);
            typeMap[nestedName] = typeSymbol;
        }

        private void IncrementReferenceCountForNativeArray()
        {
            if (this is ClassSymbol classType)
            {
                classType.Indexer?.AssociatedType.IncrementReferenceCount();
            }
            else if (this is InterfaceSymbol interfaceType)
            {
                interfaceType.Indexer?.AssociatedType.IncrementReferenceCount();
            }
        }

        private void IncrementReferenceCountForGenericType()
        {
            if (GenericArguments == null)
            {
                return;
            }

            foreach (TypeSymbol genericArgument in GenericArguments)
            {
                genericArgument.IncrementReferenceCount();
            }
        }
    }
}
