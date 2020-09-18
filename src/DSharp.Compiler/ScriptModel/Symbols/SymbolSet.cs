// SymbolSet.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Extensions;
using DSharp.Compiler.References;
using DSharp.Compiler.ScriptModel.Visitors;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolSet : ISymbolTable
    {
        private class ExtensionMethodInfo
        {
            public string MethodNamespace { get; set; }
            public MethodSymbol MethodSymbol { get; set; }
            public bool IsTargetParameterGeneric { get; set; }
            public string TargetParameterTypeFullName { get; set; }
        }

        private readonly List<ScriptReference> dependencies;
        private readonly Dictionary<string, ScriptReference> dependencySet;
        private readonly Dictionary<string, NamespaceSymbol> namespaceMap;
        private readonly Dictionary<string, List<ExtensionMethodInfo>> extensionMethods;

        private readonly List<NamespaceSymbol> namespaces;

        private readonly Dictionary<string, Dictionary<string, ResXItem>> resources;

        private Dictionary<string, TypeSymbol> arrayTypeTable;

        private XmlDocument docComments;

        private Dictionary<string, TypeSymbol> genericTypeTable = new Dictionary<string, TypeSymbol>();

        public SymbolSet()
        {
            namespaces = new List<NamespaceSymbol>();
            namespaceMap = new Dictionary<string, NamespaceSymbol>();
            extensionMethods = new Dictionary<string, List<ExtensionMethodInfo>>();

            GlobalNamespace = new NamespaceSymbol(string.Empty, this);
            GlobalNamespace.SetTransformedName(string.Empty);
            namespaces.Add(GlobalNamespace);
            namespaceMap[string.Empty] = GlobalNamespace;

            SystemNamespace = new NamespaceSymbol("System", this);
            namespaces.Add(SystemNamespace);
            namespaceMap["System"] = SystemNamespace;

            dependencies = new List<ScriptReference>();
            dependencySet = new Dictionary<string, ScriptReference>(StringComparer.Ordinal);
            resources = new Dictionary<string, Dictionary<string, ResXItem>>(StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerable<ScriptReference> Dependencies => dependencies;

        public MemberSymbol EntryPoint { get; private set; }

        public NamespaceSymbol GlobalNamespace { get; }

        public bool HasResources => resources.Count != 0;

        public ICollection<NamespaceSymbol> Namespaces => namespaces;

        public string ScriptName { get; set; }

        public NamespaceSymbol SystemNamespace { get; }

        public void AddDependency(ScriptReference dependency)
        {
            if (dependencySet.TryGetValue(dependency.Name, out ScriptReference existingDependency))
            {
                // The dependency already exists ... copy over identifier
                // from the new one to the existing one.

                // This is to support the scenario where a dependency got defined
                // by virtue of the app using a [ScriptReference] to specify path/delayLoad
                // semnatics, and we're finding the imported dependency later on
                // such as when a type with a dependency is referred in the code.

                if (existingDependency.HasIdentifier == false &&
                    dependency.HasIdentifier)
                {
                    existingDependency.Identifier = dependency.Identifier;
                }
            }
            else
            {
                dependencies.Add(dependency);
                dependencySet[dependency.Name] = dependency;
            }
        }

        public TypeSymbol CreateArrayTypeSymbol(TypeSymbol itemTypeSymbol)
        {
            if (arrayTypeTable != null && arrayTypeTable.ContainsKey(itemTypeSymbol.FullName))
            {
                return arrayTypeTable[itemTypeSymbol.FullName];
            }

            TypeSymbol specificArrayTypeSymbol = CreateArrayTypeCore(itemTypeSymbol);

            if (arrayTypeTable == null)
            {
                arrayTypeTable = new Dictionary<string, TypeSymbol>();
            }

            arrayTypeTable[itemTypeSymbol.FullName] = specificArrayTypeSymbol;

            return specificArrayTypeSymbol;
        }

        private TypeSymbol CreateArrayTypeCore(TypeSymbol itemTypeSymbol)
        {
            TypeSymbol arrayTypeSymbol =
                (TypeSymbol)((ISymbolTable)SystemNamespace).FindSymbol("Array", null, SymbolFilter.Types);
            Debug.Assert(arrayTypeSymbol != null);

            TypeSymbol specificArrayTypeSymbol = new ClassSymbol("Array", SystemNamespace);
            foreach (MemberSymbol memberSymbol in arrayTypeSymbol.Members)
                specificArrayTypeSymbol.AddMember(memberSymbol);

            IndexerSymbol indexerSymbol = new IndexerSymbol(specificArrayTypeSymbol, itemTypeSymbol,
                MemberVisibility.Public);
            indexerSymbol.SetScriptIndexer();
            specificArrayTypeSymbol.AddMember(indexerSymbol);
            specificArrayTypeSymbol.SetIgnoreNamespace();
            specificArrayTypeSymbol.SetNativeArray();

            return specificArrayTypeSymbol;
        }

        private MemberSymbol CreateGenericMember(MemberSymbol templateMember, IList<TypeSymbol> typeArguments)
        {
            TypeSymbol parentType = (TypeSymbol)templateMember.Parent;
            TypeSymbol instanceAssociatedType;

            if (templateMember.AssociatedType.Type == SymbolType.GenericParameter)
            {
                GenericParameterSymbol genericParameter = (GenericParameterSymbol)templateMember.AssociatedType;
                instanceAssociatedType = typeArguments[genericParameter.Index];
            }
            else
            {
                instanceAssociatedType = typeArguments[0];
            }

            if (templateMember.Type == SymbolType.Indexer)
            {
                IndexerSymbol templateIndexer = (IndexerSymbol)templateMember;
                IndexerSymbol instanceIndexer = new IndexerSymbol(parentType, instanceAssociatedType);

                if (templateIndexer.UseScriptIndexer)
                {
                    instanceIndexer.SetScriptIndexer();
                }

                instanceIndexer.SetVisibility(templateIndexer.Visibility);

                return instanceIndexer;
            }

            if (templateMember.Type == SymbolType.Property)
            {
                PropertySymbol templateProperty = (PropertySymbol)templateMember;
                PropertySymbol instanceProperty =
                    new PropertySymbol(templateProperty.Name, parentType, instanceAssociatedType);

                if (templateProperty.IsTransformed)
                {
                    instanceProperty.SetTransformedName(templateProperty.GeneratedName);
                }

                instanceProperty.SetNameCasing(templateProperty.IsCasePreserved);
                instanceProperty.SetVisibility(templateProperty.Visibility);

                return instanceProperty;
            }

            if (templateMember.Type == SymbolType.Field)
            {
                FieldSymbol templateField = (FieldSymbol)templateMember;
                FieldSymbol instanceField = new FieldSymbol(templateField.Name, parentType, instanceAssociatedType);

                if (templateField.IsTransformed)
                {
                    instanceField.SetTransformName(templateField.GeneratedName);
                }

                instanceField.SetNameCasing(templateField.IsCasePreserved);
                instanceField.SetVisibility(templateField.Visibility);

                return instanceField;
            }

            if (templateMember.Type == SymbolType.Method)
            {
                MethodSymbol templateMethod = (MethodSymbol)templateMember;
                MethodSymbol instanceMethod = new MethodSymbol(templateMethod.Name, parentType, instanceAssociatedType);

                if (templateMethod.IsAliased)
                {
                    instanceMethod.SetTransformedName(templateMethod.TransformName);
                }
                else if (templateMethod.IsTransformed)
                {
                    instanceMethod.SetTransformedName(templateMethod.GeneratedName);
                }

                if (templateMethod.SkipGeneration)
                {
                    instanceMethod.SetSkipGeneration();
                }

                if (templateMethod.InterfaceMember != null)
                {
                    instanceMethod.SetInterfaceMember(templateMethod.InterfaceMember);
                }

                instanceMethod.SetNameCasing(templateMethod.IsCasePreserved);
                instanceMethod.SetVisibility(templateMethod.Visibility);

                return instanceMethod;
            }

            Debug.Fail("Unexpected generic member '" + templateMember.Name + " on type '" +
                       ((TypeSymbol)templateMember.Parent).FullName + "'.");

            return null;
        }

        public TypeSymbol CreateGenericTypeSymbol(TypeSymbol templateType, IList<TypeSymbol> typeArguments)
        {
            foreach (TypeSymbol typeSymbol in typeArguments)
                if (typeSymbol is GenericParameterSymbol genericParameterSymbol && genericParameterSymbol.Owner == null)
                {
                    return templateType;
                }

            string key = CreateTypeName(templateType, typeArguments);

            if (!genericTypeTable.TryGetValue(key, out TypeSymbol instanceTypeSymbol))
            {
                // Prepopulate with a placeholder ... if a generic type's member refers to its
                // parent type it will use the type being created when the return value is null.
                genericTypeTable[key] = null;
                instanceTypeSymbol = CreateGenericTypeCore(templateType, typeArguments);
                genericTypeTable[key] = instanceTypeSymbol;
            }
            return instanceTypeSymbol;
        }

        private static string CreateTypeName(TypeSymbol symbol, IEnumerable<TypeSymbol> arguments)
        {
            if (arguments?.Any() ?? false)
            {
                return $"{symbol.FullName}<{string.Join(",", arguments.Select(s => CreateTypeName(s, s.GenericArguments)))}>";
            }

            return symbol.FullName;
        }

        private TypeSymbol CreateGenericTypeCore(TypeSymbol templateType, IList<TypeSymbol> typeArguments)
        {
            if (templateType.Type == SymbolType.Delegate)
            {
                DelegateSymbol genericDelegate = (DelegateSymbol)templateType;
                DelegateSymbol instanceDelegate =
                    new DelegateSymbol(genericDelegate.Name, (NamespaceSymbol)genericDelegate.Parent);

                instanceDelegate.AddGenericParameters(genericDelegate.GenericParameters);
                instanceDelegate.AddGenericArguments(genericDelegate, typeArguments);

                CreateGenericTypeMembers(genericDelegate, instanceDelegate, typeArguments);

                return instanceDelegate;
            }



            if (templateType.Type == SymbolType.Class
                || templateType.Type == SymbolType.Interface)
            {
                TypeSymbol genericCoreType = null;
                TypeSymbol instanceCoreType = null;

                if (templateType.Type == SymbolType.Class)
                {
                    ClassSymbol genericClass = (ClassSymbol)templateType;
                    ClassSymbol instanceClass = new ClassSymbol(genericClass.Name, (NamespaceSymbol)genericClass.Parent);

                    instanceClass.SetInheritance(genericClass.BaseClass, genericClass.Interfaces);

                    genericCoreType = genericClass;
                    instanceCoreType = instanceClass;
                }
                else if (templateType.Type == SymbolType.Interface)
                {
                    InterfaceSymbol genericInterface = (InterfaceSymbol)templateType;
                    InterfaceSymbol instanceInterface =
                        new InterfaceSymbol(genericInterface.Name, (NamespaceSymbol)genericInterface.Parent);

                    instanceInterface.SetInheritance(genericInterface.Interfaces);

                    genericCoreType = genericInterface;
                    instanceCoreType = instanceInterface;
                }

                if (genericCoreType.Dependency != null)
                {
                    instanceCoreType.SetImported(genericCoreType.Dependency);
                }

                if (genericCoreType.IgnoreNamespace)
                {
                    instanceCoreType.SetIgnoreNamespace();
                }

                instanceCoreType.ScriptNamespace = genericCoreType.ScriptNamespace;

                if (genericCoreType.IsTransformed)
                {
                    instanceCoreType.SetTransformedName(genericCoreType.GeneratedName);
                }
                else if (genericCoreType.IsTransformAllowed == false)
                {
                    instanceCoreType.DisableNameTransformation();
                }

                if (genericCoreType.IsNativeArray)
                {
                    instanceCoreType.SetNativeArray();
                }

                instanceCoreType.AddGenericParameters(genericCoreType.GenericParameters);
                instanceCoreType.AddGenericArguments(genericCoreType, typeArguments);

                CreateGenericTypeMembers(genericCoreType, instanceCoreType, typeArguments);

                if (templateType.IgnoreGenericTypeArguments)
                {
                    instanceCoreType.SetIgnoreGenerics();
                }

                return instanceCoreType;
            }

            return null;
        }

        private void CreateGenericTypeMembers(TypeSymbol templateType, TypeSymbol instanceType,
                                              IList<TypeSymbol> typeArguments)
        {
            foreach (MemberSymbol memberSymbol in templateType.Members)
                if (memberSymbol.AssociatedType.Type == SymbolType.GenericParameter &&
                    ((GenericParameterSymbol)memberSymbol.AssociatedType).IsTypeParameter)
                {
                    MemberSymbol instanceMemberSymbol = CreateGenericMember(memberSymbol, typeArguments);
                    instanceType.AddMember(instanceMemberSymbol);
                }
                else if (memberSymbol.AssociatedType.IsGeneric &&
                         memberSymbol.AssociatedType.GenericArguments == null &&
                         memberSymbol.AssociatedType.GenericParameters.Count == typeArguments.Count)
                {
                    TypeSymbol genericType = CreateGenericTypeSymbol(memberSymbol.AssociatedType, typeArguments);

                    if (genericType == null)
                    {
                        genericType = instanceType;
                    }

                    List<TypeSymbol> memberTypeArgs = new List<TypeSymbol> { genericType };

                    MemberSymbol instanceMemberSymbol = CreateGenericMember(memberSymbol, memberTypeArgs);
                    instanceType.AddMember(instanceMemberSymbol);
                }
                else
                {
                    instanceType.AddMember(memberSymbol);
                }

            IndexerSymbol indexer = null;

            if (templateType.Type == SymbolType.Class)
            {
                indexer = ((ClassSymbol)templateType).Indexer;
            }
            else if (templateType.Type == SymbolType.Interface)
            {
                indexer = ((InterfaceSymbol)templateType).Indexer;
            }

            if (indexer != null)
            {
                if (indexer.AssociatedType.Type == SymbolType.GenericParameter)
                {
                    MemberSymbol instanceIndexer = CreateGenericMember(indexer, typeArguments);
                    instanceType.AddMember(instanceIndexer);
                }
                else if (indexer.AssociatedType.IsGeneric &&
                         indexer.AssociatedType.GenericArguments == null &&
                         indexer.AssociatedType.GenericParameters.Count == typeArguments.Count)
                {
                    TypeSymbol genericType = CreateGenericTypeSymbol(indexer.AssociatedType, typeArguments);

                    if (genericType == null)
                    {
                        genericType = instanceType;
                    }

                    List<TypeSymbol> memberTypeArgs = new List<TypeSymbol> { genericType };

                    MemberSymbol instanceMemberSymbol = CreateGenericMember(indexer, memberTypeArgs);
                    instanceType.AddMember(instanceMemberSymbol);
                }
                else
                {
                    instanceType.AddMember(indexer);
                }
            }
        }

        private void CreateNamespace(string namespaceName)
        {
            if (namespaceName.IndexOf('.') > 0)
            {
                NamespaceSymbol namespaceSymbol = new NamespaceSymbol(namespaceName, this);

                namespaces.Add(namespaceSymbol);
                namespaceMap[namespaceName] = namespaceSymbol;
            }
            else
            {
                // Split up the namespace into its individual parts, and then
                // create namespace symbols for each sub-namespace leading up
                // to the full specified namespace

                string[] namespaceParts = namespaceName.Split('.');

                for (int i = 0; i < namespaceParts.Length; i++)
                {
                    string partialNamespace;

                    if (i == 0)
                    {
                        partialNamespace = namespaceParts[0];
                    }
                    else
                    {
                        partialNamespace = string.Join(".", namespaceParts, 0, i + 1);
                    }

                    NamespaceSymbol namespaceSymbol = new NamespaceSymbol(partialNamespace, this);

                    namespaces.Add(namespaceSymbol);
                    namespaceMap[namespaceName] = namespaceSymbol;
                }
            }
        }

        public ScriptReference GetDependency(string name, out bool newReference)
        {
            newReference = false;

            if (dependencySet.TryGetValue(name, out ScriptReference reference) == false)
            {
                reference = ScriptReferenceProvider.Instance.GetReference(name, null);
                newReference = true;
                AddDependency(reference);
            }

            return reference;
        }

        public NamespaceSymbol GetNamespace(string namespaceName)
        {
            if (namespaceMap.ContainsKey(namespaceName) == false)
            {
                CreateNamespace(namespaceName);
            }

            return namespaceMap[namespaceName];
        }

        public string GetParameterDocumentation(string id, string paramName)
        {
            if (docComments != null)
            {
                XmlNode paramNode = docComments.SelectSingleNode(
                    string.Format("//doc/members/member[@name='{0}']/param[@name='{1}']", id, paramName));

                if (paramNode != null)
                {
                    return paramNode.InnerXml;
                }
            }

            return string.Empty;
        }

        public Dictionary<string, ResXItem> GetResources(string name)
        {
            Debug.Assert(string.IsNullOrEmpty(name) == false);

            if (resources.TryGetValue(name, out Dictionary<string, ResXItem> resourceTable))
            {
                return resourceTable;
            }

            resourceTable = new Dictionary<string, ResXItem>(StringComparer.Ordinal);
            resources[name] = resourceTable;

            return resourceTable;
        }

        public string GetSummaryDocumentation(string id)
        {
            if (docComments != null)
            {
                XmlNode summaryNode = docComments.SelectSingleNode(
                    string.Format("//doc/members/member[@name='{0}']/summary", id));

                if (summaryNode != null)
                {
                    return summaryNode.InnerXml;
                }
            }

            return string.Empty;
        }

        public bool IsSymbol(TypeSymbol symbol, string symbolName)
        {
            return ((ISymbolTable)this).FindSymbol(symbolName, null, SymbolFilter.Types) == symbol;
        }

        public TypeSymbol[] ResolveIntrinsicTypes(params IntrinsicType[] types)
        {
            return types.Select(t => ResolveIntrinsicType(t)).ToArray();
        }

        /// <summary>
        ///     This maps C# intrinsic types (managed types that have an equivalent
        ///     C# keyword)
        /// </summary>
        public TypeSymbol ResolveIntrinsicType(IntrinsicType type)
        {
            string mappedTypeName = null;
            string mappedNamespace = null;

            switch (type)
            {
                case IntrinsicType.Object:
                    mappedTypeName = "Object";

                    break;
                case IntrinsicType.Boolean:
                    mappedTypeName = "Boolean";

                    break;
                case IntrinsicType.String:
                    mappedTypeName = "String";

                    break;
                case IntrinsicType.Integer:
                    mappedTypeName = "Int32";

                    break;
                case IntrinsicType.UnsignedInteger:
                    mappedTypeName = "UInt32";

                    break;
                case IntrinsicType.Long:
                    mappedTypeName = "Int64";

                    break;
                case IntrinsicType.UnsignedLong:
                    mappedTypeName = "UInt64";

                    break;
                case IntrinsicType.Short:
                    mappedTypeName = "Int16";

                    break;
                case IntrinsicType.UnsignedShort:
                    mappedTypeName = "UInt16";

                    break;
                case IntrinsicType.Byte:
                    mappedTypeName = "Byte";

                    break;
                case IntrinsicType.SignedByte:
                    mappedTypeName = "SByte";

                    break;
                case IntrinsicType.Single:
                    mappedTypeName = "Single";

                    break;
                case IntrinsicType.Date:
                    mappedTypeName = "Date";

                    break;
                case IntrinsicType.Decimal:
                    mappedTypeName = "Decimal";

                    break;
                case IntrinsicType.Double:
                    mappedTypeName = "Double";

                    break;
                case IntrinsicType.Delegate:
                    mappedTypeName = "Delegate";

                    break;
                case IntrinsicType.Function:
                    mappedTypeName = "Function";

                    break;
                case IntrinsicType.Void:
                    mappedTypeName = "Void";

                    break;
                case IntrinsicType.Array:
                    mappedTypeName = "Array";
                    break;

                case IntrinsicType.GenericList:
                    mappedTypeName = "List`1";
                    mappedNamespace = "System.Collections.Generic";
                    break;

                case IntrinsicType.GenericDictionary:
                    mappedTypeName = "Dictionary`2";
                    mappedNamespace = "System.Collections.Generic";
                    break;

                case IntrinsicType.IDictionary:
                    mappedTypeName = "IDictionary";
                    mappedNamespace = "System.Collections";
                    break;

                case IntrinsicType.GenericIDictionary:
                    mappedTypeName = "IDictionary`2";
                    mappedNamespace = "System.Collections.Generic";
                    break;

                case IntrinsicType.GenericIReadOnlyDictionary:
                    mappedTypeName = "IReadOnlyDictionary`2";
                    mappedNamespace = "System.Collections.Generic";
                    break;

                case IntrinsicType.Type:
                    mappedTypeName = "Type";
                    mappedNamespace = "System";

                    break;
                case IntrinsicType.MemberInfo:
                    mappedTypeName = "MemberInfo";
                    mappedNamespace = "System.Reflection";

                    break;
                case IntrinsicType.Enumerator:
                    mappedTypeName = "IEnumerator";
                    mappedNamespace = "System.Collections";

                    break;
                case IntrinsicType.Enum:
                    mappedTypeName = "Enum";

                    break;
                case IntrinsicType.Exception:
                    mappedTypeName = "Exception";

                    break;
                case IntrinsicType.Script:
                    mappedTypeName = "Script";

                    break;
                case IntrinsicType.Number:
                    mappedTypeName = "Number";

                    break;
                case IntrinsicType.Arguments:
                    mappedTypeName = "Arguments";

                    break;
                case IntrinsicType.Nullable:
                    mappedTypeName = "Nullable`1";

                    break;

                case IntrinsicType.Anonymous:
                    mappedTypeName = "__AnonymousType__";
                    mappedNamespace = "";
                    break;

                default:
                    Debug.Fail("Unmapped intrinsic type " + type);
                    break;
            }

            NamespaceSymbol ns = SystemNamespace;

            if (mappedNamespace != null)
            {
                ns = GetNamespace(mappedNamespace);
                Debug.Assert(ns != null);
            }

            if (mappedTypeName != null)
            {
                TypeSymbol typeSymbol =
                    (TypeSymbol)((ISymbolTable)ns).FindSymbol(mappedTypeName, null, SymbolFilter.Types);
                Debug.Assert(typeSymbol != null);

                return typeSymbol;
            }

            return null;
        }

        public TypeSymbol ResolveIntrinsicToken(Token token)
        {
            if (token == null)
            {
                return null;
            }

            IntrinsicType intrinsicType = IntrinsicType.Void;

            switch (token.Type)
            {
                case TokenType.Object:
                    intrinsicType = IntrinsicType.Object;
                    break;
                case TokenType.Bool:
                    intrinsicType = IntrinsicType.Boolean;
                    break;
                case TokenType.String:
                case TokenType.Char:
                    intrinsicType = IntrinsicType.String;
                    break;
                case TokenType.Int:
                    intrinsicType = IntrinsicType.Integer;
                    break;
                case TokenType.UInt:
                    intrinsicType = IntrinsicType.UnsignedInteger;
                    break;
                case TokenType.Long:
                    intrinsicType = IntrinsicType.Long;
                    break;
                case TokenType.ULong:
                    intrinsicType = IntrinsicType.UnsignedLong;
                    break;
                case TokenType.Short:
                    intrinsicType = IntrinsicType.Short;
                    break;
                case TokenType.UShort:
                    intrinsicType = IntrinsicType.UnsignedShort;
                    break;
                case TokenType.Byte:
                    intrinsicType = IntrinsicType.Byte;
                    break;
                case TokenType.SByte:
                    intrinsicType = IntrinsicType.SignedByte;
                    break;
                case TokenType.Float:
                    intrinsicType = IntrinsicType.Single;
                    break;
                case TokenType.Decimal:
                    intrinsicType = IntrinsicType.Decimal;
                    break;
                case TokenType.Double:
                    intrinsicType = IntrinsicType.Double;
                    break;
                case TokenType.Delegate:
                    intrinsicType = IntrinsicType.Delegate;
                    break;
                case TokenType.Void:
                    intrinsicType = IntrinsicType.Void;
                    break;
            }

            return ResolveIntrinsicType(intrinsicType);
        }

        public TypeSymbol ResolveType(ParseNode node, ISymbolTable symbolTable, Symbol contextSymbol)
        {
            if (node is IntrinsicTypeNode intrinsicTypeNode)
            {
                IntrinsicType intrinsicType = IntrinsicType.Integer;

                switch (intrinsicTypeNode.Type)
                {
                    case TokenType.Object:
                        intrinsicType = IntrinsicType.Object;

                        break;
                    case TokenType.Bool:
                        intrinsicType = IntrinsicType.Boolean;

                        break;
                    case TokenType.String:
                    case TokenType.Char:
                        intrinsicType = IntrinsicType.String;

                        break;
                    case TokenType.Int:
                        intrinsicType = IntrinsicType.Integer;

                        break;
                    case TokenType.UInt:
                        intrinsicType = IntrinsicType.UnsignedInteger;

                        break;
                    case TokenType.Long:
                        intrinsicType = IntrinsicType.Long;

                        break;
                    case TokenType.ULong:
                        intrinsicType = IntrinsicType.UnsignedLong;

                        break;
                    case TokenType.Short:
                        intrinsicType = IntrinsicType.Short;

                        break;
                    case TokenType.UShort:
                        intrinsicType = IntrinsicType.UnsignedShort;

                        break;
                    case TokenType.Byte:
                        intrinsicType = IntrinsicType.Byte;

                        break;
                    case TokenType.SByte:
                        intrinsicType = IntrinsicType.SignedByte;

                        break;
                    case TokenType.Float:
                        intrinsicType = IntrinsicType.Single;

                        break;
                    case TokenType.Decimal:
                        intrinsicType = IntrinsicType.Decimal;

                        break;
                    case TokenType.Double:
                        intrinsicType = IntrinsicType.Double;

                        break;
                    case TokenType.Delegate:
                        intrinsicType = IntrinsicType.Delegate;

                        break;
                    case TokenType.Void:
                        intrinsicType = IntrinsicType.Void;

                        break;
                }

                TypeSymbol typeSymbol = ResolveIntrinsicType(intrinsicType);

                if (intrinsicTypeNode.IsNullable)
                {
                    TypeSymbol nullableType = ResolveIntrinsicType(IntrinsicType.Nullable);
                    typeSymbol = CreateGenericTypeSymbol(nullableType, new List<TypeSymbol> { typeSymbol });
                }

                return typeSymbol;
            }

            if (node is ArrayTypeNode)
            {
                ArrayTypeNode arrayTypeNode = (ArrayTypeNode)node;

                TypeSymbol itemTypeSymbol = ResolveType(arrayTypeNode.BaseType, symbolTable, contextSymbol);
                Debug.Assert(itemTypeSymbol != null);

                return CreateArrayTypeSymbol(itemTypeSymbol);
            }

            if (node is AtomicNameNode atomicNameNode)
            {
                TypeSymbol typeSymbol = ResolveAtomicNameNodeType(atomicNameNode, symbolTable, contextSymbol);
                if (typeSymbol != null)
                {
                    return typeSymbol;
                }
            }

            if (node is GenericNameNode genericNameNode)
            {
                string genericTypeName = genericNameNode.Name + "`" + genericNameNode.TypeArguments.Count;
                TypeSymbol templateType =
                    (TypeSymbol)symbolTable.FindSymbol(genericTypeName, contextSymbol, SymbolFilter.Types);

                if (!templateType.IsGeneric || genericNameNode.TypeArguments.All(n => n is AtomicNameNode n1 && n1.Name == "__unknown"))
                {
                    //generics ignored
                    return templateType;
                }

                List<TypeSymbol> typeArguments = new List<TypeSymbol>();

                foreach (ParseNode argNode in genericNameNode.TypeArguments)
                {
                    TypeSymbol argType = ResolveType(argNode, symbolTable, contextSymbol);
                    if (argType == null)
                    {
                        return null;
                    }
                    Debug.Assert(argType != null);
                    typeArguments.Add(argType);
                }

                if (templateType != null)
                {
                    TypeSymbol resolvedSymbol = CreateGenericTypeSymbol(templateType, typeArguments);
                    Debug.Assert(resolvedSymbol != null);

                    return resolvedSymbol;
                }
            }

            Debug.Assert(node is NameNode);

            if (node is NameNode nameNode)
            {
                if (symbolTable.FindSymbol(nameNode.Name, contextSymbol, SymbolFilter.Types) is TypeSymbol typeSymbol)
                {
                    return typeSymbol;
                }
            }

            if (node is MultiPartNameNode multiPartNameNode)
            {
                var parts = multiPartNameNode.Parts.Reverse();
                var names = new List<string>();

                string multipartName = string.Join(".", multiPartNameNode.Parts.Select(nn => nn.Identifier.Identifier));
                if (symbolTable.FindSymbol(multipartName, contextSymbol, SymbolFilter.Types) is TypeSymbol rootedType)
                {
                    return rootedType;
                }

                foreach (var part in parts)
                {
                    names.Insert(0, part.Name);
                    var nestedTypeName = string.Join("$", names);

                    if (symbolTable.FindSymbol(nestedTypeName, contextSymbol, SymbolFilter.Types) is TypeSymbol typeSymbol)
                    {
                        return typeSymbol;
                    }
                }

            }

            return default;
        }

        private TypeSymbol ResolveAtomicNameNodeType(AtomicNameNode atomicNameNode, ISymbolTable symbolTable, Symbol contextSymbol)
        {
            if (atomicNameNode.Parent is GenericNameNode || atomicNameNode.Parent is ArrayTypeNode || atomicNameNode.Parent is MethodDeclarationNode)
            {
                var methodDeclaration = atomicNameNode.FindParent<MethodDeclarationNode>();
                if (methodDeclaration != null && (methodDeclaration?.TypeParameters?.Count ?? 0) > 0)
                {
                    if (contextSymbol is MethodSymbol methodSymbol && methodSymbol.Name == methodDeclaration.Name)
                    {
                        var genericArgument = methodSymbol.GenericArguments.FirstOrDefault(arg => arg.Name == atomicNameNode.Name);
                        if (genericArgument != null)
                        {
                            return genericArgument;
                        }
                    }

                    for (int i = 0; i < methodDeclaration.TypeParameters.Count; i++)
                    {
                        TypeParameterNode typeParameterNode = (TypeParameterNode)methodDeclaration.TypeParameters[i];
                        if (typeParameterNode.NameNode.Equals(atomicNameNode))
                        {
                            return new GenericParameterSymbol(i, atomicNameNode.Name, true, GlobalNamespace);
                        }
                    }
                }
            }

            //TODO: Implement Var resolution mechanism here. Need to evaluate the right hand expression of the node, probably needs roslyn
            if (atomicNameNode.Name == "var")
            {
                return ResolveIntrinsicType(IntrinsicType.Object);
            }

            return null;
        }

        public void AddExtensionMethod(MethodSymbol extensionMethod, string targetParameterTypeFullName, bool isTargetParameterGeneric)
        {
            if (!extensionMethods.ContainsKey(extensionMethod.Name))
            {
                extensionMethods[extensionMethod.Name] = new List<ExtensionMethodInfo>();
            }

            extensionMethods[extensionMethod.Name].Add(new ExtensionMethodInfo()
            {
                MethodSymbol = extensionMethod,
                MethodNamespace = extensionMethod.GetFirstClassSymbolParent()?.Namespace,
                IsTargetParameterGeneric = isTargetParameterGeneric,
                TargetParameterTypeFullName = targetParameterTypeFullName,
            });
        }

        //TODO: Migrate this to be on the symbol directly
        public MethodSymbol ResolveExtensionMethodSymbol(TypeSymbol type, string memberName, IEnumerable<string> visibleNamespaces)
        {
            //Try to find none generic extension method
            var extensionMethods = TypeSymbolVisitor.Visit(type, t => FindExtensionMethodWithNonGenericTarget(t, memberName, visibleNamespaces))
                .Where(i => i != null)
                .Distinct()
                .ToList();

            if (extensionMethods.Any())
            {
                return extensionMethods.First();
            }

            //Try finding none constraint generic version
            extensionMethods = TypeSymbolVisitor.Visit(type, t => FindExtensionMethodWithGenericTarget(t, memberName, visibleNamespaces))
                .Where(i => i != null)
                .Distinct()
                .ToList();

            if (extensionMethods.Any())
            {
                return extensionMethods.First();
            }

            var objectType = ResolveIntrinsicType(IntrinsicType.Object);
            return FindExtensionMethodWithNonGenericTarget(objectType, memberName, visibleNamespaces) ?? FindExtensionMethodWithGenericTarget(objectType, memberName, visibleNamespaces);
        }

        private MethodSymbol FindExtensionMethodWithNonGenericTarget(TypeSymbol type, string name, IEnumerable<string> visibleNamespaces)
        {
            if (type == null || !this.extensionMethods.TryGetValue(name, out var extensionMethods))
            {
                return null;
            }

            foreach (ExtensionMethodInfo extensionMethod in extensionMethods)
            {
                if (visibleNamespaces != null && !visibleNamespaces.Any(ns => ns == extensionMethod.MethodNamespace))
                {
                    continue;
                }

                if (!extensionMethod.IsTargetParameterGeneric)
                {
                    // If the input parameter is a generic parameter we will match any target parameter and rely on the C#
                    // compiler to detect reference errors
                    if (type is GenericParameterSymbol genericType)
                    {
                        return extensionMethod.MethodSymbol;
                    }
                    else if (extensionMethod.TargetParameterTypeFullName == type.FullName)
                    {
                        return extensionMethod.MethodSymbol;
                    }
                }
            }

            return null;
        }

        private MethodSymbol FindExtensionMethodWithGenericTarget(TypeSymbol type, string name, IEnumerable<string> visibleNamespaces)
        {
            if (type == null || !this.extensionMethods.TryGetValue(name, out var extensionMethods))
            {
                return null;
            }

            foreach (ExtensionMethodInfo extensionMethod in extensionMethods)
            {
                if (visibleNamespaces != null && !visibleNamespaces.Any(ns => ns == extensionMethod.MethodNamespace))
                {
                    continue;
                }

                if (extensionMethod.IsTargetParameterGeneric)
                {
                    return extensionMethod.MethodSymbol;
                }
            }

            return null;
        }

        public void SetComments(XmlDocument docComments)
        {
            Debug.Assert(this.docComments == null);
            Debug.Assert(docComments != null);

            this.docComments = docComments;
        }

        public void SetEntryPoint(MemberSymbol entryPoint)
        {
            Debug.Assert(EntryPoint == null);
            Debug.Assert(entryPoint != null);

            EntryPoint = entryPoint;
        }

        public ICollection Symbols => namespaces;

        private bool CompareTypeName(TypeSymbol typeSymbol, string name)
        {
            return name.Equals(typeSymbol.FullName.Replace('$', '.'))
                || name.Equals(typeSymbol.Name.Replace('$', '.'));
        }

        public Symbol FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            if ((filter & SymbolFilter.Types) == 0)
            {
                return null;
            }

            Symbol symbol = null;

            if (name.IndexOf('.') > 0)
            {
                symbol = FindSymbolFromNamespace(name, context);
            }
            else
            {
                Debug.Assert(context != null);

                if (context is MethodSymbol methodContext)
                {
                    GenericParameterSymbol genericType = FindGenericType(name, methodContext);

                    if (genericType != null)
                    {
                        return genericType;
                    }
                }

                TypeSymbol typeSymbol = context as TypeSymbol;

                if (typeSymbol == null)
                {
                    Symbol parentSymbol = context.Parent;

                    while (parentSymbol != null)
                    {
                        typeSymbol = parentSymbol as TypeSymbol;

                        if (typeSymbol != null)
                        {
                            break;
                        }

                        parentSymbol = parentSymbol.Parent;
                    }
                }

                Debug.Assert(typeSymbol != null);

                if (typeSymbol == null)
                {
                    return null;
                }

                if (typeSymbol.IsGeneric)
                {
                    var resolved = typeSymbol.GenericParameters.FirstOrDefault(param => param.Name == name);
                    if (resolved != null)
                    {
                        return resolved;
                    }
                }

                bool systemNamespaceChecked = false;

                NamespaceSymbol containerNamespace = (NamespaceSymbol)typeSymbol.Parent;
                Debug.Assert(containerNamespace != null);

                symbol = ((ISymbolTable)containerNamespace).FindSymbol(name, /* context */ typeSymbol, SymbolFilter.Types);

                if (containerNamespace == SystemNamespace)
                {
                    systemNamespaceChecked = true;
                }

                if (symbol == null)
                {
                    if (typeSymbol.Aliases != null && typeSymbol.Aliases.ContainsKey(name))
                    {
                        string typeReference = typeSymbol.Aliases[name];
                        symbol = ((ISymbolTable)this).FindSymbol(typeReference, /* context */ null,
                            SymbolFilter.Types);
                    }
                    else if (typeSymbol.Imports != null)
                    {
                        foreach (string importedNamespaceReference in typeSymbol.Imports)
                        {
                            if (namespaceMap.ContainsKey(importedNamespaceReference) == false)
                            {
                                // Since we included all parent namespaces of the current type's
                                // namespace, we might run into a namespace that doesn't contain
                                // any defined types, i.e. doesn't exist.

                                continue;
                            }

                            NamespaceSymbol importedNamespace = namespaceMap[importedNamespaceReference];

                            if (importedNamespace == containerNamespace)
                            {
                                continue;
                            }

                            symbol = ((ISymbolTable)importedNamespace).FindSymbol(name, /* context */ null,
                                SymbolFilter.Types);

                            if (importedNamespace == SystemNamespace)
                            {
                                systemNamespaceChecked = true;
                            }

                            if (symbol != null)
                            {
                                break;
                            }
                        }
                    }
                }

                if (symbol == null && systemNamespaceChecked == false)
                {
                    symbol = ((ISymbolTable)SystemNamespace).FindSymbol(name, /* context */ null, SymbolFilter.Types);
                }

                if (symbol == null)
                {
                    symbol = ((ISymbolTable)GlobalNamespace).FindSymbol(name, /* context */ null, SymbolFilter.Types);
                }
            }

            return symbol;
        }

        private static GenericParameterSymbol FindGenericType(string name, MethodSymbol methodContext)
        {
            var genericType = methodContext.GenericArguments?.SingleOrDefault(a => a.Name == name);

            if (genericType == null && methodContext.Parent.IsGeneric)
            {
                genericType = methodContext.Parent.GenericParameters.FirstOrDefault(a => a.Name == name);
            }

            return genericType;
        }

        private Symbol FindSymbolFromNamespace(string name, Symbol context)
        {
            int nameIndex = name.LastIndexOf('.');
            string typeName = name.Substring(nameIndex + 1);
            string namespaceName = name.Substring(0, nameIndex);

            if (namespaceMap.TryGetValue(namespaceName, out NamespaceSymbol namespaceSymbol))
            {
                return namespaceSymbol.FindSymbol(typeName, /* context */ null, SymbolFilter.Types);
            }
            else
            {
                return SearchAllNamespaces(name, context, typeName, namespaceName);
            }
        }

        private Symbol SearchAllNamespaces(string name, Symbol context, string typeName, string namespaceName)
        {
            foreach (NamespaceSymbol namespaceSymbol in namespaces)
            {
                if (namespaceSymbol.FindSymbol(typeName, /* context */ null, SymbolFilter.Types) is TypeSymbol foundType)
                {
                    if (IsNamespaceMatch(foundType, name, namespaceName, context))
                    {
                        return foundType;
                    }
                }
            }

            return null;
        }

        private bool IsNamespaceMatch(TypeSymbol foundType, string name, string namespaceName, Symbol context)
        {
            return CompareTypeName(foundType, name)
                || string.Equals(foundType.Namespace, namespaceName)
                || foundType.Namespace.EndsWith(namespaceName) // Partial namespace match
                || GetAliasesFromContext(context)
                    .Select(a => name.Replace(a.Key, a.Value))
                    .Any(n => CompareTypeName(foundType, n));
        }

        private IEnumerable<KeyValuePair<string, string>> GetAliasesFromContext(Symbol context)
        {
            if (context is TypeSymbol typeContext)
            {
                return typeContext.Aliases ?? Enumerable.Empty<KeyValuePair<string, string>>();
            }
            if (context is MemberSymbol memberContext && memberContext.Parent is TypeSymbol parentContext)
            {
                return parentContext.Aliases ?? Enumerable.Empty<KeyValuePair<string, string>>();
            }

            return Enumerable.Empty<KeyValuePair<string, string>>();
        }
    }
}
