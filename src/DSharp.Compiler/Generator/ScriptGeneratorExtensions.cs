using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using DSharp.Compiler.ScriptModel.Symbols;
using DSharp.Compiler.ScriptModel.Expressions;
using System.Text;

namespace DSharp.Compiler.Generator
{
    //TODO: Make this class work with the current expression generation mechanism.
    internal static class ScriptGeneratorExtensions
    {
        public static ScriptGenerator WriteGenericTypeArgumentsMap(this ScriptGenerator generator, IList<TypeSymbol> typeArguments, IList<GenericParameterSymbol> typeParameters)
        {
            ScriptTextWriter writer = generator.Writer;

            if (typeArguments.Count > 0 && typeArguments.Count == typeParameters.Count)
            {
                WriteGenericTypeArguments(writer.Write, typeArguments, typeParameters);
            }

            return generator;
        }

        private static void WriteObject(Action<string> write, IDictionary<string, string> properties)
        {
            bool commaNeeded = false;
            write("{");
            foreach (var property in properties)
            {
                if(commaNeeded)
                {
                    write(", ");
                }
                write($"{property.Key} : {property.Value}");
                commaNeeded = true;
            }
            write("}");
        }

        private static void WriteGenericTypeArguments(Action<string> write, IList<TypeSymbol> typeArguments, IList<GenericParameterSymbol> typeParameters)
        {
            var dictionary = new Dictionary<string, string>();
            for (int i = 0; i < typeArguments.Count; i++)
            {
                var typeArgument = typeArguments[i];
                var typeParameter = typeParameters[i];

                var typeExpression = CreateTypeArgumentName(typeArgument);
                dictionary.Add(typeParameter.FullName, typeExpression);
            }

            WriteObject(write, dictionary);
        }

        private static string CreateTypeArgumentName(TypeSymbol typeArgument)
        {
            if(typeArgument is GenericParameterSymbol parameterSymbol)
            {
                if(parameterSymbol.Owner is ClassSymbol)
                {
                    return $"{DSharpStringResources.ScriptExportMember("getTypeArgument")}(this, '{typeArgument.FullGeneratedName}')";
                }

                return $"{DSharpStringResources.GeneratedScript.GENERIC_ARGS_PARAMETER_NAME}['{typeArgument.FullGeneratedName}']";
            }

            if(typeArgument.IsGeneric)
            {
                StringBuilder stringBuilder = new StringBuilder();

                //Local method to recursively write the string.
                void Write(string value) => stringBuilder.Append(value);

                stringBuilder.Append(DSharpStringResources.ScriptExportMember("getGenericConstructor"));
                stringBuilder.Append("(");
                stringBuilder.Append(typeArgument.FullGeneratedName);
                stringBuilder.Append(", ");
                WriteGenericTypeArguments(Write, typeArgument.GenericArguments, typeArgument.GenericParameters);
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }

            return typeArgument.FullGeneratedName;
        }
    }
}
