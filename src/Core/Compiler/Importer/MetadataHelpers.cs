// MetadataHelpers.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static string GetScriptAssemblyName(ICustomAttributeProvider attributeProvider, out string assemblyIdentifier) {
            assemblyIdentifier = null;

            CustomAttribute scriptAssemblyAttribute = GetAttribute(attributeProvider, "System.ScriptAssemblyAttribute");
            if (scriptAssemblyAttribute != null) {
                string name = GetAttributeArgument(scriptAssemblyAttribute);
                if (scriptAssemblyAttribute.Properties.Count != 0) {
                    assemblyIdentifier = (string)scriptAssemblyAttribute.Properties[0].Argument.Value;
                }

                return name;
            }

            return null;
        }

        public static string GetScriptDependencyName(ICustomAttributeProvider attributeProvider, out string dependencyIdentifier) {
            dependencyIdentifier = null;

            CustomAttribute scriptDependencyAttribute = GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptDependencyAttribute");
            if (scriptDependencyAttribute != null) {
                string name = GetAttributeArgument(scriptDependencyAttribute);
                if (scriptDependencyAttribute.Properties.Count != 0) {
                    dependencyIdentifier = (string)scriptDependencyAttribute.Properties[0].Argument.Value;
                }

                return name;
            }

            return null;
        }

        public static bool GetScriptEventAccessors(EventDefinition eventDefinition, out string addAccessor, out string removeAccessor) {
            addAccessor = null;
            removeAccessor = null;

            CustomAttribute eventAttribute = GetAttribute(eventDefinition, "System.Runtime.CompilerServices.ScriptEventAttribute");
            if (eventAttribute != null) {
                addAccessor = eventAttribute.ConstructorArguments[0].Value as string;
                removeAccessor = eventAttribute.ConstructorArguments[1].Value as string;

                return true;
            }

            return false;
        }

        public static string GetScriptMethodSelector(MethodDefinition method) {
            CustomAttribute selectorAttribute = GetAttribute(method, "System.Runtime.CompilerServices.ScriptMethodAttribute");
            if (selectorAttribute != null) {
                return GetAttributeArgument(selectorAttribute);
            }

            return null;
        }

        public static string GetScriptName(ICustomAttributeProvider attributeProvider, out bool preserveName, out bool preserveCase) {
            string name = null;
            preserveName = false;
            preserveCase = false;

            CustomAttribute nameAttribute = GetAttribute(attributeProvider, "System.ScriptNameAttribute");
            if (nameAttribute != null) {
                if (nameAttribute.HasConstructorArguments) {
                    name = GetAttributeArgument(nameAttribute);
                }
                if (nameAttribute.HasProperties) {
                    for (int i = 0; i < nameAttribute.Properties.Count; i++) {
                        if (String.CompareOrdinal(nameAttribute.Properties[i].Name, "PreserveName") == 0) {
                            preserveName = (bool)nameAttribute.Properties[i].Argument.Value;
                        }
                        else {
                            preserveCase = (bool)nameAttribute.Properties[i].Argument.Value;
                        }
                    }
                }
            }

            return name;
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

        public static bool IsScriptExtension(TypeDefinition type, out string extendee) {
            extendee = null;

            CustomAttribute extensionAttribute = GetAttribute(type, "System.ScriptExtensionAttribute");
            if (extensionAttribute != null) {
                extendee = GetAttributeArgument(extensionAttribute);
                if (String.IsNullOrEmpty(extendee) == false) {
                    return true;
                }
            }

            return false;
        }

        public static bool ShouldIgnoreNamespace(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.ScriptIgnoreNamespaceAttribute") != null;
        }

        public static bool ShouldImportScriptCoreType(TypeDefinition type) {
            return GetAttribute(type, "System.Runtime.CompilerServices.ScriptIgnoreAttribute") == null;
        }

        public static bool ShouldSkipFromScript(ICustomAttributeProvider attributeProvider) {
            return GetAttribute(attributeProvider, "System.Runtime.CompilerServices.ScriptSkipAttribute") != null;
        }

        public static bool ShouldTreatAsScriptField(PropertyDefinition property) {
            return GetAttribute(property, "System.Runtime.CompilerServices.ScriptFieldAttribute") != null;
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
            return GetAttribute(type, "System.ScriptObjectAttribute") != null;
        }

        public static bool ShouldUseEnumNames(TypeDefinition type) {
            CustomAttribute attribute = GetAttribute(type, "System.ScriptConstantsAttribute");
            if (attribute != null) {
                if (attribute.HasProperties) {
                    Debug.Assert(attribute.Properties.Count == 1);
                    Debug.Assert(String.CompareOrdinal(attribute.Properties[0].Name, "UseNames") == 0);
                    Debug.Assert(attribute.Properties[0].Argument.Value is bool);

                    return (bool)attribute.Properties[0].Argument.Value;
                }
            }

            return false;
        }

        public static bool ShouldUseEnumValues(TypeDefinition type) {
            CustomAttribute attribute = GetAttribute(type, "System.ScriptConstantsAttribute");
            if (attribute != null) {
                if (attribute.HasProperties) {
                    Debug.Assert(attribute.Properties.Count == 1);
                    Debug.Assert(String.CompareOrdinal(attribute.Properties[0].Name, "UseNames") == 0);
                    Debug.Assert(attribute.Properties[0].Argument.Value is bool);

                    return (bool)attribute.Properties[0].Argument.Value == false;
                }

                return true;
            }

            return false;
        }
    }
}
