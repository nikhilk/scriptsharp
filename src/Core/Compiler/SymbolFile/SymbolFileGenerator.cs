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
    public class SymbolFileGenerator {

        const string RootElement = "Root";
        const string SymbolElement = "Symbol";
        const string GeneratedNameAttribute = "GeneratedName";
        const string NameAttribute = "Name";
        const string TypeAttribute = "Type";
        const string HasApplicationTypesAttribute = "HasApplicationTypes";
        const string IsExtenderClassAttribute = "IsExtenderClass";
        const string BaseClassAttribute = "BaseClass";
        const string FlagAttribute = "Flag";
        const string ReadOnlyAttribute = "ReadOnly";
        const string AssociatedTypeAttribute = "AssociatedType";
        const string VisibilityAttribute = "Visibility";
        const string ConditionsAttribute = "Conditions";
        const string ValueTypeAttribute = "ValueType";
        const string ModeAttribute = "Mode";
        const string IsPublicAttribute = "IsPublic";
        const string AbstractAttribute = "Abstract";
        const string InterfaceMemberAttribute = "InterfaceMember";

        private readonly XmlTextWriter _writer;


        internal SymbolFileGenerator(TextWriter writer) {
            Debug.Assert(writer != null);
            _writer = new XmlTextWriter(writer);

        }

        internal void Generate(SymbolSet symbols) {

            _writer.WriteStartDocument();
            _writer.WriteStartElement(RootElement);

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

                _writer.WriteWhitespace("\n");
            }
        }


        private void WriteElement(Symbol s) {

            _writer.WriteEndElement();
            _writer.WriteWhitespace("\n");

        }

        #endregion
        private void DumpClass(ClassSymbol classSymbol) {

            if (classSymbol.BaseClass != null) {
                _writer.WriteAttributeString(BaseClassAttribute, classSymbol.BaseClass.Name);
            }
            if (classSymbol.Interfaces != null) {
                foreach (InterfaceSymbol interfaceSymbol in classSymbol.Interfaces) {
                    _writer.WriteStartElement(SymbolElement);
                    _writer.WriteAttributeString(TypeAttribute, interfaceSymbol.Type.ToString());
                    _writer.WriteAttributeString(NameAttribute, interfaceSymbol.Name);
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
            _writer.WriteAttributeString(FlagAttribute, enumSymbol.Flags.ToString());
        }

        private void DumpEnumerationField(EnumerationFieldSymbol enumFieldSymbol) {
        }

        private void DumpEvent(EventSymbol eventSymbol) {
        }

        private void DumpField(FieldSymbol fieldSymbol) {
        }

        private void DumpIndexer(IndexerSymbol indexerSymbol) {
            _writer.WriteAttributeString(ReadOnlyAttribute, indexerSymbol.IsReadOnly.ToString());
            _writer.WriteAttributeString(AbstractAttribute, indexerSymbol.IsAbstract.ToString());
        }

        private void DumpInterface(InterfaceSymbol interfaceSymbol) {
        }

        private void DumpMember(MemberSymbol memberSymbol) {

            _writer.WriteAttributeString(AssociatedTypeAttribute, memberSymbol.AssociatedType.Name.ToString());
            _writer.WriteAttributeString(VisibilityAttribute, memberSymbol.Visibility.ToString());
            _writer.WriteAttributeString(GeneratedNameAttribute, memberSymbol.GeneratedName);

            if (memberSymbol.InterfaceMember != null) {
                _writer.WriteAttributeString(InterfaceMemberAttribute, string.Format(
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


            _writer.WriteAttributeString(AbstractAttribute, methodSymbol.IsAbstract.ToString());

            if (methodSymbol.Conditions != null) {

                StringBuilder sb = new StringBuilder();
                foreach (string condition in methodSymbol.Conditions) {
                    sb.Append(condition);
                    sb.Append(",");
                }
                _writer.WriteAttributeString(ConditionsAttribute, sb.ToString());
            }

            if (methodSymbol.Parameters != null) {

                foreach (ParameterSymbol paramSymbol in methodSymbol.Parameters) {
                    DumpSymbol(paramSymbol);
                }

            }
        }

        private void DumpNamespace(NamespaceSymbol namespaceSymbol) {

            _writer.WriteAttributeString(HasApplicationTypesAttribute, namespaceSymbol.HasApplicationTypes.ToString());

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
            _writer.WriteAttributeString(ValueTypeAttribute, parameterSymbol.ValueType.Name);
            _writer.WriteAttributeString(ModeAttribute, parameterSymbol.Mode.ToString());
        }

        private void DumpProperty(PropertySymbol propertySymbol) {
            _writer.WriteAttributeString(ReadOnlyAttribute, propertySymbol.IsReadOnly.ToString());
            _writer.WriteAttributeString(AbstractAttribute, propertySymbol.IsAbstract.ToString());
        }

        private void DumpSymbol(Symbol symbol) {

            _writer.WriteStartElement(SymbolElement);
            _writer.WriteAttributeString(TypeAttribute, symbol.Type.ToString());
            _writer.WriteAttributeString(NameAttribute, symbol.Name);

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

            _writer.WriteAttributeString(IsExtenderClassAttribute, typeSymbol.IsApplicationType.ToString());
            _writer.WriteAttributeString(IsPublicAttribute, typeSymbol.IsPublic.ToString());
            _writer.WriteAttributeString(GeneratedNameAttribute, typeSymbol.GeneratedName);

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
            _writer.WriteWhitespace(Environment.NewLine);

        }
        private sealed class SymbolComparer : IComparer {

            public int Compare(object x, object y) {
                return String.Compare(((Symbol)x).Name, ((Symbol)y).Name);
            }
        }


    }
}
