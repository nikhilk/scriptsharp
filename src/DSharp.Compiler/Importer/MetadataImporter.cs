// MetadataImporter.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DSharp.Compiler.Errors;
using DSharp.Compiler.ScriptModel.Symbols;
using Mono.Cecil;

namespace DSharp.Compiler.Importer
{
    internal sealed class MetadataImporter
    {
        private readonly IErrorHandler errorHandler;

        private List<TypeSymbol> importedTypes;
        private bool resolveError;

        private SymbolSet symbols;

        public MetadataImporter(IErrorHandler errorHandler)
        {
            Debug.Assert(errorHandler != null);

            this.errorHandler = errorHandler;
        }

        private ICollection<TypeSymbol> ImportAssemblies(MetadataSource mdSource)
        {
            importedTypes = new List<TypeSymbol>();

            ImportScriptAssembly(mdSource, mdSource.CoreAssemblyPath, /* coreAssembly */ true);

            foreach (TypeSymbol typeSymbol in importedTypes)
                if (typeSymbol.Type == SymbolType.Class &&
                    typeSymbol.Name.Equals(nameof(Array), StringComparison.Ordinal))
                {
                    // Array is special - it is used to build other Arrays of more
                    // specific types we load members for in the second pass...
                    ImportMembers(typeSymbol);
                }

            foreach (TypeSymbol typeSymbol in importedTypes)
                if (typeSymbol.IsGeneric)
                {
                    // Generics are also special - they are used to build other generic instances
                    // with specific types for generic arguments as we load members for other
                    // types subsequently...
                    ImportMembers(typeSymbol);
                }

            foreach (TypeSymbol typeSymbol in importedTypes)
            {
                if (typeSymbol.IsGeneric == false &&
                    (typeSymbol.Type != SymbolType.Class ||
                     typeSymbol.Name.Equals(nameof(Array), StringComparison.Ordinal) == false))
                {
                    ImportMembers(typeSymbol);
                }

                // There is some special-case logic to be performed on some members of the
                // global namespace.

                if (typeSymbol.Type == SymbolType.Class)
                {
                    if (typeSymbol.Name.Equals("Script", StringComparison.Ordinal))
                    {
                        // The Script class contains additional pseudo global methods that cannot
                        // be referenced at compile-time by the app author, but can be
                        // referenced by generated code during compilation.
                        ImportPseudoMembers(PseudoClassMembers.Script, (ClassSymbol) typeSymbol);
                    }
                    else if (typeSymbol.Name.Equals(nameof(Object), StringComparison.Ordinal))
                    {
                        // We need to add a static GetType method

                        ImportPseudoMembers(PseudoClassMembers.Object, (ClassSymbol) typeSymbol);
                    }
                    else if (typeSymbol.Name.Equals(typeof(Dictionary<,>).Name, StringComparison.Ordinal))
                    {
                        // The Dictionary class contains static methods at runtime, rather
                        // than instance methods.

                        ImportPseudoMembers(PseudoClassMembers.Dictionary, (ClassSymbol) typeSymbol);
                    }
                    else if (typeSymbol.Name.Equals("Arguments", StringComparison.Ordinal))
                    {
                        // We need to add a static indexer, which isn't allowed in C#

                        ImportPseudoMembers(PseudoClassMembers.Arguments, (ClassSymbol) typeSymbol);
                    }
                }
            }

            // Import all the types first.
            // Types need to be loaded upfront so that they can be used in resolving types associated
            // with members.
            foreach (string assemblyPath in mdSource.Assemblies)
                ImportScriptAssembly(mdSource, assemblyPath, /* coreAssembly */ false);

            // Resolve Base Types
            foreach (TypeSymbol typeSymbol in importedTypes)
                if (typeSymbol.Type == SymbolType.Class)
                {
                    ImportBaseType((ClassSymbol) typeSymbol);
                    BuildInterfaceAssociations((ClassSymbol)typeSymbol);
                }
                else if (typeSymbol.Type == SymbolType.Interface)
                {
                    ImportInterfaces((InterfaceSymbol) typeSymbol);
                }

            // Import members
            foreach (TypeSymbol typeSymbol in importedTypes)
            {
                if (typeSymbol.IsCoreType)
                {
                    // already processed above
                    continue;
                }

                ImportMembers(typeSymbol);
            }

            foreach (TypeSymbol typeSymbol in importedTypes)
            {
                if(typeSymbol is ClassSymbol classSymbol && classSymbol.IsPublic)
                {
                    foreach(var method in GetExtensionMethods(typeSymbol.Members))
                    {
                        ParameterDefinition parameter = ((MethodDefinition)method.ParseContext).Parameters.First();
                        string typeToExtend = parameter.ParameterType.FullName;
                        symbols.AddExtensionType(typeToExtend, method.Name, method);
                    }
                }
            }

            return importedTypes;
        }

