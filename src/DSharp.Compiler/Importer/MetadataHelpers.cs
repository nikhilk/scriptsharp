// MetadataHelpers.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mono.Cecil;

namespace DSharp.Compiler.Importer
{
    internal static class MetadataHelpers
    {
        private static CustomAttribute GetAttribute(ICustomAttributeProvider attributeProvider,
                                                    string attributeTypeName)
        {
            foreach (CustomAttribute attribute in attributeProvider.CustomAttributes)
                if (string.CompareOrdinal(attribute.Constructor.DeclaringType.FullName, attributeTypeName) == 0)
                {
                    return attribute;
                }

            return null;
        }

        private static string GetAttributeArgument(CustomAttribute attribute)
        {
            return attribute.ConstructorArguments[0].Value as string;
        }

        public static string GetTransformedName(ICustomAttributeProvider attributeProvider)
        {
            CustomAttribute dsharpScriptMemberName = GetAttribute(attributeProvider, "System.Runtime.CompilerServices.DSharpScriptMemberNameAttribute");

            if(dsharpScriptMemberName != null)
            {
                return DSharpStringResources.ScriptExportMember(GetAttributeArgument(dsharpScriptMemberName));
            }

            CustomAttribute scriptAliasAttribute =
                GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptAliasAttribute");

            if (scriptAliasAttribute != null)
            {
                return GetAttributeArgument(scriptAliasAttribute);
            }

            return null;
        }

        public static string GetScriptAssemblyName(ICustomAttributeProvider attributeProvider,
                                                   out string assemblyIdentifier)
        {
            assemblyIdentifier = null;

            //TODO: Replace with auto generated name from the assembly title or name attributes
            CustomAttribute scriptAssemblyAttribute = GetAttribute(attributeProvider, "System.ScriptAssemblyAttribute");

            if (scriptAssemblyAttribute != null)
            {
                string name = GetAttributeArgument(scriptAssemblyAttribute);

                if (scriptAssemblyAttribute.Properties.Count != 0)
                {
                    assemblyIdentifier = (string) scriptAssemblyAttribute.Properties[0].Argument.Value;
                }

                return name;
            }

            return null;
        }

        public static string GetScriptDependencyName(ICustomAttributeProvider attributeProvider,
                                                     out string dependencyIdentifier)
        {
            dependencyIdentifier = null;

            CustomAttribute scriptDependencyAttribute = GetAttribute(attributeProvider,
                "System.Runtime.CompilerServices.ScriptDependencyAttribute");

            if (scriptDependencyAttribute != null)
            {
                string name = GetAttributeArgument(scriptDependencyAttribute);

                if (scriptDependencyAttribute.Properties.Count != 0)
                {
                    dependencyIdentifier = (string) scriptDependencyAttribute.Properties[0].Argument.Value;
                }

                return name;
            }

            return null;
        }

        public static bool GetScriptEventAccessors(EventDefinition eventDefinition, out string addAccessor,
                                                   out string removeAccessor)
        {
            addAccessor = null;
            removeAccessor = null;

            CustomAttribute eventAttribute =
                GetAttribute(eventDefinition, "System.Runtime.CompilerServices.ScriptEventAttribute");

            if (eventAttribute != null)
            {
                addAccessor = eventAttribute.ConstructorArguments[0].Value as string;
                removeAccessor = eventAttribute.ConstructorArguments[1].Value as string;

                return true;
            }

            return false;
        }

        public static string GetScriptMethodSelector(MethodDefinition method)
        {
            CustomAttribute selectorAttribute =
                GetAttribute(method, "System.Runtime.CompilerServices.ScriptMethodAttribute");

            if (selectorAttribute != null)
            {
                return GetAttributeArgument(selectorAttribute);
            }

            return null;
        }

        public static bool IsExtensionMethod(MethodDefinition method)
        {
            return GetAttribute(method, typeof(ExtensionAttribute).FullName)
                != null;
        }

        public static bool IsIgnored(MethodDefinition method)
        {
            return GetAttribute(method, DSharpStringResources.SCRIPT_IGNORE_ATTRIBUTE_FULLTYPENAME)
                != null;
        }

