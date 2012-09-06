// SymbolSetDumper.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp.ScriptModel {

#if DEBUG

    internal sealed class SymbolSetDumper {

        private IndentedTextWriter _writer;

        public SymbolSetDumper(TextWriter writer) {
            Debug.Assert(writer != null);
            _writer = new IndentedTextWriter(writer, "    ");
        }

        private void DumpClass(ClassSymbol classSymbol) {
            _writer.Write("Global Methods: ");
            _writer.WriteLine(classSymbol.HasGlobalMethods);

            if (classSymbol.BaseClass != null) {
                _writer.Write("BaseClass: ");
                _writer.WriteLine(classSymbol.BaseClass.FullName);
            }
            if (classSymbol.Interfaces != null) {
                _writer.WriteLine("Interfaces:");
                _writer.Indent++;
                foreach (InterfaceSymbol interfaceSymbol in classSymbol.Interfaces) {
                    _writer.WriteLine(interfaceSymbol.FullName);
                }
                _writer.Indent--;
            }
            if (classSymbol.Constructor != null) {
                _writer.WriteLine("Constructor:");
                _writer.Indent++;
                DumpSymbol(classSymbol.Constructor);
                _writer.Indent--;
            }
            if (classSymbol.StaticConstructor != null) {
                _writer.WriteLine("StaticConstructor:");
                _writer.Indent++;
                DumpSymbol(classSymbol.StaticConstructor);
                _writer.Indent--;
            }
            if (classSymbol.Indexer != null) {
                _writer.WriteLine("Indexer:");
                _writer.Indent++;
                DumpSymbol(classSymbol.Indexer);
                _writer.Indent--;
            }
        }

        private void DumpConstructor(ConstructorSymbol ctorSymbol) {
            if (ctorSymbol.Parameters != null) {
                _writer.Write("Parameters:");
                _writer.Indent++;
                foreach (ParameterSymbol paramSymbol in ctorSymbol.Parameters) {
                    DumpSymbol(paramSymbol);
                }
                _writer.Indent--;
            }
        }

        private void DumpDelegate(DelegateSymbol delegateSymbol) {
        }

        private void DumpEnumeration(EnumerationSymbol enumSymbol) {
            _writer.Write("Flags: ");
            _writer.WriteLine(enumSymbol.Flags);
        }

        private void DumpEnumerationField(EnumerationFieldSymbol enumFieldSymbol) {
        }

        private void DumpEvent(EventSymbol eventSymbol) {
        }

        private void DumpField(FieldSymbol fieldSymbol) {
        }

        private void DumpIndexer(IndexerSymbol indexerSymbol) {
            _writer.Write("ReadOnly: ");
            _writer.WriteLine(indexerSymbol.IsReadOnly);
            _writer.Write("Abstract: ");
            _writer.WriteLine(indexerSymbol.IsAbstract);
        }

        private void DumpInterface(InterfaceSymbol interfaceSymbol) {
        }

        private void DumpMember(MemberSymbol memberSymbol) {
            _writer.Indent++;

            _writer.Write("AssociatedType: ");
            _writer.WriteLine(memberSymbol.AssociatedType.FullName);
            _writer.Write("Visibility: ");
            _writer.WriteLine(memberSymbol.Visibility.ToString());
            _writer.Write("Generated Name: ");
            _writer.WriteLine(memberSymbol.GeneratedName);
            if (memberSymbol.InterfaceMember != null) {
                _writer.Write("Associated Interface Member: ");
                _writer.Write(memberSymbol.InterfaceMember.Parent.Name);
                _writer.Write(".");
                _writer.WriteLine(memberSymbol.InterfaceMember.Name);
            }

            switch (memberSymbol.Type) {
                case SymbolType.Field:
                    DumpField((FieldSymbol)memberSymbol);
                    break;
                case SymbolType.EnumerationField:
                    DumpEnumerationField((EnumerationFieldSymbol)memberSymbol);
                    break;
                case SymbolType.Constructor:
                    DumpConstructor((ConstructorSymbol)memberSymbol);
                    break;
                case SymbolType.Property:
                    DumpProperty((PropertySymbol)memberSymbol);
                    break;
                case SymbolType.Indexer:
                    DumpIndexer((IndexerSymbol)memberSymbol);
                    break;
                case SymbolType.Event:
                    DumpEvent((EventSymbol)memberSymbol);
                    break;
                case SymbolType.Method:
                    DumpMethod((MethodSymbol)memberSymbol);
                    break;
            }

            _writer.Indent--;
        }

        private void DumpMethod(MethodSymbol methodSymbol) {
            _writer.Write("Abstract: ");
            _writer.WriteLine(methodSymbol.IsAbstract);

            if (methodSymbol.Conditions != null) {
                _writer.WriteLine("Conditions:");
                _writer.Indent++;
                foreach (string condition in methodSymbol.Conditions) {
                    _writer.WriteLine(condition);
                }
                _writer.Indent--;
            }

            if (methodSymbol.Parameters != null) {
                _writer.WriteLine("Parameters:");
                _writer.Indent++;
                foreach (ParameterSymbol paramSymbol in methodSymbol.Parameters) {
                    DumpSymbol(paramSymbol);
                }
                _writer.Indent--;
            }
        }

        private void DumpNamespace(NamespaceSymbol namespaceSymbol) {
            _writer.Write("HasApplicationTypes: ");
            _writer.WriteLine(namespaceSymbol.HasApplicationTypes);
            _writer.WriteLine("Types:");
            _writer.Indent++;

            ArrayList types = new ArrayList(namespaceSymbol.Types.Count);
            foreach (TypeSymbol type in namespaceSymbol.Types) {
                types.Add(type);
            }
            types.Sort(new SymbolComparer());

            foreach (TypeSymbol type in types) {
                DumpSymbol(type);
            }
            _writer.Indent--;
        }

        private void DumpParameter(ParameterSymbol parameterSymbol) {
            _writer.Write("AssociatedType: ");
            _writer.WriteLine(parameterSymbol.ValueType.FullName);
            _writer.Write("Mode: ");
            _writer.WriteLine(parameterSymbol.Mode.ToString());
        }

        private void DumpProperty(PropertySymbol propertySymbol) {
            _writer.Write("ReadOnly: ");
            _writer.WriteLine(propertySymbol.IsReadOnly);
            _writer.Write("Abstract: ");
            _writer.WriteLine(propertySymbol.IsAbstract);
        }

        private void DumpSymbol(Symbol symbol) {
            _writer.Write(symbol.Type.ToString());
            _writer.Write(": ");
            _writer.WriteLine(symbol.Name);

            switch (symbol.Type) {
                case SymbolType.Namespace:
                    DumpNamespace((NamespaceSymbol)symbol);
                    break;
                case SymbolType.Class:
                case SymbolType.Interface:
                case SymbolType.Enumeration:
                case SymbolType.Delegate:
                case SymbolType.Record:
                    DumpType((TypeSymbol)symbol);
                    break;
                case SymbolType.Field:
                case SymbolType.EnumerationField:
                case SymbolType.Constructor:
                case SymbolType.Property:
                case SymbolType.Indexer:
                case SymbolType.Event:
                case SymbolType.Method:
                    DumpMember((MemberSymbol)symbol);
                    break;
                case SymbolType.Parameter:
                    DumpParameter((ParameterSymbol)symbol);
                    break;
            }
        }

        public void DumpSymbols(SymbolSet symbols) {
            ArrayList namespaces = new ArrayList(symbols.Namespaces.Count);
            foreach (NamespaceSymbol ns in symbols.Namespaces) {
                namespaces.Add(ns);
            }
            namespaces.Sort(new SymbolComparer());

            foreach (NamespaceSymbol ns in namespaces) {
                DumpSymbol(ns);
                _writer.WriteLine();
            }
        }

        private void DumpType(TypeSymbol typeSymbol) {
            _writer.Indent++;

            _writer.Write("Application Type: ");
            _writer.WriteLine(typeSymbol.IsApplicationType);
            _writer.Write("Public: ");
            _writer.WriteLine(typeSymbol.IsPublic);
            _writer.Write("Generated Name: ");
            _writer.WriteLine(typeSymbol.GeneratedName);

            switch (typeSymbol.Type) {
                case SymbolType.Class:
                case SymbolType.Record:
                    DumpClass((ClassSymbol)typeSymbol);
                    break;
                case SymbolType.Interface:
                    DumpInterface((InterfaceSymbol)typeSymbol);
                    break;
                case SymbolType.Enumeration:
                    DumpEnumeration((EnumerationSymbol)typeSymbol);
                    break;
                case SymbolType.Delegate:
                    DumpDelegate((DelegateSymbol)typeSymbol);
                    break;
            }

            _writer.WriteLine("Members:");
            _writer.Indent++;
            foreach (MemberSymbol member in typeSymbol.Members) {
                DumpSymbol(member);
            }
            _writer.Indent--;
            _writer.WriteLine();

            _writer.Indent--;
        }


        private sealed class SymbolComparer : IComparer {

            public int Compare(object x, object y) {
                return String.Compare(((Symbol)x).Name, ((Symbol)y).Name);
            }
        }
    }

#endif // DEBUG
}