        public static void BuildInterfaceAssociations(ClassSymbol classSymbol)
        {
            if (classSymbol.PrimaryPartialClass != classSymbol)
            {
                // Don't build interface associations for non-primary partial classes.
                return;
            }

            Dictionary<string, MemberSymbol> interfaceMemberSymbols = new Dictionary<string, MemberSymbol>();
            AggregateInterfaceMembers(classSymbol.Interfaces, interfaceMemberSymbols);

            if (interfaceMemberSymbols.Count > 0)
            {
                foreach (MemberSymbol memberSymbol in interfaceMemberSymbols.Values)
                {
                    MemberSymbol associatedSymbol = classSymbol.GetMember(memberSymbol.Name);

                    if (associatedSymbol != null)
                    {
                        associatedSymbol.SetInterfaceMember(memberSymbol);
                    }
                }
            }
        }

        public static void AggregateInterfaceMembers(ICollection<InterfaceSymbol> subInterfaceCollection,
                                               Dictionary<string, MemberSymbol> aggregateMemberCollection)
        {
            if (subInterfaceCollection == null)
            {
                return;
            }

            foreach (InterfaceSymbol newInterfaceSymbol in subInterfaceCollection)
            {
                AddInterfaceMembers(newInterfaceSymbol.Members, aggregateMemberCollection);
                AggregateInterfaceMembers(newInterfaceSymbol.Interfaces, aggregateMemberCollection);
            }
        }

        public static void AddInterfaceMembers(ICollection<MemberSymbol> newMemberSymbols,
                                         Dictionary<string, MemberSymbol> aggregateMemberCollection)
        {
            if (newMemberSymbols == null)
            {
                return;
            }

            foreach (MemberSymbol newMemberSymbol in newMemberSymbols)
                if (!aggregateMemberCollection.ContainsKey(newMemberSymbol.Name))
                {
                    aggregateMemberCollection[newMemberSymbol.Name] = newMemberSymbol;
                }
        }

        public IEnumerable<MethodSymbol> GetExtensionMethods(IEnumerable<MemberSymbol> memberSymbols)
        {
            return memberSymbols.Where(member => member is MethodSymbol method && method.IsExtensionMethod && method.IsPublic)
                .Cast<MethodSymbol>();
        }

        private void ImportBaseType(ClassSymbol classSymbol)
        {
            TypeDefinition type = (TypeDefinition) classSymbol.MetadataReference;
            ICollection<InterfaceSymbol> interfaces = GetInterfaceSymbols(type.Interfaces);
            TypeReference baseType = type.BaseType;

            if (baseType != null)
            {
                if (ResolveType(baseType) is ClassSymbol baseClassSymbol &&
                    string.CompareOrdinal(baseClassSymbol.FullName, "Object") != 0)
                {
                    classSymbol.SetInheritance(baseClassSymbol, interfaces);
                }
            }
            else
            {
                classSymbol.SetInheritance(null, interfaces);
            }
        }

        private void ImportInterfaces(InterfaceSymbol interfaceSymbol)
        {
            TypeDefinition type = (TypeDefinition) interfaceSymbol.MetadataReference;
            ICollection<InterfaceSymbol> interfaces = GetInterfaceSymbols(type.Interfaces);
            interfaceSymbol.SetInheritance(interfaces);
        }

        private ICollection<InterfaceSymbol> GetInterfaceSymbols(
            ICollection<InterfaceImplementation> interfaceReferences)
        {
            if (interfaceReferences == null || interfaceReferences.Count == 0)
            {
                return null;
            }

            return interfaceReferences.Select(i => (InterfaceSymbol) ResolveType(i.InterfaceType)).ToList();
        }

