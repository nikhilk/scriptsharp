// MemberGenerator.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal static class MemberGenerator {

        private static void GenerateEvent(ScriptGenerator generator, string typeName, EventSymbol eventSymbol) {
            ScriptTextWriter writer = generator.Writer;

            ParameterSymbol valueParameter = eventSymbol.Parameters[0];
            if (generator.Options.Minimize) {
                bool obfuscateParams = !eventSymbol.IsPublic;
                if (obfuscateParams) {
                    valueParameter.SetTransformedName("$p0");
                }
            }

            string eventName = eventSymbol.GeneratedName;
            string fieldName = eventName;
            if (eventSymbol.DefaultImplementation) {
                fieldName = "__" + Utility.CreateCamelCaseName(eventSymbol.Name);

                Debug.Assert(eventSymbol.Parent.Type == SymbolType.Class);

                Symbol fieldSymbol = ((ClassSymbol)eventSymbol.Parent).GetMember(fieldName);
                Debug.Assert((fieldSymbol != null) && (fieldSymbol.Type == SymbolType.Field));

                fieldName = fieldSymbol.GeneratedName;
            }

            string fieldReference;
            if ((eventSymbol.Visibility & MemberVisibility.Static) == 0) {
                fieldReference = "this.";
            }
            else {
                fieldReference = typeName + ".";
            }
            fieldReference += fieldName;

            bool instanceMember = true;
            if ((eventSymbol.Visibility & MemberVisibility.Static) != 0) {
                instanceMember = false;
                writer.Write(typeName);
                writer.Write(".");
            }

            writer.Write("add_");
            writer.Write(eventName);
            if (instanceMember) {
                writer.WriteTrimmed(": ");
            }
            else {
                writer.WriteTrimmed(" = ");
            }
            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(typeName.Replace(".", "_"));
                writer.Write("$add_");
                writer.Write(eventName);
            }
            writer.Write("(");
            writer.Write(valueParameter.GeneratedName);
            writer.Write(")");
            writer.WriteTrimmed(" {");
            writer.WriteNewLine();
            writer.Indent++;

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, eventSymbol);
            }

            if (eventSymbol.DefaultImplementation) {
                writer.Write(fieldReference);
                writer.WriteTrimmed(" = ");
                writer.Write("ss.Delegate.combine(");
                writer.Write(fieldReference);
                writer.WriteTrimmed(", ");
                writer.Write(valueParameter.GeneratedName);
                writer.Write(");");
                writer.WriteNewLine();
            }
            else {
                CodeGenerator.GenerateScript(generator, eventSymbol, /* add */ true);
            }
            writer.Indent--;
            writer.Write("}");

            if (instanceMember == false) {
                writer.WriteSignificantNewLine();
            }

            if (instanceMember) {
                writer.Write(",");
                writer.WriteNewLine();
            }
            else {
                writer.Write(typeName);
                writer.Write(".");
            }
            writer.Write("remove_");
            writer.Write(eventName);
            if (instanceMember) {
                writer.WriteTrimmed(": ");
            }
            else {
                writer.WriteTrimmed(" = ");
            }
            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(typeName.Replace(".", "_"));
                writer.Write("$remove_");
                writer.Write(eventName);
            }
            writer.Write("(");
            writer.Write(valueParameter.GeneratedName);
            writer.Write(")");
            writer.WriteTrimmed(" {");
            writer.WriteNewLine();
            writer.Indent++;

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, eventSymbol);
            }

            if (eventSymbol.DefaultImplementation) {
                writer.Write(fieldReference);
                writer.WriteTrimmed(" = ");
                writer.Write("ss.Delegate.remove(");
                writer.Write(fieldReference);
                writer.WriteTrimmed(", ");
                writer.Write(valueParameter.GeneratedName);
                writer.Write(");");
                writer.WriteNewLine();
            }
            else {
                CodeGenerator.GenerateScript(generator, eventSymbol, /* add */ false);
            }
            writer.Indent--;
            writer.Write("}");

            if (instanceMember == false) {
                writer.WriteSignificantNewLine();
            }
        }

        private static void GenerateField(ScriptGenerator generator, string typeName, FieldSymbol fieldSymbol) {
            ScriptTextWriter writer = generator.Writer;

            bool instanceMember = true;
            if ((fieldSymbol.Visibility & MemberVisibility.Static) != 0) {
                instanceMember = false;
                writer.Write(typeName);
                writer.Write(".");
            }

            writer.Write(fieldSymbol.GeneratedName);
            if (instanceMember) {
                writer.WriteTrimmed(": ");
            }
            else {
                writer.WriteTrimmed(" = ");
            }
            CodeGenerator.GenerateScript(generator, fieldSymbol);

            if (instanceMember == false) {
                writer.Write(";");
                writer.WriteNewLine();
            }
        }

        private static void GenerateIndexer(ScriptGenerator generator, string typeName, PropertySymbol indexerSymbol) {
            if (indexerSymbol.IsAbstract) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            bool instanceMember = true;
            if ((indexerSymbol.Visibility & MemberVisibility.Static) != 0) {
                instanceMember = false;
                writer.Write(typeName);
                writer.Write(".");
            }

            bool obfuscateParams = !indexerSymbol.IsPublic;
            if (obfuscateParams && generator.Options.Minimize) {
                for (int i = 0; i < indexerSymbol.Parameters.Count; i++) {
                    ParameterSymbol parameterSymbol = indexerSymbol.Parameters[i];
                    parameterSymbol.SetTransformedName("$p" + i);
                }
            }

            writer.Write("get_");
            writer.Write(indexerSymbol.GeneratedName);
            if (instanceMember) {
                writer.WriteTrimmed(": ");
            }
            else {
                writer.WriteTrimmed(" = ");
            }

            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(typeName.Replace(".", "_"));
                writer.Write("$get_");
                writer.Write(indexerSymbol.GeneratedName);
            }

            writer.Write("(");

            for (int i = 0; i < indexerSymbol.Parameters.Count - 1; i++) {
                ParameterSymbol parameterSymbol = indexerSymbol.Parameters[i];
                if (i > 0) {
                    writer.WriteTrimmed(", ");
                }
                writer.Write(parameterSymbol.GeneratedName);
            }

            writer.Write(")");
            writer.WriteTrimmed(" {");
            writer.WriteNewLine();
            writer.Indent++;

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, indexerSymbol);
            }

            CodeGenerator.GenerateScript(generator, (IndexerSymbol)indexerSymbol, /* getter */ true);
            writer.Indent--;
            writer.Write("}");

            if (instanceMember == false) {
                writer.WriteSignificantNewLine();
            }

            if (indexerSymbol.IsReadOnly == false) {
                if (instanceMember) {
                    writer.Write(",");
                    writer.WriteNewLine();
                }
                else {
                    writer.Write(typeName);
                    writer.Write(".");
                }

                writer.Write("set_");
                writer.Write(indexerSymbol.GeneratedName);
                if (instanceMember) {
                    writer.WriteTrimmed(": ");
                }
                else {
                    writer.WriteTrimmed(" = ");
                }
                writer.Write("function");
                if (generator.Options.DebugFlavor) {
                    writer.Write(" ");
                    writer.Write(typeName.Replace(".", "_"));
                    writer.Write("$set_");
                    writer.Write(indexerSymbol.GeneratedName);
                }
                writer.Write("(");
                for (int i = 0; i < indexerSymbol.Parameters.Count; i++) {
                    ParameterSymbol parameterSymbol = indexerSymbol.Parameters[i];
                    if (i > 0) {
                        writer.WriteTrimmed(", ");
                    }
                    writer.Write(parameterSymbol.GeneratedName);
                }
                writer.Write(")");
                writer.WriteTrimmed(" {");
                writer.WriteNewLine();
                writer.Indent++;

                if (generator.Options.EnableDocComments) {
                    DocCommentGenerator.GenerateComment(generator, indexerSymbol);
                }

                CodeGenerator.GenerateScript(generator, (IndexerSymbol)indexerSymbol, /* getter */ false);
                writer.Write("return ");
                writer.Write(indexerSymbol.Parameters[indexerSymbol.Parameters.Count - 1].GeneratedName);
                writer.Write(";");
                writer.WriteNewLine();
                writer.Indent--;
                writer.Write("}");

                if (instanceMember == false) {
                    writer.WriteSignificantNewLine();
                }
            }
        }

        private static void GenerateMethod(ScriptGenerator generator, string typeName, MethodSymbol methodSymbol) {
            if (methodSymbol.IsAbstract) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            bool instanceMember = ((methodSymbol.Visibility & MemberVisibility.Static) == 0);
            if (instanceMember == false) {
                if (methodSymbol.IsGlobalMethod) {
                    string mixinRoot = null;
                    if (methodSymbol.Parent.Type == SymbolType.Class) {
                        mixinRoot = ((ClassSymbol)methodSymbol.Parent).MixinRoot;
                    }
                    if (String.IsNullOrEmpty(mixinRoot)) {
                        mixinRoot = "window";
                    }

                    writer.Write(mixinRoot);
                }
                else {
                    writer.Write(typeName);
                }

                writer.Write(".");
            }

            writer.Write(methodSymbol.GeneratedName);
            if (instanceMember) {
                writer.WriteTrimmed(": ");
            }
            else {
                writer.WriteTrimmed(" = ");
            }

            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(typeName.Replace(".", "_"));
                writer.Write("$");
                writer.Write(methodSymbol.GeneratedName);
            }
            writer.Write("(");
            if (methodSymbol.Parameters != null) {
                bool obfuscateParams = false;
                if (generator.Options.Minimize) {
                    obfuscateParams = !methodSymbol.IsPublic;
                }

                int paramIndex = 0;
                foreach (ParameterSymbol parameterSymbol in methodSymbol.Parameters) {
                    if (paramIndex > 0) {
                        writer.WriteTrimmed(", ");
                    }
                    if (obfuscateParams) {
                        parameterSymbol.SetTransformedName("$p" + paramIndex);
                    }
                    writer.Write(parameterSymbol.GeneratedName);

                    paramIndex++;
                }
            }
            writer.WriteTrimmed(") ");
            writer.Write("{");
            writer.WriteNewLine();
            writer.Indent++;

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, methodSymbol);
            }

            CodeGenerator.GenerateScript(generator, methodSymbol);
            writer.Indent--;
            writer.Write("}");

            if (instanceMember == false) {
                writer.WriteSignificantNewLine();
            }
        }

        private static void GenerateProperty(ScriptGenerator generator, string typeName, PropertySymbol propertySymbol) {
            if (propertySymbol.IsAbstract) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            bool instanceMember = true;
            if ((propertySymbol.Visibility & MemberVisibility.Static) != 0) {
                instanceMember = false;
                writer.Write(typeName);
                writer.Write(".");
            }

            writer.Write("get_");
            writer.Write(propertySymbol.GeneratedName);
            if (instanceMember) {
                writer.WriteTrimmed(": ");
            }
            else {
                writer.WriteTrimmed(" = ");
            }
            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(typeName.Replace(".", "_"));
                writer.Write("$get_");
                writer.Write(propertySymbol.GeneratedName);
            }
            writer.Write("()");
            writer.WriteTrimmed(" {");
            writer.WriteNewLine();
            writer.Indent++;

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, propertySymbol);
            }

            CodeGenerator.GenerateScript(generator, propertySymbol, /* getter */ true);
            writer.Indent--;
            writer.Write("}");

            if (instanceMember == false) {
                writer.WriteSignificantNewLine();
            }

            if (propertySymbol.IsReadOnly == false) {
                ParameterSymbol valueParameter = propertySymbol.Parameters[0];
                if (generator.Options.Minimize) {
                    bool obfuscateParams = !propertySymbol.IsPublic;
                    if (obfuscateParams) {
                        valueParameter.SetTransformedName("$p0");
                    }
                }

                if (instanceMember) {
                    writer.Write(",");
                    writer.WriteNewLine();
                }
                else {
                    writer.Write(typeName);
                    writer.Write(".");
                }

                writer.Write("set_");
                writer.Write(propertySymbol.GeneratedName);
                if (instanceMember) {
                    writer.WriteTrimmed(": ");
                }
                else {
                    writer.WriteTrimmed(" = ");
                }
                writer.Write("function");
                if (generator.Options.DebugFlavor) {
                    writer.Write(" ");
                    writer.Write(typeName.Replace(".", "_"));
                    writer.Write("$set_");
                    writer.Write(propertySymbol.GeneratedName);
                }
                writer.Write("(");
                writer.Write(valueParameter.GeneratedName);
                writer.Write(")");
                writer.WriteTrimmed(" {");
                writer.WriteNewLine();
                writer.Indent++;

                if (generator.Options.EnableDocComments) {
                    DocCommentGenerator.GenerateComment(generator, propertySymbol);
                }

                CodeGenerator.GenerateScript(generator, propertySymbol, /* getter */ false);
                writer.Write("return ");
                writer.Write(valueParameter.GeneratedName);
                writer.Write(";");
                writer.WriteNewLine();
                writer.Indent--;
                writer.Write("}");

                if (instanceMember == false) {
                    writer.WriteSignificantNewLine();
                }
            }
        }

        public static void GenerateScript(ScriptGenerator generator, MemberSymbol memberSymbol) {
            Debug.Assert(memberSymbol.Parent is TypeSymbol);
            TypeSymbol typeSymbol = (TypeSymbol)memberSymbol.Parent;

            string typeName = typeSymbol.FullGeneratedName;

            switch (memberSymbol.Type) {
                case SymbolType.Field:
                    GenerateField(generator, typeName, (FieldSymbol)memberSymbol);
                    break;
                case SymbolType.Indexer:
                    GenerateIndexer(generator, typeName, (IndexerSymbol)memberSymbol);
                    break;
                case SymbolType.Property:
                    GenerateProperty(generator, typeName, (PropertySymbol)memberSymbol);
                    break;
                case SymbolType.Method:
                    GenerateMethod(generator, typeName, (MethodSymbol)memberSymbol);
                    break;
                case SymbolType.Event:
                    GenerateEvent(generator, typeName, (EventSymbol)memberSymbol);
                    break;
            }
        }
    }
}
