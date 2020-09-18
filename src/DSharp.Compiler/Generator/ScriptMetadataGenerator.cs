// ScriptGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal sealed class ScriptMetadataGenerator
    {
        private readonly IComparer<TypeSymbol> typeComparer = new ScriptGenerator.TypeComparer();

        private SymbolSet symbols;

        public ScriptMetadataGenerator(TextWriter writer, CompilerOptions options, SymbolSet symbols)
        {
            Debug.Assert(writer != null);
            Writer = new ScriptTextWriter(writer);

            Options = options;
            this.symbols = symbols;
        }

        public CompilerOptions Options { get; }

        public ScriptTextWriter Writer { get; }

        public void GenerateScriptMetadata(SymbolSet symbolSet)
        {
            Debug.Assert(symbolSet != null);
            TypeSymbol nullableType = symbolSet.ResolveIntrinsicType(IntrinsicType.Nullable);

            var types = CollectEmittableTypes(symbolSet)
                .OrderBy(t => t, typeComparer);

            List<string> dependencies = GenerateDependenciesList(symbolSet);

            Writer.Write("ss.registerMetadataImporter(function(){");
            Writer.Write("(function(");
            Writer.Write(string.Join(",", dependencies));
            Writer.WriteLine(") {");
            Writer.Indent++;
            Writer.WriteLine("\"use strict\"");
            Writer.WriteLine("var Void = null;");
            Writer.WriteLine("var Type = Function;");
            Writer.WriteLine($"var module = {DSharpStringResources.DSHARP_SCRIPT_NAME}.modules['{symbols.ScriptName}'];");

            foreach (TypeSymbol type in types)
            {
                if (GetMembers(type) is IEnumerable<MemberSymbol> members && members.Any())
                {
                    Writer.WriteLine($"module.{type.GeneratedName}.$members = [");
                    Writer.Indent++;
                    WriteMembers(members, nullableType);
                    Writer.WriteLine("];");
                    Writer.Indent--;
                }
            }

            Writer.Indent--;
            Writer.Write("})(");
            Writer.Write(string.Join(",", dependencies.Select(d => d != DSharpStringResources.DSHARP_SCRIPT_NAME
                ? $"ss.dependency('{d}')"
                : DSharpStringResources.DSHARP_SCRIPT_NAME)));
            Writer.Write(")});");
        }

        private List<string> GenerateDependenciesList(SymbolSet symbols)
        {
            List<string> dependencies = new List<string>();

            foreach (ScriptReference dependency in symbols.Dependencies)
            {
                if (dependency.DelayLoaded)
                {
                    continue;
                }

                if (dependency.TypeReferenceCount <= 0
                    && dependency.Identifier != DSharpStringResources.DSHARP_SCRIPT_NAME)
                {
                    if (dependency.ConstReferenceCount <= 0)
                    {
                        Console.WriteLine($"WARN: Unnecessary dependency to '{dependency.Identifier}'.");
                    }

                    continue;
                }

                dependencies.Add(dependency.Identifier);
            }

            return dependencies;
        }

        private IEnumerable<MemberSymbol> GetMembers(TypeSymbol type)
        {
            MemberSymbol indexerSymbol = null;

            if(type is ClassSymbol classSymbol)
            {
                indexerSymbol = classSymbol.GetIndexer();
            }
            else if (type is InterfaceSymbol interfaceSymbol)
            {
                indexerSymbol = interfaceSymbol.Indexer;
            }

            return type.Members?.Concat(new [] {indexerSymbol}).Where(MemberHasMetadata);
        }

        private void WriteMembers(IEnumerable<MemberSymbol> members, TypeSymbol nullableType)
        {
            bool first = true;
            foreach (var member in members)
            {
                if (!first)
                {
                    Writer.WriteLine(",");
                }
                first = false;

                var memberType = GetMemberType(member);

                if(memberType.HasValue)
                {
                    if(member is IndexerSymbol indexerSymbol && !indexerSymbol.UseScriptIndexer)
                    {
                        WriteMember(memberType.Value, $"get_{member.GeneratedName}", GetType(member.AssociatedType, nullableType));
                        Writer.WriteLine(",");
                        WriteMember(memberType.Value, $"set_{member.GeneratedName}", GetType(member.AssociatedType, nullableType));
                    }
                    else
                    {
                        WriteMember(memberType.Value, member.GeneratedName, GetType(member.AssociatedType, nullableType));
                    }
                }
            }
        }

        private int? GetMemberType(MemberSymbol member)
        {
            switch(member.Type)
            {
                case SymbolType.Method:
                case SymbolType.Indexer:
                    return 8;

                case SymbolType.Property:
                    return 16;

                case SymbolType.Field:
                    return 4;

                default:
                    return null;
            }
        }

        private string GetType(TypeSymbol associatedType, TypeSymbol nullableType)
        {
            if (associatedType.FullName == nullableType.FullName)
            {
                associatedType = associatedType.GenericArguments.First();
            }

            if (associatedType.IsApplicationType
                && associatedType.Type != SymbolType.Delegate) // transpile named delegates to native functions
            {
                if (associatedType is GenericParameterSymbol || associatedType.IsAnonymousType)
                {
                    // we have no idea what the generic parameters are at this point
                    // apply boxing and hope for the best
                    return "Object";
                }

                return $"module.{associatedType.FullGeneratedName}";
            }

            return associatedType.FullGeneratedName;
        }

        private void WriteMember(int memberType, string name, string type)
        {
            Writer.Write("{");
            Writer.Write($"MemberType: {memberType},");
            Writer.Write($"Name: '{name}'");
            Writer.Write(", ");
            Writer.Write("Type: eval(\"try{");
            Writer.Write(type);
            Writer.Write("}catch{}\")");
            Writer.Write("}");
        }

        private bool MemberHasMetadata(MemberSymbol arg)
        {
            switch (arg?.Type)
            {
                case SymbolType.Method:
                case SymbolType.Field:
                case SymbolType.Property:
                case SymbolType.Indexer:
                //case SymbolType.Event: //todo
                    return true;
                default:
                    return false;
            }
        }

        private static List<TypeSymbol> CollectEmittableTypes(SymbolSet symbolSet)
        {
            var types = new List<TypeSymbol>();

            foreach (NamespaceSymbol namespaceSymbol in symbolSet.Namespaces.Where(ns => ns.HasApplicationTypes))
                foreach (TypeSymbol type in namespaceSymbol.Types.Where(type => type.IsApplicationType))
                {
                    switch (type.Type)
                    {
                        case SymbolType.Interface:
                        case SymbolType.Class:
                            types.Add(type);
                            break;

                        default:
                            break;
                    }
                }

            return types;
        }
    }
}
