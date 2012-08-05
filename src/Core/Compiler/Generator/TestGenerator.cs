// TestGenerator.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal static class TestGenerator {

        public static void GenerateScript(ScriptGenerator generator, ClassSymbol testClassSymbol) {
            Debug.Assert(generator != null);

            List<MethodSymbol> testMethods = new List<MethodSymbol>();
            bool hasSetup = false;
            bool hasCleanup = false;

            foreach (MemberSymbol member in testClassSymbol.Members) {
                if (member.Type == SymbolType.Method) {
                    if (String.CompareOrdinal(member.Name, "Setup") == 0) {
                        hasSetup = true;
                    }
                    else if (String.CompareOrdinal(member.Name, "Cleanup") == 0) {
                        hasCleanup = true;
                    }
                    else if (member.Name.StartsWith("Test", StringComparison.Ordinal)) {
                        testMethods.Add((MethodSymbol)member);
                    }
                }
            }

            ScriptTextWriter writer = generator.Writer;

            writer.WriteLine();
            writer.Write("module('");
            writer.Write(testClassSymbol.GeneratedName);
            writer.WriteLine("', {");
            writer.Indent++;
            writer.WriteLine("setup: function() {");
            writer.Indent++;
            writer.Write("this.instance = new ");
            writer.Write(testClassSymbol.FullGeneratedName);
            writer.WriteLine("();");
            if (hasSetup) {
                writer.WriteLine("this.instance.setup();");
            }
            writer.Indent--;
            writer.WriteLine("},");
            writer.WriteLine("teardown: function() {");
            writer.Indent++;
            if (hasCleanup) {
                writer.WriteLine("this.instance.cleanup();");
            }
            writer.WriteLine("delete this.instance;");
            writer.Indent--;
            writer.WriteLine("}");
            writer.Indent--;
            writer.WriteLine("});");
            writer.WriteLine();

            foreach (MethodSymbol testMethod in testMethods) {
                writer.Write("test('");
                writer.Write(testMethod.GeneratedName);
                writer.WriteLine("', function() {");
                writer.Indent++;
                writer.Write("this.instance.");
                writer.Write(testMethod.GeneratedName);
                writer.WriteLine("();");
                writer.Indent--;
                writer.WriteLine("});");
            }
        }
    }
}