        private void ImportDelegateInvoke(TypeSymbol delegateTypeSymbol)
        {
            TypeDefinition type = (TypeDefinition) delegateTypeSymbol.MetadataReference;

            foreach (MethodDefinition method in type.Methods)
            {
                if (string.CompareOrdinal(method.Name, "Invoke") != 0)
                {
                    continue;
                }

                TypeSymbol returnType = ResolveType(method.MethodReturnType.ReturnType);
                Debug.Assert(returnType != null);

                if (returnType == null)
                {
                    continue;
                }

                MethodSymbol methodSymbol =
                    new MethodSymbol("Invoke", delegateTypeSymbol, returnType, MemberVisibility.Public);
                methodSymbol.SetImplementationState(SymbolImplementationFlags.Abstract);
                methodSymbol.SetTransformedName(string.Empty);

                delegateTypeSymbol.AddMember(methodSymbol);
            }
        }

        private void ImportEnumFields(TypeSymbol enumTypeSymbol)
        {
            TypeDefinition type = (TypeDefinition) enumTypeSymbol.MetadataReference;

            foreach (FieldDefinition field in type.Fields)
            {
                if (field.IsSpecialName)
                {
                    continue;
                }

                Debug.Assert(enumTypeSymbol is EnumerationSymbol);
                EnumerationSymbol enumSymbol = (EnumerationSymbol) enumTypeSymbol;

                TypeSymbol fieldType;

                if (enumSymbol.UseNamedValues)
                {
                    fieldType = symbols.ResolveIntrinsicType(IntrinsicType.String);
                }
                else
                {
                    fieldType = symbols.ResolveIntrinsicType(IntrinsicType.Integer);
                }

                string fieldName = field.Name;

                EnumerationFieldSymbol fieldSymbol =
                    new EnumerationFieldSymbol(fieldName, enumTypeSymbol, field.Constant, fieldType);
                ImportMemberDetails(fieldSymbol, null, field);

                enumTypeSymbol.AddMember(fieldSymbol);
            }
        }

        private void ImportEvents(TypeSymbol typeSymbol)
        {
            TypeDefinition type = (TypeDefinition) typeSymbol.MetadataReference;

            foreach (EventDefinition eventDef in type.Events)
            {
                if (eventDef.IsSpecialName)
                {
                    continue;
                }

                if (eventDef.AddMethod == null || eventDef.RemoveMethod == null)
                {
                    continue;
                }

                if (eventDef.AddMethod.IsPrivate || eventDef.AddMethod.IsAssembly ||
                    eventDef.AddMethod.IsFamilyAndAssembly)
                {
                    continue;
                }

                string eventName = eventDef.Name;

                TypeSymbol eventHandlerType = ResolveType(eventDef.EventType);

                if (eventHandlerType == null)
                {
                    continue;
                }

                EventSymbol eventSymbol = new EventSymbol(eventName, typeSymbol, eventHandlerType);
                ImportMemberDetails(eventSymbol, eventDef.AddMethod, eventDef);

                if (MetadataHelpers.GetScriptEventAccessors(eventDef, out string addAccessor, out string removeAccessor))
                {
                    eventSymbol.SetAccessors(addAccessor, removeAccessor);
                }

                typeSymbol.AddMember(eventSymbol);
            }
        }

        private void ImportFields(TypeSymbol typeSymbol)
        {
            TypeDefinition type = (TypeDefinition) typeSymbol.MetadataReference;

            foreach (FieldDefinition field in type.Fields)
            {
                if (field.IsSpecialName)
                {
                    continue;
                }

                if (field.IsPrivate || field.IsAssembly || field.IsFamilyAndAssembly)
                {
                    continue;
                }

                string fieldName = field.Name;

                TypeSymbol fieldType = ResolveType(field.FieldType);

                if (fieldType == null)
                {
                    continue;
                }

                MemberVisibility visibility = MemberVisibility.PrivateInstance;

                if (field.IsStatic)
                {
                    visibility |= MemberVisibility.Static;
                }

                if (field.IsPublic)
                {
                    visibility |= MemberVisibility.Public;
                }
                else if (field.IsFamily || field.IsFamilyOrAssembly)
                {
                    visibility |= MemberVisibility.Protected;
                }

                FieldSymbol fieldSymbol = new FieldSymbol(fieldName, typeSymbol, fieldType);

                fieldSymbol.SetVisibility(visibility);
                ImportMemberDetails(fieldSymbol, null, field);

                typeSymbol.AddMember(fieldSymbol);
            }
        }

