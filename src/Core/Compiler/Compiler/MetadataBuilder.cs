// MetadataBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using ScriptSharp;
using ScriptSharp.CodeModel;
using ScriptSharp.ResourceModel;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Compiler {

    internal sealed class MetadataBuilder {

        private IErrorHandler _errorHandler;
        private CompilerOptions _options;

        private SymbolSet _symbols;
        private ISymbolTable _symbolTable;

        public MetadataBuilder(IErrorHandler errorHandler) {
            Debug.Assert(errorHandler != null);
            _errorHandler = errorHandler;
        }

        private EnumerationFieldSymbol BuildEnumField(EnumerationFieldNode fieldNode, TypeSymbol typeSymbol) {
            Debug.Assert(typeSymbol is EnumerationSymbol);
            EnumerationSymbol enumSymbol = (EnumerationSymbol)typeSymbol;

            TypeSymbol fieldTypeSymbol;
            if (enumSymbol.UseNamedValues) {
                fieldTypeSymbol = _symbols.ResolveIntrinsicType(IntrinsicType.String);
            }
            else {
                fieldTypeSymbol = _symbols.ResolveIntrinsicType(IntrinsicType.Integer);
            }

            EnumerationFieldSymbol fieldSymbol = new EnumerationFieldSymbol(fieldNode.Name, typeSymbol, fieldNode.Value, fieldTypeSymbol);
            BuildMemberDetails(fieldSymbol, typeSymbol, fieldNode, fieldNode.Attributes);

            return fieldSymbol;
        }

        private EventSymbol BuildEvent(EventDeclarationNode eventNode, TypeSymbol typeSymbol) {
            TypeSymbol handlerType = typeSymbol.SymbolSet.ResolveType(eventNode.Type, _symbolTable, typeSymbol);
            Debug.Assert(handlerType != null);

            if (handlerType != null) {
                EventSymbol eventSymbol = new EventSymbol(eventNode.Name, typeSymbol, handlerType);
                BuildMemberDetails(eventSymbol, typeSymbol, eventNode, eventNode.Attributes);

                if (eventNode.IsField) {
                    eventSymbol.SetImplementationState(SymbolImplementationFlags.Generated);
                }
                else {
                    if ((eventNode.Modifiers & Modifiers.Abstract) != 0) {
                        eventSymbol.SetImplementationState(SymbolImplementationFlags.Abstract);
                    }
                    else if ((eventNode.Modifiers & Modifiers.Override) != 0) {
                        eventSymbol.SetImplementationState(SymbolImplementationFlags.Override);
                    }
                }

                return eventSymbol;
            }

            return null;
        }

        private FieldSymbol BuildField(FieldDeclarationNode fieldNode, TypeSymbol typeSymbol) {
            TypeSymbol fieldType = typeSymbol.SymbolSet.ResolveType(fieldNode.Type, _symbolTable, typeSymbol);
            Debug.Assert(fieldType != null);

            if (fieldType != null) {
                FieldSymbol symbol = new FieldSymbol(fieldNode.Name, typeSymbol, fieldType);
                BuildMemberDetails(symbol, typeSymbol, fieldNode, fieldNode.Attributes);

                if (fieldNode.Initializers.Count != 0) {
                    VariableInitializerNode initializer = (VariableInitializerNode)fieldNode.Initializers[0];

                    if ((initializer.Value != null) && (initializer.Value.NodeType != ParseNodeType.Literal)) {
                        symbol.SetImplementationState(/* hasInitializer */ true);
                    }
                }

                if (fieldNode.NodeType == ParseNodeType.ConstFieldDeclaration) {
                    Debug.Assert(fieldNode.Initializers.Count == 1);

                    VariableInitializerNode initializer = (VariableInitializerNode)fieldNode.Initializers[0];
                    if ((initializer.Value != null) && (initializer.Value.NodeType == ParseNodeType.Literal)) {
                        symbol.SetConstant();
                        symbol.Value = ((LiteralToken)initializer.Value.Token).LiteralValue;
                    }

                    // TODO: Handle other constant cases that can be evaluated at compile
                    //       time (eg. combining enum flags)
                }

                return symbol;
            }

            return null;
        }

        private IndexerSymbol BuildIndexer(IndexerDeclarationNode indexerNode, TypeSymbol typeSymbol) {
            TypeSymbol indexerType = typeSymbol.SymbolSet.ResolveType(indexerNode.Type, _symbolTable, typeSymbol);
            Debug.Assert(indexerType != null);

            if (indexerType != null) {
                IndexerSymbol indexer = new IndexerSymbol(typeSymbol, indexerType);
                BuildMemberDetails(indexer, typeSymbol, indexerNode, indexerNode.Attributes);

                if (AttributeNode.FindAttribute(indexerNode.Attributes, "IntrinsicProperty") != null) {
                    indexer.SetIntrinsic();
                }

                SymbolImplementationFlags implFlags = SymbolImplementationFlags.Regular;
                if (indexerNode.SetAccessor == null) {
                    implFlags |= SymbolImplementationFlags.ReadOnly;
                }
                if ((indexerNode.Modifiers & Modifiers.Abstract) != 0) {
                    implFlags |= SymbolImplementationFlags.Abstract;
                }
                else if ((indexerNode.Modifiers & Modifiers.Override) != 0) {
                    implFlags |= SymbolImplementationFlags.Override;
                }

                indexer.SetImplementationState(implFlags);

                Debug.Assert(indexerNode.Parameters.Count != 0);
                foreach (ParameterNode parameterNode in indexerNode.Parameters) {
                    ParameterSymbol paramSymbol = BuildParameter(parameterNode, indexer);
                    if (paramSymbol != null) {
                        paramSymbol.SetParseContext(parameterNode);
                        indexer.AddParameter(paramSymbol);
                    }
                }

                indexer.AddParameter(new ParameterSymbol("value", indexer, indexerType, ParameterMode.In));

                return indexer;
            }

            return null;
        }

        private void BuildInterfaceAssociations(ClassSymbol classSymbol) {
            if (classSymbol.PrimaryPartialClass != classSymbol) {
                // Don't build interface associations for non-primary partial classes.
                return;
            }

            ICollection<InterfaceSymbol> interfaces = classSymbol.Interfaces;
            if ((interfaces != null) && (interfaces.Count != 0)) {
                foreach (InterfaceSymbol interfaceSymbol in interfaces) {
                    foreach (MemberSymbol memberSymbol in interfaceSymbol.Members) {
                        MemberSymbol associatedSymbol = classSymbol.GetMember(memberSymbol.Name);
                        if (associatedSymbol != null) {
                            associatedSymbol.SetInterfaceMember(memberSymbol);
                        }
                    }
                }
            }
        }

        private void BuildMemberDetails(MemberSymbol memberSymbol, TypeSymbol typeSymbol, MemberNode memberNode, ParseNodeList attributes) {
            if (memberSymbol.Type != SymbolType.EnumerationField) {
                memberSymbol.SetVisibility(GetVisibility(memberNode, typeSymbol));
            }

            bool preserveCase = (AttributeNode.FindAttribute(attributes, "PreserveCase") != null);
            memberSymbol.SetNameCasing(preserveCase);

            string scriptName = GetAttributeValue(attributes, "ScriptName");
            if (scriptName != null) {
                memberSymbol.SetTransformedName(scriptName);
            }
            else if (AttributeNode.FindAttribute(attributes, "PreserveName") != null) {
                memberSymbol.DisableNameTransformation();
            }
        }

        private void BuildMembers(TypeSymbol typeSymbol) {
            if (typeSymbol.Type == SymbolType.Delegate) {
                DelegateTypeNode delegateNode = (DelegateTypeNode)typeSymbol.ParseContext;

                TypeSymbol returnType = typeSymbol.SymbolSet.ResolveType(delegateNode.ReturnType, _symbolTable, typeSymbol);
                Debug.Assert(returnType != null);

                if (returnType != null) {
                    MethodSymbol invokeMethod = new MethodSymbol("Invoke", typeSymbol, returnType, MemberVisibility.Public);
                    invokeMethod.SetTransformedName(String.Empty);

                    // Mark the method as abstract, as there is no actual implementation of the method
                    // to be generated
                    invokeMethod.SetImplementationState(SymbolImplementationFlags.Abstract);

                    typeSymbol.AddMember(invokeMethod);
                }
                return;
            }

            CustomTypeNode typeNode = (CustomTypeNode)typeSymbol.ParseContext;

            foreach (MemberNode member in typeNode.Members) {
                MemberSymbol memberSymbol = null;
                switch (member.NodeType) {
                    case ParseNodeType.FieldDeclaration:
                    case ParseNodeType.ConstFieldDeclaration:
                        memberSymbol = BuildField((FieldDeclarationNode)member, typeSymbol);
                        break;
                    case ParseNodeType.PropertyDeclaration:
                        memberSymbol = BuildPropertyAsField((PropertyDeclarationNode)member, typeSymbol);
                        if (memberSymbol == null) {
                            memberSymbol = BuildProperty((PropertyDeclarationNode)member, typeSymbol);
                        }
                        break;
                    case ParseNodeType.IndexerDeclaration:
                        memberSymbol = BuildIndexer((IndexerDeclarationNode)member, typeSymbol);
                        break;
                    case ParseNodeType.ConstructorDeclaration:
                    case ParseNodeType.MethodDeclaration:
                        if ((member.Modifiers & Modifiers.Extern) != 0) {
                            // Extern methods are there for defining overload signatures, so
                            // we just skip them as far as metadata goes. The validator has
                            // taken care of the requirements/constraints around use of extern methods.
                            continue;
                        }
                        memberSymbol = BuildMethod((MethodDeclarationNode)member, typeSymbol);
                        break;
                    case ParseNodeType.EventDeclaration:
                        memberSymbol = BuildEvent((EventDeclarationNode)member, typeSymbol);
                        break;
                    case ParseNodeType.EnumerationFieldDeclaration:
                        memberSymbol = BuildEnumField((EnumerationFieldNode)member, typeSymbol);
                        break;
                }

                if (memberSymbol != null) {
                    memberSymbol.SetParseContext(member);

                    if ((typeSymbol.IsApplicationType == false) &&
                        ((memberSymbol.Type == SymbolType.Constructor) ||
                         (typeSymbol.GetMember(memberSymbol.Name) != null))) {
                        // If the type is an imported type, then it is allowed to contain
                        // overloads, and we're simply going to ignore its existence, as long
                        // as one overload has been added to the member table.
                        continue;
                    }

                    typeSymbol.AddMember(memberSymbol);

                    if ((typeSymbol.Type == SymbolType.Class) && (memberSymbol.Type == SymbolType.Event)) {
                        EventSymbol eventSymbol = (EventSymbol)memberSymbol;
                        if (eventSymbol.DefaultImplementation) {
                            // Add a private field that will serve as the backing member
                            // later on in the conversion (eg. in non-event expressions)
                            MemberVisibility visibility = MemberVisibility.PrivateInstance;
                            if ((eventSymbol.Visibility & MemberVisibility.Static) != 0) {
                                visibility |= MemberVisibility.Static;
                            }

                            FieldSymbol fieldSymbol =
                                new FieldSymbol("__" + Utility.CreateCamelCaseName(eventSymbol.Name), typeSymbol,
                                                eventSymbol.AssociatedType);
                            fieldSymbol.SetVisibility(visibility);
                            fieldSymbol.SetParseContext(((EventDeclarationNode)eventSymbol.ParseContext).Field);

                            typeSymbol.AddMember(fieldSymbol);
                        }
                    }
                }
            }
        }

        public ICollection<TypeSymbol> BuildMetadata(ParseNodeList compilationUnits, SymbolSet symbols, CompilerOptions options) {
            Debug.Assert(compilationUnits != null);
            Debug.Assert(symbols != null);

            _symbols = symbols;
            _symbolTable = symbols;
            _options = options;

            string scriptName = GetAssemblyScriptName(compilationUnits);
            if (String.IsNullOrEmpty(scriptName)) {
                _errorHandler.ReportError("You must declare a ScriptAssembly attribute.", String.Empty);
            }
            else if (Utility.IsValidScriptName(scriptName) == false) {
                string errorMessage = "The ScriptAssembly attribute referenced an invalid name '{0}'. Script names must only contain letters, numbers, dots or underscores.";
                _errorHandler.ReportError(String.Format(errorMessage, scriptName), String.Empty);
            }
            symbols.ScriptName = scriptName;

            string scriptPrefix = GetAssemblyScriptPrefix(compilationUnits);
            if (String.IsNullOrEmpty(scriptPrefix) == false) {
                if (Utility.IsValidIdentifier(scriptPrefix) == false) {
                    string errorMessage = "The ScriptQualifier attribute referenced an invalid prefix '{0}'. Script prefix must be valid identifiers.";
                    _errorHandler.ReportError(String.Format(errorMessage, scriptPrefix), String.Empty);
                }
            }
            else {
                scriptPrefix = scriptName.Replace(".", String.Empty);
            }
            symbols.ScriptPrefix = scriptPrefix;

            string assemblyScriptNamespace = GetAssemblyScriptNamespace(compilationUnits);
            List<TypeSymbol> types = new List<TypeSymbol>();

            // Build all the types first.
            // Types need to be loaded upfront so that they can be used in resolving types associated
            // with members.
            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (NamespaceNode namespaceNode in compilationUnit.Members) {
                    string namespaceName = namespaceNode.Name;

                    NamespaceSymbol namespaceSymbol = symbols.GetNamespace(namespaceName);

                    List<string> imports = null;
                    Dictionary<string, string> aliases = null;

                    ParseNodeList usingClauses = namespaceNode.UsingClauses;
                    if ((usingClauses != null) && (usingClauses.Count != 0)) {
                        foreach (ParseNode usingNode in namespaceNode.UsingClauses) {
                            if (usingNode is UsingNamespaceNode) {
                                if (imports == null) {
                                    imports = new List<string>(usingClauses.Count);
                                }

                                string referencedNamespace = ((UsingNamespaceNode)usingNode).ReferencedNamespace;
                                if (imports.Contains(referencedNamespace) == false) {
                                    imports.Add(referencedNamespace);
                                }
                            }
                            else {
                                Debug.Assert(usingNode is UsingAliasNode);
                                if (aliases == null) {
                                    aliases = new Dictionary<string, string>();
                                }
                                UsingAliasNode aliasNode = (UsingAliasNode)usingNode;
                                aliases[aliasNode.Alias] = aliasNode.TypeName;
                            }
                        }
                    }

                    // Add parent namespaces as imports in reverse order since they
                    // are searched in that fashion.
                    string[] namespaceParts = namespaceName.Split('.');
                    for (int i = namespaceParts.Length - 2; i >= 0; i--) {
                        string partialNamespace;
                        if (i == 0) {
                            partialNamespace = namespaceParts[0];
                        }
                        else {
                            partialNamespace = String.Join(".", namespaceParts, 0, i + 1);
                        }

                        if (imports == null) {
                            imports = new List<string>();
                        }

                        if (imports.Contains(partialNamespace) == false) {
                            imports.Add(partialNamespace);
                        }
                    }

                    // Build type symbols for all user-defined types
                    foreach (TypeNode typeNode in namespaceNode.Members) {
                        UserTypeNode userTypeNode = typeNode as UserTypeNode;
                        if (userTypeNode == null) {
                            continue;
                        }

                        // Check if we have overriding script namespace for this type.
                        string typeScriptNamespace = GetScriptNamespace(userTypeNode.Attributes);
                        if (String.IsNullOrEmpty(typeScriptNamespace)) {
                            typeScriptNamespace = assemblyScriptNamespace;
                        }
                        
                        ClassSymbol partialTypeSymbol = null;
                        bool isPartial = false;

                        if ((userTypeNode.Modifiers & Modifiers.Partial) != 0) {
                            partialTypeSymbol = (ClassSymbol)((ISymbolTable)namespaceSymbol).FindSymbol(userTypeNode.Name, /* context */ null, SymbolFilter.Types);
                            if ((partialTypeSymbol != null) && partialTypeSymbol.IsApplicationType) {
                                // This class will be considered as a partial class
                                isPartial = true;

                                // Merge code model information for the partial class onto the code model node
                                // for the primary partial class. Interesting bits of information include things
                                // such as base class etc. that is yet to be processed.
                                CustomTypeNode partialTypeNode = (CustomTypeNode)partialTypeSymbol.ParseContext;
                                partialTypeNode.MergePartialType((CustomTypeNode)userTypeNode);

                                // Merge interesting bits of information onto the primary type symbol as well
                                // representing this partial class
                                BuildType(partialTypeSymbol, userTypeNode);

                                if (String.IsNullOrEmpty(typeScriptNamespace) == false) {
                                    partialTypeSymbol.ScriptNamespace = typeScriptNamespace;
                                }
                            }
                        }

                        TypeSymbol typeSymbol = BuildType(userTypeNode, namespaceSymbol);
                        if (typeSymbol != null) {
                            typeSymbol.SetParseContext(userTypeNode);
                            typeSymbol.SetParentSymbolTable(symbols);
                            if (imports != null) {
                                typeSymbol.SetImports(imports);
                            }
                            if (aliases != null) {
                                typeSymbol.SetAliases(aliases);
                            }

                            if (String.IsNullOrEmpty(typeScriptNamespace) == false) {
                                typeSymbol.ScriptNamespace = typeScriptNamespace;
                            }

                            if (isPartial == false) {
                                namespaceSymbol.AddType(typeSymbol);
                            }
                            else {
                                // Partial types don't get added to the namespace, so we don't have
                                // duplicated named items. However, they still do get instantiated
                                // and processed as usual.
                                //
                                // The members within partial classes refer to the partial type as their parent,
                                // and hence derive context such as the list of imports scoped to the
                                // particular type.
                                // However, the members will get added to the primary partial type's list of
                                // members so they can be found.
                                // Effectively the partial class here gets created just to hold
                                // context of type-symbol level bits of information such as the list of
                                // imports, that are consumed when generating code for the members defined
                                // within a specific partial class.
                                ((ClassSymbol)typeSymbol).SetPrimaryPartialClass(partialTypeSymbol);
                            }

                            types.Add(typeSymbol);
                        }
                    }
                }
            }

            // Build inheritance chains
            foreach (TypeSymbol typeSymbol in types) {
                if (typeSymbol.Type == SymbolType.Class) {
                    BuildTypeInheritance((ClassSymbol)typeSymbol);
                }
            }

            // Import members
            foreach (TypeSymbol typeSymbol in types) {
                BuildMembers(typeSymbol);
            }

            // Associate interface members with interface member symbols
            foreach (TypeSymbol typeSymbol in types) {
                if (typeSymbol.Type == SymbolType.Class) {
                    BuildInterfaceAssociations((ClassSymbol)typeSymbol);
                }
            }

            // Load resource values
            if (_symbols.HasResources) {
                foreach (TypeSymbol typeSymbol in types) {
                    if (typeSymbol.Type == SymbolType.Resources) {
                        BuildResources((ResourcesSymbol)typeSymbol);
                    }
                }
            }

            // Load documentation
            if (_options.EnableDocComments) {
                Stream docCommentsStream = options.DocCommentFile.GetStream();
                if (docCommentsStream != null) {
                    try {
                        XmlDocument docComments = new XmlDocument();
                        docComments.Load(docCommentsStream);

                        symbols.SetComments(docComments);
                    }
                    finally {
                        options.DocCommentFile.CloseStream(docCommentsStream);
                    }
                }
            }

            return types;
        }

        private MethodSymbol BuildMethod(MethodDeclarationNode methodNode, TypeSymbol typeSymbol) {
            MethodSymbol method = null;
            if (methodNode.NodeType == ParseNodeType.ConstructorDeclaration) {
                method = new ConstructorSymbol(typeSymbol, (methodNode.Modifiers & Modifiers.Static) != 0);
            }
            else {
                TypeSymbol returnType = typeSymbol.SymbolSet.ResolveType(methodNode.Type, _symbolTable, typeSymbol);
                Debug.Assert(returnType != null);

                if (returnType != null) {
                    method = new MethodSymbol(methodNode.Name, typeSymbol, returnType);
                    BuildMemberDetails(method, typeSymbol, methodNode, methodNode.Attributes);

                    ICollection<string> conditions = null;
                    foreach (AttributeNode attrNode in methodNode.Attributes) {
                        if (attrNode.TypeName.Equals("Conditional", StringComparison.Ordinal)) {
                            if (conditions == null) {
                                conditions = new List<string>();
                            }

                            Debug.Assert(attrNode.Arguments[0] is LiteralNode);
                            Debug.Assert(((LiteralNode)attrNode.Arguments[0]).Value is string);

                            conditions.Add((string)((LiteralNode)attrNode.Arguments[0]).Value);
                        }
                    }

                    if (conditions != null) {
                        method.SetConditions(conditions);
                    }
                }
            }

            if (method != null) {
                if ((methodNode.Modifiers & Modifiers.Abstract) != 0) {
                    method.SetImplementationState(SymbolImplementationFlags.Abstract);
                }
                else if ((methodNode.Modifiers & Modifiers.Override) != 0) {
                    method.SetImplementationState(SymbolImplementationFlags.Override);
                }

                if ((methodNode.Parameters != null) && (methodNode.Parameters.Count != 0)) {
                    foreach (ParameterNode parameterNode in methodNode.Parameters) {
                        ParameterSymbol paramSymbol = BuildParameter(parameterNode, method);
                        if (paramSymbol != null) {
                            paramSymbol.SetParseContext(parameterNode);
                            method.AddParameter(paramSymbol);
                        }
                    }
                }

                if ((method.Visibility & MemberVisibility.Static) != 0) {
                    string scriptAlias = GetAttributeValue(methodNode.Attributes, "ScriptAlias");
                    if (scriptAlias != null) {
                        method.SetAlias(scriptAlias);
                    }
                }
            }

            return method;
        }

        private ParameterSymbol BuildParameter(ParameterNode parameterNode, MethodSymbol methodSymbol) {
            ParameterMode parameterMode = ParameterMode.In;

            if ((parameterNode.Flags == ParameterFlags.Out) ||
                (parameterNode.Flags == ParameterFlags.Ref)) {
                parameterMode = ParameterMode.InOut;
            }
            else if (parameterNode.Flags == ParameterFlags.Params) {
                parameterMode = ParameterMode.List;
            }

            TypeSymbol parameterType = methodSymbol.SymbolSet.ResolveType(parameterNode.Type, _symbolTable, methodSymbol);
            Debug.Assert(parameterType != null);

            if (parameterType != null) {
                return new ParameterSymbol(parameterNode.Name, methodSymbol, parameterType, parameterMode);
            }

            return null;
        }

        private ParameterSymbol BuildParameter(ParameterNode parameterNode, IndexerSymbol indexerSymbol) {
            TypeSymbol parameterType = indexerSymbol.SymbolSet.ResolveType(parameterNode.Type, _symbolTable, indexerSymbol);
            Debug.Assert(parameterType != null);

            if (parameterType != null) {
                return new ParameterSymbol(parameterNode.Name, indexerSymbol, parameterType, ParameterMode.In);
            }

            return null;
        }

        private PropertySymbol BuildProperty(PropertyDeclarationNode propertyNode, TypeSymbol typeSymbol) {
            TypeSymbol propertyType = typeSymbol.SymbolSet.ResolveType(propertyNode.Type, _symbolTable, typeSymbol);
            Debug.Assert(propertyType != null);

            if (propertyType != null) {
                PropertySymbol property = new PropertySymbol(propertyNode.Name, typeSymbol, propertyType);
                BuildMemberDetails(property, typeSymbol, propertyNode, propertyNode.Attributes);

                SymbolImplementationFlags implFlags = SymbolImplementationFlags.Regular;
                if (propertyNode.SetAccessor == null) {
                    implFlags |= SymbolImplementationFlags.ReadOnly;
                }
                if ((propertyNode.Modifiers & Modifiers.Abstract) != 0) {
                    implFlags |= SymbolImplementationFlags.Abstract;
                }
                else if ((propertyNode.Modifiers & Modifiers.Override) != 0) {
                    implFlags |= SymbolImplementationFlags.Override;
                }
                property.SetImplementationState(implFlags);

                property.AddParameter(new ParameterSymbol("value", property, propertyType, ParameterMode.In));

                return property;
            }

            return null;
        }

        private FieldSymbol BuildPropertyAsField(PropertyDeclarationNode propertyNode, TypeSymbol typeSymbol) {
            AttributeNode intrinsicPropertyAttribute = AttributeNode.FindAttribute(propertyNode.Attributes, "IntrinsicProperty");
            if (intrinsicPropertyAttribute == null) {
                return null;
            }

            TypeSymbol fieldType = typeSymbol.SymbolSet.ResolveType(propertyNode.Type, _symbolTable, typeSymbol);
            Debug.Assert(fieldType != null);

            if (fieldType != null) {
                FieldSymbol symbol = new FieldSymbol(propertyNode.Name, typeSymbol, fieldType);
                BuildMemberDetails(symbol, typeSymbol, propertyNode, propertyNode.Attributes);

                string scriptAlias = GetAttributeValue(propertyNode.Attributes, "ScriptAlias");
                if (scriptAlias != null) {
                    symbol.SetAlias(scriptAlias);
                }

                return symbol;
            }

            return null;
        }

        private void BuildResources(ResourcesSymbol resourcesSymbol) {
            ICollection<ResXItem> items = _symbols.GetResources(resourcesSymbol.Name).Values;

            if (items.Count != 0) {
                foreach (ResXItem item in items) {
                    FieldSymbol fieldSymbol = resourcesSymbol.GetMember(item.Name) as FieldSymbol;
                    Debug.Assert(fieldSymbol != null);

                    if (fieldSymbol != null) {
                        fieldSymbol.Value = item.Value;
                    }
                }
            }
        }

        private TypeSymbol BuildType(UserTypeNode typeNode, NamespaceSymbol namespaceSymbol) {
            Debug.Assert(typeNode != null);
            Debug.Assert(namespaceSymbol != null);

            TypeSymbol typeSymbol = null;
            ParseNodeList attributes = typeNode.Attributes;

            if (typeNode.Type == TokenType.Class) {
                CustomTypeNode customTypeNode = (CustomTypeNode)typeNode;
                Debug.Assert(customTypeNode != null);

                NameNode baseTypeNameNode = null;
                if (customTypeNode.BaseTypes.Count != 0) {
                    baseTypeNameNode = customTypeNode.BaseTypes[0] as NameNode;
                }

                if ((baseTypeNameNode != null) && (String.CompareOrdinal(baseTypeNameNode.Name, "Record") == 0)) {
                    typeSymbol = new RecordSymbol(typeNode.Name, namespaceSymbol);
                }
                else {
                    AttributeNode resourcesAttribute = AttributeNode.FindAttribute(attributes, "Resources");
                    if (resourcesAttribute != null) {
                        typeSymbol = new ResourcesSymbol(typeNode.Name, namespaceSymbol);
                    }
                    else {
                        typeSymbol = new ClassSymbol(typeNode.Name, namespaceSymbol);

                        if ((baseTypeNameNode != null) &&
                            (String.CompareOrdinal(baseTypeNameNode.Name, "TestClass") == 0)) {
                            ((ClassSymbol)typeSymbol).SetTestClass();
                        }
                    }
                }
            }
            else if (typeNode.Type == TokenType.Interface) {
                typeSymbol = new InterfaceSymbol(typeNode.Name, namespaceSymbol);
            }
            else if (typeNode.Type == TokenType.Enum) {
                bool flags = false;

                AttributeNode flagsAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "Flags");
                if (flagsAttribute != null) {
                    flags = true;
                }

                typeSymbol = new EnumerationSymbol(typeNode.Name, namespaceSymbol, flags);
            }
            else if (typeNode.Type == TokenType.Delegate) {
                typeSymbol = new DelegateSymbol(typeNode.Name, namespaceSymbol);
                typeSymbol.SetTransformedName("Function");
                typeSymbol.SetIgnoreNamespace();
            }

            Debug.Assert(typeSymbol != null, "Unexpected type node " + typeNode.Type);
            if (typeSymbol != null) {
                if ((typeNode.Modifiers & Modifiers.Public) != 0) {
                    typeSymbol.SetPublic();
                }

                BuildType(typeSymbol, typeNode);

                if (namespaceSymbol.Name.EndsWith(_options.TestsSubnamespace, StringComparison.Ordinal)) {
                    typeSymbol.SetTestType();
                }
            }

            return typeSymbol;
        }

        private void BuildType(TypeSymbol typeSymbol, UserTypeNode typeNode) {
            Debug.Assert(typeSymbol != null);
            Debug.Assert(typeNode != null);

            ParseNodeList attributes = typeNode.Attributes;

            if (AttributeNode.FindAttribute(attributes, "Imported") != null) {
                typeSymbol.SetImported(/* dependencyName */ null);
            }

            if (AttributeNode.FindAttribute(attributes, "IgnoreNamespace") != null) {
                typeSymbol.SetIgnoreNamespace();
            }

            if (AttributeNode.FindAttribute(attributes, "PreserveName") != null) {
                typeSymbol.DisableNameTransformation();
            }

            string scriptName = GetAttributeValue(attributes, "ScriptName");
            if (scriptName != null) {
                typeSymbol.SetTransformedName(scriptName);
            }

            if (typeNode.Type == TokenType.Class) {
                bool globalizeMembers = false;
                string mixinRoot = null;

                AttributeNode globalMethodsAttribute = AttributeNode.FindAttribute(attributes, "GlobalMethods");
                if (globalMethodsAttribute != null) {
                    globalizeMembers = true;
                }
                else {
                    AttributeNode mixinAttribute = AttributeNode.FindAttribute(attributes, "Mixin");
                    if (mixinAttribute != null) {
                        Debug.Assert(mixinAttribute.Arguments[0] is LiteralNode);
                        Debug.Assert(((LiteralNode)mixinAttribute.Arguments[0]).Value is string);

                        mixinRoot = (string)((LiteralNode)mixinAttribute.Arguments[0]).Value;
                        globalizeMembers = true;
                    }
                }

                if (globalizeMembers) {
                    ((ClassSymbol)typeSymbol).SetGlobalMethods(mixinRoot);
                }
            }

            if (typeNode.Type == TokenType.Enum) {
                if (AttributeNode.FindAttribute(attributes, "NamedValues") != null) {
                    ((EnumerationSymbol)typeSymbol).SetNamedValues();
                }
                else if (AttributeNode.FindAttribute(attributes, "NumericValues") != null) {
                    ((EnumerationSymbol)typeSymbol).SetNumericValues();
                }
            }
        }

        private void BuildTypeInheritance(ClassSymbol classSymbol) {
            if (classSymbol.PrimaryPartialClass != classSymbol) {
                // Don't build type inheritance for non-primary partial classes.
                return;
            }

            CustomTypeNode customTypeNode = (CustomTypeNode)classSymbol.ParseContext;

            if ((customTypeNode.BaseTypes != null) && (customTypeNode.BaseTypes.Count != 0)) {
                ClassSymbol baseClass = null;
                List<InterfaceSymbol> interfaces = null;

                foreach (NameNode node in customTypeNode.BaseTypes) {
                    TypeSymbol baseTypeSymbol = (TypeSymbol)_symbolTable.FindSymbol(node.Name, classSymbol, SymbolFilter.Types);
                    Debug.Assert(baseTypeSymbol != null);

                    if (baseTypeSymbol.Type == SymbolType.Class) {
                        Debug.Assert(baseClass == null);
                        baseClass = (ClassSymbol)baseTypeSymbol;
                    }
                    else {
                        Debug.Assert(baseTypeSymbol.Type == SymbolType.Interface);

                        if (interfaces == null) {
                            interfaces = new List<InterfaceSymbol>();
                        }
                        interfaces.Add((InterfaceSymbol)baseTypeSymbol);
                    }
                }

                if ((baseClass != null) || (interfaces != null)) {
                    classSymbol.SetInheritance(baseClass, interfaces);
                }
            }
        }

        private string GetAssemblyScriptName(ParseNodeList compilationUnits) {
            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (AttributeBlockNode attribBlock in compilationUnit.Attributes) {
                    string scriptName = GetAttributeValue(attribBlock.Attributes, "ScriptAssembly");
                    if (scriptName != null) {
                        return scriptName;
                    }
                }
            }
            return null;
        }

        private string GetAssemblyScriptNamespace(ParseNodeList compilationUnits) {
            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (AttributeBlockNode attribBlock in compilationUnit.Attributes) {
                    string scriptNamespace = GetScriptNamespace(attribBlock.Attributes);
                    if (scriptNamespace != null) {
                        return scriptNamespace;
                    }
                }
            }
            return null;
        }

        private string GetAssemblyScriptPrefix(ParseNodeList compilationUnits) {
            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (AttributeBlockNode attribBlock in compilationUnit.Attributes) {
                    string scriptPrefix = GetAttributeValue(attribBlock.Attributes, "ScriptQualifier");
                    if (scriptPrefix != null) {
                        return scriptPrefix;
                    }
                }
            }
            return null;
        }

        private string GetAttributeValue(ParseNodeList attributes, string attributeName) {
            AttributeNode node = AttributeNode.FindAttribute(attributes, attributeName);

            if (node != null) {
                Debug.Assert(node.Arguments[0] is LiteralNode);
                Debug.Assert(((LiteralNode)node.Arguments[0]).Value is string);

                return (string)((LiteralNode)node.Arguments[0]).Value;
            }
            return null;
        }

        private string GetScriptNamespace(ParseNodeList attributes) {
            return GetAttributeValue(attributes, "ScriptNamespace");
        }

        private MemberVisibility GetVisibility(MemberNode node, TypeSymbol typeSymbol) {
            if (typeSymbol.Type == SymbolType.Interface) {
                return MemberVisibility.Public;
            }

            MemberVisibility visibility = MemberVisibility.PrivateInstance;

            if (((node.Modifiers & Modifiers.Static) != 0) ||
                (node.NodeType == ParseNodeType.ConstFieldDeclaration)) {
                visibility |= MemberVisibility.Static;
            }

            if ((node.Modifiers & Modifiers.Public) != 0) {
                visibility |= MemberVisibility.Public;
            }
            else {
                if ((node.Modifiers & Modifiers.Protected) != 0) {
                    visibility |= MemberVisibility.Protected;
                }
                if ((node.Modifiers & Modifiers.Internal) != 0) {
                    visibility |= MemberVisibility.Internal;
                }
            }

            return visibility;
        }
    }
}
