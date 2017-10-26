// TypeGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator
{

    internal static class TypeGenerator
    {
        public static void GenerateNamespaceTable(this ScriptGenerator generator, NamespaceTable namespaceTable)
        {
            ScriptTextWriter writer = generator.Writer;
            if(namespaceTable.Namespaces.Count <= 0)
            {
                return;
            }

            foreach(KeyValuePair<string, string> namespaceEntry in namespaceTable.Namespaces)
            {
                writer.WriteLine("var {0} = \"{1}\";", namespaceEntry.Value, namespaceEntry.Key);
            }
        }

        private static void GenerateClass(ScriptGenerator generator, ClassSymbol classSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string name = classSymbol.FullGeneratedName;

            writer.Write("function ");
            writer.Write(name);
            writer.Write("(");
            if ((classSymbol.Constructor != null) && (classSymbol.Constructor.Parameters != null)) {
                bool firstParameter = true;
                foreach (ParameterSymbol parameterSymbol in classSymbol.Constructor.Parameters) {
                    if (firstParameter == false) {
                        writer.Write(", ");
                    }
                    writer.Write(parameterSymbol.GeneratedName);
                    firstParameter = false;
                }
            }
            writer.WriteLine(") {");
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
                        writer.Write(" = ");
                        CodeGenerator.GenerateScript(generator, fieldSymbol);
                        writer.Write(";");
                        writer.WriteLine();
                    }
                }
            }
            if (classSymbol.Constructor != null) {
                CodeGenerator.GenerateScript(generator, classSymbol.Constructor);
            }
            else if ((classSymbol.BaseClass != null) && (classSymbol.IsTestClass == false)) {
                writer.Write(classSymbol.BaseClass.FullGeneratedName);
                writer.Write(".call(this);");
                writer.WriteLine();
            }
            writer.Indent--;
            writer.WriteLine("}");

            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                if ((memberSymbol.Type != SymbolType.Field) &&
                    (memberSymbol.Visibility & MemberVisibility.Static) != 0) {
                    MemberGenerator.GenerateScript(generator, memberSymbol);
                }
            }

            if (classSymbol.IsStaticClass == false) {
                writer.Write("var ");
                writer.Write(name);
                writer.WriteLine("$ = {");
                writer.Indent++;

                bool firstMember = true;
                foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                    if ((memberSymbol.Visibility & MemberVisibility.Static) == 0) {
                        if (memberSymbol.Type == SymbolType.Field) {
                            continue;
                        }

                        if ((memberSymbol is CodeMemberSymbol) &&
                            ((CodeMemberSymbol)memberSymbol).IsAbstract) {
                            continue;
                        }

                        if (firstMember == false) {
                            writer.WriteLine(",");
                        }

                        MemberGenerator.GenerateScript(generator, memberSymbol);
                        firstMember = false;
                    }
                }

                if (classSymbol.Indexer != null) {
                    if (firstMember == false) {
                        writer.WriteLine(",");
                    }

                    MemberGenerator.GenerateScript(generator, classSymbol.Indexer);
                }

                writer.Indent--;
                writer.WriteLine();
                writer.Write("};");
                writer.WriteLine();
            }
        }

        private static void GenerateEnumeration(ScriptGenerator generator, EnumerationSymbol enumSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string enumName = enumSymbol.FullGeneratedName;

            writer.Write("var ");
            writer.Write(enumSymbol.FullGeneratedName);
            writer.Write(" = {");
            writer.Indent++;

            bool firstValue = true;
            foreach (MemberSymbol memberSymbol in enumSymbol.Members) {
                EnumerationFieldSymbol fieldSymbol = memberSymbol as EnumerationFieldSymbol;
                if (fieldSymbol == null) {
                    continue;
                }

                if (firstValue == false) {
                    writer.Write(", ");
                }

                writer.WriteLine();
                writer.Write(fieldSymbol.GeneratedName);
                writer.Write(": ");
                if (enumSymbol.UseNamedValues) {
                    writer.Write(Utility.QuoteString(enumSymbol.CreateNamedValue(fieldSymbol)));
                }
                else {
                    writer.Write(fieldSymbol.Value);
                }
                firstValue = false;
            }

            writer.Indent--;
            writer.WriteLine();
            writer.Write("};");
            writer.WriteLine();
        }

        private static void GenerateInterface(ScriptGenerator generator, InterfaceSymbol interfaceSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string interfaceName = interfaceSymbol.FullGeneratedName;

            writer.Write("function ");
            writer.Write(interfaceName);
            writer.WriteLine("() { }");
        }

        public static void GenerateClassConstructorScript(ScriptGenerator generator, ClassSymbol classSymbol) {
            // NOTE: This is emitted last in the script file, and separate from the initial class definition
            //       because it needs to be emitted after the class registration.

            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                if ((memberSymbol.Type == SymbolType.Field) &&
                    ((memberSymbol.Visibility & MemberVisibility.Static) != 0)) {
                    FieldSymbol fieldSymbol = (FieldSymbol)memberSymbol;

                    if (fieldSymbol.IsConstant &&
                        ((memberSymbol.Visibility & (MemberVisibility.Public | MemberVisibility.Protected)) == 0)) {
                        // PrivateInstance/Internal constant fields are omitted since they have been inlined
                        continue;
                    }

                    if (fieldSymbol.HasInitializer) {
                        MemberGenerator.GenerateScript(generator, memberSymbol);
                    }
                }
            }

            if (classSymbol.StaticConstructor != null) {
                ScriptTextWriter writer = generator.Writer;

                SymbolImplementation implementation = classSymbol.StaticConstructor.Implementation;
                bool requiresFunctionScope = implementation.DeclaresVariables;

                if (requiresFunctionScope) {
                    writer.WriteLine("(function() {");
                    writer.Indent++;
                }
                CodeGenerator.GenerateScript(generator, classSymbol.StaticConstructor);
                if (requiresFunctionScope) {
                    writer.Indent--;
                    writer.Write("})();");
                    writer.WriteLine();
                }
            }
        }

        private static void GenerateExtensionMethods(ScriptGenerator generator, ClassSymbol classSymbol) {
            foreach (MemberSymbol memberSymbol in classSymbol.Members) {
                Debug.Assert(memberSymbol.Type == SymbolType.Method);
                Debug.Assert((memberSymbol.Visibility & MemberVisibility.Static) != 0);

                MemberGenerator.GenerateScript(generator, memberSymbol);
            }
        }

        private static void GenerateRecord(ScriptGenerator generator, RecordSymbol recordSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string recordName = recordSymbol.FullGeneratedName;

            writer.Write("function ");
            writer.Write(recordName);
            writer.Write("(");
            if (recordSymbol.Constructor != null) {
                ConstructorSymbol ctorSymbol = recordSymbol.Constructor;

                if (ctorSymbol.Parameters != null) {
                    bool firstParameter = true;
                    foreach (ParameterSymbol parameterSymbol in ctorSymbol.Parameters) {
                        if (firstParameter == false) {
                            writer.Write(", ");
                        }
                        writer.Write(parameterSymbol.GeneratedName);
                        firstParameter = false;
                    }
                }
            }
            writer.Write(") {");
            if (recordSymbol.Constructor != null) {
                writer.Indent++;
                writer.WriteLine();
                writer.WriteLine("var $o = {};");
                CodeGenerator.GenerateScript(generator, recordSymbol.Constructor);
                writer.Write("return $o;");
                writer.WriteLine();
                writer.Indent--;
            }
            else {
                writer.Write(" return {}; ");
            }
            writer.Write("}");
            writer.WriteLine();
        }

        public static void GenerateRegistrationScript(
            ScriptGenerator generator, 
            TypeSymbol typeSymbol, 
            NamespaceTable namespaceTable)
        {
            ClassSymbol classSymbol = typeSymbol as ClassSymbol;

            if ((classSymbol != null) && classSymbol.IsExtenderClass) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;
            string namespaceLookup = namespaceTable.GenerateNamespaceRequest(typeSymbol.Namespace);

            writer.Write(typeSymbol.GeneratedName);
            writer.Write(": ");

            switch (typeSymbol.Type) {
                case SymbolType.Class:
                    GenerateClassRegistrationScript(generator, classSymbol, namespaceLookup);
                    
                    break;
                case SymbolType.Interface:
                    GenerateInterfaceRegistrationScript(generator, (InterfaceSymbol)typeSymbol, namespaceLookup);
                    
                    break;
                case SymbolType.Record:
                case SymbolType.Resources:
                case SymbolType.Enumeration:
                    writer.Write(typeSymbol.FullGeneratedName);
                    break;
            }
        }

        private static void GenerateClassRegistrationScript(ScriptGenerator generator, ClassSymbol classSymbol, string namespaceToken)
        {
            ScriptTextWriter writer = generator.Writer;

            //class definition
            writer.Write("ss.defineClass(");
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

            //constructor params
            writer.Write("[");
            if ((classSymbol.Constructor != null) && (classSymbol.Constructor.Parameters != null))
            {
                bool firstParameter = true;
                foreach (ParameterSymbol parameterSymbol in classSymbol.Constructor.Parameters)
                {
                    if (firstParameter == false)
                    {
                        writer.Write(", ");
                    }
                    var parameterType = parameterSymbol.ValueType;
                    string parameterTypeName = GetParameterTypeName(parameterType);
                    writer.Write(parameterTypeName);
                    firstParameter = false;
                }
            }
            writer.Write("], ");

            //base class
            if ((classSymbol.BaseClass == null) || classSymbol.IsTestClass)
            {
                // TODO: We need to introduce the notion of a base class that only exists in the metadata
                //       and not at runtime. At that point this check of IsTestClass can be generalized.

                writer.Write("null");
            }
            else
            {
                writer.Write(classSymbol.BaseClass.FullGeneratedName);
            }
            writer.Write(", ");

            //interfaces
            if (classSymbol.Interfaces != null)
            {
                writer.Write("[");
                bool first = true;

                foreach (InterfaceSymbol inheritedInterface in classSymbol.Interfaces)
                {
                    if (!first)
                    {
                        writer.Write(", ");
                    }
                    writer.Write(inheritedInterface.FullGeneratedName);
                    first = false;
                }

                writer.Write("]");
            }
            else
            {
                writer.Write("[]");
            }

            //namespace
            if(!string.IsNullOrWhiteSpace(namespaceToken))
            {
                writer.Write(", " + namespaceToken);
            }

            //end
            writer.Write(")");
        }

        private static string GetParameterTypeName(TypeSymbol parameterType)
        {
            var symbolSet = parameterType.SymbolSet;
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

            return parameterType.FullGeneratedName;
        }

        private static void GenerateInterfaceRegistrationScript(ScriptGenerator generator, InterfaceSymbol interfaceSymbol, string namespaceToken)
        {
            ScriptTextWriter writer = generator.Writer;

            writer.Write("ss.defineInterface(");
            writer.Write(interfaceSymbol.FullGeneratedName);
            writer.Write(", ");

            if (interfaceSymbol.Interfaces != null)
            {
                writer.Write("[");
                bool first = true;

                foreach (InterfaceSymbol inheritedInterface in interfaceSymbol.Interfaces)
                {
                    if (!first)
                    {
                        writer.Write(", ");
                    }
                    writer.Write(inheritedInterface.FullGeneratedName);
                    first = false;
                }

                writer.Write("]");
            }
            else
            {
                writer.Write("[]");
            }

            //namespace
            if(!string.IsNullOrWhiteSpace(namespaceToken))
            {
                writer.Write(", "+ namespaceToken);
            }

            writer.Write(")");
        }

        private static void GenerateResources(ScriptGenerator generator, ResourcesSymbol resourcesSymbol) {
            ScriptTextWriter writer = generator.Writer;
            string resourcesName = resourcesSymbol.FullGeneratedName;

            writer.Write("var ");
            writer.Write(resourcesName);
            writer.WriteLine(" = {");
            writer.Indent++;

            bool firstValue = true;
            foreach (FieldSymbol member in resourcesSymbol.Members) {
                Debug.Assert(member.Value is string);

                if (firstValue == false) {
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

        public static void GenerateScript(ScriptGenerator generator, TypeSymbol typeSymbol) {
            Debug.Assert(generator != null);
            Debug.Assert(typeSymbol != null);
            Debug.Assert(typeSymbol.IsApplicationType);

            if (typeSymbol.Type == SymbolType.Delegate) {
                // No-op ... there is currently nothing to generate for a particular delegate type
                return;
            }

            if ((typeSymbol.Type == SymbolType.Record) &&
                (typeSymbol.IsPublic == false) &&
                (((RecordSymbol)typeSymbol).Constructor == null)) {
                // Nothing to generate for internal records with no explicit ctor
                return;
            }

            if ((typeSymbol.Type == SymbolType.Class) &&
                ((ClassSymbol)typeSymbol).IsModuleClass) {
                // No members on script modules, which only contain startup code
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            writer.WriteLine("// " + typeSymbol.FullName);
            writer.WriteLine();

            switch (typeSymbol.Type) {
                case SymbolType.Class:
                    if (((ClassSymbol)typeSymbol).IsExtenderClass) {
                        GenerateExtensionMethods(generator, (ClassSymbol)typeSymbol);
                    }
                    else {
                        GenerateClass(generator, (ClassSymbol)typeSymbol);
                    }
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