        private void ImportMemberDetails(MemberSymbol memberSymbol, MethodDefinition methodDefinition,
                                         ICustomAttributeProvider attributeProvider)
        {
            if (methodDefinition != null)
            {
                MemberVisibility visibility = MemberVisibility.PrivateInstance;

                if (methodDefinition.IsStatic)
                {
                    visibility |= MemberVisibility.Static;
                }

                if (methodDefinition.IsPublic)
                {
                    visibility |= MemberVisibility.Public;
                }
                else if (methodDefinition.IsFamily || methodDefinition.IsFamilyOrAssembly)
                {
                    visibility |= MemberVisibility.Protected;
                }

                memberSymbol.SetVisibility(visibility);
            }

            string scriptName = MetadataHelpers.GetScriptName(attributeProvider, out bool _, out bool preserveCase);

            memberSymbol.SetNameCasing(preserveCase);

            if (scriptName != null)
            {
                memberSymbol.SetTransformedName(scriptName);
            }

            // PreserveName is ignored - it only is used for internal members, which are not imported.
        }

        private void ImportMembers(TypeSymbol typeSymbol)
        {
            switch (typeSymbol.Type)
            {
                case SymbolType.Class:
                case SymbolType.Interface:
                case SymbolType.Record:

                    if (typeSymbol.Type != SymbolType.Interface)
                    {
                        ImportFields(typeSymbol);
                    }

                    ImportProperties(typeSymbol);
                    ImportMethods(typeSymbol);
                    ImportEvents(typeSymbol);

                    break;
                case SymbolType.Enumeration:
                    ImportEnumFields(typeSymbol);

                    break;
                case SymbolType.Delegate:
                    ImportDelegateInvoke(typeSymbol);

                    break;
                default:
                    Debug.Fail("Unknown symbol type.");

                    break;
            }
        }

        public ICollection<TypeSymbol> ImportMetadata(ICollection<string> references, SymbolSet symbols)
        {
            Debug.Assert(references != null);
            Debug.Assert(symbols != null);

            this.symbols = symbols;

            MetadataSource mdSource = new MetadataSource();
            bool hasLoadErrors = mdSource.LoadReferences(references, errorHandler);

            ICollection<TypeSymbol> importedTypes = null;

            if (!hasLoadErrors)
            {
                importedTypes = ImportAssemblies(mdSource);
            }

            return resolveError 
                ? null 
                : importedTypes;
        }

