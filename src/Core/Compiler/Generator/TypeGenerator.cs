// TypeGenerator.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal static class TypeGenerator {

        private static void GenerateClass(ScriptGenerator generator, ClassSymbol classSymbol) {
            if (classSymbol.HasGlobalMethods) {
                GenerateGlobalMethods(generator, classSymbol);
                generator.AddGeneratedClass(classSymbol);
                return;
            }

            ScriptTextWriter writer = generator.Writer;
            string name = classSymbol.FullGeneratedName;

            if (classSymbol.Namespace.Length == 0) {
                writer.Write("window.");
            }

            writer.Write(name);
            writer.WriteTrimmed(" = ");
            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(name.Replace(".", "_"));
            }
            writer.Write("(");
            if ((classSymbol.Constructor != null) && (classSymbol.Constructor.Parameters != null)) {
                bool firstParameter = true;
                foreach (ParameterSymbol parameterSymbol in classSymbol.Constructor.Parameters) {
                    if (firstParameter == false) {
                        writer.WriteTrimmed(", ");
                    }
                    writer.Write(parameterSymbol.GeneratedName);
                    firstParameter = false;
                }
            }
            writer.WriteTrimmed(") ");
            writer.Write("{");
            writer.WriteNewLine();
            writer.Indent++;

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, classSymbol);
            }

            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                if ((memberSymbol.Type == SymbolType.Field) &&
                    (memberSymbol.Visibility & MemberVisibility.Static) == 0) {
                    FieldSymbol fieldSymbol = (FieldSymbol)memberSymbol;
                    if (fieldSymbol.HasInitializer) {
                        writer.Write("this.");
                        writer.Write(fieldSymbol.GeneratedName);
                        writer.WriteTrimmed(" = ");
                        CodeGenerator.GenerateScript(generator, fieldSymbol);
                        writer.Write(";");
                        writer.WriteNewLine();
                    }
                }
            }
            if (classSymbol.Constructor != null) {
                CodeGenerator.GenerateScript(generator, classSymbol.Constructor);
            }
            else if (classSymbol.BaseClass != null) {
                writer.Write(classSymbol.FullGeneratedName);
                writer.Write(".initializeBase(this);");
                writer.WriteNewLine();
            }
            writer.Indent--;
            writer.Write("}");
            writer.WriteSignificantNewLine();

            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                if ((memberSymbol.Type != SymbolType.Field) &&
                    (memberSymbol.Visibility & MemberVisibility.Static) != 0) {
                    MemberGenerator.GenerateScript(generator, memberSymbol);
                }
            }

            bool hasPrototypeMembers = false;
            bool firstMember = true;
            bool lastMemberWasField = true;
            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                if ((memberSymbol.Visibility & MemberVisibility.Static) == 0) {
                    if ((memberSymbol.Type == SymbolType.Field) &&
                        ((FieldSymbol)memberSymbol).HasInitializer) {
                        continue;
                    }

                    if ((memberSymbol is CodeMemberSymbol) &&
                        ((CodeMemberSymbol)memberSymbol).IsAbstract) {
                        continue;
                    }

                    if (hasPrototypeMembers == false) {
                        hasPrototypeMembers = true;

                        writer.Write(name);
                        writer.Write(".prototype");
                        writer.WriteTrimmed(" = ");
                        writer.Write("{");
                        writer.WriteNewLine();
                        writer.Indent++;
                    }

                    if (firstMember == false) {
                        writer.Write(",");
                        writer.WriteNewLine();
                    }
                    if ((lastMemberWasField == false) || !(memberSymbol is FieldSymbol)) {
                        writer.WriteNewLine();
                    }

                    MemberGenerator.GenerateScript(generator, memberSymbol);
                    lastMemberWasField = (memberSymbol is FieldSymbol);
                    firstMember = false;
                }
            }

            if (classSymbol.Indexer != null) {
                if (hasPrototypeMembers == false) {
                    hasPrototypeMembers = true;

                    writer.Write(name);
                    writer.Write(".prototype");
                    writer.WriteTrimmed(" = ");
                    writer.Write("{");
                    writer.WriteNewLine();
                    writer.Indent++;
                
                }
                if (firstMember == false) {
                    writer.Write(",");
                    writer.WriteNewLine();
                }

                MemberGenerator.GenerateScript(generator, classSymbol.Indexer);
            }

            if (hasPrototypeMembers) {
                writer.Indent--;
                writer.WriteNewLine();
                writer.Write("}");
                writer.WriteSignificantNewLine();
            }

            generator.AddGeneratedClass(classSymbol);
        }

        private static void GenerateDelegate(ScriptGenerator generator, DelegateSymbol delegateSymbol) {
            // No-op
            // There is currently nothing to generate for a particular delegate type
        }

        private static void GenerateEnumeration(ScriptGenerator generator, EnumerationSymbol enumSymbol) {
            ScriptTextWriter writer = generator.Writer;

            if (enumSymbol.Namespace.Length == 0) {
                writer.Write("window.");
            }

            writer.Write(enumSymbol.FullGeneratedName);
            writer.WriteTrimmed(" = ");
            writer.Write("function()");
            writer.WriteTrimmed(" { ");

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, enumSymbol);
            }

            writer.Write("};");
            writer.WriteNewLine();
            writer.Write(enumSymbol.FullGeneratedName);
            writer.Write(".prototype = {");
            writer.Indent++;

            bool firstValue = true;
            foreach (MemberSymbol memberSymbol in enumSymbol.Members) {
                EnumerationFieldSymbol fieldSymbol = memberSymbol as EnumerationFieldSymbol;
                if (fieldSymbol == null) {
                    continue;
                }

                if (firstValue == false) {
                    writer.WriteTrimmed(", ");
                }

                writer.WriteNewLine();
                writer.Write(fieldSymbol.GeneratedName);
                writer.WriteTrimmed(": ");
                if (enumSymbol.UseNamedValues) {
                    writer.Write(Utility.QuoteString(enumSymbol.CreateNamedValue(fieldSymbol)));
                }
                else {
                    writer.Write(fieldSymbol.Value);
                }
                firstValue = false;
            }

            writer.Indent--;
            writer.WriteNewLine();
            writer.WriteTrimmed("}");
            writer.WriteSignificantNewLine();

            writer.Write(enumSymbol.FullGeneratedName);
            writer.Write(".registerEnum('");
            writer.Write(enumSymbol.FullGeneratedName);
            writer.WriteTrimmed("', ");
            writer.Write(enumSymbol.Flags ? "true" : "false");
            writer.Write(");");
            writer.WriteNewLine();
        }

        private static void GenerateInterface(ScriptGenerator generator, InterfaceSymbol interfaceSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string interfaceName = interfaceSymbol.FullGeneratedName;

            if (interfaceSymbol.Namespace.Length == 0) {
                writer.Write("window.");
            }

            writer.Write(interfaceName);
            writer.WriteTrimmed(" = ");
            writer.Write("function()");
            writer.WriteTrimmed(" { ");

            if (generator.Options.EnableDocComments) {
                DocCommentGenerator.GenerateComment(generator, interfaceSymbol);
            }

            writer.Write("};");
            writer.WriteNewLine();

            if (generator.Options.DebugFlavor) {
                writer.Write(interfaceName);
                writer.Write(".prototype = {");
                writer.WriteLine();
                writer.Indent++;
                bool firstMember = true;
                foreach (MemberSymbol member in interfaceSymbol.Members) {
                    if (firstMember == false) {
                        writer.Write(",");
                        writer.WriteLine();
                    }

                    if (member.Type == SymbolType.Property) {
                        writer.Write("get_");
                        writer.Write(member.GeneratedName);
                        writer.WriteTrimmed(" : ");
                        writer.Write("null");

                        if (((PropertySymbol)member).IsReadOnly == false) {
                            writer.Write(",");
                            writer.WriteLine();

                            writer.Write("set_");
                            writer.Write(member.GeneratedName);
                            writer.WriteTrimmed(" : ");
                            writer.Write("null");
                        }
                    }
                    else if (member.Type == SymbolType.Event) {
                        writer.Write("add_");
                        writer.Write(member.GeneratedName);
                        writer.WriteTrimmed(" : ");
                        writer.Write("null,");
                        writer.WriteLine();

                        writer.Write("remove_");
                        writer.Write(member.GeneratedName);
                        writer.WriteTrimmed(" : ");
                        writer.Write("null");
                    }
                    else {
                        writer.Write(member.GeneratedName);
                        writer.WriteTrimmed(" : ");
                        writer.Write("null");
                    }
                    firstMember = false;
                }
                writer.Indent--;
                writer.WriteLine();
                writer.Write("}");
                writer.WriteSignificantNewLine();
            }

            writer.Write(interfaceName);
            writer.Write(".registerInterface('");
            writer.Write(interfaceName);
            writer.Write("');");
            writer.WriteNewLine();
        }

        public static void GenerateClassConstructorScript(ScriptGenerator generator, ClassSymbol classSymbol) {
            // NOTE: This is emitted last in the script file, and separate from the initial class definition
            //       because it needs to be emitted after the class registration.

            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                if ((memberSymbol.Type == SymbolType.Field) &&
                    ((memberSymbol.Visibility & MemberVisibility.Static) != 0)) {
                    if (((FieldSymbol)memberSymbol).IsConstant &&
                        ((memberSymbol.Visibility & (MemberVisibility.Public | MemberVisibility.Protected)) == 0)) {
                        // PrivateInstance/Internal constant fields are omitted since they have been inlined
                        continue;
                    }

                    MemberGenerator.GenerateScript(generator, memberSymbol);
                }
            }

            if (classSymbol.StaticConstructor != null) {
                ScriptTextWriter writer = generator.Writer;

                SymbolImplementation implementation = classSymbol.StaticConstructor.Implementation;
                bool requiresFunctionScope = implementation.DeclaresVariables;

                if (requiresFunctionScope) {
                    writer.Write("(function");
                    writer.WriteTrimmed(" () ");
                    writer.Write("{");
                    writer.WriteNewLine();
                    writer.Indent++;
                }
                CodeGenerator.GenerateScript(generator, classSymbol.StaticConstructor);
                if (requiresFunctionScope) {
                    writer.Indent--;
                    writer.Write("})();");
                    writer.WriteSignificantNewLine();
                }
            }
        }

        public static void GenerateClassRegistrationScript(ScriptGenerator generator, ClassSymbol classSymbol) {
            // NOTE: This is emitted towards the end of the script file as opposed to immediately after the
            //       class definition, because it allows us to reference other class (base class, interfaces)
            //       without having to do a manual topological sort to get the ordering of class definitions
            //       that would be needed otherwise.

            ScriptTextWriter writer = generator.Writer;
            string name = classSymbol.FullGeneratedName;

            writer.Write(name);
            writer.Write(".registerClass('");
            writer.Write(name);
            writer.Write("'");

            // TODO: We need to introduce the notion of a base class that only exists in the metadata
            //       and not at runtime. At that point this check of IsTestClass can be generalized.
            if (classSymbol.IsTestClass) {
                writer.Write(");");
                writer.WriteNewLine();

                return;
            }

            if (classSymbol.BaseClass != null) {
                writer.WriteTrimmed(", ");
                writer.Write(classSymbol.BaseClass.FullGeneratedName);
            }

            if (classSymbol.Interfaces != null) {
                if (classSymbol.BaseClass == null) {
                    writer.WriteTrimmed(", ");
                    writer.Write("null");
                }
                foreach (InterfaceSymbol interfaceSymbol in classSymbol.Interfaces) {
                    writer.WriteTrimmed(", ");
                    writer.Write(interfaceSymbol.FullGeneratedName);
                }
            }

            writer.Write(");");
            writer.WriteNewLine();
        }

        private static void GenerateGlobalMethods(ScriptGenerator generator, ClassSymbol classSymbol) {
            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                Debug.Assert(memberSymbol.Type == SymbolType.Method);
                Debug.Assert((memberSymbol.Visibility & MemberVisibility.Static) != 0);

                MemberGenerator.GenerateScript(generator, memberSymbol);
            }
        }

        private static void GenerateRecord(ScriptGenerator generator, RecordSymbol recordSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string recordName = recordSymbol.GeneratedName;

            if ((recordSymbol.Namespace.Length == 0) || recordSymbol.IgnoreNamespace) {
                writer.Write("window.");
            }
            else {
                writer.Write(recordSymbol.GeneratedNamespace);
                writer.Write(".");
            }
            writer.Write("$create_");
            writer.Write(recordName);
            writer.WriteTrimmed(" = ");
            writer.Write("function");
            if (generator.Options.DebugFlavor) {
                writer.Write(" ");
                writer.Write(recordSymbol.FullGeneratedName.Replace(".", "_"));
            }
            writer.Write("(");
            if (recordSymbol.Constructor != null) {
                ConstructorSymbol ctorSymbol = recordSymbol.Constructor;

                if (ctorSymbol.Parameters != null) {
                    bool firstParameter = true;
                    foreach (ParameterSymbol parameterSymbol in ctorSymbol.Parameters) {
                        if (firstParameter == false) {
                            writer.WriteTrimmed(", ");
                        }
                        writer.Write(parameterSymbol.GeneratedName);
                        firstParameter = false;
                    }
                }
            }
            writer.WriteTrimmed(")");
            writer.WriteTrimmed(" {");
            if (recordSymbol.Constructor != null) {
                writer.Indent++;
                writer.WriteNewLine();
                writer.Write("var $o");
                writer.WriteTrimmed(" = ");
                writer.WriteTrimmed("{ ");
                writer.Write("};");
                writer.WriteNewLine();
                CodeGenerator.GenerateScript(generator, recordSymbol.Constructor);
                writer.Write("return $o;");
                writer.WriteNewLine();
                writer.Indent--;
            }
            else {
                writer.WriteTrimmed(" return {}; ");
            }
            writer.Write("}");
            writer.WriteSignificantNewLine();
        }

        private static void GenerateResources(ScriptGenerator generator, ResourcesSymbol resourcesSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string resourcesName = resourcesSymbol.FullGeneratedName;

            writer.Write(resourcesName);
            writer.WriteTrimmed(" = ");
            writer.WriteTrimmed("{ ");
            writer.WriteNewLine();
            writer.Indent++;

            bool firstValue = true;
            foreach (FieldSymbol member in resourcesSymbol.Members) {
                Debug.Assert(member.Value is string);

                if (firstValue == false) {
                    writer.Write(",");
                    writer.WriteLine();
                }

                writer.Write(member.GeneratedName);
                writer.WriteTrimmed(": ");
                writer.Write(Utility.QuoteString((string)member.Value));

                firstValue = false;
            }

            writer.Indent--;
            writer.WriteLine();
            writer.Write("};");
            writer.WriteNewLine();
        }

        public static void GenerateScript(ScriptGenerator generator, TypeSymbol typeSymbol) {
            Debug.Assert(generator != null);
            Debug.Assert(typeSymbol != null);
            Debug.Assert(typeSymbol.IsApplicationType);

            if ((typeSymbol.Type == SymbolType.Enumeration) && (typeSymbol.IsPublic == false)) {
                // Internal enums can be skipped since their values have been inlined.
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            if (generator.Options.Minimize == false) {
                writer.WriteLine(new String('/', 80));
                writer.WriteLine("// " + typeSymbol.FullGeneratedName);
                writer.WriteLine();
            }

            switch (typeSymbol.Type) {
                case SymbolType.Class:
                    GenerateClass(generator, (ClassSymbol)typeSymbol);
                    break;
                case SymbolType.Interface:
                    GenerateInterface(generator, (InterfaceSymbol)typeSymbol);
                    break;
                case SymbolType.Enumeration:
                    GenerateEnumeration(generator, (EnumerationSymbol)typeSymbol);
                    break;
                case SymbolType.Delegate:
                    GenerateDelegate(generator, (DelegateSymbol)typeSymbol);
                    break;
                case SymbolType.Record:
                    GenerateRecord(generator, (RecordSymbol)typeSymbol);
                    break;
                case SymbolType.Resources:
                    GenerateResources(generator, (ResourcesSymbol)typeSymbol);
                    break;
            }

            writer.WriteNewLine();
            writer.WriteNewLine();
        }
    }
}
