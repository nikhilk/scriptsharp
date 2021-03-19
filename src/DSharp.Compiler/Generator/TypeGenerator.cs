// TypeGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal static class TypeGenerator
    {
        private static void GenerateClass(ScriptGenerator generator, ClassSymbol classSymbol)
        {
            ScriptTextWriter writer = generator.Writer;
            string name = classSymbol.FullGeneratedName;

            GenerateClassConstructor(generator, classSymbol, writer, name);
            GenerateClassStaticMembers(generator, classSymbol);

            GenerateClassMembers(generator, classSymbol, writer, name);
        }

        private static void GenerateClassMembers(ScriptGenerator generator, ClassSymbol classSymbol, ScriptTextWriter writer, string name)
        {
            if (classSymbol.IsStaticClass)
            {
                return;
            }

            writer.Write("var ");
            writer.Write(name);
            writer.WriteLine("$ = {");
            writer.Indent++;

            bool firstMember = true;

            foreach (MemberSymbol memberSymbol in classSymbol.Members.Where(member => !member.Visibility.HasFlag(MemberVisibility.Static)))
            {
                if (memberSymbol.Type == SymbolType.Field
                    || (memberSymbol is CodeMemberSymbol codeMemberSymbol && codeMemberSymbol.IsAbstract)
                    || (memberSymbol is PropertySymbol propertySymbol && propertySymbol.IsAutoProperty()))
                {
                    continue;
                }

                if (firstMember == false)
                {
                    writer.WriteLine(",");
                }

                MemberGenerator.GenerateScript(generator, memberSymbol);
                firstMember = false;
            }

            if (classSymbol.Indexer != null)
            {
                if (firstMember == false)
                {
                    writer.WriteLine(",");
                }

                MemberGenerator.GenerateScript(generator, classSymbol.Indexer);
            }

            writer.Indent--;
            writer.WriteLine();
            writer.Write("};");
            writer.WriteLine();

        }

        private static void GenerateClassStaticMembers(ScriptGenerator generator, ClassSymbol classSymbol)
        {
            foreach (MemberSymbol memberSymbol in classSymbol.Members)
            {
                if (memberSymbol.Type != SymbolType.Field && memberSymbol.Visibility.HasFlag(MemberVisibility.Static))
                {
                    MemberGenerator.GenerateScript(generator, memberSymbol);
                }
            }
        }

        private static void GenerateClassConstructor(ScriptGenerator generator, ClassSymbol classSymbol, ScriptTextWriter writer, string name)
        {
            var ctorSymbol = classSymbol.Constructor;

            if (HasParamsModifier(ctorSymbol))
            {
                writer.Write($"var {name} = ss.namedFunction('{name}',");
                writer.Write($"{DSharpStringResources.ScriptExportMember("paramsGenerator")}(");
                writer.Write($"{ctorSymbol.GetGeneratedParamsCount()}, function");
            }
            else
            {
                writer.Write("function ");
                writer.Write(name);
            }

            writer.Write("(");

            if (ctorSymbol != null && ctorSymbol.Parameters != null)
            {
                bool firstParameter = true;

                foreach (ParameterSymbol parameterSymbol in ctorSymbol.Parameters)
                {
                    if (firstParameter == false)
                    {
                        writer.Write(", ");
                    }

                    writer.Write(parameterSymbol.GeneratedName);
                    firstParameter = false;
                }
            }

            writer.WriteLine(") {");
            writer.Indent++;

            if (generator.Options.EnableDocComments)
            {
                DocCommentGenerator.GenerateComment(generator, classSymbol);
            }

            foreach (var property in GetNonReadonlyAutoProperties(classSymbol))
            {
                writer.Write(DSharpStringResources.ScriptExportMember("defineProperty"));
                writer.Write($"(this, '{property.GeneratedName}', ");

                var initialValueExpression = Compiler.ImplementationBuilder.GetDefaultValueExpression(property.AssociatedType, property.SymbolSet);
                ExpressionGenerator.GenerateLiteralExpression(generator, property, initialValueExpression);

                writer.Write(");");
                writer.WriteLine();
            }

            foreach (MemberSymbol memberSymbol in classSymbol.Members)
            {
                if (memberSymbol.Type == SymbolType.Field &&
                    (memberSymbol.Visibility & MemberVisibility.Static) == 0)
                {
                    FieldSymbol fieldSymbol = (FieldSymbol)memberSymbol;

                    if (fieldSymbol.HasInitializer)
                    {
                        writer.Write("this.");
                        writer.Write(fieldSymbol.GeneratedName);
                        writer.Write(" = ");
                        CodeGenerator.GenerateScript(generator, fieldSymbol);
                        writer.Write(";");
                        writer.WriteLine();
                    }
                }
            }

            if (ctorSymbol != null)
            {
                CodeGenerator.GenerateScript(generator, ctorSymbol);
            }
            else if (classSymbol.BaseClass is ClassSymbol baseClass)
            {
                ExpressionGenerator.WriteFullTypeName(writer, baseClass);
                writer.WriteLine(".call(this);");
            }

            writer.Indent--;
            writer.WriteLine("}");

            if (HasParamsModifier(ctorSymbol))
            {
                writer.WriteLine($"));");
            }
        }

        private static IEnumerable<PropertySymbol> GetNonReadonlyAutoProperties(ClassSymbol classSymbol)
        {
            return classSymbol.Members
                .Where(symbol => symbol is PropertySymbol)
                .Cast<PropertySymbol>()
                .Where(prop => prop.IsAutoProperty() && !prop.IsReadOnly && !prop.IsAbstract && !prop.Visibility.HasFlag(MemberVisibility.Static));
        }

        private static void GenerateEnumeration(ScriptGenerator generator, EnumerationSymbol enumSymbol)
        {
            ScriptTextWriter writer = generator.Writer;
            string enumName = enumSymbol.FullGeneratedName;

            writer.Write("var ");
            writer.Write(enumName);
            writer.Write(" = new ");
            writer.Write(DSharpStringResources.ScriptExportMember("Enum"));
            writer.Write("('");
            writer.Write(enumName);
            writer.Write("', ");
            writer.Write("{");
            writer.Indent++;

            bool firstValue = true;

            foreach (MemberSymbol memberSymbol in enumSymbol.Members)
            {
                if (!(memberSymbol is EnumerationFieldSymbol fieldSymbol))
                {
                    continue;
                }

                if (firstValue == false)
                {
                    writer.Write(", ");
                }

                writer.WriteLine();
                writer.Write(fieldSymbol.GeneratedName);
                writer.Write(": ");

                if (enumSymbol.UseNamedValues)
                {
                    writer.Write(Utility.QuoteString(enumSymbol.CreateNamedValue(fieldSymbol)));
                }
                else
                {
                    writer.Write(fieldSymbol.Value);
                }

                firstValue = false;
            }

            writer.Indent--;
            writer.WriteLine();
            writer.Write("});");
            writer.WriteLine();
        }

        private static void GenerateInterface(ScriptGenerator generator, InterfaceSymbol interfaceSymbol)
        {
            ScriptTextWriter writer = generator.Writer;
            string interfaceName = interfaceSymbol.FullGeneratedName;

            writer.Write("function ");
            writer.Write(interfaceName);
            writer.WriteLine("() { }");
        }

        public static void GenerateClassConstructorScript(ScriptGenerator generator, ClassSymbol classSymbol)
        {
            // NOTE: This is emitted last in the script file, and separate from the initial class definition
            //       because it needs to be emitted after the class registration.

            foreach (MemberSymbol memberSymbol in classSymbol.Members)
                if (memberSymbol.Type == SymbolType.Field &&
                    (memberSymbol.Visibility & MemberVisibility.Static) != 0)
                {
                    FieldSymbol fieldSymbol = (FieldSymbol)memberSymbol;

                    if (fieldSymbol.IsConstant &&
                        (memberSymbol.Visibility & (MemberVisibility.Public | MemberVisibility.Protected)) == 0)
                    {
                        // PrivateInstance/Internal constant fields are omitted since they have been inlined
                        continue;
                    }

                    if (fieldSymbol.HasInitializer)
                    {
                        MemberGenerator.GenerateScript(generator, memberSymbol);
                    }
                }

            if (classSymbol.StaticConstructor != null)
            {
                ScriptTextWriter writer = generator.Writer;

                SymbolImplementation implementation = classSymbol.StaticConstructor.Implementation;
                bool requiresFunctionScope = implementation.DeclaresVariables;

                if (requiresFunctionScope)
                {
                    writer.WriteLine("(function() {");
                    writer.Indent++;
                }

                CodeGenerator.GenerateScript(generator, classSymbol.StaticConstructor);

                if (requiresFunctionScope)
                {
                    writer.Indent--;
                    writer.Write("})();");
                    writer.WriteLine();
                }
            }
        }

        private static void GenerateRecord(ScriptGenerator generator, RecordSymbol recordSymbol)
        {
            ScriptTextWriter writer = generator.Writer;
            string recordName = recordSymbol.FullGeneratedName;

            writer.Write("function ");
            writer.Write(recordName);
            writer.Write("(");

            ConstructorSymbol ctorSymbol = recordSymbol.Constructor;

            if (ctorSymbol?.Parameters != null)
            {
                bool firstParameter = true;

                foreach (ParameterSymbol parameterSymbol in ctorSymbol.Parameters)
                {
                    if (firstParameter == false)
                    {
                        writer.Write(", ");
                    }

                    writer.Write(parameterSymbol.GeneratedName);
                    firstParameter = false;
                }
            }

            writer.Write(") {");

            if (recordSymbol.Constructor != null)
            {
                writer.Indent++;
                writer.WriteLine();
                writer.WriteLine("var $o = {};");
                CodeGenerator.GenerateScript(generator, recordSymbol.Constructor);
                writer.Write("return $o;");
                writer.WriteLine();
                writer.Indent--;
            }
            else
            {
                writer.Write(" return {}; ");
            }

            writer.Write("}");
            writer.WriteLine();
        }

        public static void GenerateRegistrationScript(ScriptGenerator generator, TypeSymbol typeSymbol)
        {
            ScriptTextWriter writer = generator.Writer;

            writer.Write(typeSymbol.GeneratedName);
            writer.Write(": ");

            switch (typeSymbol.Type)
            {
                case SymbolType.Class:
                    GenerateClassRegistrationScript(generator, (ClassSymbol)typeSymbol);
                    break;
                case SymbolType.Interface:
                    GenerateInterfaceRegistrationScript(generator, (InterfaceSymbol)typeSymbol);
                    break;
                case SymbolType.Enumeration:
                    GenerateEnumerationRegistrationScript(generator, (EnumerationSymbol)typeSymbol);
                    break;
                case SymbolType.Record:
                case SymbolType.Resources:
                    writer.Write(typeSymbol.FullGeneratedName);

                    break;
            }
        }

        private static void GenerateClassRegistrationScript(ScriptGenerator generator, ClassSymbol classSymbol)
        {
            ScriptTextWriter writer = generator.Writer;

            //class definition
            writer.Write($"{DSharpStringResources.ScriptExportMember("defineClass")}(");
            writer.Write(classSymbol.FullGeneratedName);
            writer.Write(", ");

            if (classSymbol.IsStaticClass)
            {
                writer.Write("null, ");
            }
            else
            {
                writer.Write(classSymbol.FullGeneratedName);
                writer.Write("$, ");
            }

            WriteConstructorParameters(classSymbol, writer);
            WriteBaseClass(classSymbol, writer);
            WriteInterfaces(writer, classSymbol.Interfaces);

            writer.Write(")");
        }

        private static void WriteConstructorParameters(ClassSymbol classSymbol, ScriptTextWriter writer)
        {
            if (classSymbol.Constructor?.Parameters is null)
            {
                writer.Write("[], ");
                return;
            }

            bool hasApplicationTypes = classSymbol.Constructor.Parameters
                .Select(p => p.ValueType)
                .Any(ShouldUseRegistry);

            if (hasApplicationTypes)
            {
                writer.Write("function (");
                writer.Write("registry");
                writer.Write(")");
                writer.Write(" { return ");
            }

            writer.Write("[");

            bool firstParameter = true;

            foreach (ParameterSymbol parameterSymbol in classSymbol.Constructor.Parameters)
            {
                if (firstParameter == false)
                {
                    writer.Write(", ");
                }

                TypeSymbol parameterType = parameterSymbol.ValueType;
                if (parameterType is GenericParameterSymbol)
                {
                    writer.Write($"'{parameterType.FullGeneratedName}'");
                }
                else
                {
                    if (ShouldUseRegistry(parameterType))
                    {
                        WriteTypeReference(writer, parameterType, "registry.");
                    }
                    else
                    {
                        WriteTypeReference(writer, parameterType);
                    }
                }
                firstParameter = false;
            }

            writer.Write("]");

            if (hasApplicationTypes)
            {
                writer.Write("}");
            }

            writer.Write(", ");
        }

        private static bool ShouldUseRegistry(TypeSymbol type)
        {
            if (type is GenericParameterSymbol)
            {
                return false;
            }

            return type.IsApplicationType && !type.IgnoreNamespace;
        }

        private static void WriteBaseClass(ClassSymbol classSymbol, ScriptTextWriter writer)
        {
            if (classSymbol.BaseClass is ClassSymbol baseClass)
            {
                writer.Write("function (");
                if (ShouldUseRegistry(baseClass))
                {
                    writer.Write("registry");
                    writer.Write(")");
                    writer.Write(" { return ");
                    WriteTypeReference(writer, baseClass, "registry.");
                }
                else
                {
                    writer.Write(")");
                    writer.Write(" { return ");
                    WriteTypeReference(writer, baseClass);
                }
                writer.Write("}");
            }
            else
            {
                // TODO: We need to introduce the notion of a base class that only exists in the metadata
                //       and not at runtime. At that point this check of IsTestClass can be generalized.
                writer.Write("null");
            }
        }

        private static void WriteInterfaces(ScriptTextWriter writer, ICollection<InterfaceSymbol> interfaces)
        {
            if (interfaces is null)
            {
                return;
            }
            writer.Write(", [");
            bool first = true;

            foreach (InterfaceSymbol inheritedInterface in interfaces)
            {
                if (!first)
                {
                    writer.Write(", ");
                }

                WriteTypeReference(writer, inheritedInterface);

                first = false;
            }

            writer.Write("]");
        }

        private static void WriteTypeReference(ScriptTextWriter writer, TypeSymbol typeSymbol, string typePrefix = "")
        {
            typeSymbol = GetParameterType(typeSymbol);

            if (typeSymbol.IsGeneric && typeSymbol.GenericArguments is IList<TypeSymbol>)
            {
                if (typeSymbol.IgnoreGenericTypeArguments)
                {
                    writer.Write(typePrefix);
                    writer.Write(typeSymbol.FullGeneratedName);
                }
                else if (typeSymbol.GenericArguments.Any(p => p is GenericParameterSymbol gp && gp.IsTypeParameter))
                {
                    writer.Write($"ss.makeMappedGenericTemplate({typePrefix}{typeSymbol.FullGeneratedName}, ");
                    ScriptGeneratorExtensions.WriteGenericTypeArguments(writer.Write, typeSymbol.GenericArguments, typeSymbol.GenericParameters, writeNameMap: true);
                    writer.Write(")");
                }
                else
                {
                    writer.Write($"ss.getGenericConstructor({typePrefix}{typeSymbol.FullGeneratedName}, ");
                    ScriptGeneratorExtensions.WriteGenericTypeArguments(writer.Write, typeSymbol.GenericArguments, typeSymbol.GenericParameters);
                    writer.Write(")");
                }
            }
            else
            {
                writer.Write(typePrefix);
                writer.Write(typeSymbol.FullGeneratedName);
            }
        }

        private static bool HasParamsModifier(MethodSymbol methodSymbol)
        {
            if (methodSymbol == null || methodSymbol.Parameters == null || methodSymbol.Parameters.Count() == 0)
            {
                return false;
            }

            ParameterNode lastParameterParseContext = methodSymbol.Parameters.Last().ParseContext as ParameterNode;

            return lastParameterParseContext.Flags.HasFlag(ParameterFlags.Params);
        }

        private static TypeSymbol GetParameterType(TypeSymbol parameterType)
        {
            SymbolSet symbolSet = parameterType.SymbolSet;
            TypeSymbol nullableType = symbolSet.ResolveIntrinsicType(IntrinsicType.Nullable);

            if (parameterType.FullName == nullableType.FullName)
            {
                parameterType = parameterType.GenericArguments.First();
            }

            TypeSymbol typeType = symbolSet.ResolveIntrinsicType(IntrinsicType.Type);
            TypeSymbol functionType = symbolSet.ResolveIntrinsicType(IntrinsicType.Function);

            if (parameterType.FullName == typeType.FullName || parameterType.Type == SymbolType.Delegate)
            {
                parameterType = functionType;
            }

            if (parameterType.Type == SymbolType.Enumeration)
            {
                EnumerationSymbol enumType = (EnumerationSymbol)parameterType;

                if (enumType.UseNamedValues)
                {
                    TypeSymbol stringType = symbolSet.ResolveIntrinsicType(IntrinsicType.String);
                    parameterType = stringType;
                }
                else
                {
                    TypeSymbol numberType = symbolSet.ResolveIntrinsicType(IntrinsicType.Number);
                    parameterType = numberType;
                }
            }

            if (parameterType is GenericParameterSymbol)
            {
                parameterType = symbolSet.ResolveIntrinsicType(IntrinsicType.Object);
            }

            return parameterType;
        }

        private static void GenerateInterfaceRegistrationScript(ScriptGenerator generator,
                                                                InterfaceSymbol interfaceSymbol)
        {
            ScriptTextWriter writer = generator.Writer;

            writer.Write($"{DSharpStringResources.ScriptExportMember("defineInterface")}(");
            writer.Write(interfaceSymbol.FullGeneratedName);

            WriteInterfaces(writer, interfaceSymbol.Interfaces);

            writer.Write(")");
        }

        private static void GenerateEnumerationRegistrationScript(
            ScriptGenerator generator,
            EnumerationSymbol enumerationSymbol)
        {
            ScriptTextWriter writer = generator.Writer;

            writer.Write(enumerationSymbol.FullGeneratedName);
        }

        private static void GenerateResources(ScriptGenerator generator, ResourcesSymbol resourcesSymbol)
        {
            ScriptTextWriter writer = generator.Writer;
            string resourcesName = resourcesSymbol.FullGeneratedName;

            writer.Write("var ");
            writer.Write(resourcesName);
            writer.WriteLine(" = {");
            writer.Indent++;

            bool firstValue = true;

            foreach (FieldSymbol member in resourcesSymbol.Members)
            {
                Debug.Assert(member.Value is string);

                if (firstValue == false)
                {
                    writer.Write(",");
                    writer.WriteLine();
                }

                writer.Write(member.GeneratedName);
                writer.Write(": ");
                writer.Write(Utility.QuoteString((string)member.Value));

                firstValue = false;
            }

            writer.Indent--;
            writer.WriteLine();
            writer.Write("};");
            writer.WriteLine();
        }

        public static void GenerateScript(ScriptGenerator generator, TypeSymbol typeSymbol)
        {
            Debug.Assert(generator != null);
            Debug.Assert(typeSymbol != null);
            Debug.Assert(typeSymbol.IsApplicationType);

            if (typeSymbol.Type == SymbolType.Delegate)
            {
                // No-op ... there is currently nothing to generate for a particular delegate type
                return;
            }

            if (typeSymbol.Type == SymbolType.Record &&
                typeSymbol.IsPublic == false &&
                ((RecordSymbol)typeSymbol).Constructor == null)
            {
                // Nothing to generate for internal records with no explicit ctor
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            writer.WriteLine("// " + typeSymbol.FullName);
            writer.WriteLine();

            switch (typeSymbol.Type)
            {
                case SymbolType.Class:
                    GenerateClass(generator, (ClassSymbol)typeSymbol);
                    break;
                case SymbolType.Interface:
                    GenerateInterface(generator, (InterfaceSymbol)typeSymbol);
                    break;
                case SymbolType.Enumeration:
                    GenerateEnumeration(generator, (EnumerationSymbol)typeSymbol);
                    break;
                case SymbolType.Record:
                    GenerateRecord(generator, (RecordSymbol)typeSymbol);
                    break;
                case SymbolType.Resources:
                    GenerateResources(generator, (ResourcesSymbol)typeSymbol);
                    break;
            }

            writer.WriteLine();
            writer.WriteLine();
        }
    }
}