        private void ImportMethods(TypeSymbol typeSymbol)
        {
            // NOTE: We do not import parameters for imported members.
            //       Parameters are used in the script model generation phase to populate
            //       symbol tables, which is not done for imported methods.

            TypeDefinition type = (TypeDefinition) typeSymbol.MetadataReference;

            foreach (MethodDefinition method in type.Methods)
            {
                if (method.IsSpecialName)
                {
                    continue;
                }

                if (method.IsPrivate || method.IsAssembly || method.IsFamilyAndAssembly)
                {
                    continue;
                }

                string methodName = method.Name;

                if (typeSymbol.GetMember(methodName) != null)
                {
                    // Ignore if its an overload since we don't care about parameters
                    // for imported methods, overloaded ctors don't matter.
                    // We just care about return values pretty much, and existence of the
                    // method.
                    continue;
                }

                TypeSymbol returnType = ResolveType(method.MethodReturnType.ReturnType);

                if (returnType == null)
                {
                    continue;
                }

                // skip symbol generation for members decorated with [ScriptIgnore]
                if (MetadataHelpers.IsIgnored(method))
                {
                    continue;
                }

                MethodSymbol methodSymbol = new MethodSymbol(
                    methodName, 
                    typeSymbol, 
                    returnType, 
                    MetadataHelpers.IsExtensionMethod(method));

                methodSymbol.SetParseContext(method);
                ImportMemberDetails(methodSymbol, method, method);

                if (method.HasGenericParameters)
                {
                    List<GenericParameterSymbol> genericArguments = new List<GenericParameterSymbol>();

                    foreach (GenericParameter genericParameter in method.GenericParameters)
                    {
                        GenericParameterSymbol arg =
                            new GenericParameterSymbol(genericParameter.Position, genericParameter.Name,
                                /* typeArgument */ false,
                                symbols.GlobalNamespace);
                        genericArguments.Add(arg);
                    }

                    methodSymbol.AddGenericArguments(genericArguments);
                }

                if (method.IsAbstract)
                {
                    // NOTE: We're ignoring the override scenario - it doesn't matter in terms
                    //       of the compilation and code generation
                    methodSymbol.SetImplementationState(SymbolImplementationFlags.Abstract);
                }

                if (MetadataHelpers.ShouldSkipFromScript(method))
                {
                    methodSymbol.SetSkipGeneration();
                }

                string transformedName = MetadataHelpers.GetTransformedName(method);

                if (string.IsNullOrEmpty(transformedName) == false)
                {
                    methodSymbol.SetTransformName(transformedName);
                }

                string scriptName = MetadataHelpers.GetScriptName(method, out _, out _);

                if (string.IsNullOrEmpty(scriptName) == false && !methodSymbol.IsTransformed)
                {
                    methodSymbol.SetTransformedName(scriptName);
                }

                string selector = MetadataHelpers.GetScriptMethodSelector(method);

                if (string.IsNullOrEmpty(selector) == false)
                {
                    methodSymbol.SetSelector(selector);
                }

                if (MetadataHelpers.ShouldTreatAsConditionalMethod(method, out ICollection<string> conditions))
                {
                    methodSymbol.SetConditions(conditions);
                }

                typeSymbol.AddMember(methodSymbol);
            }
        }

        private void ImportProperties(TypeSymbol typeSymbol)
        {
            TypeDefinition type = (TypeDefinition) typeSymbol.MetadataReference;

            foreach (PropertyDefinition property in type.Properties)
            {
                if (property.IsSpecialName)
                {
                    continue;
                }

                if (property.GetMethod == null)
                {
                    continue;
                }

                if (property.GetMethod.IsPrivate || property.GetMethod.IsAssembly ||
                    property.GetMethod.IsFamilyAndAssembly)
                {
                    continue;
                }

                string propertyName = property.Name;
                bool scriptField = MetadataHelpers.ShouldTreatAsScriptField(property);

                // TODO: Why are we ignoring the other bits...
                // bool dummyPreserveName;
                // bool preserveCase;
                // string dummyName = MetadataHelpers.GetScriptName(property, out dummyPreserveName, out preserveCase);

                TypeSymbol propertyType = ResolveType(property.PropertyType);

                if (propertyType == null)
                {
                    continue;
                }

                PropertySymbol propertySymbol = null;

                if (property.Parameters.Count != 0)
                {
                    IndexerSymbol indexerSymbol = new IndexerSymbol(typeSymbol, propertyType);
                    ImportMemberDetails(indexerSymbol, property.GetMethod, property);

                    if (scriptField)
                    {
                        indexerSymbol.SetScriptIndexer();
                    }

                    propertySymbol = indexerSymbol;
                    // propertySymbol.SetNameCasing(preserveCase);
                }
                else
                {
                    if (scriptField)
                    {
                        // Properties marked with this attribute are to be thought of as
                        // fields. If they are read-only, the C# compiler will enforce that,
                        // so we don't have to worry about making them read-write via a field
                        // instead of a property

                        FieldSymbol fieldSymbol = new FieldSymbol(propertyName, typeSymbol, propertyType);
                        ImportMemberDetails(fieldSymbol, property.GetMethod, property);

                        string transformedName = MetadataHelpers.GetTransformedName(property);

                        if (string.IsNullOrEmpty(transformedName) == false)
                        {
                            fieldSymbol.SetTransformName(transformedName);
                        }

                        typeSymbol.AddMember(fieldSymbol);
                    }
                    else
                    {
                        propertySymbol = new PropertySymbol(propertyName, typeSymbol, propertyType);
                        ImportMemberDetails(propertySymbol, property.GetMethod, property);
                        propertySymbol.SetNameCasing(true);

                        string transformedName = MetadataHelpers.GetTransformedName(property.GetMethod);

                        if (string.IsNullOrEmpty(transformedName) == false)
                        {
                            propertySymbol.SetTransformedName(transformedName);
                        }
                    }
                }

                if (propertySymbol != null)
                {
                    SymbolImplementationFlags implFlags = SymbolImplementationFlags.Regular;

                    if (property.SetMethod == null)
                    {
                        implFlags |= SymbolImplementationFlags.ReadOnly;
                    }

                    if (property.GetMethod.IsAbstract)
                    {
                        implFlags |= SymbolImplementationFlags.Abstract;
                    }

                    propertySymbol.SetImplementationState(implFlags);

                    typeSymbol.AddMember(propertySymbol);
                }
            }
        }

