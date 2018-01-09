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

        private void BuildAssembly(ParseNodeList compilationUnits) {
            string scriptName = GetAssemblyScriptName(compilationUnits);
            if (String.IsNullOrEmpty(scriptName)) {
                _errorHandler.ReportError("You must declare a ScriptAssembly attribute.", String.Empty);
            }
            else if (Utility.IsValidScriptName(scriptName) == false) {
                string errorMessage = "The ScriptAssembly attribute referenced an invalid name '{0}'. Script names must only contain letters, numbers, dots or underscores.";
                _errorHandler.ReportError(String.Format(errorMessage, scriptName), String.Empty);
            }

            _symbols.ScriptName = scriptName;

            List<AttributeNode> referenceAttributes = GetAttributes(compilationUnits, "ScriptReference");
            foreach (AttributeNode attribNode in referenceAttributes) {
                string name = null;
                string identifier = null;
                string path = null;
                bool delayLoad = false;

                Debug.Assert((attribNode.Arguments.Count != 0) && (attribNode.Arguments[0].NodeType == ParseNodeType.Literal));
                Debug.Assert(((LiteralNode)attribNode.Arguments[0]).Value is string);
                name = (string)((LiteralNode)attribNode.Arguments[0]).Value;

                if (attribNode.Arguments.Count > 1) {
                    for (int i = 1; i < attribNode.Arguments.Count; i++) {
                        Debug.Assert(attribNode.Arguments[1] is BinaryExpressionNode);

                        BinaryExpressionNode propExpression = (BinaryExpressionNode)attribNode.Arguments[1];
                        Debug.Assert((propExpression.LeftChild.NodeType == ParseNodeType.Name));

                        string propName = ((NameNode)propExpression.LeftChild).Name;
                        if (String.CompareOrdinal(propName, "Identifier") == 0) {
                            Debug.Assert(propExpression.RightChild.NodeType == ParseNodeType.Literal);
                            Debug.Assert(((LiteralNode)propExpression.RightChild).Value is string);

                            identifier = (string)((LiteralNode)propExpression.RightChild).Value;
                        }
                        if (String.CompareOrdinal(propName, "Path") == 0) {
                            Debug.Assert(propExpression.RightChild.NodeType == ParseNodeType.Literal);
                            Debug.Assert(((LiteralNode)propExpression.RightChild).Value is string);

                            path = (string)((LiteralNode)propExpression.RightChild).Value;
                        }
                        else if (String.CompareOrdinal(propName, "DelayLoad") == 0) {
                            Debug.Assert(propExpression.RightChild.NodeType == ParseNodeType.Literal);
                            Debug.Assert(((LiteralNode)propExpression.RightChild).Value is bool);

                            delayLoad = (bool)((LiteralNode)propExpression.RightChild).Value;
                        }
                    }
                }

                bool newReference;
                ScriptReference reference = _symbols.GetDependency(name, out newReference);
                reference.Path = path;
                reference.DelayLoaded = delayLoad;
                if (newReference) {
                    reference.Identifier = identifier;
                }
            }

            string template;
            if (GetScriptTemplate(compilationUnits, out template)) {
                _options.ScriptInfo.Template = template;
            }

            string description;
            string copyright;
            string version;
            GetAssemblyMetadata(compilationUnits, out description, out copyright, out version);
            if (description != null) {
                _options.ScriptInfo.Description = description;
            }
            if (copyright != null) {
                _options.ScriptInfo.Copyright = copyright;
            }
            if (version != null) {
                _options.ScriptInfo.Version = version;
            }
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

                if (typeSymbol.IsApplicationType == false) {
                    AttributeNode eventAttribute = AttributeNode.FindAttribute(eventNode.Attributes, "ScriptEvent");
                    if ((eventAttribute != null) && (eventAttribute.Arguments != null) && (eventAttribute.Arguments.Count == 2)) {
                        string addAccessor = (string)((LiteralNode)eventAttribute.Arguments[0]).Value;
                        string removeAccessor = (string)((LiteralNode)eventAttribute.Arguments[1]).Value;

                        eventSymbol.SetAccessors(addAccessor, removeAccessor);
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

                    if (initializer.Value != null) {
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

                if (AttributeNode.FindAttribute(indexerNode.Attributes, "ScriptField") != null) {
                    indexer.SetScriptIndexer();
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

        private void AggregateInterfaceMembers(ICollection<InterfaceSymbol> subInterfaceCollection, Dictionary<string, MemberSymbol> aggregateMemberCollection)
        {
            if(subInterfaceCollection == null)
            {
                return;
            }

            foreach (InterfaceSymbol newInterfaceSymbol in subInterfaceCollection)
            {
                AddInterfaceMembers(newInterfaceSymbol.Members, aggregateMemberCollection);
                AggregateInterfaceMembers(newInterfaceSymbol.Interfaces, aggregateMemberCollection);
            }
        }

        private void AddInterfaceMembers(ICollection<MemberSymbol> newMemberSymbols, Dictionary<string, MemberSymbol> aggregateMemberCollection)
        {
            if (newMemberSymbols == null)
            {
                return;
            }

            foreach(MemberSymbol newMemberSymbol in newMemberSymbols)
            {
                if(!aggregateMemberCollection.ContainsKey(newMemberSymbol.Name))
                {
                    aggregateMemberCollection[newMemberSymbol.Name] = newMemberSymbol;
                }
            }
        }

        private void BuildMemberDetails(MemberSymbol memberSymbol, TypeSymbol typeSymbol, MemberNode memberNode, ParseNodeList attributes) {
            if (memberSymbol.Type != SymbolType.EnumerationField) {
                memberSymbol.SetVisibility(GetVisibility(memberNode, typeSymbol));
            }

            AttributeNode nameAttribute = AttributeNode.FindAttribute(attributes, "ScriptName");
            if ((nameAttribute != null) && (nameAttribute.Arguments != null) &&
                (nameAttribute.Arguments.Count != 0)) {
                string name = null;
                bool preserveCase = false;
                bool preserveName = false;

                foreach (ParseNode argNode in nameAttribute.Arguments) {
                    Debug.Assert((argNode.NodeType == ParseNodeType.Literal) ||
                                 (argNode.NodeType == ParseNodeType.BinaryExpression));

                    if (argNode.NodeType == ParseNodeType.Literal) {
                        Debug.Assert(((LiteralNode)argNode).Value is string);
                        name = (string)((LiteralNode)argNode).Value;
                        preserveName = preserveCase = true;
                        break;
                    }
                    else {
                        BinaryExpressionNode propSetNode = (BinaryExpressionNode)argNode;

                        if (String.CompareOrdinal(((NameNode)propSetNode.LeftChild).Name, "PreserveName") == 0) {
                            preserveName = (bool)((LiteralNode)propSetNode.RightChild).Value;
                        }
                        else {
                            preserveCase = (bool)((LiteralNode)propSetNode.RightChild).Value;
                            if (preserveCase) {
                                preserveName = true;
                                break;
                            }
                        }
                    }
                }

                if (String.IsNullOrEmpty(name) == false) {
                    memberSymbol.SetTransformedName(name);
                }
                else {
                    memberSymbol.SetNameCasing(preserveCase);
                    if (preserveName) {
                        memberSymbol.DisableNameTransformation();
                    }
                }
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
            BuildAssembly(compilationUnits);

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
                else if (typeSymbol.Type == SymbolType.Interface)
                {
                    BuildTypeInheritance((InterfaceSymbol)typeSymbol);
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

                    if (typeSymbol.IsApplicationType == false) {
                        foreach (AttributeNode attrNode in methodNode.Attributes) {
                            if (attrNode.TypeName.Equals("ScriptMethod", StringComparison.Ordinal)) {
                                Debug.Assert(attrNode.Arguments[0] is LiteralNode);
                                Debug.Assert(((LiteralNode)attrNode.Arguments[0]).Value is string);

                                method.SetSelector((string)((LiteralNode)attrNode.Arguments[0]).Value);
                                break;
                            }
                        }
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
                        ParameterSymbol paramSymbol;

                        if (IsGenericTypeParameter(methodNode, parameterNode))
                        {
                            TypeSymbol baseIntrensicType = method.SymbolSet.ResolveIntrinsicType(IntrinsicType.Object);
                            paramSymbol = BuildParameter(parameterNode, method, baseIntrensicType);
                        }
                        else
                        {
                            paramSymbol = BuildParameter(parameterNode, method);
                        }
                        
                        if (paramSymbol != null) {
                            paramSymbol.SetParseContext(parameterNode);
                            method.AddParameter(paramSymbol);
                        }
                    }
                }

                string scriptAlias = GetAttributeValue(methodNode.Attributes, "ScriptAlias");
                if (scriptAlias != null) {
                    method.SetAlias(scriptAlias);
                }
            }

            return method;
        }

        private bool IsGenericTypeParameter(MethodDeclarationNode methodNode, ParameterNode parameterNode)
        {
            Debug.Assert(methodNode != null, "methodNode can't be null when resolving a generic parameter");
            Debug.Assert(parameterNode != null, "parameterNode can't be null when resolving a generic parameter");

            if(methodNode.TypeParameters == null || methodNode.TypeParameters.Count <= 0)
            {
                return false;
            }

            foreach (TypeParameterNode typeParemeterNode in methodNode.TypeParameters)
            {
                if(typeParemeterNode.NameNode.Name == ((AtomicNameNode)parameterNode.Type).Name)
                {
                    return true;
                }
            }

            return false;
        }

        private ParameterSymbol BuildParameter(ParameterNode parameterNode, MethodSymbol methodSymbol, TypeSymbol parameterType = null) {
            ParameterMode parameterMode = ParameterMode.In;

            if ((parameterNode.Flags == ParameterFlags.Out) ||
                (parameterNode.Flags == ParameterFlags.Ref)) {
                parameterMode = ParameterMode.InOut;
            }
            else if (parameterNode.Flags == ParameterFlags.Params) {
                parameterMode = ParameterMode.List;
            }

            if(parameterType == null)
            {
                parameterType = methodSymbol.SymbolSet.ResolveType(parameterNode.Type, _symbolTable, methodSymbol);
                Debug.Assert(parameterType != null);
            }

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
                property.SetNameCasing(true);
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
            AttributeNode scriptFieldAttribute = AttributeNode.FindAttribute(propertyNode.Attributes, "ScriptField");
            if (scriptFieldAttribute == null) {
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

            if (typeNode.Type == TokenType.Class || typeNode.Type == TokenType.Struct) {
                CustomTypeNode customTypeNode = (CustomTypeNode)typeNode;
                Debug.Assert(customTypeNode != null);

                if (AttributeNode.FindAttribute(attributes, "ScriptObject") != null) {
                    typeSymbol = new RecordSymbol(typeNode.Name, namespaceSymbol);
                }
                else if (AttributeNode.FindAttribute(attributes, "ScriptResources") != null) {
                    typeSymbol = new ResourcesSymbol(typeNode.Name, namespaceSymbol);
                }
                else {
                    typeSymbol = new ClassSymbol(typeNode.Name, namespaceSymbol);

                    NameNode baseTypeNameNode = null;
                    if (customTypeNode.BaseTypes.Count != 0) {
                        baseTypeNameNode = customTypeNode.BaseTypes[0] as NameNode;
                    }

                    if ((baseTypeNameNode != null) &&
                        (String.CompareOrdinal(baseTypeNameNode.Name, "TestClass") == 0)) {
                        ((ClassSymbol)typeSymbol).SetTestClass();
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

                if (namespaceSymbol.Name.EndsWith(".Tests", StringComparison.Ordinal) ||
                    (namespaceSymbol.Name.IndexOf(".Tests.", StringComparison.Ordinal) > 0)) {
                    typeSymbol.SetTestType();
                }
            }

            return typeSymbol;
        }

        private void BuildType(TypeSymbol typeSymbol, UserTypeNode typeNode) {
            Debug.Assert(typeSymbol != null);
            Debug.Assert(typeNode != null);

            ParseNodeList attributes = typeNode.Attributes;

            if (AttributeNode.FindAttribute(attributes, "ScriptImport") != null) {
                ScriptReference dependency = null;

                AttributeNode dependencyAttribute = AttributeNode.FindAttribute(attributes, "ScriptDependency");
                if (dependencyAttribute != null) {
                    string dependencyIdentifier = null;

                    Debug.Assert((dependencyAttribute.Arguments.Count != 0) && (dependencyAttribute.Arguments[0].NodeType == ParseNodeType.Literal));
                    Debug.Assert(((LiteralNode)dependencyAttribute.Arguments[0]).Value is string);
                    string dependencyName = (string)((LiteralNode)dependencyAttribute.Arguments[0]).Value;

                    if (dependencyAttribute.Arguments.Count > 1) {
                        Debug.Assert(dependencyAttribute.Arguments[1] is BinaryExpressionNode);

                        BinaryExpressionNode propExpression = (BinaryExpressionNode)dependencyAttribute.Arguments[1];
                        Debug.Assert((propExpression.LeftChild.NodeType == ParseNodeType.Name) &&
                                     (String.CompareOrdinal(((NameNode)propExpression.LeftChild).Name, "Identifier") == 0));

                        Debug.Assert(propExpression.RightChild.NodeType == ParseNodeType.Literal);
                        Debug.Assert(((LiteralNode)propExpression.RightChild).Value is string);

                        dependencyIdentifier = (string)((LiteralNode)propExpression.RightChild).Value;
                    }

                    dependency = new ScriptReference(dependencyName, dependencyIdentifier);
                }

                typeSymbol.SetImported(dependency);

                if ((AttributeNode.FindAttribute(attributes, "ScriptIgnoreNamespace") != null) ||
                    (dependency == null)) {
                    typeSymbol.SetIgnoreNamespace();
                }
                else {
                    typeSymbol.ScriptNamespace = dependency.Identifier;
                }
            }

            if (AttributeNode.FindAttribute(attributes, "PreserveName") != null) {
                typeSymbol.DisableNameTransformation();
            }

            string scriptName = GetAttributeValue(attributes, "ScriptName");
            if (scriptName != null) {
                typeSymbol.SetTransformedName(scriptName);
            }

            if (typeNode.Type == TokenType.Class || typeNode.Type == TokenType.Struct) {
                AttributeNode extensionAttribute = AttributeNode.FindAttribute(attributes, "ScriptExtension");
                if (extensionAttribute != null) {
                    Debug.Assert(extensionAttribute.Arguments[0] is LiteralNode);
                    Debug.Assert(((LiteralNode)extensionAttribute.Arguments[0]).Value is string);

                    string extendee = (string)((LiteralNode)extensionAttribute.Arguments[0]).Value;
                    Debug.Assert(String.IsNullOrEmpty(extendee) == false);

                    ((ClassSymbol)typeSymbol).SetExtenderClass(extendee);
                }

                AttributeNode moduleAttribute = AttributeNode.FindAttribute(attributes, "ScriptModule");
                if (moduleAttribute != null) {
                    ((ClassSymbol)typeSymbol).SetModuleClass();
                }

                if ((typeNode.Modifiers & Modifiers.Static) != 0) {
                    ((ClassSymbol)typeSymbol).SetStaticClass();
                }
            }

            if (typeNode.Type == TokenType.Enum) {
                AttributeNode constantsAttribute = AttributeNode.FindAttribute(attributes, "ScriptConstants");
                if (constantsAttribute != null) {
                    bool useNames = false;

                    if ((constantsAttribute.Arguments != null) && (constantsAttribute.Arguments.Count != 0)) {
                        Debug.Assert(constantsAttribute.Arguments[0] is BinaryExpressionNode);

                        BinaryExpressionNode propExpression = (BinaryExpressionNode)constantsAttribute.Arguments[0];
                        Debug.Assert((propExpression.LeftChild.NodeType == ParseNodeType.Name) &&
                                     (String.CompareOrdinal(((NameNode)propExpression.LeftChild).Name, "UseNames") == 0));

                        Debug.Assert(propExpression.RightChild.NodeType == ParseNodeType.Literal);
                        Debug.Assert(((LiteralNode)propExpression.RightChild).Value is bool);

                        useNames = (bool)((LiteralNode)propExpression.RightChild).Value;
                    }

                    if (useNames) {
                        ((EnumerationSymbol)typeSymbol).SetNamedValues();
                    }
                    else {
                        ((EnumerationSymbol)typeSymbol).SetNumericValues();
                    }
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

        private void BuildTypeInheritance(InterfaceSymbol interfaceSymbol)
        {
            CustomTypeNode customTypeNode = (CustomTypeNode)interfaceSymbol.ParseContext;

            if ((customTypeNode.BaseTypes != null) && (customTypeNode.BaseTypes.Count != 0))
            {
                List<InterfaceSymbol> interfaces = null;

                foreach (NameNode node in customTypeNode.BaseTypes)
                {
                    TypeSymbol baseTypeSymbol = (TypeSymbol)_symbolTable.FindSymbol(node.Name, interfaceSymbol, SymbolFilter.Types);
                        Debug.Assert(baseTypeSymbol.Type == SymbolType.Interface);

                        if (interfaces == null)
                        {
                            interfaces = new List<InterfaceSymbol>();
                        }
                        interfaces.Add((InterfaceSymbol)baseTypeSymbol);
                    
                }

                if (interfaces != null)
                {
                    interfaceSymbol.SetInheritance(interfaces);
                }
            }
        }

        private void GetAssemblyMetadata(ParseNodeList compilationUnits, out string description, out string copyright, out string version) {
            description = null;
            copyright = null;
            version = null;

            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (AttributeBlockNode attribBlock in compilationUnit.Attributes) {
                    if (description == null) {
                        description = GetAttributeValue(attribBlock.Attributes, "AssemblyDescription");
                    }
                    if (copyright == null) {
                        copyright = GetAttributeValue(attribBlock.Attributes, "AssemblyCopyright");
                    }
                    if (version == null) {
                        version = GetAttributeValue(attribBlock.Attributes, "AssemblyFileVersion");
                    }
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

        private List<AttributeNode> GetAttributes(ParseNodeList compilationUnits, string attributeName) {
            List<AttributeNode> attributes = new List<AttributeNode>();

            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (AttributeBlockNode attribBlock in compilationUnit.Attributes) {
                    foreach (AttributeNode attribNode in attribBlock.Attributes) {
                        if (attribNode.TypeName.Equals(attributeName, StringComparison.Ordinal)) {
                            attributes.Add(attribNode);
                        }
                    }
                }
            }

            return attributes;
        }

        private string GetAttributeValue(ParseNodeList attributes, string attributeName) {
            AttributeNode node = AttributeNode.FindAttribute(attributes, attributeName);

            if ((node != null) &&
                (node.Arguments.Count != 0) && (node.Arguments[0].NodeType == ParseNodeType.Literal)) {
                Debug.Assert(((LiteralNode)node.Arguments[0]).Value is string);

                return (string)((LiteralNode)node.Arguments[0]).Value;
            }
            return null;
        }

        private bool GetScriptTemplate(ParseNodeList compilationUnits, out string template) {
            template = null;

            foreach (CompilationUnitNode compilationUnit in compilationUnits) {
                foreach (AttributeBlockNode attribBlock in compilationUnit.Attributes) {
                    template = GetAttributeValue(attribBlock.Attributes, "ScriptTemplate");
                    if (template != null) {
                        return true;
                    }
                }
            }

            return false;
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