        public static string GetScriptName(ICustomAttributeProvider attributeProvider, out bool preserveName,
                                           out bool preserveCase)
        {
            string name = null;
            preserveName = false;
            preserveCase = false;

            CustomAttribute nameAttribute = GetAttribute(attributeProvider, "System.ScriptNameAttribute");

            if (nameAttribute != null)
            {
                if (nameAttribute.HasConstructorArguments)
                {
                    name = GetAttributeArgument(nameAttribute);
                }

                if (nameAttribute.HasProperties)
                {
                    for (int i = 0; i < nameAttribute.Properties.Count; i++)
                        if (string.CompareOrdinal(nameAttribute.Properties[i].Name, "PreserveName") == 0)
                        {
                            preserveName = (bool) nameAttribute.Properties[i].Argument.Value;
                        }
                        else
                        {
                            preserveCase = (bool) nameAttribute.Properties[i].Argument.Value;
                        }
                }
            }

            return name;
        }

        public static bool IsCompilerGeneratedType(TypeDefinition type)
        {
            return GetAttribute(type, "System.Runtime.CompilerServices.CompilerGeneratedAttribute") != null;
        }

        public static bool IsDelegate(TypeDefinition type)
        {
            TypeReference baseType = type.BaseType;

            if (baseType == null)
            {
                return false;
            }

            string baseTypeName = type.BaseType.FullName;

            return string.CompareOrdinal(baseTypeName, "System.MulticastDelegate") == 0 ||
                   string.CompareOrdinal(baseTypeName, "System.Delegate") == 0;
        }

        public static bool IsEnum(TypeDefinition type)
        {
            TypeReference baseType = type.BaseType;

            if (baseType == null)
            {
                return false;
            }

            return string.CompareOrdinal(type.BaseType.FullName, "System.Enum") == 0;
        }

        public static bool IsScriptExtension(TypeDefinition type, out string extendee)
        {
            extendee = null;

            CustomAttribute extensionAttribute = GetAttribute(type, "System.ScriptExtensionAttribute");

            if (extensionAttribute != null)
            {
                extendee = GetAttributeArgument(extensionAttribute);

                if (string.IsNullOrEmpty(extendee) == false)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ShouldIgnoreNamespace(TypeDefinition type)
        {
            return GetAttribute(type, "System.Runtime.CompilerServices.ScriptIgnoreNamespaceAttribute") != null;
        }

        public static bool ShouldImportScriptCoreType(TypeDefinition type)
        {
            return GetAttribute(type, "System.Runtime.CompilerServices.ScriptIgnoreAttribute") == null;
        }

        public static bool ShouldSkipFromScript(ICustomAttributeProvider attributeProvider)
        {
            return GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptSkipAttribute") != null;
        }

        public static bool ShouldTreatAsScriptField(PropertyDefinition property)
        {
            return GetAttribute(property, "System.Runtime.CompilerServices.ScriptFieldAttribute") != null;
        }

        public static bool ShouldTreatAsConditionalMethod(MethodDefinition method, out ICollection<string> conditions)
        {
            conditions = null;

            foreach (CustomAttribute attribute in method.CustomAttributes)
            {
                string typeName = attribute.Constructor.DeclaringType.FullName;

                if (string.CompareOrdinal(typeName, "System.Diagnostics.ConditionalAttribute") == 0)
                {
                    if (conditions == null)
                    {
                        conditions = new List<string>();
                    }

                    conditions.Add(GetAttributeArgument(attribute));
                }
            }

            return conditions != null;
        }

        public static bool ShouldTreatAsRecordType(TypeDefinition type)
        {
            return GetAttribute(type, "System.ScriptObjectAttribute") != null;
        }

        public static bool ShouldUseEnumNames(TypeDefinition type)
        {
            CustomAttribute attribute = GetAttribute(type, "System.ScriptConstantsAttribute");

            if (attribute != null)
            {
                if (attribute.HasProperties)
                {
                    Debug.Assert(attribute.Properties.Count == 1);
                    Debug.Assert(string.CompareOrdinal(attribute.Properties[0].Name, "UseNames") == 0);
                    Debug.Assert(attribute.Properties[0].Argument.Value is bool);

                    return (bool) attribute.Properties[0].Argument.Value;
                }
            }

            return false;
        }

        public static bool ShouldUseEnumValues(TypeDefinition type)
        {
            CustomAttribute attribute = GetAttribute(type, "System.ScriptConstantsAttribute");

            if (attribute != null)
            {
                if (attribute.HasProperties)
                {
                    Debug.Assert(attribute.Properties.Count == 1);
                    Debug.Assert(string.CompareOrdinal(attribute.Properties[0].Name, "UseNames") == 0);
                    Debug.Assert(attribute.Properties[0].Argument.Value is bool);

                    return (bool) attribute.Properties[0].Argument.Value == false;
                }

                return true;
            }

            return false;
        }
    }
}
