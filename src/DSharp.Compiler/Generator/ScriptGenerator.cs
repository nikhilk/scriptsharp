// ScriptGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal sealed class ScriptGenerator
    {
        private readonly Stack<SymbolImplementation> implementationStack;
        private readonly IComparer<TypeSymbol> typeComparer = new TypeComparer();

        private SymbolSet symbols;

        public ScriptGenerator(TextWriter writer, CompilerOptions options, SymbolSet symbols)
        {
            Debug.Assert(writer != null);
            Writer = new ScriptTextWriter(writer);

            Options = options;
            this.symbols = symbols;

            implementationStack = new Stack<SymbolImplementation>();
        }

        public SymbolImplementation CurrentImplementation => implementationStack.Peek();

        public CompilerOptions Options { get; }

        public ScriptTextWriter Writer { get; }

        public void EndImplementation()
        {
            Debug.Assert(implementationStack.Count != 0);
            implementationStack.Pop();
        }

        public void GenerateScript(SymbolSet symbolSet)
        {
            Debug.Assert(symbolSet != null);

            var types = CollectEmittableTypes(symbolSet)
                .OrderBy(t => t, typeComparer);

            // Sort the types, so similar types of types are grouped, and parent classes
            // come before derived classes.

            bool initialIndent = false;

            if (string.IsNullOrEmpty(Options.ScriptInfo.Template) == false)
            {
                int scriptIndex = Options.ScriptInfo.Template.IndexOf("{script}");

                if (scriptIndex > 0 && Options.ScriptInfo.Template[scriptIndex - 1] == ' ')
                {
                    // Heuristic to turn on initial indent:
                    // The script template has a space prior to {script}, i.e. {script} is not the
                    // first thing on a line within the template.

                    initialIndent = true;
                }
            }

            if (initialIndent)
            {
                Writer.Indent++;
            }

            foreach (TypeSymbol type in types)
            {
                TypeGenerator.GenerateScript(this, type);
            }

            GenerateModuleExports(symbolSet, types);

            foreach (TypeSymbol type in types)
            {
                if (type is ClassSymbol classSymbol)
                {
                    TypeGenerator.GenerateClassConstructorScript(this, classSymbol);
                }
            }

            if (initialIndent)
            {
                Writer.Indent--;
            }
        }

        private void GenerateModuleExports(SymbolSet symbolSet, IEnumerable<TypeSymbol> types)
        {
            if (!types.Any())
            {
                return;
            }

            IEnumerable<TypeSymbol> publicTypes = types.Where(type => type.IsPublic);
            IEnumerable<TypeSymbol> internalTypes = types.Where(type => type.IsInternal);

            Writer.Write($"var $module = {DSharpStringResources.ScriptExportMember("module")}('");
            Writer.Write(symbolSet.ScriptName);
            Writer.Write("',");

            if (internalTypes.Any())
            {
                Writer.WriteLine();
                Writer.Indent++;
                Writer.WriteLine("{");
                Writer.Indent++;
                bool firstType = true;

                foreach (TypeSymbol type in internalTypes)
                {
                    if (type.Type == SymbolType.Record && ((RecordSymbol)type).Constructor == null)
                    {
                        continue;
                    }

                    if (firstType == false)
                    {
                        Writer.WriteLine(",");
                    }

                    TypeGenerator.GenerateRegistrationScript(this, type);
                    firstType = false;
                }

                Writer.Indent--;
                Writer.WriteLine();
                Writer.Write("},");
                Writer.Indent--;
            }
            else
            {
                Writer.Write(" null,");
            }

            if (publicTypes.Any())
            {
                Writer.WriteLine();
                Writer.Indent++;
                Writer.WriteLine("{");
                Writer.Indent++;
                bool firstType = true;

                foreach (TypeSymbol type in publicTypes)
                {
                    if (firstType == false)
                    {
                        Writer.WriteLine(",");
                    }

                    TypeGenerator.GenerateRegistrationScript(this, type);
                    firstType = false;
                }

                Writer.Indent--;
                Writer.WriteLine();
                Writer.Write("}");
                Writer.Indent--;
            }
            else
            {
                Writer.Write(" null");
            }

            Writer.WriteLine(");");
            Writer.WriteLine($"var $exports = $module.api;");
            Writer.WriteLine();
        }

        private static List<TypeSymbol> CollectEmittableTypes(SymbolSet symbolSet)
        {
            var types = new List<TypeSymbol>();

            foreach (NamespaceSymbol namespaceSymbol in symbolSet.Namespaces.Where(ns => ns.HasApplicationTypes))
                foreach (TypeSymbol type in namespaceSymbol.Types.Where(type => type.IsApplicationType))
                {
                    if (type.Type == SymbolType.Delegate)
                    {
                        // Nothing needs to be generated for delegate types.
                        continue;
                    }

                    if (type.Type == SymbolType.Enumeration &&
                        (type.IsPublic == false || ((EnumerationSymbol)type).Constants))
                    {
                        // Internal enums can be skipped since their values have been inlined.
                        // Public enums marked as constants can also be skipped since their
                        // values will always be inlined.
                        continue;
                    }

                    types.Add(type);
                }

            return types;
        }

        public void StartImplementation(SymbolImplementation implementation)
        {
            implementationStack.Push(implementation);
        }

        internal sealed class TypeComparer : IComparer<TypeSymbol>
        {
            public int Compare(TypeSymbol x, TypeSymbol y)
            {
                if (x.Type != y.Type)
                {
                    // If types are different, then use the symbol type to
                    // similar types of types together.
                    return (int)x.Type - (int)y.Type;
                }

                if (x.Type == SymbolType.Class)
                {
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
