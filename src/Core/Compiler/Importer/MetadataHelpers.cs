// MetadataHelpers.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Reflection;
using ScriptSharp.Importer.IL;
using ScriptSharp.ScriptModel;
using ICustomAttributeProvider = ScriptSharp.Importer.IL.ICustomAttributeProvider;

namespace ScriptSharp.Importer {

    internal static class MetadataHelpers {

        private static CustomAttribute GetAttribute(ICustomAttributeProvider attributeProvider, string attributeTypeName) {
            foreach (CustomAttribute attribute in attributeProvider.CustomAttributes) {
                if (String.CompareOrdinal(attribute.Constructor.DeclaringType.FullName, attributeTypeName) == 0) {
                    return attribute;
                }
            }

            return null;
        }

        private static string GetAttributeArgument(CustomAttribute attribute) {
            return attribute.ConstructorArguments[0].Value as string;
        }

        public static string GetScriptAlias(ICustomAttributeProvider attributeProvider) {
            CustomAttribute scriptAliasAttribute = GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptAliasAttribute");
            if (scriptAliasAttribute != null) {
                return GetAttributeArgument(scriptAliasAttribute);
            }

            return null;
        }

        public static string GetScriptAssemblyName(ICustomAttributeProvider attributeProvider) {
            CustomAttribute scriptAssemblyAttribute = GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptAssemblyAttribute");
            if (scriptAssemblyAttribute != null) {
                return GetAttributeArgument(scriptAssemblyAttribute);
            }

            return null;
        }

        public static string GetScriptName(ICustomAttributeProvider attributeProvider) {
            CustomAttribute scriptAssemblyAttribute = GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptNameAttribute");
            if (scriptAssemblyAttribute != null) {
                return GetAttributeArgument(scriptAssemblyAttribute);
            }

            return null;
        }

        public static string GetScriptNamespace(ICustomAttributeProvider attributeProvider) {
            CustomAttribute scriptNamespaceAttribute = GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptNamespaceAttribute");
            if (scriptNamespaceAttribute != null) {
                return GetAttributeArgument(scriptNamespaceAttribute);
            }

            return null;
        }

        public static bool IsCompilerGeneratedType(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.CompilerGeneratedAttribute") != null;
        }

        public static bool IsDelegate(TypeDefinition type) {
            TypeReference baseType = type.BaseType;
            if (baseType == null) {
                return false;
            }

            string baseTypeName = type.BaseType.FullName;

            return (String.CompareOrdinal(baseTypeName, "System.MulticastDelegate") == 0) ||
                   (String.CompareOrdinal(baseTypeName, "System.Delegate") == 0);
        }

        public static bool IsEnum(TypeDefinition type) {
            TypeReference baseType = type.BaseType;
            if (baseType == null) {
                return false;
            }

            return (String.CompareOrdinal(type.BaseType.FullName, "System.Enum") == 0);
        }

        public static bool ShouldGlobalizeMembers(TypeDefinition type, out string mixinRoot) {
            mixinRoot = null;

            CustomAttribute globalMethodsAttribute = GetAttribute(type, "System.Runtime.CompilerServices.GlobalMethodsAttribute");
            if (globalMethodsAttribute != null) {
                return true;
            }

            CustomAttribute mixinAttribute = GetAttribute(type, "System.Runtime.CompilerServices.MixinAttribute");
            if (mixinAttribute != null) {
                mixinRoot = GetAttributeArgument(mixinAttribute);
            }

            return false;
        }

        public static bool ShouldIgnoreNamespace(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.IgnoreNamespaceAttribute") != null;
        }

        public static bool ShouldImportScriptCoreType(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.NonScriptableAttribute") == null;
        }

        public static bool ShouldPreserveCase(ICustomAttributeProvider attributeProvider) {
            return GetAttribute(attributeProvider, "System.Runtime.CompilerServices.PreserveCaseAttribute") != null;
        }

        public static bool ShouldSkipFromScript(ICustomAttributeProvider attributeProvider) {
            return GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptSkipAttribute") != null;
        }

        public static bool ShouldTreatAsIntrinsicProperty(PropertyDefinition property) {
            return GetAttribute(property, "System.Runtime.CompilerServices.IntrinsicPropertyAttribute") != null;
        }

        public static bool ShouldTreatAsConditionalMethod(MethodDefinition method, out ICollection<string> conditions) {
            conditions = null;

            foreach (CustomAttribute attribute in method.CustomAttributes) {
                string typeName = attribute.Constructor.DeclaringType.FullName;
                if (String.CompareOrdinal(typeName, "System.Diagnostics.ConditionalAttribute") == 0) {
                    if (conditions == null) {
                        conditions = new List<string>();
                    }

                    conditions.Add(GetAttributeArgument(attribute));
                }
            }
            
            return (conditions != null);
        }

        public static bool ShouldTreatAsRecordType(TypeDefinition type) {
            if ((type.BaseType != null) &&
                (String.CompareOrdinal(type.BaseType.FullName, "System.Record") == 0)) {
                return true;
            }

            return false;
        }

        public static bool ShouldUseEnumNames(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.NamedValuesAttribute") != null;
        }

        public static bool ShouldUseEnumValues(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.NumericValuesAttribute") != null;
        }
    }
}
