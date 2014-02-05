using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using ScriptSharp.ScriptModel;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Xml;

namespace ScriptSharp.SymbolFile {

    /// <summary>
    /// Generates symbol files from extracted symbol informations.
    /// </summary>
    internal class SymbolFileGenerator {


        private readonly XmlTextWriter _writer;


        internal SymbolFileGenerator(TextWriter writer) {
            Debug.Assert(writer != null);

            _writer = new XmlTextWriter(writer);

        }

        internal void Generate(SymbolSet symbols) {

            _writer.WriteStartDocument();
            _writer.WriteStartElement(SymbolFile.RootElement);

            DumpSymbols(symbols);

            _writer.WriteEndElement();
            _writer.WriteEndDocument();

        }
        #region Dump


        private void DumpSymbols(SymbolSet symbols) {
            ArrayList namespaces = new ArrayList(symbols.Namespaces.Count);
            foreach (NamespaceSymbol ns in symbols.Namespaces) {
                namespaces.Add(ns);
            }
            namespaces.Sort(new SymbolComparer());

            foreach (NamespaceSymbol ns in namespaces) {
                DumpSymbol(ns);

            }
        }


        private void WriteElement(Symbol s) {

            _writer.WriteEndElement();

        }

        #endregion
        private void DumpClass(ClassSymbol classSymbol) {

            if (classSymbol.BaseClass != null) {
                _writer.WriteAttributeString(SymbolFile.BaseClassAttribute, classSymbol.BaseClass.Name);
            }
            if (classSymbol.Interfaces != null) {
                foreach (InterfaceSymbol interfaceSymbol in classSymbol.Interfaces) {
                    _writer.WriteStartElement(SymbolFile.SymbolElement);
                    _writer.WriteAttributeString(SymbolFile.TypeAttribute, interfaceSymbol.Type.ToString());
                    _writer.WriteAttributeString(SymbolFile.NameAttribute, interfaceSymbol.Name);
                    _writer.WriteEndElement();
                }
            }
            if (classSymbol.Constructor != null) {
                DumpSymbol(classSymbol.Constructor);
            }
            if (classSymbol.StaticConstructor != null) {
                DumpSymbol(classSymbol.StaticConstructor);
            }
            if (classSymbol.Indexer != null) {
                DumpSymbol(classSymbol.Indexer);
            }
        }

        private void DumpConstructor(ConstructorSymbol ctorSymbol) {
            if (ctorSymbol.Parameters != null) {

                foreach (ParameterSymbol paramSymbol in ctorSymbol.Parameters) {
                    DumpSymbol(paramSymbol);
                }
            }
        }

        private void DumpDelegate(DelegateSymbol delegateSymbol) {
        }

        private void DumpEnumeration(EnumerationSymbol enumSymbol) {
            _writer.WriteAttributeString(SymbolFile.FlagAttribute, enumSymbol.Flags.ToString());
        }

        private void DumpEnumerationField(EnumerationFieldSymbol enumFieldSymbol) {
        }

