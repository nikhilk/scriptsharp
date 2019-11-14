// CodeGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using DSharp.Compiler.ScriptModel.Statements;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal static class CodeGenerator
    {
        private static void GenerateImplementationScript(
            ScriptGenerator generator, 
            MemberSymbol symbol,
            SymbolImplementation implementation)
        {
            if(implementation == null)
            {
                throw new ArgumentNullException(nameof(implementation), $"Member: {symbol?.Name} has no valid implementation");
            }

            generator.StartImplementation(implementation);

            try
            {
                bool generateThisCacheStatement = false;

                if ((symbol.Visibility & MemberVisibility.Static) == 0)
                {
                    if (symbol is CodeMemberSymbol codeMemberSymbol && codeMemberSymbol.AnonymousMethods != null)
                    {
                        foreach (AnonymousMethodSymbol anonymousMethod in codeMemberSymbol.AnonymousMethods)
                            if ((anonymousMethod.Visibility & MemberVisibility.Static) == 0)
                            {
                                generateThisCacheStatement = true;

                                break;
                            }
                    }
                }

                if (generateThisCacheStatement)
                {
                    ScriptTextWriter writer = generator.Writer;

                    writer.WriteLine("var $this = this;");
                    writer.WriteLine();
                }

                foreach (Statement statement in implementation.Statements)
                    StatementGenerator.GenerateStatement(generator, symbol, statement);
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                generator.EndImplementation();
            }
        }

        public static void GenerateScript(ScriptGenerator generator, EventSymbol symbol, bool add)
        {
            SymbolImplementation accessorImpl;

            if (add)
            {
                accessorImpl = symbol.AdderImplementation;
            }
            else
            {
                accessorImpl = symbol.RemoverImplementation;
            }

            GenerateImplementationScript(generator, symbol, accessorImpl);
        }

        public static void GenerateScript(ScriptGenerator generator, FieldSymbol symbol)
        {
            GenerateImplementationScript(generator, symbol, symbol.Implementation);
        }

        public static void GenerateScript(ScriptGenerator generator, MethodSymbol symbol)
        {
            GenerateImplementationScript(generator, symbol, symbol.Implementation);
        }

        public static void GenerateScript(ScriptGenerator generator, AnonymousMethodSymbol symbol)
        {
            GenerateImplementationScript(generator, symbol, symbol.Implementation);
        }

        public static void GenerateScript(ScriptGenerator generator, PropertySymbol symbol, bool getter)
        {
            SymbolImplementation accessorImpl;

            if (getter)
            {
                accessorImpl = symbol.GetterImplementation;
            }
            else
            {
                accessorImpl = symbol.SetterImplementation;
            }

            GenerateImplementationScript(generator, symbol, accessorImpl);
        }

        public static void GenerateScript(ScriptGenerator generator, IndexerSymbol symbol, bool getter)
        {
            SymbolImplementation accessorImpl;

            if (getter)
            {
                accessorImpl = symbol.GetterImplementation;
            }
            else
            {
                accessorImpl = symbol.SetterImplementation;
            }

            GenerateImplementationScript(generator, symbol, accessorImpl);
        }
    }
}