        //TODO: Investigate removing these.
        private void ImportPseudoMembers(PseudoClassMembers memberSet, ClassSymbol classSymbol)
        {
            // Import pseudo members that go on the class but aren't defined in mscorlib.dll
            // These are meant to be used by internal compiler-generated transformations etc.
            // and aren't meant to be referenced directly in C# code.

            if (memberSet == PseudoClassMembers.Script)
            {
                TypeSymbol objectType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol("Object", null,
                        SymbolFilter.Types);
                Debug.Assert(objectType != null);

                TypeSymbol stringType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol("String", null,
                        SymbolFilter.Types);
                Debug.Assert(stringType != null);

                TypeSymbol boolType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol("Boolean", null,
                        SymbolFilter.Types);
                Debug.Assert(boolType != null);

                TypeSymbol dateType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol("Date", null, SymbolFilter.Types);
                Debug.Assert(dateType != null);

                // Enumerate - IEnumerable.GetEnumerator gets mapped to this

                MethodSymbol enumerateMethod = new MethodSymbol("Enumerate", classSymbol, objectType,
                    MemberVisibility.Public | MemberVisibility.Static);
                enumerateMethod.SetTransformName(DSharpStringResources.ScriptExportMember("enumerate"));
                enumerateMethod.AddParameter(new ParameterSymbol("obj", enumerateMethod, objectType, ParameterMode.In));
                classSymbol.AddMember(enumerateMethod);

                // TypeName - Type.Name gets mapped to this

                MethodSymbol typeNameMethod = new MethodSymbol("GetTypeName", classSymbol, stringType,
                    MemberVisibility.Public | MemberVisibility.Static);
                typeNameMethod.SetTransformName(DSharpStringResources.ScriptExportMember("typeName"));
                typeNameMethod.AddParameter(new ParameterSymbol("obj", typeNameMethod, objectType, ParameterMode.In));
                classSymbol.AddMember(typeNameMethod);

                // CompareDates - Date equality checks get converted to call to compareDates

                MethodSymbol compareDatesMethod = new MethodSymbol("CompareDates", classSymbol, boolType,
                    MemberVisibility.Public | MemberVisibility.Static);
                compareDatesMethod.SetTransformName(DSharpStringResources.ScriptExportMember("compareDates"));
                compareDatesMethod.AddParameter(new ParameterSymbol("d1", compareDatesMethod, dateType,
                    ParameterMode.In));
                compareDatesMethod.AddParameter(new ParameterSymbol("d2", compareDatesMethod, dateType,
                    ParameterMode.In));
                classSymbol.AddMember(compareDatesMethod);

                return;
            }

            if (memberSet == PseudoClassMembers.Arguments)
            {
                TypeSymbol objectType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol(nameof(Object), null,
                        SymbolFilter.Types);
                Debug.Assert(objectType != null);

                IndexerSymbol indexer = new IndexerSymbol(classSymbol, objectType,
                    MemberVisibility.Public | MemberVisibility.Static);
                indexer.SetScriptIndexer();
                classSymbol.AddMember(indexer);

                return;
            }

            if (memberSet == PseudoClassMembers.Dictionary)
            {
                TypeSymbol intType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol(nameof(Int32), null, SymbolFilter.Types);
                Debug.Assert(intType != null);

                TypeSymbol stringType =
                    (TypeSymbol) ((ISymbolTable) symbols.SystemNamespace).FindSymbol(nameof(String), null,
                        SymbolFilter.Types);
                Debug.Assert(stringType != null);

                // Define Dictionary.Keys
                MethodSymbol getKeysMethod = new MethodSymbol("GetKeys", classSymbol,
                    symbols.CreateArrayTypeSymbol(stringType), MemberVisibility.Public | MemberVisibility.Static);
                getKeysMethod.SetTransformName(DSharpStringResources.ScriptExportMember("keys"));
                classSymbol.AddMember(getKeysMethod);

                // Define Dictionary.Values
                MethodSymbol getValuesMethod = new MethodSymbol("GetValues", classSymbol,
                    symbols.CreateArrayTypeSymbol(stringType), MemberVisibility.Public | MemberVisibility.Static);
                getValuesMethod.SetTransformName(DSharpStringResources.ScriptExportMember("values"));
                classSymbol.AddMember(getValuesMethod);

                // Define Dictionary.GetCount
                MethodSymbol countMethod = new MethodSymbol("GetKeyCount", classSymbol, intType,
                    MemberVisibility.Public | MemberVisibility.Static);
                countMethod.SetTransformName(DSharpStringResources.ScriptExportMember("keyCount"));
                classSymbol.AddMember(countMethod);
            }
        }

