// TypeSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {
    
    internal abstract class TypeSymbol : Symbol, ISymbolTable {

        private ICollection<string> _imports;
        private IDictionary<string, string> _aliases;
        private ScriptReference _dependency;
        private bool _applicationType;
        private bool _isPublic;
        private bool _isArray;
        private ICollection<GenericParameterSymbol> _genericParameters;
        private ICollection<TypeSymbol> _genericArguments;
        private TypeSymbol _genericType;

        private ISymbolTable _parentSymbolTable;
        private Dictionary<string, MemberSymbol> _memberTable;
        private List<MemberSymbol> _members;

        private object _metadataReference;
        private bool _coreType;
        private bool _ignoreNamespace;
        private string _scriptNamespace;
        private bool _testType;

        protected TypeSymbol(SymbolType type, string name, NamespaceSymbol parent)
            : base(type, name, parent) {
            Debug.Assert(parent != null);

            _memberTable = new Dictionary<string, MemberSymbol>();
            _members = new List<MemberSymbol>();
            _applicationType = true;
        }

        public IDictionary<string, string> Aliases {
            get {
                return _aliases;
            }
        }

        public ScriptReference Dependency {
            get {
                return _dependency;
            }
        }

        public override string DocumentationID {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append("T:");
                sb.Append(Namespace);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public string FullGeneratedName {
            get {
                if (_ignoreNamespace == false) {
                    string namespaceName = GeneratedNamespace;
                    if (namespaceName.Length != 0) {
                        if (IsApplicationType) {
                            return namespaceName + "$" + GeneratedName;
                        }
                        else {
                            return namespaceName + "." + GeneratedName;
                        }
                    }
                }
                return GeneratedName;
            }
        }

        public string FullName {
            get {
                string namespaceName = Namespace;
                if (namespaceName.Length != 0) {
                    return namespaceName + "." + Name;
                }
                return Name;
            }
        }

        public string GeneratedNamespace {
            get {
                if (IsApplicationType) {
                    return Namespace.Replace(".", "$");
                }
                return _scriptNamespace != null ? _scriptNamespace : String.Empty;
            }
        }

        public ICollection<TypeSymbol> GenericArguments {
            get {
                return _genericArguments;
            }
        }

        public ICollection<GenericParameterSymbol> GenericParameters {
            get {
                return _genericParameters;
            }
        }

        public TypeSymbol GenericType {
            get {
                return _genericType;
            }
        }

        public bool IgnoreNamespace {
            get {
                return _ignoreNamespace;
            }
        }

        public ICollection<string> Imports {
            get {
                return _imports;
            }
        }

        public bool IsArray {
            get {
                return _isArray;
            }
        }

        public bool IsApplicationType {
            get {
                return _applicationType;
            }
        }

        public bool IsCoreType {
            get {
                return _coreType;
            }
        }

        public bool IsGeneric {
            get {
                return (_genericParameters != null) &&
                       (_genericParameters.Count != 0);
            }
        }

        public bool IsPublic {
            get {
                return _isPublic;
            }
        }

        public bool IsTestType {
            get {
                return _testType;
            }
        }

        public ICollection<MemberSymbol> Members {
            get {
                return _members;
            }
        }

        public object MetadataReference {
            get {
                Debug.Assert(_metadataReference != null);
                return _metadataReference;
            }
        }

        public string Namespace {
            get {
                Debug.Assert(Parent is NamespaceSymbol);
                return ((NamespaceSymbol)Parent).Name;
            }
        }

        public string ScriptNamespace {
            get {
                return _scriptNamespace;
            }
            set {
                _scriptNamespace = value;
            }
        }

        public virtual void AddMember(MemberSymbol memberSymbol) {
            Debug.Assert(memberSymbol != null);
            Debug.Assert(String.IsNullOrEmpty(memberSymbol.Name) == false);
            Debug.Assert(_memberTable.ContainsKey(memberSymbol.Name) == false);

            _members.Add(memberSymbol);
            _memberTable[memberSymbol.Name] = memberSymbol;
        }

        public void AddGenericArguments(TypeSymbol genericType, ICollection<TypeSymbol> genericArguments) {
            Debug.Assert(genericType != null);
            Debug.Assert(_genericType == null);

            Debug.Assert(_genericParameters != null);

            Debug.Assert(_genericArguments == null);
            Debug.Assert(genericArguments != null);
            Debug.Assert(genericArguments.Count == _genericParameters.Count);

            _genericType = genericType;
            _genericArguments = genericArguments;
        }

        public void AddGenericParameters(ICollection<GenericParameterSymbol> genericParameters) {
            Debug.Assert(_genericParameters == null);
            Debug.Assert(genericParameters != null);
            Debug.Assert(genericParameters.Count != 0);

            _genericParameters = genericParameters;
        }

        public virtual TypeSymbol GetBaseType() {
            return null;
        }

        public virtual MemberSymbol GetMember(string name) {
            if (_memberTable.ContainsKey(name)) {
                return _memberTable[name];
            }
            return null;
        }

        public void SetMetadataToken(object metadataReference, bool coreType) {
            Debug.Assert(metadataReference != null);
            Debug.Assert(_metadataReference == null);

            _metadataReference = metadataReference;
            _coreType = coreType;
        }

        public void SetAliases(IDictionary<string, string> aliases) {
            Debug.Assert(_aliases == null);
            Debug.Assert(aliases != null);
            _aliases = aliases;
        }

        public void SetIgnoreNamespace() {
            _ignoreNamespace = true;
        }

        public void SetImported(ScriptReference dependency) {
            Debug.Assert(_applicationType == true);

            _applicationType = false;
            _dependency = dependency;
        }

        public void SetArray() {
            _isArray = true;
        }

        public void SetImports(ICollection<string> imports) {
            Debug.Assert(_imports == null);
            Debug.Assert(imports != null);
            _imports = imports;
        }

        public void SetPublic() {
            _isPublic = true;
        }

        public override bool MatchFilter(SymbolFilter filter) {
            if ((filter & SymbolFilter.Types) == 0) {
                return false;
            }
            return true;
        }

        public void SetParentSymbolTable(ISymbolTable symbolTable) {
            Debug.Assert(_parentSymbolTable == null);
            Debug.Assert(symbolTable != null);

            _parentSymbolTable = symbolTable;
        }

        public void SetTestType() {
            _testType = true;
        }

        #region ISymbolTable Members
        ICollection ISymbolTable.Symbols {
            get {
                return _members;
            }
        }

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(context != null);

            Symbol symbol = null;

            if ((filter & SymbolFilter.Members) != 0) {
                SymbolFilter baseFilter = filter | SymbolFilter.ExcludeParent;

                symbol = GetMember(name);

                if (symbol == null) {
                    TypeSymbol baseType = GetBaseType();
                    TypeSymbol objectType = (TypeSymbol)((ISymbolTable)this.SymbolSet.SystemNamespace).FindSymbol("Object", null, SymbolFilter.Types);
                    if ((baseType == null) && (this != objectType)) {
                        baseType = objectType;
                    }

                    if (baseType != null) {
                        symbol = ((ISymbolTable)baseType).FindSymbol(name, context, baseFilter);
                    }
                }

                if ((symbol != null) && (symbol.MatchFilter(filter) == false)) {
                    symbol = null;
                }
            }

            if ((symbol == null) && (_parentSymbolTable != null) &&
                ((filter & SymbolFilter.ExcludeParent) == 0)) {
                symbol = _parentSymbolTable.FindSymbol(name, context, filter);
            }

            return symbol;
        }
        #endregion
    }
}
