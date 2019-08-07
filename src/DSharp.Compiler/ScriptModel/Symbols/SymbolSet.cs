// SymbolSet.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class SymbolSet : ISymbolTable
    {
        private readonly Dictionary<string, HashSet<(string method, MethodSymbol relatedType)>>
            extensionMethods = new Dictionary<string, HashSet<(string method, MethodSymbol relatedType)>>();
        private readonly List<ScriptReference> dependencies;
        private readonly Dictionary<string, ScriptReference> dependencySet;
        private readonly Dictionary<string, NamespaceSymbol> namespaceMap;

        private readonly List<NamespaceSymbol> namespaces;

        private readonly Dictionary<string, Dictionary<string, ResXItem>> resources;

        private Dictionary<string, TypeSymbol> arrayTypeTable;

        private XmlDocument docComments;

        private Dictionary<string, TypeSymbol> genericTypeTable;

        public SymbolSet()
        {
            namespaces = new List<NamespaceSymbol>();
            namespaceMap = new Dictionary<string, NamespaceSymbol>();

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
                if (typeSymbol.Type == SymbolType.GenericParameter)
                {
                    return templateType;
                }

            StringBuilder keyBuilder = new StringBuilder(templateType.FullName);

            foreach (TypeSymbol typeSymbol in typeArguments)
            {
                keyBuilder.Append("+");
                keyBuilder.Append(typeSymbol.FullName);
            }

            string key = keyBuilder.ToString();

            if (genericTypeTable != null && genericTypeTable.ContainsKey(key))
            {
                return genericTypeTable[key];
            }

            if (genericTypeTable == null)
            {
                genericTypeTable = new Dictionary<string, TypeSymbol>();
            }

            // Prepopulate with a placeholder ... if a generic type's member refers to its
            // parent type it will use the type being created when the return value is null.
            genericTypeTable[key] = null;

            TypeSymbol instanceTypeSymbol = CreateGenericTypeCore(templateType, typeArguments);
            genericTypeTable[key] = instanceTypeSymbol;

            return instanceTypeSymbol;
        }

        private TypeSymbol CreateGenericTypeCore(TypeSymbol templateType, IList<TypeSymbol> typeArguments)
        {
            if (templateType.Type == SymbolType.Class)
            {
                ClassSymbol genericClass = (ClassSymbol)templateType;
                ClassSymbol instanceClass = new ClassSymbol(genericClass.Name, (NamespaceSymbol) genericClass.Parent);

                instanceClass.SetInheritance(genericClass.BaseClass, genericClass.Interfaces);
                instanceClass.SetImported(genericClass.Dependency);

                if (genericClass.IgnoreNamespace)
                {
                    instanceClass.SetIgnoreNamespace();
                }

                instanceClass.ScriptNamespace = genericClass.ScriptNamespace;

                if (genericClass.IsTransformed)
                {
                    instanceClass.SetTransformedName(genericClass.GeneratedName);
                }
                else if (genericClass.IsTransformAllowed == false)
                {
                    instanceClass.DisableNameTransformation();
                }

                if (genericClass.IsNativeArray)
                {
                    instanceClass.SetNativeArray();
                }

                instanceClass.AddGenericParameters(genericClass.GenericParameters);
                instanceClass.AddGenericArguments(genericClass, typeArguments);

                CreateGenericTypeMembers(genericClass, instanceClass, typeArguments);

                return instanceClass;
            }

            if (templateType.Type == SymbolType.Interface)
            {
                InterfaceSymbol genericInterface = (InterfaceSymbol)templateType;
                InterfaceSymbol instanceInterface =
                    new InterfaceSymbol(genericInterface.Name, (NamespaceSymbol)genericInterface.Parent);

                instanceInterface.SetInheritance(genericInterface.Interfaces);
                instanceInterface.SetImported(genericInterface.Dependency);

                if (genericInterface.IgnoreNamespace)
                {
                    instanceInterface.SetIgnoreNamespace();
                }

                if (genericInterface.IsTransformed)
                {
                    instanceInterface.SetTransformedName(genericInterface.GeneratedName);
                }
                else if (genericInterface.IsTransformAllowed == false)
                {
                    instanceInterface.DisableNameTransformation();
                }

                instanceInterface.AddGenericParameters(genericInterface.GenericParameters);
                instanceInterface.AddGenericArguments(genericInterface, typeArguments);

                CreateGenericTypeMembers(genericInterface, instanceInterface, typeArguments);

                return instanceInterface;
            }

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
                reference = new ScriptReference(name, null);
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
            if (node is IntrinsicTypeNode)
            {
                IntrinsicType intrinsicType = IntrinsicType.Integer;

                IntrinsicTypeNode intrinsicTypeNode = (IntrinsicTypeNode)node;

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

            if (node is GenericNameNode)
            {
                GenericNameNode genericNameNode = (GenericNameNode)node;
                string genericTypeName = genericNameNode.Name + "`" + genericNameNode.TypeArguments.Count;
                TypeSymbol templateType =
                    (TypeSymbol)symbolTable.FindSymbol(genericTypeName, contextSymbol, SymbolFilter.Types);

                List<TypeSymbol> typeArguments = new List<TypeSymbol>();

                foreach (ParseNode argNode in genericNameNode.TypeArguments)
                {
                    TypeSymbol argType = ResolveType(argNode, symbolTable, contextSymbol);
                    typeArguments.Add(argType);
                }

                TypeSymbol resolvedSymbol = CreateGenericTypeSymbol(templateType, typeArguments);
                Debug.Assert(resolvedSymbol != null);

                return resolvedSymbol;
            }

            Debug.Assert(node is NameNode);
            NameNode nameNode = (NameNode)node;

            return (TypeSymbol)symbolTable.FindSymbol(nameNode.Name, contextSymbol, SymbolFilter.Types);
        }

        public void AddExtensionType(string typeToExtend, string extensionMethodName, MethodSymbol methodSymbol)
        {
            if (string.IsNullOrWhiteSpace(typeToExtend) || string.IsNullOrWhiteSpace(extensionMethodName))
            {
                return;
            }

            if (!extensionMethods.TryGetValue(typeToExtend, out HashSet<(string method, MethodSymbol relatedType)> registrations))
            {
                registrations = new HashSet<(string method, MethodSymbol relatedType)>();
                extensionMethods.Add(typeToExtend, registrations);
            }

            registrations.Add((extensionMethodName, methodSymbol));
        }

        public MethodSymbol ResolveExtensionMethodSymbol(string typeName, string memberName)
        {
            if (!extensionMethods.TryGetValue(typeName, out HashSet<(string method, MethodSymbol methodSymbol)> registrations))
            {
                return null;
            }

            return registrations.FirstOrDefault(reg => StringComparer.InvariantCultureIgnoreCase.Equals(reg.method, memberName)).methodSymbol;
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

        #region ISymbolTable Members

        ICollection ISymbolTable.Symbols => namespaces;

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            if ((filter & SymbolFilter.Types) == 0)
            {
                return null;
            }

            Symbol symbol = null;

            if (name.IndexOf('.') > 0)
            {
                int nameIndex = name.LastIndexOf('.') + 1;
                Debug.Assert(nameIndex < name.Length);

                string namespaceName = name.Substring(0, nameIndex - 1);
                name = name.Substring(nameIndex);

                if (namespaceMap.TryGetValue(namespaceName, out NamespaceSymbol namespaceSymbol))
                {
                    symbol = ((ISymbolTable)namespaceSymbol).FindSymbol(name, /* context */ null, SymbolFilter.Types);
                }
            }
            else
            {
                Debug.Assert(context != null);

                if (context is MethodSymbol methodContext)
                {
                    var genericType = methodContext.GenericArguments?.SingleOrDefault(a => a.Name == name);

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

                bool systemNamespaceChecked = false;

                NamespaceSymbol containerNamespace = (NamespaceSymbol)typeSymbol.Parent;
                Debug.Assert(containerNamespace != null);

                symbol = ((ISymbolTable)containerNamespace).FindSymbol(name, /* context */ null, SymbolFilter.Types);

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

        #endregion
    }
}