        private void ImportScriptAssembly(MetadataSource mdSource, string assemblyPath, bool coreAssembly)
        {
            string scriptName = null;

            AssemblyDefinition assembly;

            if (coreAssembly)
            {
                assembly = mdSource.CoreAssemblyMetadata;
            }
            else
            {
                assembly = mdSource.GetMetadata(assemblyPath);
            }

            string scriptNamespace = null;
            scriptName = MetadataHelpers.GetScriptAssemblyName(assembly, out string scriptIdentifier);

            if (string.IsNullOrEmpty(scriptName) == false)
            {
                ScriptReference dependency = new ScriptReference(scriptName, scriptIdentifier);

                symbols.AddDependency(dependency);
                scriptNamespace = dependency.Identifier;
            }

            foreach (TypeDefinition type in assembly.MainModule.Types)
                try
                {
                    if (MetadataHelpers.IsCompilerGeneratedType(type))
                    {
                        continue;
                    }

                    ImportType(mdSource, type, coreAssembly, scriptNamespace);
                }
                catch (Exception e)
                {
                    Debug.Fail(e.ToString());
                }
        }

        private void ImportType(MetadataSource mdSource, TypeDefinition type, bool inScriptCoreAssembly,
                                string scriptNamespace)
        {
            if (type.IsPublic == false)
            {
                return;
            }

            if (inScriptCoreAssembly && MetadataHelpers.ShouldImportScriptCoreType(type) == false)
            {
                return;
            }

            string name = type.Name;
            string namespaceName = type.Namespace;

            bool dummy;
            string scriptName = MetadataHelpers.GetScriptName(type, out dummy, out dummy);

            NamespaceSymbol namespaceSymbol = symbols.GetNamespace(namespaceName);
            TypeSymbol typeSymbol = null;

            if (type.IsInterface)
            {
                typeSymbol = new InterfaceSymbol(name, namespaceSymbol);
            }
            else if (MetadataHelpers.IsEnum(type))
            {
                // NOTE: We don't care about the flags bit on imported enums
                //       because this is only consumed by the generation logic.
                typeSymbol = new EnumerationSymbol(name, namespaceSymbol, /* flags */ false);

                if (MetadataHelpers.ShouldUseEnumNames(type))
                {
                    ((EnumerationSymbol) typeSymbol).SetNamedValues();
                }
                else if (MetadataHelpers.ShouldUseEnumValues(type))
                {
                    ((EnumerationSymbol) typeSymbol).SetNumericValues();
                }
            }
            else if (MetadataHelpers.IsDelegate(type))
            {
                typeSymbol = new DelegateSymbol(name, namespaceSymbol);
                typeSymbol.SetTransformedName("Function");
            }
            else
            {
                if (MetadataHelpers.ShouldTreatAsRecordType(type))
                {
                    typeSymbol = new RecordSymbol(name, namespaceSymbol);
                    typeSymbol.SetTransformedName(nameof(Object));
                }
                else
                {
                    typeSymbol = new ClassSymbol(name, namespaceSymbol);

                    if (MetadataHelpers.IsScriptExtension(type, out string extendee))
                    {
                        ((ClassSymbol) typeSymbol).SetExtenderClass(extendee);
                    }
                }
            }

            if (typeSymbol != null)
            {
                if (type.HasGenericParameters)
                {
                    List<GenericParameterSymbol> genericArguments = new List<GenericParameterSymbol>();

                    foreach (GenericParameter genericParameter in type.GenericParameters)
                    {
                        GenericParameterSymbol arg =
                            new GenericParameterSymbol(genericParameter.Position, genericParameter.Name,
                                /* typeArgument */ true,
                                symbols.GlobalNamespace);
                        genericArguments.Add(arg);
                    }

                    typeSymbol.AddGenericParameters(genericArguments);
                }

                ScriptReference dependency = null;
                string dependencyName = MetadataHelpers.GetScriptDependencyName(type, out string dependencyIdentifier);

                if (dependencyName != null)
                {
                    dependency = new ScriptReference(dependencyName, dependencyIdentifier);
                    scriptNamespace = dependency.Identifier;
                }

                typeSymbol.SetImported(dependency);
                typeSymbol.SetMetadataToken(type, inScriptCoreAssembly);

                bool ignoreNamespace = MetadataHelpers.ShouldIgnoreNamespace(type);

                if (ignoreNamespace || string.IsNullOrEmpty(scriptNamespace))
                {
                    typeSymbol.SetIgnoreNamespace();
                }
                else
                {
                    typeSymbol.ScriptNamespace = scriptNamespace;
                }

                typeSymbol.IsPublic = true;

                if (string.IsNullOrEmpty(scriptName) == false)
                {
                    typeSymbol.SetTransformedName(scriptName);
                }

                SetArrayTypeMetadata(type, typeSymbol, scriptName);

                namespaceSymbol.AddType(typeSymbol);
                importedTypes.Add(typeSymbol);
            }
        }

