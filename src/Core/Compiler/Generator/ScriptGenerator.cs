// ScriptGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator
{

    internal sealed class ScriptGenerator {

        private ScriptTextWriter _writer;
        private CompilerOptions _options;
        private SymbolSet _symbols;

        private Stack<SymbolImplementation> _implementationStack;

        public ScriptGenerator(TextWriter writer, CompilerOptions options, SymbolSet symbols) {
            Debug.Assert(writer != null);
            _writer = new ScriptTextWriter(writer);

            _options = options;
            _symbols = symbols;

            _implementationStack = new Stack<SymbolImplementation>();
        }

        public SymbolImplementation CurrentImplementation {
            get {
                return _implementationStack.Peek();
            }
        }

        public CompilerOptions Options {
            get {
                return _options;
            }
        }

        public ScriptTextWriter Writer {
            get {
                return _writer;
            }
        }

        public void EndImplementation() {
            Debug.Assert(_implementationStack.Count != 0);
            _implementationStack.Pop();
        }

        public void GenerateScript(SymbolSet symbolSet) {
            Debug.Assert(symbolSet != null);

            List<TypeSymbol> types = new List<TypeSymbol>();
            List<TypeSymbol> publicTypes = new List<TypeSymbol>();
            List<TypeSymbol> internalTypes = new List<TypeSymbol>();

            bool hasNonModuleInternalTypes = false;

            foreach (NamespaceSymbol namespaceSymbol in symbolSet.Namespaces) {
                if (namespaceSymbol.HasApplicationTypes) {
                    foreach (TypeSymbol type in namespaceSymbol.Types) {
                        if (type.IsApplicationType == false) {
                            continue;
                        }

                        if (type.Type == SymbolType.Delegate) {
                            // Nothing needs to be generated for delegate types.
                            continue;
                        }

                        if (type.IsTestType && (_options.IncludeTests == false)) {
                            continue;
                        }

                        if ((type.Type == SymbolType.Enumeration) &&
                            ((type.IsPublic == false) || ((EnumerationSymbol)type).Constants)) {
                            // Internal enums can be skipped since their values have been inlined.
                            // Public enums marked as constants can also be skipped since their
                            // values will always be inlined.
                            continue;
                        }

                        types.Add(type);
                        if (type.IsPublic) {
                            publicTypes.Add(type);
                        }
                        else {
                            if ((type.Type != SymbolType.Class) ||
                                (((ClassSymbol)type).IsModuleClass == false)) {
                                hasNonModuleInternalTypes = true;
                            }
                            internalTypes.Add(type);
                        }
                    }
                }
            }

            // Sort the types, so similar types of types are grouped, and parent classes
            // come before derived classes.
            IComparer<TypeSymbol> typeComparer = new TypeComparer();
            types = types.OrderBy(t => t, typeComparer).ToList();
            publicTypes = publicTypes.OrderBy(t => t, typeComparer).ToList();
            internalTypes = internalTypes.OrderBy(t => t, typeComparer).ToList();

            bool initialIndent = false;
            if (String.IsNullOrEmpty(_options.ScriptInfo.Template) == false) {
                int scriptIndex = _options.ScriptInfo.Template.IndexOf("{script}");
                if ((scriptIndex > 0) && (_options.ScriptInfo.Template[scriptIndex - 1] == ' ')) {
                    // Heuristic to turn on initial indent:
                    // The script template has a space prior to {script}, i.e. {script} is not the
                    // first thing on a line within the template.

                    initialIndent = true;
                }
            }
            if (initialIndent) {
                _writer.Indent++;
            }

            foreach (TypeSymbol type in types) {
                TypeGenerator.GenerateScript(this, type);
            }

            bool generateModule = (publicTypes.Count != 0) ||
                                  ((internalTypes.Count != 0) && hasNonModuleInternalTypes);

            if (generateModule) {

                NamespaceTable namespaceTable = BuildNamespaceTable(types);
                this.GenerateNamespaceTable(namespaceTable);
                _writer.WriteLine();

                _writer.Write("var $exports = ss.module('");
                _writer.Write(symbolSet.ScriptName);
                _writer.Write("', '");
                _writer.Write(symbolSet.ScriptVersion);
                _writer.Write("',");
                if ((internalTypes.Count != 0) && hasNonModuleInternalTypes) {
                    _writer.WriteLine();
                    _writer.Indent++;
                    _writer.WriteLine("{");
                    _writer.Indent++;
                    bool firstType = true;
                    foreach (TypeSymbol type in internalTypes) {
                        if ((type.Type == SymbolType.Class) &&
                            (((ClassSymbol)type).IsExtenderClass || ((ClassSymbol)type).IsModuleClass)) {
                            continue;
                        }
                        if ((type.Type == SymbolType.Record) &&
                            ((RecordSymbol)type).Constructor == null) {
                            continue;
                        }

                        if (firstType == false) {
                            _writer.WriteLine(",");
                        }
                        TypeGenerator.GenerateRegistrationScript(this, type, namespaceTable);
                        firstType = false;
                    }
                    _writer.Indent--;
                    _writer.WriteLine();
                    _writer.Write("},");
                    _writer.Indent--;
                }
                else {
                    _writer.Write(" null,");
                }
                if (publicTypes.Count != 0) {
                    _writer.WriteLine();
                    _writer.Indent++;
                    _writer.WriteLine("{");
                    _writer.Indent++;
                    bool firstType = true;
                    foreach (TypeSymbol type in publicTypes) {
                        if ((type.Type == SymbolType.Class) &&
                            ((ClassSymbol)type).IsExtenderClass) {
                            continue;
                        }

                        if (firstType == false) {
                            _writer.WriteLine(",");
                        }
                        TypeGenerator.GenerateRegistrationScript(this, type, namespaceTable);
                        firstType = false;
                    }
                    _writer.Indent--;
                    _writer.WriteLine();
                    _writer.Write("}");
                    _writer.Indent--;
                }
                else {
                    _writer.Write(" null");
                }
                _writer.WriteLine(");");
                _writer.WriteLine();
            }

            foreach (TypeSymbol type in types) {
                if (type.Type == SymbolType.Class) {
                    TypeGenerator.GenerateClassConstructorScript(this, (ClassSymbol)type);
                }
            }

            if (_options.IncludeTests) {
                foreach (TypeSymbol type in types) {
                    ClassSymbol classSymbol = type as ClassSymbol;
                    if ((classSymbol != null) && classSymbol.IsTestClass) {
                        TestGenerator.GenerateScript(this, classSymbol);
                    }
                }
            }

            if (initialIndent) {
                _writer.Indent--;
            }
        }

        private NamespaceTable BuildNamespaceTable(IList<TypeSymbol> types)
        {
            NamespaceTable namespaceTable = new NamespaceTable();        

            foreach(TypeSymbol typeSymbol in types)
            {
                namespaceTable.AddNamespace(typeSymbol.Namespace);
            }

            return namespaceTable;
        }

        public void StartImplementation(SymbolImplementation implementation) {
            Debug.Assert(implementation != null);
            _implementationStack.Push(implementation);
        }


        private sealed class TypeComparer : IComparer<TypeSymbol> {

            public int Compare(TypeSymbol x, TypeSymbol y) {
                if (x.Type != y.Type) {
                    // If types are different, then use the symbol type to
                    // similar types of types together.
                    return (int)x.Type - (int)y.Type;
                }

                if (x.Type == SymbolType.Class) {
                    // For classes, sort by inheritance depth. This is a crude
                    // way to ensure the base class for a class is generated
                    // first, without specifically looking at the inheritance
                    // chain for any particular type. A parent class with lesser
                    // inheritance depth has to by definition come first.

                    return ((ClassSymbol)x).InheritanceDepth - ((ClassSymbol)y).InheritanceDepth;
                }

                return 0;
            }
        }
    }
}