        private void DumpEvent(EventSymbol eventSymbol) {

            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, SymbolFile.GetterTypeName);
            _writer.WriteAttributeString(SymbolFile.NameAttribute, eventSymbol.Name);
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, "add_" + eventSymbol.GeneratedName);
            _writer.WriteEndElement();

            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, SymbolFile.SetterTypeName);
            _writer.WriteAttributeString(SymbolFile.NameAttribute, eventSymbol.Name);
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, "remove_" + eventSymbol.GeneratedName);
            _writer.WriteEndElement();
        }

        private void DumpField(FieldSymbol fieldSymbol) {
            _writer.WriteAttributeString(SymbolFile.AliasedAttribute, fieldSymbol.IsGlobalField.ToString());
        }

        private void DumpIndexer(IndexerSymbol indexerSymbol) {
            _writer.WriteAttributeString(SymbolFile.ReadOnlyAttribute, indexerSymbol.IsReadOnly.ToString());
            _writer.WriteAttributeString(SymbolFile.AbstractAttribute, indexerSymbol.IsAbstract.ToString());


            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, SymbolFile.GetterTypeName);
            _writer.WriteAttributeString(SymbolFile.NameAttribute, indexerSymbol.Name);
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, "get_" + indexerSymbol.GeneratedName);
            _writer.WriteEndElement();

            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, SymbolFile.SetterTypeName);
            _writer.WriteAttributeString(SymbolFile.NameAttribute, indexerSymbol.Name);
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, "set_" + indexerSymbol.GeneratedName);
            _writer.WriteEndElement();

        }

        private void DumpInterface(InterfaceSymbol interfaceSymbol) {
        }

        private void DumpMember(MemberSymbol memberSymbol) {

            _writer.WriteAttributeString(SymbolFile.AssociatedTypeAttribute, memberSymbol.AssociatedType.Name.ToString());
            _writer.WriteAttributeString(SymbolFile.VisibilityAttribute, memberSymbol.Visibility.ToString());
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, memberSymbol.GeneratedName);

            if (memberSymbol.InterfaceMember != null) {
                _writer.WriteAttributeString(SymbolFile.InterfaceMemberAttribute, string.Format(
                    "{0}.{1}", memberSymbol.InterfaceMember.Parent.Name, memberSymbol.InterfaceMember.Name));
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

        }

        private void DumpMethod(MethodSymbol methodSymbol) {


            _writer.WriteAttributeString(SymbolFile.AbstractAttribute, methodSymbol.IsAbstract.ToString());
            _writer.WriteAttributeString(SymbolFile.AliasedAttribute, methodSymbol.IsAliased.ToString());
            
            if (methodSymbol.Conditions != null) {

                StringBuilder sb = new StringBuilder();
                foreach (string condition in methodSymbol.Conditions) {
                    sb.Append(condition);
                    sb.Append(",");
                }
                _writer.WriteAttributeString(SymbolFile.ConditionsAttribute, sb.ToString());
            }

            if (methodSymbol.Parameters != null) {

                foreach (ParameterSymbol paramSymbol in methodSymbol.Parameters) {
                    DumpSymbol(paramSymbol);
                }

            }
        }

        private void DumpNamespace(NamespaceSymbol namespaceSymbol) {

            _writer.WriteAttributeString(SymbolFile.HasApplicationTypesAttribute, namespaceSymbol.HasApplicationTypes.ToString());

            ArrayList types = new ArrayList(namespaceSymbol.Types.Count);
            foreach (TypeSymbol type in namespaceSymbol.Types) {
                types.Add(type);
            }
            types.Sort(new SymbolComparer());

            foreach (TypeSymbol type in types) {
                DumpSymbol(type);
            }
        }

        private void DumpParameter(ParameterSymbol parameterSymbol) {
            _writer.WriteAttributeString(SymbolFile.ValueTypeAttribute, parameterSymbol.ValueType.Name);
            _writer.WriteAttributeString(SymbolFile.ModeAttribute, parameterSymbol.Mode.ToString());
        }

        private void DumpProperty(PropertySymbol propertySymbol) {
            _writer.WriteAttributeString(SymbolFile.ReadOnlyAttribute, propertySymbol.IsReadOnly.ToString());
            _writer.WriteAttributeString(SymbolFile.AbstractAttribute, propertySymbol.IsAbstract.ToString());

            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, SymbolFile.GetterTypeName);
            _writer.WriteAttributeString(SymbolFile.NameAttribute, propertySymbol.Name);
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, "get_" + propertySymbol.GeneratedName);
            _writer.WriteEndElement();

            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, SymbolFile.SetterTypeName);
            _writer.WriteAttributeString(SymbolFile.NameAttribute, propertySymbol.Name);
            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, "set_" + propertySymbol.GeneratedName);
            _writer.WriteEndElement();

        }

        private void DumpSymbol(Symbol symbol) {

            _writer.WriteStartElement(SymbolFile.SymbolElement);
            _writer.WriteAttributeString(SymbolFile.TypeAttribute, symbol.Type.ToString());
            _writer.WriteAttributeString(SymbolFile.NameAttribute, symbol.Name);

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

            _writer.WriteEndElement();

        }

        private void DumpType(TypeSymbol typeSymbol) {

            _writer.WriteAttributeString(SymbolFile.IsExtenderClassAttribute, typeSymbol.IsApplicationType.ToString());
            _writer.WriteAttributeString(SymbolFile.IsPublicAttribute, typeSymbol.IsPublic.ToString());
            _writer.WriteAttributeString(SymbolFile.IsScriptImportedAttribute, typeSymbol.IsScriptImported.ToString());

            _writer.WriteAttributeString(SymbolFile.GeneratedNameAttribute, typeSymbol.GeneratedName);

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

            foreach (MemberSymbol member in typeSymbol.Members) {
                DumpSymbol(member);
            }

        }
        private sealed class SymbolComparer : IComparer {

            public int Compare(object x, object y) {
                return String.Compare(((Symbol)x).Name, ((Symbol)y).Name);
            }
        }



    }
}
