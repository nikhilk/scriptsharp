// CodeGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.Compiler;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal static class CodeGenerator {

        private static void GenerateImplementationScript(ScriptGenerator generator, MemberSymbol symbol, SymbolImplementation implementation) {
            generator.StartImplementation(implementation);
            try {
                bool generateThisCacheStatement = false;

                if ((symbol.Visibility & MemberVisibility.Static) == 0) {
                    CodeMemberSymbol codeMemberSymbol = symbol as CodeMemberSymbol;
                    if ((codeMemberSymbol != null) && (codeMemberSymbol.AnonymousMethods != null)) {
                        foreach (AnonymousMethodSymbol anonymousMethod in codeMemberSymbol.AnonymousMethods) {
                            if ((anonymousMethod.Visibility & MemberVisibility.Static) == 0) {
                                generateThisCacheStatement = true;
                                break;
                            }
                        }
                    }
                }

                if (generateThisCacheStatement) {
                    ScriptTextWriter writer = generator.Writer;

                    writer.WriteLine("var $this = this;");
                    writer.WriteLine();
                }

                foreach (Statement statement in implementation.Statements) {
                    StatementGenerator.GenerateStatement(generator, symbol, statement);
                }
            }
            finally {
                generator.EndImplementation();
            }
        }

        public static void GenerateScript(ScriptGenerator generator, EventSymbol symbol, bool add) {
            SymbolImplementation accessorImpl;
            if (add) {
                accessorImpl = symbol.AdderImplementation;
            }
            else {
                accessorImpl = symbol.RemoverImplementation;
            }
            GenerateImplementationScript(generator, symbol, accessorImpl);
        }

        public static void GenerateScript(ScriptGenerator generator, FieldSymbol symbol) {
            GenerateImplementationScript(generator, symbol, symbol.Implementation);
        }

        public static void GenerateScript(ScriptGenerator generator, MethodSymbol symbol) {
            GenerateImplementationScript(generator, symbol, symbol.Implementation);
        }

        public static void GenerateScript(ScriptGenerator generator, AnonymousMethodSymbol symbol) {
            GenerateImplementationScript(generator, symbol, symbol.Implementation);
        }

        public static void GenerateScript(ScriptGenerator generator, PropertySymbol symbol, bool getter) {
            SymbolImplementation accessorImpl;
            if (getter) {
                accessorImpl = symbol.GetterImplementation;
            }
            else {
                accessorImpl = symbol.SetterImplementation;
            }
            GenerateImplementationScript(generator, symbol, accessorImpl);
        }

        public static void GenerateScript(ScriptGenerator generator, IndexerSymbol symbol, bool getter) {
            SymbolImplementation accessorImpl;
            if (getter) {
                accessorImpl = symbol.GetterImplementation;
            }
            else {
                accessorImpl = symbol.SetterImplementation;
            }
            GenerateImplementationScript(generator, symbol, accessorImpl);
        }
    }
}
