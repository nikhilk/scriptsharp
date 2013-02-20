// ClassSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {
    
    internal class ClassSymbol : TypeSymbol {

        private ClassSymbol _baseClass;
        private ICollection<InterfaceSymbol> _interfaces;
        private int _inheritanceDepth;
        private int _minimizationDepth;
        private int _transformationCookie;

        private ConstructorSymbol _constructor;
        private ConstructorSymbol _staticConstructor;
        private IndexerSymbol _indexer;

        private string _extendee;
        private bool _testClass;
        private bool _moduleClass;
        private bool _staticClass;

        private ClassSymbol _primaryPartialClass;

        public ClassSymbol(string name, NamespaceSymbol parent)
            : this(SymbolType.Class, name, parent) {
        }

        protected ClassSymbol(SymbolType type, string name, NamespaceSymbol parent)
            : base(type, name, parent) {
            _inheritanceDepth = -1;
            _minimizationDepth = -1;
            _transformationCookie = -1;
        }

        public ClassSymbol BaseClass {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.BaseClass;
                }
                return _baseClass;
            }
        }

        public ConstructorSymbol Constructor {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.Constructor;
                }
                return _constructor;
            }
        }

        public string Extendee {
            get {
                return _extendee;
            }
        }

        public override string GeneratedName {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.GeneratedName;
                }
                return base.GeneratedName;
            }
        }

        public IndexerSymbol Indexer {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.Indexer;
                }
                return _indexer;
            }
        }

        public int InheritanceDepth {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.InheritanceDepth;
                }
                if (_inheritanceDepth == -1) {
                    if (_baseClass != null) {
                        _inheritanceDepth = _baseClass.InheritanceDepth + 1;
                    }
                    else {
                        _inheritanceDepth = 0;
                    }
                }
                return _inheritanceDepth;
            }
        }

        public ICollection<InterfaceSymbol> Interfaces {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.Interfaces;
                }
                return _interfaces;
            }
        }

        public bool IsExtenderClass {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.IsExtenderClass;
                }

                return (String.IsNullOrEmpty(_extendee) == false);
            }
        }

        public bool IsModuleClass {
            get {
                return _moduleClass;
            }
        }

        public bool IsStaticClass {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.IsStaticClass;
                }
                return _staticClass;
            }
        }

        public bool IsTestClass {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.IsTestClass;
                }
                return _testClass;
            }
        }

        public int MinimizationDepth {
            get {
                // This is like InheritanceDepth but not the same. It is specific for
                // use by the minimization process.
                //
                // - For imported types this matches actual inheritance depth.
                // - When the base class is an imported type, then we also go ahead
                //   and use matches inheritance depth as well.
                // - Special case: When this type and the base type are both application
                //   types, they both have the same minimization depth. (This is done to
                //   keep inheritance depth to 0 as much as possible, since this
                //   reduces size of minimized identifiers).

                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.MinimizationDepth;
                }
                if (_minimizationDepth == -1) {
                    if (_baseClass != null) {
                        if (IsApplicationType && _baseClass.IsApplicationType) {
                            _minimizationDepth = _baseClass.MinimizationDepth;
                        }
                        else {
                            _minimizationDepth = _baseClass.MinimizationDepth + 1;
                        }
                    }
                    else {
                        _minimizationDepth = 0;
                    }
                }
                return _minimizationDepth;
            }
        }

        public ClassSymbol PrimaryPartialClass {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass;
                }
                return this;
            }
        }

        public ConstructorSymbol StaticConstructor {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.StaticConstructor;
                }
                return _staticConstructor;
            }
        }

        public int TransformationCookie {
            get {
                if (_primaryPartialClass != null) {
                    return _primaryPartialClass.TransformationCookie;
                }
                if ((_transformationCookie == -1) &&
                    (_baseClass != null)) {
                    // If this classes members did not get transformed,
                    // return the base classes transformation cookie.
                    //
                    // The transformation cookie is accessed when transforming
                    // members of a derived class, so by then this classes
                    // members would have been transformed if they needed
                    // to be. The fact that the transformation cookie is unset
                    // implies no members on this class needed to be transformed.

                    return _baseClass.TransformationCookie;
                }
                return _transformationCookie;
            }
            set {
                if (_primaryPartialClass != null) {
                    _primaryPartialClass.TransformationCookie = value;
                }
                _transformationCookie = value;
            }
        }

        public override void AddMember(MemberSymbol memberSymbol) {
            if (_primaryPartialClass != null) {
                _primaryPartialClass.AddMember(memberSymbol);
                return;
            }

            Debug.Assert(memberSymbol != null);

            if (memberSymbol.Type == SymbolType.Constructor) {
                if ((memberSymbol.Visibility & MemberVisibility.Static) == 0) {
                    Debug.Assert(_constructor == null);
                    _constructor = (ConstructorSymbol)memberSymbol;
                }
                else {
                    Debug.Assert(_staticConstructor == null);
                    _staticConstructor = (ConstructorSymbol)memberSymbol;
                }
            }
            else if (memberSymbol.Type == SymbolType.Indexer) {
                Debug.Assert((IsApplicationType == false) || (_indexer == null));
                _indexer = (IndexerSymbol)memberSymbol;
            }
            else {
                base.AddMember(memberSymbol);
            }
        }

        public override TypeSymbol GetBaseType() {
            if (_primaryPartialClass != null) {
                return _primaryPartialClass.GetBaseType();
            }
            return _baseClass;
        }

        public IndexerSymbol GetIndexer() {
            if (_primaryPartialClass != null) {
                return _primaryPartialClass.GetIndexer();
            }

            ClassSymbol classSymbol = this;
            IndexerSymbol indexer = classSymbol.Indexer;

            while (indexer == null) {
                classSymbol = (ClassSymbol)classSymbol.GetBaseType();
                if (classSymbol == null) {
                    break;
                }

                indexer = classSymbol.Indexer;
            }

            return indexer;
        }

        public override MemberSymbol GetMember(string name) {
            if (_primaryPartialClass != null) {
                return _primaryPartialClass.GetMember(name);
            }
            return base.GetMember(name);
        }

        public void SetExtenderClass(string extendee) {
            Debug.Assert(String.IsNullOrEmpty(extendee) == false);

            if (_primaryPartialClass != null) {
                _primaryPartialClass.SetExtenderClass(extendee);
                return;
            }

            _extendee = extendee;
        }

        public void SetInheritance(ClassSymbol baseClass, ICollection<InterfaceSymbol> interfaces) {
            // Inheritance should only be assigned to a primary partial class.
            Debug.Assert(_primaryPartialClass == null);

            _baseClass = baseClass;
            _interfaces = interfaces;
        }

        public void SetModuleClass() {
            _moduleClass = true;
        }

        public void SetPrimaryPartialClass(ClassSymbol primaryPartialClass) {
            Debug.Assert(_primaryPartialClass == null);
            Debug.Assert(primaryPartialClass != null);

            _primaryPartialClass = primaryPartialClass;
        }

        public void SetStaticClass() {
            if (_primaryPartialClass != null) {
                _primaryPartialClass.SetStaticClass();
                return;
            }

            _staticClass = true;
        }

        public void SetTestClass() {
            if (_primaryPartialClass != null) {
                _primaryPartialClass.SetTestClass();
                return;
            }

            Debug.Assert(_testClass == false);
            _testClass = true;
        }
    }
}
