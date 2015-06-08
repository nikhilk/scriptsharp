// CodeBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.CodeModel;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Compiler {

    internal sealed class CodeBuilder {

        private CompilerOptions _options;
        private IErrorHandler _errorHandler;

        private List<SymbolImplementation> _implementations;

        public CodeBuilder(CompilerOptions options, IErrorHandler errorHandler) {
            _options = options;
            _errorHandler = errorHandler;
        }

        public ICollection<SymbolImplementation> BuildCode(SymbolSet symbols) {
            _implementations = new List<SymbolImplementation>();

            foreach (NamespaceSymbol namespaceSymbol in symbols.Namespaces) {
                if (namespaceSymbol.HasApplicationTypes == false) {
                    continue;
                }

                foreach (TypeSymbol type in namespaceSymbol.Types) {
                    if (type.IsApplicationType == false) {
                        continue;
                    }

                    if (type.IsTestType && !_options.IncludeTests) {
                        // Ignore test types, if tests are not to be compiled
                        continue;
                    }

                    switch (type.Type) {
                        case SymbolType.Class:
                            BuildCode((ClassSymbol)type);
                            break;
                        case SymbolType.Record:
                            if (((RecordSymbol)type).Constructor != null) {
                                BuildCode(((RecordSymbol)type).Constructor);
                            }
                            break;
                    }
                }
            }

            return _implementations;
        }

        private void BuildCode(ClassSymbol classSymbol) {
            if (classSymbol.Constructor != null) {
                BuildCode(classSymbol.Constructor);
            }

            if (classSymbol.StaticConstructor != null) {
                BuildCode(classSymbol.StaticConstructor);
            }

            if (classSymbol.Indexer != null) {
                BuildCode(classSymbol.Indexer);
            }

            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                switch (memberSymbol.Type) {
                    case SymbolType.Event:
                        BuildCode((EventSymbol)memberSymbol);
                        break;
                    case SymbolType.Field:
                        BuildCode((FieldSymbol)memberSymbol);
                        break;
                    case SymbolType.Method:
                        BuildCode((MethodSymbol)memberSymbol);
                        break;
                    case SymbolType.Property:
                        BuildCode((PropertySymbol)memberSymbol);
                        break;
                }
            }
        }

        private void BuildCode(EventSymbol eventSymbol) {
            if (eventSymbol.IsAbstract || eventSymbol.DefaultImplementation) {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(_options, _errorHandler);

            eventSymbol.AddImplementation(implBuilder.BuildEventAdd(eventSymbol), /* adder */ true);
            eventSymbol.AddImplementation(implBuilder.BuildEventRemove(eventSymbol), /* adder */ false);

            _implementations.Add(eventSymbol.AdderImplementation);
            _implementations.Add(eventSymbol.RemoverImplementation);

            if (eventSymbol.AnonymousMethods != null) {
                foreach (AnonymousMethodSymbol anonymousMethod in eventSymbol.AnonymousMethods) {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    _implementations.Add(anonymousMethod.Implementation);
                }
            }
        }

        private void BuildCode(FieldSymbol fieldSymbol) {
            ImplementationBuilder implBuilder = new ImplementationBuilder(_options, _errorHandler);
            SymbolImplementation implementation = implBuilder.BuildField(fieldSymbol);

            if (implementation != null) {
                fieldSymbol.AddImplementation(implementation);
                _implementations.Add(fieldSymbol.Implementation);
            }
        }

        private void BuildCode(IndexerSymbol indexerSymbol) {
            if (indexerSymbol.IsAbstract) {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(_options, _errorHandler);

            indexerSymbol.AddImplementation(implBuilder.BuildIndexerGetter(indexerSymbol), /* getter */ true);
            _implementations.Add(indexerSymbol.GetterImplementation);

            if (indexerSymbol.IsReadOnly == false) {
                indexerSymbol.AddImplementation(implBuilder.BuildPropertySetter(indexerSymbol), /* getter */ false);
                _implementations.Add(indexerSymbol.SetterImplementation);
            }

            if (indexerSymbol.AnonymousMethods != null) {
                foreach (AnonymousMethodSymbol anonymousMethod in indexerSymbol.AnonymousMethods) {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    _implementations.Add(anonymousMethod.Implementation);
                }
            }
        }

        private void BuildCode(MethodSymbol methodSymbol) {
            if (methodSymbol.IsAbstract) {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(_options, _errorHandler);
            methodSymbol.AddImplementation(implBuilder.BuildMethod(methodSymbol));

            _implementations.Add(methodSymbol.Implementation);

            if (methodSymbol.AnonymousMethods != null) {
                foreach (AnonymousMethodSymbol anonymousMethod in methodSymbol.AnonymousMethods) {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    _implementations.Add(anonymousMethod.Implementation);
                }
            }
        }

        private void BuildCode(PropertySymbol propertySymbol) {
            if (propertySymbol.IsAbstract) {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(_options, _errorHandler);
            
            propertySymbol.AddImplementation(implBuilder.BuildPropertyGetter(propertySymbol), /* getter */ true);
            _implementations.Add(propertySymbol.GetterImplementation);

            if (propertySymbol.IsReadOnly == false) {
                propertySymbol.AddImplementation(implBuilder.BuildPropertySetter(propertySymbol), /* getter */ false);
                _implementations.Add(propertySymbol.SetterImplementation);
            }

            if (propertySymbol.AnonymousMethods != null) {
                foreach (AnonymousMethodSymbol anonymousMethod in propertySymbol.AnonymousMethods) {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    _implementations.Add(anonymousMethod.Implementation);
                }
            }
        }
    }
}
