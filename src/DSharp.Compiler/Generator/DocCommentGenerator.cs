// DocCommentGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal static class DocCommentGenerator
    {
        public static void GenerateComment(ScriptGenerator generator, Symbol symbol)
        {
            ScriptTextWriter writer = generator.Writer;

            switch (symbol.Type)
            {
                case SymbolType.Class:
                    GenerateClassComment(writer, (ClassSymbol) symbol);

                    break;
                case SymbolType.Enumeration:

                    // No-op - no doc-comments get generated for enums.
                    break;
                case SymbolType.Event:
                    GenerateEventComment(writer, (EventSymbol) symbol);

                    break;
                case SymbolType.Indexer:
                    GenerateIndexerComment(writer, (IndexerSymbol) symbol);

                    break;
                case SymbolType.Interface:
                    GenerateInterfaceComment(writer, (InterfaceSymbol) symbol);

                    break;
                case SymbolType.Method:
                    GenerateMethodComment(writer, (MethodSymbol) symbol);

                    break;
                case SymbolType.Property:
                    GeneratePropertyComment(writer, (PropertySymbol) symbol);

                    break;
                default:
                    Debug.Fail("Unexpected symbol type");

                    break;
            }
        }

        private static void GenerateClassComment(ScriptTextWriter writer, ClassSymbol classSymbol)
        {
            GenerateSummaryComment(writer, classSymbol);

            if (classSymbol.Constructor != null &&
                classSymbol.Constructor.Parameters != null)
            {
                foreach (ParameterSymbol parameterSymbol in classSymbol.Constructor.Parameters)
                    GenerateParameterComment(writer, parameterSymbol);
            }

            foreach (MemberSymbol memberSymbol in classSymbol.Members)
            {
                if (memberSymbol is FieldSymbol fieldSymbol)
                {
                    GenerateFieldComment(writer, fieldSymbol);
                }
            }
        }

        private static void GenerateFormattedComment(ScriptTextWriter writer, string text)
        {
            foreach (string line in text.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                string trimmedLine = line.Trim();

                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    writer.WriteLine("/// {0}", trimmedLine);
                }
            }
        }

        private static void GenerateInterfaceComment(ScriptTextWriter writer, InterfaceSymbol interfaceSymbol)
        {
            writer.WriteLine();
            writer.Indent++;

            GenerateSummaryComment(writer, interfaceSymbol);

            writer.Indent--;
        }

        private static void GenerateParameterComment(ScriptTextWriter writer, ParameterSymbol parameterSymbol)
        {
            writer.Write("/// <param name=\"{0}\"", parameterSymbol.GeneratedName);

            GenerateTypeAttributes(writer, parameterSymbol.ValueType);

            writer.WriteLine(">");

            GenerateFormattedComment(writer, parameterSymbol.Documentation);

            writer.WriteLine("/// </param>");
        }

        private static void GenerateEventComment(ScriptTextWriter writer, EventSymbol eventSymbol)
        {
            GenerateSummaryComment(writer, eventSymbol);

            writer.WriteLine("/// <param name=\"{0}\" type=\"Function\" />", eventSymbol.Parameters[0].Name);
        }

        private static void GenerateFieldComment(ScriptTextWriter writer, FieldSymbol fieldSymbol)
        {
            writer.Write("/// <field name=\"{0}\"", fieldSymbol.GeneratedName);

            GenerateTypeAttributes(writer, fieldSymbol.AssociatedType);

            if ((fieldSymbol.Visibility & MemberVisibility.Static) != 0)
            {
                writer.Write(" static=\"true\"");
            }

            writer.WriteLine(">");

            GenerateFormattedComment(writer, fieldSymbol.Documentation);

            writer.WriteLine("/// </field>");
        }

        private static void GenerateIndexerComment(ScriptTextWriter writer, IndexerSymbol indexerSymbol)
        {
            GenerateSummaryComment(writer, indexerSymbol);

            if (indexerSymbol.Parameters != null)
            {
                foreach (ParameterSymbol parameterSymbol in indexerSymbol.Parameters)
                    GenerateParameterComment(writer, parameterSymbol);
            }

            GenerateReturnsComment(writer, indexerSymbol.AssociatedType);
        }

        private static void GenerateMethodComment(ScriptTextWriter writer, MethodSymbol methodSymbol)
        {
            GenerateSummaryComment(writer, methodSymbol);

            if (methodSymbol.Parameters != null)
            {
                foreach (ParameterSymbol parameterSymbol in methodSymbol.Parameters)
                    GenerateParameterComment(writer, parameterSymbol);
            }

            GenerateReturnsComment(writer, methodSymbol.AssociatedType);
        }

        private static void GeneratePropertyComment(ScriptTextWriter writer, PropertySymbol propertySymbol)
        {
            GenerateSummaryComment(writer, propertySymbol);

            writer.Write("/// <value");

            GenerateTypeAttributes(writer, propertySymbol.AssociatedType);

            writer.WriteLine("></value>");
        }

        private static void GenerateReturnsComment(ScriptTextWriter writer, TypeSymbol typeSymbol)
        {
            if (IsVoid(typeSymbol))
            {
                return;
            }

            writer.Write("/// <returns");

            GenerateTypeAttributes(writer, typeSymbol);

            writer.WriteLine("></returns>");
        }

        private static void GenerateSummaryComment(ScriptTextWriter writer, Symbol symbol)
        {
            string documentation = symbol.Documentation;

            if (string.IsNullOrEmpty(documentation) == false)
            {
                writer.WriteLine("/// <summary>");
                GenerateFormattedComment(writer, documentation);
                writer.WriteLine("/// </summary>");
            }
        }

        private static void GenerateTypeAttributes(ScriptTextWriter writer, TypeSymbol typeSymbol)
        {
            if (IsDomElement(typeSymbol))
            {
                writer.Write(" type=\"Object\" domElement=\"true\"");
            }
            else
            {
                writer.Write(" type=\"{0}\"", typeSymbol.FullGeneratedName);
            }

            if (IsInteger(typeSymbol))
            {
                writer.Write(" integer=\"true\"");
            }

            if (typeSymbol.IsNativeArray)
            {
                ClassSymbol classSymbol = (ClassSymbol) typeSymbol;

                TypeSymbol elementTypeSymbol = classSymbol.Indexer.AssociatedType;

                if (IsDomElement(elementTypeSymbol))
                {
                    writer.Write(" elementType=\"Object\" elementDomElement=\"true\"");
                }
                else
                {
                    writer.Write(" elementType=\"{0}\"", elementTypeSymbol.GeneratedName);
                }

                if (IsInteger(elementTypeSymbol))
                {
                    writer.Write(" elementInteger=\"true\"");
                }
            }
        }

        private static bool IsDomElement(TypeSymbol typeSymbol)
        {
            ClassSymbol classSymbol = typeSymbol as ClassSymbol;

            while (classSymbol != null)
            {
                // TODO: This is a dependency on Script.Web.dll that we should remove.
                //       For now, changed SymbolSet.FindSymbol to handle the case
                //       where a namespace being looked up might not be defined.

                if (IsSymbol(classSymbol, "System.Html.Element"))
                {
                    return true;
                }

                classSymbol = classSymbol.BaseClass;
            }

            return false;
        }

        private static bool IsInteger(TypeSymbol typeSymbol)
        {
            return IsSymbol(typeSymbol, "System.Byte") ||
                   IsSymbol(typeSymbol, "System.Int16") ||
                   IsSymbol(typeSymbol, "System.Int32") ||
                   IsSymbol(typeSymbol, "System.Int64") ||
                   IsSymbol(typeSymbol, "System.SByte") ||
                   IsSymbol(typeSymbol, "System.UInt16") ||
                   IsSymbol(typeSymbol, "System.UInt32") ||
                   IsSymbol(typeSymbol, "System.UInt64");
        }

        private static bool IsSymbol(TypeSymbol typeSymbol, string name)
        {
            return typeSymbol.SymbolSet.IsSymbol(typeSymbol, name);
        }

        private static bool IsVoid(TypeSymbol typeSymbol)
        {
            return IsSymbol(typeSymbol, "System.Void");
        }
    }
}