        private void SetArrayTypeMetadata(TypeDefinition type, TypeSymbol symbol, string scriptName)
        {
            if (scriptName == nameof(Array) || scriptName == nameof(Object))
            {
                symbol.SetNativeArray();
            }
        }

        private TypeSymbol ResolveType(TypeReference type)
        {
            int arrayDimensions = 0;

            while (type is ArrayType arrayType)
            {
                arrayDimensions++;
                type = arrayType.ElementType;
            }

            GenericInstanceType genericType = type as GenericInstanceType;
            if (genericType != null)
            {
                type = genericType.ElementType;
            }

            string name = type.FullName;

            if (string.CompareOrdinal(name, MscorlibTypeNames.System_ValueType) == 0)
            {
                // Ignore this type - it is the base class for enums, and other primitive types
                // but we don't import it since it is not useful in script
                return null;
            }

            TypeSymbol typeSymbol;

            if (type is GenericParameter genericParameter)
            {
                typeSymbol = new GenericParameterSymbol(genericParameter.Position, genericParameter.Name,
                    genericParameter.Owner.GenericParameterType == GenericParameterType.Type,
                    symbols.GlobalNamespace);
            }
            else
            {
                typeSymbol = (TypeSymbol) ((ISymbolTable) symbols).FindSymbol(name, null, SymbolFilter.Types);

                if (typeSymbol == null)
                {
                    //TODO: Improve this error and provide context as to what type is missing from where
                    errorHandler.ReportMissingReferenceError(name);
                    resolveError = true;
                }
            }

            if (genericType != null)
            {
                List<TypeSymbol> typeArgs = new List<TypeSymbol>();

                foreach (TypeReference argTypeRef in genericType.GenericArguments)
                {
                    TypeSymbol argType = ResolveType(argTypeRef);
                    typeArgs.Add(argType);
                }

                typeSymbol = symbols.CreateGenericTypeSymbol(typeSymbol, typeArgs);
                Debug.Assert(typeSymbol != null);
            }

            if (arrayDimensions != 0)
            {
                for (int i = 0; i < arrayDimensions; i++) typeSymbol = symbols.CreateArrayTypeSymbol(typeSymbol);
            }

            return typeSymbol;
        }

        private enum PseudoClassMembers
        {
            Script,

            Dictionary,

            Arguments,

            Object
        }
    }
}
