using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;
using DSharp.Compiler.ScriptModel.Expressions;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Compiler
{
    internal sealed class ExpressionBuilder
    {
        private readonly ClassSymbol classContext;
        private readonly IErrorHandler errorHandler;
        private readonly CodeMemberSymbol memberContext;

        private readonly CompilerOptions options;
        private readonly Symbol symbolContext;
        private readonly SymbolSet symbolSet;
        private readonly ILocalSymbolTable symbolTable;

        public ExpressionBuilder(ILocalSymbolTable symbolTable, CodeMemberSymbol memberContext,
                                 IErrorHandler errorHandler, CompilerOptions options)
        {
            this.symbolTable = symbolTable;
            symbolContext = memberContext;
            this.memberContext = memberContext;
            classContext = ((ClassSymbol)memberContext.Parent).PrimaryPartialClass;
            symbolSet = memberContext.SymbolSet;
            this.errorHandler = errorHandler;
            this.options = options;
        }

        public ExpressionBuilder(ILocalSymbolTable symbolTable, FieldSymbol fieldContext, IErrorHandler errorHandler,
                                 CompilerOptions options)
        {
            this.symbolTable = symbolTable;
            symbolContext = fieldContext;
            classContext = ((ClassSymbol)fieldContext.Parent).PrimaryPartialClass;
            symbolSet = fieldContext.SymbolSet;
            this.errorHandler = errorHandler;
            this.options = options;
        }

        public Expression BuildExpression(ParseNode node)
        {
            Expression expression = null;

            switch (node.NodeType)
            {
                case ParseNodeType.Literal:
                    expression = ProcessLiteralNode((LiteralNode)node);

                    break;
                case ParseNodeType.Name:
                case ParseNodeType.GenericName:
                    expression = ProcessNameNode((NameNode)node);

                    break;
                case ParseNodeType.Typeof:
                    expression = ProcessTypeofNode((TypeofNode)node);

                    break;
                case ParseNodeType.This:
                    expression = ProcessThisNode((ThisNode)node);

                    break;
                case ParseNodeType.Base:
                    expression = ProcessBaseNode((BaseNode)node);

                    break;
                case ParseNodeType.UnaryExpression:
                    expression = ProcessUnaryExpressionNode((UnaryExpressionNode)node);

                    break;
                case ParseNodeType.BinaryExpression:
                    expression = ProcessBinaryExpressionNode((BinaryExpressionNode)node);

                    break;
                case ParseNodeType.Conditional:
                    expression = ProcessConditionalNode((ConditionalNode)node);

                    break;
                case ParseNodeType.New:
                    expression = ProcessNewNode((NewNode)node);

                    break;
                case ParseNodeType.ArrayNew:
                    expression = ProcessArrayNewNode((ArrayNewNode)node);

                    break;
                case ParseNodeType.ArrayInitializer:
                    expression = ProcessArrayInitializerNode((ArrayInitializerNode)node);

                    break;
                case ParseNodeType.ArrayType:
                    expression = ProcessArrayTypeNode((ArrayTypeNode)node);

                    break;
                case ParseNodeType.PredefinedType:
                    expression = ProcessIntrinsicType((IntrinsicTypeNode)node);

                    break;
                case ParseNodeType.Cast:
                    expression = ProcessCastNode((CastNode)node);

                    break;
                case ParseNodeType.AnonymousMethod:
                    expression = ProcessAnonymousMethodNode((AnonymousMethodNode)node);

                    break;
                default:
                    Debug.Fail("Unhandled Expression Node: " + node.NodeType);

                    break;
            }

            if (node is ExpressionNode expressionNode && expressionNode.Parenthesized)
            {
                expression.AddParenthesisHint();
            }

            return expression;
        }

        public List<Expression> BuildExpressionList(ExpressionListNode node)
        {
            List<Expression> expressions = new List<Expression>(node.Expressions.Count);

            foreach (ParseNode itemNode in node.Expressions)
            {
                Expression itemExpr = BuildExpression(itemNode);

                if (itemExpr is MemberExpression)
                {
                    itemExpr = TransformMemberExpression((MemberExpression)itemExpr);
                }

                expressions.Add(itemExpr);
            }

            return expressions;
        }

        private Expression ProcessAnonymousMethodNode(AnonymousMethodNode node)
        {
            TypeSymbol voidType = symbolSet.ResolveIntrinsicType(IntrinsicType.Void);
            Debug.Assert(voidType != null);

            bool createStaticDelegate = (memberContext.Visibility & MemberVisibility.Static) != 0;

            AnonymousMethodSymbol methodSymbol =
                new AnonymousMethodSymbol(memberContext, symbolTable, voidType, createStaticDelegate);
            methodSymbol.SetParseContext(node);

            if (node.Parameters != null && node.Parameters.Count != 0)
            {
                foreach (ParameterNode parameterNode in node.Parameters)
                {
                    TypeSymbol parameterType = symbolSet.ResolveType(parameterNode.Type, symbolTable, symbolContext);
                    Debug.Assert(parameterType != null);

                    ParameterSymbol paramSymbol =
                        new ParameterSymbol(parameterNode.Name, methodSymbol, parameterType, ParameterMode.In);

                    if (paramSymbol != null)
                    {
                        paramSymbol.SetParseContext(parameterNode);
                        methodSymbol.AddParameter(paramSymbol);
                    }
                }
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(options, errorHandler);
            SymbolImplementation implementation = implBuilder.BuildMethod(methodSymbol);

            methodSymbol.AddImplementation(implementation);

            if (createStaticDelegate == false && implementation.RequiresThisContext == false)
            {
                methodSymbol.SetVisibility(methodSymbol.Visibility | MemberVisibility.Static);
                createStaticDelegate = true;
            }

            Expression objectExpression;

            if (createStaticDelegate)
            {
                TypeSymbol objectType = symbolSet.ResolveIntrinsicType(IntrinsicType.Object);
                Debug.Assert(objectType != null);

                objectExpression = new LiteralExpression(objectType, null);
            }
            else
            {
                objectExpression = new ThisExpression(classContext, /* explicitReference */ true);
            }

            return new DelegateExpression(objectExpression, methodSymbol);
        }

        private Expression ProcessArrayInitializerNode(ArrayInitializerNode node)
        {
            TypeSymbol itemTypeSymbol = symbolSet.ResolveIntrinsicType(IntrinsicType.Object);
            Debug.Assert(itemTypeSymbol != null);

            TypeSymbol arrayTypeSymbol = symbolSet.CreateArrayTypeSymbol(itemTypeSymbol);
            Expression[] values = new Expression[node.Values.Count];

            int i = 0;

            foreach (ParseNode valueNode in node.Values)
            {
                values[i] = BuildExpression(valueNode);

                if (values[i] is MemberExpression)
                {
                    values[i] = TransformMemberExpression((MemberExpression)values[i]);
                }

                i++;
            }

            return new LiteralExpression(arrayTypeSymbol, values);
        }

        private Expression ProcessArrayNewNode(ArrayNewNode node)
        {
            TypeSymbol itemTypeSymbol = symbolSet.ResolveType(node.TypeReference, symbolTable, symbolContext);
            Debug.Assert(itemTypeSymbol != null);

            TypeSymbol arrayTypeSymbol = symbolSet.CreateArrayTypeSymbol(itemTypeSymbol);

            if (node.InitializerExpression == null)
            {
                if (node.ExpressionList == null)
                {
                    return new LiteralExpression(arrayTypeSymbol, new Expression[0]);
                }

                Debug.Assert(node.ExpressionList.NodeType == ParseNodeType.ExpressionList);
                ExpressionListNode argsList = (ExpressionListNode)node.ExpressionList;

                Debug.Assert(argsList.Expressions.Count == 1);
                Expression sizeExpression = BuildExpression(argsList.Expressions[0]);

                if (sizeExpression is MemberExpression)
                {
                    sizeExpression = TransformMemberExpression((MemberExpression)sizeExpression);
                }

                NewExpression newExpr = new NewExpression(arrayTypeSymbol);
                newExpr.AddParameterValue(sizeExpression);

                return newExpr;
            }

            ArrayInitializerNode initializerNode = (ArrayInitializerNode)node.InitializerExpression;
            Expression[] values = new Expression[initializerNode.Values.Count];

            int i = 0;

            foreach (ParseNode valueNode in initializerNode.Values)
            {
                values[i] = BuildExpression(valueNode);

                if (values[i] is MemberExpression)
                {
                    values[i] = TransformMemberExpression((MemberExpression)values[i]);
                }

                i++;
            }

            return new LiteralExpression(arrayTypeSymbol, values);
        }

        private Expression ProcessArrayTypeNode(ArrayTypeNode node)
        {
            TypeSymbol itemTypeSymbol = symbolSet.ResolveType(node.BaseType, symbolTable, symbolContext);
            Debug.Assert(itemTypeSymbol != null);

            TypeSymbol arrayTypeSymbol = symbolSet.CreateArrayTypeSymbol(itemTypeSymbol);

            return new TypeExpression(arrayTypeSymbol, SymbolFilter.Public | SymbolFilter.StaticMembers);
        }

        private Expression ProcessBaseNode(BaseNode node)
        {
            Debug.Assert(classContext.BaseClass != null);

            return new BaseExpression(classContext.BaseClass);
        }

        private Expression ProcessBinaryExpressionNode(BinaryExpressionNode node)
        {
            if (node.Operator == TokenType.PlusPlus ||
                node.Operator == TokenType.MinusMinus)
            {
                Expression childExpression = BuildExpression(node.LeftChild);

                if (childExpression is MemberExpression)
                {
                    childExpression = TransformMemberExpression((MemberExpression)childExpression);
                }

                return new UnaryExpression(
                    node.Operator == TokenType.PlusPlus ? Operator.PreIncrement : Operator.PreDecrement,
                    childExpression);
            }

            if (node.Operator == TokenType.Dot)
            {
                return ProcessDotExpressionNode(node);
            }

            if (node.Operator == TokenType.OpenParen)
            {
                return ProcessOpenParenExpressionNode(node);
            }

            if (node.Operator == TokenType.OpenSquare)
            {
                return ProcessOpenBracketsExpressionNode(node);
            }

            Expression leftExpression = BuildExpression(node.LeftChild);
            Expression rightExpression = BuildExpression(node.RightChild);

            if (node.Operator == TokenType.PlusEqual ||
                node.Operator == TokenType.MinusEqual)
            {
                if (rightExpression.Type == ExpressionType.Member)
                {
                    rightExpression = TransformMemberExpression((MemberExpression)rightExpression);
                }

                if (rightExpression.Type == ExpressionType.Delegate ||
                    rightExpression.EvaluatedType.Type == SymbolType.Delegate)
                {
                    Debug.Assert(leftExpression.Type == ExpressionType.Member);
                    Debug.Assert(((MemberExpression)leftExpression).Member.Type == SymbolType.Event);

                    bool add = node.Operator == TokenType.PlusEqual;
                    EventExpression eventExpression =
                        (EventExpression)TransformMemberExpression((MemberExpression)leftExpression,
                            add, /* isEventAddOrRemove */ true);

                    eventExpression.SetHandler(rightExpression);

                    return eventExpression;
                }

                if (leftExpression.Type == ExpressionType.Member)
                {
                    MemberExpression leftMemberExpression = (MemberExpression)leftExpression;

                    if (leftMemberExpression.Member.Type == SymbolType.Property)
                    {
                        // For properties, we need to expand out the += and -= into a get, followed by
                        // the + or - operation and then a set with the resulting value

                        leftExpression = TransformMemberExpression(leftMemberExpression, /* getter */ false);

                        Expression initialValueExpression = TransformMemberExpression(leftMemberExpression);
                        Operator substitutedOperator;

                        if (node.Operator == TokenType.PlusEqual)
                        {
                            substitutedOperator = Operator.Plus;
                        }
                        else
                        {
                            substitutedOperator = Operator.Minus;
                        }

                        Expression newValueExpression =
                            new BinaryExpression(substitutedOperator, initialValueExpression, rightExpression);

                        return new BinaryExpression(Operator.Equals, leftExpression, newValueExpression);
                    }
                }
            }

            if (leftExpression.Type == ExpressionType.Member)
            {
                leftExpression = TransformMemberExpression((MemberExpression)leftExpression,
                    /* getOrAdd */ node.Operator != TokenType.Equal);
            }

            if (rightExpression.Type == ExpressionType.Member)
            {
                rightExpression = TransformMemberExpression((MemberExpression)rightExpression);
            }

            if (node.Operator == TokenType.Coalesce)
            {
                TypeSymbol scriptType = symbolSet.ResolveIntrinsicType(IntrinsicType.Script);
                MethodSymbol valueMethod = (MethodSymbol)scriptType.GetMember("Value");

                TypeExpression scriptExpression =
                    new TypeExpression(scriptType, SymbolFilter.Public | SymbolFilter.StaticMembers);
                MethodExpression valueExpression = new MethodExpression(scriptExpression, valueMethod);

                valueExpression.AddParameterValue(leftExpression);
                valueExpression.AddParameterValue(rightExpression);
                valueExpression.Reevaluate(rightExpression.EvaluatedType);

                return valueExpression;
            }

            TypeSymbol resultType = null;
            Operator operatorType = OperatorConverter.OperatorFromToken(node.Operator);

            switch (node.Operator)
            {
                case TokenType.EqualEqual:
                case TokenType.NotEqual:
                case TokenType.Less:
                case TokenType.LessEqual:
                case TokenType.Greater:
                case TokenType.GreaterEqual:
                case TokenType.Is:
                    resultType = symbolSet.ResolveIntrinsicType(IntrinsicType.Boolean);

                    break;
                case TokenType.As:
                    resultType = rightExpression.EvaluatedType;

                    break;
                case TokenType.Plus:

                    if (rightExpression.EvaluatedType == symbolSet.ResolveIntrinsicType(IntrinsicType.String))
                    {
                        resultType = rightExpression.EvaluatedType;
                    }

                    break;
                case TokenType.Slash:
                    resultType = symbolSet.ResolveIntrinsicType(IntrinsicType.Double);

                    break;
            }

            if (operatorType != Operator.Invalid)
            {
                if (operatorType == Operator.BitwiseAnd ||
                    operatorType == Operator.BitwiseAndEquals ||
                    operatorType == Operator.BitwiseOr ||
                    operatorType == Operator.BitwiseOrEquals ||
                    operatorType == Operator.BitwiseXor ||
                    operatorType == Operator.BitwiseXorEquals)
                {
                    TypeSymbol leftExpressionType = leftExpression.EvaluatedType;

                    if (leftExpressionType == symbolSet.ResolveIntrinsicType(IntrinsicType.Boolean))
                    {
                        // For bitwise operators involving boolean expressions, we perform
                        // a type coercion due to behavioral differences between C# and JavaScript.
                        // Example:
                        //     var result = true & true;
                        //     actual: result === 1
                        //     expected: result === true
                        Operator baseOperatorType = operatorType;

                        switch (operatorType)
                        {
                            case Operator.BitwiseAndEquals:
                                baseOperatorType = Operator.BitwiseAnd;

                                break;
                            case Operator.BitwiseOrEquals:
                                baseOperatorType = Operator.BitwiseOr;

                                break;
                            case Operator.BitwiseXorEquals:
                                baseOperatorType = Operator.BitwiseXor;

                                break;
                        }

                        // Map "x op y" to "(x op y) === 1"
                        // Map "x op= y" to "x = (x op y) === 1"
                        Expression bitwiseExpression =
                            new BinaryExpression(baseOperatorType, leftExpression, rightExpression);
                        bitwiseExpression.AddParenthesisHint();

                        Expression coerceExpression =
                            new BinaryExpression(Operator.EqualEqualEqual, bitwiseExpression,
                                new LiteralExpression(symbolSet.ResolveIntrinsicType(IntrinsicType.Integer), 1));

                        if (operatorType == baseOperatorType)
                        {
                            return coerceExpression;
                        }

                        // Since y above can be a complex expression, add parentheses around it to ensure
                        // proper operator precedence.
                        rightExpression.AddParenthesisHint();

                        return new BinaryExpression(Operator.Equals, TransformGetPropertyExpression(leftExpression),
                            coerceExpression);
                    }
                }

                if (operatorType == Operator.EqualEqualEqual ||
                    operatorType == Operator.NotEqualEqual)
                {
                    LiteralExpression literalExpression = rightExpression as LiteralExpression;

                    if (literalExpression != null)
                    {
                        // Comparisons with null are mapped to the less-strict comparison operator
                        // to handle undefined as well.
                        if (literalExpression.Value == null)
                        {
                            if (operatorType == Operator.EqualEqualEqual)
                            {
                                return new BinaryExpression(Operator.EqualEqual, leftExpression, rightExpression,
                                    resultType);
                            }

                            return new BinaryExpression(Operator.NotEqual, leftExpression, rightExpression, resultType);
                        }
                    }

                    if (leftExpression.EvaluatedType == rightExpression.EvaluatedType &&
                        leftExpression.EvaluatedType == symbolSet.ResolveIntrinsicType(IntrinsicType.Date))
                    {
                        // Map equality comparison between Date objects to a call to
                        // Script.CompareDates

                        TypeSymbol scriptType = symbolSet.ResolveIntrinsicType(IntrinsicType.Script);
                        Debug.Assert(scriptType != null);

                        MethodSymbol compareMethod = (MethodSymbol)scriptType.GetMember("CompareDates");
                        Debug.Assert(compareMethod != null);

                        MethodExpression compareExpression =
                            new MethodExpression(
                                new TypeExpression(scriptType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                                compareMethod);
                        compareExpression.AddParameterValue(leftExpression);
                        compareExpression.AddParameterValue(rightExpression);

                        if (operatorType == Operator.NotEqualEqual)
                        {
                            return new UnaryExpression(Operator.LogicalNot, compareExpression);
                        }

                        return compareExpression;
                    }
                }

                if (operatorType == Operator.ShiftRight ||
                    operatorType == Operator.ShiftRightEquals)
                {
                    TypeSymbol leftExpressionType = leftExpression.EvaluatedType;

                    if (leftExpressionType == symbolSet.ResolveIntrinsicType(IntrinsicType.Byte) ||
                        leftExpressionType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedShort) ||
                        leftExpressionType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedInteger) ||
                        leftExpressionType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedLong))
                    {
                        // Switch to unsigned shift operator for unsigned types (which happens
                        // to be set up to follow the signed operator in the enumeration offset by 1)
                        Debug.Assert((int)Operator.UnsignedShiftRight - (int)Operator.ShiftRight == 2);
                        Debug.Assert((int)Operator.UnsignedShiftRightEquals - (int)Operator.ShiftRightEquals == 2);

                        operatorType = (Operator)((int)operatorType + 2);
                    }
                }

                if (resultType == null)
                {
                    return new BinaryExpression(operatorType, leftExpression, rightExpression);
                }

                return new BinaryExpression(operatorType, leftExpression, rightExpression, resultType);
            }

            return null;
        }

        private Expression ProcessCastNode(CastNode node)
        {
            Expression childExpression = BuildExpression(node.Child);

            if (childExpression.Type == ExpressionType.Member)
            {
                childExpression = TransformMemberExpression((MemberExpression)childExpression);
            }

            TypeSymbol typeSymbol = symbolSet.ResolveType(node.TypeReference, symbolTable, symbolContext);
            Debug.Assert(typeSymbol != null);

            if (typeSymbol == symbolSet.ResolveIntrinsicType(IntrinsicType.Integer))
            {
                if (childExpression.EvaluatedType == symbolSet.ResolveIntrinsicType(IntrinsicType.Double) ||
                    childExpression.EvaluatedType == symbolSet.ResolveIntrinsicType(IntrinsicType.Single))
                {
                    // A float or double is being cast to an int
                    // In regular .net this causes a truncation to happen, and we'd like
                    // to preserve that behavior.

                    TypeSymbol mathType =
                        (TypeSymbol)((ISymbolTable)symbolSet.SystemNamespace).FindSymbol("Math", null,
                            SymbolFilter.Types);
                    Debug.Assert(mathType != null);

                    MethodSymbol truncateMethod = (MethodSymbol)mathType.GetMember("Truncate");
                    Debug.Assert(truncateMethod != null);

                    MethodExpression truncateExpression =
                        new MethodExpression(
                            new TypeExpression(mathType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                            truncateMethod);
                    truncateExpression.AddParameterValue(childExpression);

                    return truncateExpression;
                }
            }

            return new UnaryExpression(Operator.Cast, childExpression, typeSymbol, childExpression.MemberMask);
        }

        private Expression ProcessConditionalNode(ConditionalNode node)
        {
            Expression conditionExpression = BuildExpression(node.Condition);
            Expression trueExpression = BuildExpression(node.TrueValue);
            Expression falseExpression = BuildExpression(node.FalseValue);

            if (conditionExpression.Type == ExpressionType.Member)
            {
                conditionExpression = TransformMemberExpression((MemberExpression)conditionExpression);
            }

            if (trueExpression.Type == ExpressionType.Member)
            {
                trueExpression = TransformMemberExpression((MemberExpression)trueExpression);
            }

            if (falseExpression.Type == ExpressionType.Member)
            {
                falseExpression = TransformMemberExpression((MemberExpression)falseExpression);
            }

            return new ConditionalExpression(conditionExpression, trueExpression, falseExpression);
        }

        private Expression ProcessDotExpressionNode(BinaryExpressionNode node, SymbolFilter filter,
                                                    out MemberSymbol memberSymbol)
        {
            Debug.Assert(node.RightChild is NameNode);

            memberSymbol = null;
            Expression objectExpression = null;

            if (node.LeftChild.NodeType == ParseNodeType.Name || node.LeftChild.NodeType == ParseNodeType.GenericName)
            {
                objectExpression = ProcessNameNode((NameNode)node.LeftChild, filter);
            }
            else
            {
                objectExpression = BuildExpression(node.LeftChild);
            }

            if (objectExpression is MemberExpression)
            {
                objectExpression = TransformMemberExpression((MemberExpression)objectExpression);
            }

            if (objectExpression == null)
            {
                throw new ExpressionBuildException($"ObjectExpression is null: {{{node.LeftChild.Token.Location}}} - {{{node.RightChild.Token.Location}}}");
            }

            if (objectExpression is LiteralExpression)
            {
                objectExpression.AddParenthesisHint();
            }

            Debug.Assert(objectExpression.EvaluatedType is ISymbolTable table);

            ISymbolTable typeSymbolTable = objectExpression.EvaluatedType;
            string memberName = ((NameNode)node.RightChild).Name;

            memberSymbol = (MemberSymbol)typeSymbolTable.FindSymbol(memberName,
                symbolContext,
                objectExpression.MemberMask);

            if (memberSymbol != null && memberSymbol.AssociatedType.Type == SymbolType.GenericParameter)
            {
                if (node.RightChild.NodeType == ParseNodeType.GenericName)
                {
                    int genericArgIndex = ((GenericParameterSymbol)memberSymbol.AssociatedType).Index;

                    Debug.Assert(node.RightChild.NodeType == ParseNodeType.GenericName);
                    Debug.Assert(((GenericNameNode)node.RightChild).TypeArguments != null);

                    ParseNode typeArgNode = ((GenericNameNode)node.RightChild).TypeArguments[genericArgIndex];
                    TypeSymbol returnType = symbolSet.ResolveType(typeArgNode, symbolTable, symbolContext);

                    if (returnType != null)
                    {
                        // We're just going to force the resulting expression to use the more
                        // specific type, rather than the generic type, and have that percolate through
                        // the rest of the expression tree.

                        objectExpression.Reevaluate(returnType);
                    }
                    else
                    {
                        memberSymbol = null;
                    }
                }
            }

            if (memberSymbol == null)
            {
                objectExpression = null;
            }

            return objectExpression;
        }

        //Move to extension;
        private T FindParentNode<T>(ParseNode node)
            where T : ParseNode
        {
            ParseNode current = node?.Parent;
            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }

                current = current.Parent;
            }

            return default(T);
        }

        private Expression ProcessDotExpressionNode(BinaryExpressionNode node)
        {
            SymbolFilter filter = SymbolFilter.All;

            Expression objectExpression = ProcessDotExpressionNode(node, filter, out MemberSymbol memberSymbol);

            if (objectExpression == null)
            {
                // We didn't successfully create an expression. The first pass attempted to
                // process the right child as an instance member of the left child expression.
                // We need to process the left child again as a type so we can process the
                // right child as a static member this time around.
                filter &= ~SymbolFilter.Members;
                objectExpression = ProcessDotExpressionNode(node, filter, out memberSymbol);
            }

            //If we are unable to parse the right hand child as a local member of the left hand expression,
            //then we want to try and find out if the token is a Extension method usage.
            if (objectExpression == null)
            {
                if (node.LeftChild.Token is LiteralToken leftLiteralToken)
                {
                    string typeName = ResolveLiteralTypeName(leftLiteralToken);

                    TypeSymbol typeSymbol = ((ISymbolTable)symbolSet).FindSymbol<TypeSymbol>(typeName, symbolContext, SymbolFilter.AllTypes);
                    if (typeSymbol == null)
                    {
                        throw new ExpressionBuildException($"Unable to resolve type '{typeName}' from symbol table.");
                    }

                    Expression extensionMethodInvocation = CreateExtensionMethodInvocationExpression(node, typeSymbol);

                    if (extensionMethodInvocation != null)
                    {
                        return extensionMethodInvocation;
                    }
                }
                else if (node.LeftChild.Token is IdentifierToken identifier)
                {
                    MethodDeclarationNode parentMethod = FindParentNode<MethodDeclarationNode>(node);
                    var token = parentMethod.Parameters.First().Token;
                    var typeNode = symbolSet.ResolveIntrinsicToken(token);

                    Expression extensionMethodInvocation = CreateExtensionMethodInvocationExpression(node, typeNode);

                    if (extensionMethodInvocation != null)
                    {
                        return extensionMethodInvocation;
                    }
                }
            }

            Debug.Assert(objectExpression != null);

            if (objectExpression == null)
            {
                throw new InvalidOperationException($"Unable to resolve expression: {node.RightChild.Token.Location}");
            }

            TypeSymbol[] dictionaryTypes = symbolSet.ResolveIntrinsicTypes(IntrinsicType.GenericDictionary, IntrinsicType.IDictionary, IntrinsicType.GenericIDictionary, IntrinsicType.GenericIReadOnlyDictionary);
            TypeSymbol nullableType = symbolSet.ResolveIntrinsicType(IntrinsicType.Nullable);
            TypeSymbol typeType = symbolSet.ResolveIntrinsicType(IntrinsicType.Type);
            TypeSymbol memberInfoType = symbolSet.ResolveIntrinsicType(IntrinsicType.MemberInfo);

            TypeSymbol evaluatedDictionaryType = dictionaryTypes.SingleOrDefault(
                t => t.FullName == objectExpression.EvaluatedType?.FullName);

            if (evaluatedDictionaryType != null)
            {
                TypeSymbol dictionarySymbol = symbolSet.ResolveIntrinsicType(IntrinsicType.GenericDictionary);
                MethodSymbol methodSymbol = null;

                if (string.CompareOrdinal(memberSymbol.Name, nameof(Dictionary<object, object>.Count)) == 0)
                {
                    methodSymbol = (MethodSymbol)dictionarySymbol.GetMember("GetKeyCount");
                    Debug.Assert(methodSymbol != null);
                }
                else if (string.CompareOrdinal(memberSymbol.Name, nameof(Dictionary<object, object>.Keys)) == 0)
                {
                    methodSymbol = (MethodSymbol)dictionarySymbol.GetMember("GetKeys");
                    Debug.Assert(methodSymbol != null);
                }
                else if (string.CompareOrdinal(memberSymbol.Name, nameof(Dictionary<object, object>.Values)) == 0)
                {
                    methodSymbol = (MethodSymbol)dictionarySymbol.GetMember("GetValues");
                    Debug.Assert(methodSymbol != null);
                }

                if (methodSymbol != null)
                {
                    MethodExpression methodExpression =
                        new MethodExpression(
                            new TypeExpression(evaluatedDictionaryType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                            methodSymbol);
                    methodExpression.AddParameterValue(objectExpression);

                    return methodExpression;
                }
            }
            else if (memberSymbol.Type == SymbolType.Property)
            {
                if (memberSymbol.Parent == nullableType)
                {
                    if (string.CompareOrdinal(memberSymbol.Name, nameof(Nullable<int>.Value)) == 0)
                    {
                        // Nullable<T>.Value becomes Nullable<T>

                        TypeSymbol underlyingType = objectExpression.EvaluatedType.GenericArguments.First();
                        objectExpression.Reevaluate(underlyingType);

                        return objectExpression;
                    }

                    if (string.CompareOrdinal(memberSymbol.Name, nameof(Nullable<int>.HasValue)) == 0)
                    {
                        // Nullable<T>.Value becomes Script.IsValue(Nullable<T>)

                        TypeSymbol scriptType = symbolSet.ResolveIntrinsicType(IntrinsicType.Script);
                        MethodSymbol isValueMethod = (MethodSymbol)scriptType.GetMember("IsValue");

                        MethodExpression methodExpression
                            = new MethodExpression(
                                new TypeExpression(scriptType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                                isValueMethod);
                        methodExpression.AddParameterValue(objectExpression);

                        return methodExpression;
                    }
                }
                else if (memberSymbol.Parent == memberInfoType || memberSymbol.Parent == typeType)
                {
                    if (string.CompareOrdinal(memberSymbol.Name, nameof(MemberInfo.Name)) == 0)
                    {
                        // type.Name becomes ss.typeName(type)

                        TypeSymbol scriptType = symbolSet.ResolveIntrinsicType(IntrinsicType.Script);
                        MethodSymbol typeNameMethod = (MethodSymbol)scriptType.GetMember("GetTypeName");

                        MethodExpression methodExpression
                            = new MethodExpression(
                                new TypeExpression(memberSymbol.AssociatedType,
                                    SymbolFilter.Public | SymbolFilter.StaticMembers),
                                typeNameMethod);
                        methodExpression.AddParameterValue(objectExpression);

                        return methodExpression;
                    }
                }
                else if (memberSymbol.IsTransformed)
                {
                    // if the property getter is transformed, we wanna replace it with a proper static method call

                    MethodSymbol methodSymbol = new MethodSymbol(memberSymbol.Name, null, memberSymbol.AssociatedType);
                    methodSymbol.SetTransformName(memberSymbol.GeneratedName);
                    methodSymbol.SetVisibility(MemberVisibility.Public | MemberVisibility.Static);

                    MethodExpression methodExpression =
                            new MethodExpression(
                                new TypeExpression(null, SymbolFilter.Public | SymbolFilter.StaticMembers),
                                methodSymbol);

                    methodExpression.AddParameterValue(objectExpression);

                    return methodExpression;
                }
            }
            else if (memberSymbol.Type == SymbolType.Method)
            {
                if (memberSymbol.Parent == nullableType)
                {
                    // Nullable<T>.GetValueOrDefault() becomes Nullable<T> || 0|false

                    TypeSymbol underlyingType = objectExpression.EvaluatedType.GenericArguments.First();

                    object defaultValue = 0;

                    if (underlyingType == symbolSet.ResolveIntrinsicType(IntrinsicType.Boolean))
                    {
                        defaultValue = false;
                    }
                    else if (underlyingType == symbolSet.ResolveIntrinsicType(IntrinsicType.String))
                    {
                        defaultValue = string.Empty;
                    }

                    LiteralExpression literalExpression = new LiteralExpression(underlyingType, defaultValue);

                    BinaryExpression logicalOrExpression =
                        new BinaryExpression(Operator.LogicalOr, objectExpression, literalExpression);
                    logicalOrExpression.Reevaluate(underlyingType);
                    logicalOrExpression.AddParenthesisHint();

                    return logicalOrExpression;
                }
            }

            ScriptReference dependency = ((TypeSymbol)memberSymbol.Parent).Dependency;

            if (dependency != null)
            {
                symbolSet.AddDependency(dependency);
            }

            MemberExpression expression = new MemberExpression(objectExpression, memberSymbol);

            if (memberSymbol.Type == SymbolType.Method
                && memberSymbol.AssociatedType.IsGeneric
                && memberSymbol.AssociatedType.GenericArguments == null
                && node.RightChild.NodeType == ParseNodeType.GenericName)
            {
                Debug.Assert(((GenericNameNode)node.RightChild).TypeArguments != null);

                List<TypeSymbol> typeArgs = new List<TypeSymbol>();
                foreach (ParseNode typeArgNode in ((GenericNameNode)node.RightChild).TypeArguments)
                    typeArgs.Add(symbolSet.ResolveType(typeArgNode, symbolTable, symbolContext));

                TypeSymbol returnType = symbolSet.CreateGenericTypeSymbol(memberSymbol.AssociatedType, typeArgs);

                if (returnType != null)
                {
                    MethodSymbol genericMethod = (MethodSymbol)memberSymbol;
                    MethodSymbol instanceMethod =
                        new MethodSymbol(genericMethod.Name, (TypeSymbol)genericMethod.Parent, returnType);

                    if (genericMethod.IsTransformed)
                    {
                        instanceMethod.SetTransformedName(genericMethod.GeneratedName);
                    }

                    instanceMethod.SetNameCasing(genericMethod.IsCasePreserved);

                    expression = new MemberExpression(objectExpression, instanceMethod);
                }
            }

            return expression;
        }

        private Expression CreateExtensionMethodInvocationExpression(BinaryExpressionNode node, TypeSymbol typeToExtend)
        {
            string memberName = ((NameNode)node.RightChild).Name;
            MethodSymbol methodSymbol = symbolSet.ResolveExtensionMethodSymbol(typeToExtend.FullName, memberName);

            if (methodSymbol == null)
            {
                return null;
            }

            MethodExpression methodExpression = new MethodExpression(
                        new TypeExpression((TypeSymbol)methodSymbol.Parent, SymbolFilter.Public | SymbolFilter.StaticMembers),
                        methodSymbol);
            Expression accessorExpression = BuildExpression(node.LeftChild);
            methodExpression.AddParameterValue(accessorExpression);
            methodExpression.IsExtensionMethod = true;

            return methodExpression;
        }

        private Expression ProcessIntrinsicType(IntrinsicTypeNode node)
        {
            TypeSymbol typeSymbol = symbolSet.ResolveType(node, symbolTable, symbolContext);
            Debug.Assert(typeSymbol != null);

            return TransformTypeSymbol(typeSymbol);
        }

        private Expression ProcessLiteralNode(LiteralNode node)
        {
            LiteralToken token = (LiteralToken)node.Token;

            string systemTypeName = ResolveLiteralTypeName(token);
            if (string.IsNullOrEmpty(systemTypeName))
            {
                Debug.Fail("Unknown Literal Token Type: " + token.LiteralType);
            }

            if (systemTypeName != null)
            {
                TypeSymbol typeSymbol =
                    (TypeSymbol)((ISymbolTable)symbolSet.SystemNamespace).FindSymbol(systemTypeName, null,
                        SymbolFilter.Types);
                Debug.Assert(typeSymbol != null);

                return new LiteralExpression(typeSymbol, token.LiteralValue);
            }

            return null;
        }

        private static string ResolveLiteralTypeName(LiteralToken token)
        {
            if (token == null)
            {
                return null;
            }

            switch (token.LiteralType)
            {
                case LiteralTokenType.Null:
                    return nameof(Object);
                case LiteralTokenType.Boolean:
                    return nameof(Boolean);
                case LiteralTokenType.Char:
                    return nameof(Char);
                case LiteralTokenType.String:
                    return nameof(String);
                case LiteralTokenType.Int:
                    return nameof(Int32);
                case LiteralTokenType.UInt:
                    return nameof(UInt32);
                case LiteralTokenType.Long:
                    return nameof(Int64);
                case LiteralTokenType.ULong:
                    return nameof(UInt64);
                case LiteralTokenType.Float:
                    return nameof(Single);
                case LiteralTokenType.Double:
                    return nameof(Double);
                case LiteralTokenType.Decimal:
                    return nameof(Decimal);
                default:
                    return null;
            }
        }

        private Expression ProcessNameNode(NameNode node)
        {
            return ProcessNameNode(node, SymbolFilter.All);
        }

        private Expression ProcessNameNode(NameNode node, SymbolFilter filter)
        {
            Symbol symbol = ResolveNameNodeSymbol(node, filter);
            Debug.Assert(symbol != null);

            if (symbol == null)
            {
                throw new ExpressionBuildException($"Null Symbol for node: {node.Token.Location}");
            }

            if (symbol is LocalSymbol localSymbol)
            {
                if (classContext == localSymbol.ValueType)
                {
                    SymbolFilter memberMask = SymbolFilter.Public | SymbolFilter.Protected | SymbolFilter.Private |
                                              SymbolFilter.InstanceMembers;

                    return new LocalExpression(localSymbol, memberMask);
                }

                return new LocalExpression(localSymbol);
            }

            if (symbol is MemberSymbol memberSymbol)
            {
                // TODO: Does C# allow access to private/protected members if the type of the member is
                //       the same as the class context?

                if ((memberSymbol.Visibility & MemberVisibility.Static) != 0)
                {
                    return new MemberExpression(new TypeExpression((TypeSymbol)memberSymbol.Parent,
                            SymbolFilter.Public | SymbolFilter.StaticMembers),
                        memberSymbol);
                }

                return new MemberExpression(new ThisExpression(classContext, /* explicitReference */ false),
                    memberSymbol);
            }

            if (symbol is TypeSymbol typeSymbol)
            {
                return TransformTypeSymbol(typeSymbol);
            }

            return null;
        }

        private Symbol ResolveNameNodeSymbol(NameNode node, SymbolFilter filter)
        {
            if (node is GenericNameNode genericNameNode)
            {
                return symbolTable.FindSymbol(genericNameNode.FullGenericName, symbolContext, filter)
                    ?? symbolTable.FindSymbol(node.Name, symbolContext, filter);
            }

            return symbolTable.FindSymbol(node.Name, symbolContext, filter);
        }

        private Expression ProcessNewNode(NewNode node)
        {
            TypeSymbol type = symbolSet.ResolveType(node.TypeReference, symbolTable, symbolContext);
            Debug.Assert(type != null);

            if (type.Type == SymbolType.Delegate)
            {
                // If its an instantiation of a delegate, return the argument itself
                // which is already a delegate expression.
                // The delegate type itself does not have a runtime representation that
                // is instantiated.

                Debug.Assert(node.Arguments is ExpressionListNode);
                Debug.Assert(((ExpressionListNode)node.Arguments).Expressions.Count == 1);

                Expression subExpression = BuildExpression(((ExpressionListNode)node.Arguments).Expressions[0]);

                // We need parenthesis if we are declaring an inline function, ie
                // Callback c = new Callback(delegate {}); --> var c = (function () {});
                // But not for:
                // Callback c = new Callback(this.callback); --> var c = this._callback;
                bool needsParenthesis = subExpression.Type == ExpressionType.Delegate;

                if (subExpression is MemberExpression)
                {
                    subExpression = TransformMemberExpression((MemberExpression)subExpression);
                }

                NewDelegateExpression expr = new NewDelegateExpression(subExpression, type);

                if (needsParenthesis)
                {
                    expr.AddParenthesisHint();
                }

                return expr;
            }

            NewExpression newExpression = new NewExpression(type);

            if (node.Arguments != null)
            {
                Debug.Assert(node.Arguments is ExpressionListNode);
                List<Expression> args = BuildExpressionList((ExpressionListNode)node.Arguments);

                if (type == symbolSet.ResolveIntrinsicType(IntrinsicType.Function) &&
                    args.Count > 1)
                {
                    // The function ctor in javascript takes parameters in
                    // reverse order, with the params array effectively at
                    // the start of the param list... in c# we must keep the params
                    // list at the end, so skip the first parameter, add the rest,
                    // and then add back the first parameter (the body of the
                    // function). Uggh!

                    Expression functionBodyParam = null;

                    foreach (Expression paramExpr in args)
                    {
                        if (functionBodyParam == null)
                        {
                            functionBodyParam = paramExpr;

                            continue;
                        }

                        newExpression.AddParameterValue(paramExpr);
                    }

                    newExpression.AddParameterValue(functionBodyParam);
                }
                else if (type.GenericType == symbolSet.ResolveIntrinsicType(IntrinsicType.Nullable))
                {
                    // Creating a new Nullable<T> ... if there is a value specified as a ctor param,
                    // just use the value; otherwise use undefined.
                    if (args.Count == 1)
                    {
                        return args[0];
                    }

                    return new InlineScriptExpression("undefined", type);
                }
                else
                {
                    foreach (Expression paramExpr in args) newExpression.AddParameterValue(paramExpr);
                }
            }

            if (type.Dependency != null)
            {
                symbolSet.AddDependency(type.Dependency);
            }

            return newExpression;
        }

        private Expression ProcessOpenBracketsExpressionNode(BinaryExpressionNode node)
        {
            Expression leftExpression = BuildExpression(node.LeftChild);

            if (leftExpression is MemberExpression)
            {
                leftExpression = TransformMemberExpression((MemberExpression)leftExpression);
            }

            Debug.Assert(leftExpression.EvaluatedType.Type == SymbolType.Class ||
                         leftExpression.EvaluatedType.Type == SymbolType.Record ||
                         leftExpression.EvaluatedType.Type == SymbolType.Interface);

            IndexerSymbol indexer = null;

            if (leftExpression.EvaluatedType.Type != SymbolType.Interface)
            {
                indexer = ((ClassSymbol)leftExpression.EvaluatedType).GetIndexer();
            }
            else
            {
                indexer = GetInterfaceIndexer((InterfaceSymbol)leftExpression.EvaluatedType);
            }

            Debug.Assert(indexer != null);
            Debug.Assert(indexer.MatchFilter(leftExpression.MemberMask));

            IndexerExpression indexerExpression = new IndexerExpression(leftExpression, indexer);

            Debug.Assert(node.RightChild is ExpressionListNode);
            ICollection<Expression> args = BuildExpressionList((ExpressionListNode)node.RightChild);

            foreach (Expression paramExpr in args) indexerExpression.AddIndexParameterValue(paramExpr);

            return indexerExpression;
        }

        private static IndexerSymbol GetInterfaceIndexer(InterfaceSymbol interfaceSymbol)
        {
            if (interfaceSymbol == null)
            {
                return null;
            }

            return interfaceSymbol.Indexer ?? GetInheritedInterfaceIndexer(interfaceSymbol);
        }

        private static IndexerSymbol GetInheritedInterfaceIndexer(InterfaceSymbol interfaceSymbol)
        {
            foreach (InterfaceSymbol inheritedInterface in interfaceSymbol.Interfaces)
            {
                IndexerSymbol indexer = inheritedInterface.Indexer != null
                    ? inheritedInterface.Indexer
                    : GetInheritedInterfaceIndexer(inheritedInterface);

                if (indexer != null)
                {
                    return indexer;
                }
            }

            return null;
        }

        private Expression ProcessOpenParenExpressionNode(BinaryExpressionNode node)
        {
            bool isDelegateInvoke = false;
            Expression leftExpression = BuildExpression(node.LeftChild);

            if (leftExpression is LocalExpression || leftExpression is NewDelegateExpression)
            {
                Debug.Assert(leftExpression.EvaluatedType.Type == SymbolType.Delegate);

                // Handle the implicit delegate invoke scenario by turning the expression
                // into an explicit call into the delegate's Invoke method

                MemberSymbol invokeMethodSymbol = leftExpression.EvaluatedType.GetMember("Invoke");
                Debug.Assert(invokeMethodSymbol != null);

                leftExpression = new MemberExpression(leftExpression, invokeMethodSymbol);
                isDelegateInvoke = true;
            }

            if (leftExpression is MethodExpression methodExpression && methodExpression.IsExtensionMethod)
            {
                var parameters = node.RightChild as ExpressionListNode;
                Debug.Assert(parameters != null);
                foreach (var parameterNode in parameters.Expressions)
                {
                    var parameterExpression = BuildExpression(parameterNode);
                    methodExpression.AddParameterValue(parameterExpression);
                }

                return methodExpression;
            }

            if (leftExpression.Type != ExpressionType.Member)
            {

                // A method call was evaluated into a non-member expression as part of building
                // the left node. For example, Nullable<T>.GetValueOrDefault() becomes a logical or expression.
                return leftExpression;
            }

            MemberExpression memberExpression = (MemberExpression)leftExpression;

            ExpressionListNode argNodes = null;
            List<Expression> args = null;

            if (node.RightChild != null)
            {
                Debug.Assert(node.RightChild is ExpressionListNode);

                argNodes = (ExpressionListNode)node.RightChild;
                args = BuildExpressionList(argNodes);
            }

            // REVIEW: Uggh... this has become too complex over time with all the transformations
            //         added over time. Refactoring needed...

            TypeSymbol objectType = symbolSet.ResolveIntrinsicType(IntrinsicType.Object);
            TypeSymbol typeType = symbolSet.ResolveIntrinsicType(IntrinsicType.Type);
            TypeSymbol[] dictionaryTypes = symbolSet.ResolveIntrinsicTypes(IntrinsicType.GenericDictionary, IntrinsicType.IDictionary, IntrinsicType.GenericIDictionary);
            TypeSymbol intType = symbolSet.ResolveIntrinsicType(IntrinsicType.Integer);
            TypeSymbol stringType = symbolSet.ResolveIntrinsicType(IntrinsicType.String);
            TypeSymbol scriptType = symbolSet.ResolveIntrinsicType(IntrinsicType.Script);
            TypeSymbol argsType = symbolSet.ResolveIntrinsicType(IntrinsicType.Arguments);
            TypeSymbol voidType = symbolSet.ResolveIntrinsicType(IntrinsicType.Void);

            if (memberExpression.Member.Type != SymbolType.Method)
            {
                // A non-method member is being used in a method call; the member must be
                // a delegate...
                Debug.Assert(memberExpression.EvaluatedType.Type == SymbolType.Delegate);
                Expression instanceExpression = TransformMemberExpression(memberExpression);

                MethodSymbol invokeMethod =
                    (MethodSymbol)memberExpression.EvaluatedType.GetMember("Invoke");
                Debug.Assert(invokeMethod != null);

                methodExpression = new MethodExpression(instanceExpression, invokeMethod);
                isDelegateInvoke = true;
            }
            else
            {
                // The member being accessed is a method...

                MethodSymbol method = (MethodSymbol)memberExpression.Member;

                if (!method.MatchesConditions(options.Defines))
                {
                    return null;
                }

                if (method.Name.Equals("GetEnumerator", StringComparison.Ordinal))
                {
                    // This is a bit dangerous - GetEnumerator on any type gets mapped to
                    // Script.Enumerate. This actually somewhat matches c# semantics, where you
                    // can perform a foreach on any type that has a GetEnumerator method, rather
                    // than only types that implement IEnumerable.

                    MethodSymbol enumerateMethod = (MethodSymbol)scriptType.GetMember("Enumerate");
                    Debug.Assert(enumerateMethod != null);

                    methodExpression = new MethodExpression(
                        new TypeExpression(scriptType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                        enumerateMethod);
                    methodExpression.AddParameterValue(memberExpression.ObjectReference);
                    methodExpression.Reevaluate(memberExpression.EvaluatedType);

                    return methodExpression;
                }

                if (method.Parent == objectType &&
                    (method.Name.Equals("ToString", StringComparison.Ordinal) ||
                     method.Name.Equals("ToLocaleString", StringComparison.Ordinal)))
                {
                    if (memberExpression.ObjectReference.EvaluatedType == stringType)
                    {
                        // No-op ToString calls on strings (this happens when performing a ToString
                        // on a named enum value.
                        return memberExpression.ObjectReference;
                    }

                    if (memberExpression.ObjectReference.EvaluatedType.Type == SymbolType.Enumeration)
                    {
                        EnumerationSymbol enumSymbol =
                            (EnumerationSymbol)memberExpression.ObjectReference.EvaluatedType;

                        if (enumSymbol.UseNamedValues)
                        {
                            // If the enum value is a named enum, then it is already a string.
                            return memberExpression.ObjectReference;
                        }

                        return new MethodExpression(memberExpression.ObjectReference, method);
                    }
                }
                else if (dictionaryTypes.Contains(method.Parent))
                {
                    if (method.Name.Equals(nameof(Dictionary<object, object>.Remove), StringComparison.Ordinal))
                    {
                        // Switch the instance Remove method on Dictionary to
                        // calls to the delete operator.
                        Debug.Assert(args.Count == 1);

                        return new LateBoundExpression(memberExpression.ObjectReference,
                            args[0], LateBoundOperation.DeleteField,
                            objectType);
                    }
                }
                else if (method.Parent == scriptType)
                {
                    if (method.Name.Equals("Literal", StringComparison.Ordinal))
                    {
                        // Convert a call to Script.Literal into a literal expression

                        Debug.Assert(args.Count >= 1);
                        string script = null;

                        if (args[0].Type == ExpressionType.Field)
                        {
                            Debug.Assert(args[0].EvaluatedType == stringType);

                            FieldSymbol field = ((FieldExpression)args[0]).Field;

                            if (field.IsConstant)
                            {
                                Debug.Assert(field.Value is string);
                                script = (string)field.Value;
                            }
                        }
                        else if (args[0].Type == ExpressionType.Literal)
                        {
                            Debug.Assert(((LiteralExpression)args[0]).Value is string);
                            script = (string)((LiteralExpression)args[0]).Value;
                        }

                        if (script == null)
                        {
                            // TODO: When we start raising errors at the expression level instead of the statement
                            //       level, we should return an ErrorExpression instead of a dummy expression.
                            ParseNode expressionNode = argNodes.Expressions[0];

                            errorHandler.ReportExpressionError(DSharpStringResources.SCRIPT_LITERAL_CONSTANT_ERROR, expressionNode);

                            return new InlineScriptExpression("", objectType);
                        }

                        if (args.Count > 1)
                        {
                            // Check whether the script is a valid string format string
                            try
                            {
                                object[] argValues = new object[args.Count - 1];
                                string.Format(CultureInfo.InvariantCulture, script, argValues);
                            }
                            catch
                            {
                                errorHandler.ReportExpressionError(DSharpStringResources.SCRIPT_LITERAL_FORMAT_ERROR, argNodes.Expressions[0]);

                                return new InlineScriptExpression("", objectType);
                            }
                        }

                        InlineScriptExpression scriptExpression = new InlineScriptExpression(script, objectType);
                        for (int i = 1; i < args.Count; i++) scriptExpression.AddParameterValue(args[i]);

                        return scriptExpression;
                    }

                    if (method.Name.Equals("Boolean", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count == 1);

                        args[0].AddParenthesisHint();

                        return new UnaryExpression(Operator.LogicalNot,
                            new UnaryExpression(Operator.LogicalNot, args[0]));
                    }

                    if (method.Name.Equals("IsTruthy", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count == 1);

                        args[0].AddParenthesisHint();

                        return new UnaryExpression(Operator.LogicalNot,
                            new UnaryExpression(Operator.LogicalNot, args[0]));
                    }

                    if (method.Name.Equals("IsFalsey", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count == 1);

                        args[0].AddParenthesisHint();

                        return new UnaryExpression(Operator.LogicalNot, args[0]);
                    }

                    if (method.Name.Equals("Or", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count >= 2);

                        Expression expr = args[0];
                        for (int i = 1; i < args.Count; i++)
                            expr = new BinaryExpression(Operator.LogicalOr, expr, args[i]);

                        expr.Reevaluate(args[0].EvaluatedType);
                        expr.AddParenthesisHint();

                        return expr;
                    }

                    if (method.Name.Equals("IsNull", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count == 1);

                        Expression expr = new BinaryExpression(Operator.EqualEqualEqual, args[0],
                            new LiteralExpression(objectType, null));
                        expr.AddParenthesisHint();

                        return expr;
                    }

                    if (method.Name.Equals("IsUndefined", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count == 1);

                        MemberSymbol undefinedMember = scriptType.GetMember("Undefined");
                        Debug.Assert(undefinedMember != null);

                        MemberExpression undefinedExpression =
                            new MemberExpression(
                                new TypeExpression(scriptType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                                undefinedMember);

                        Expression expr = new BinaryExpression(Operator.EqualEqualEqual, args[0],
                            TransformMemberExpression(undefinedExpression));
                        expr.AddParenthesisHint();

                        return expr;
                    }

                    if (method.Name.Equals("IsNullOrUndefined", StringComparison.Ordinal))
                    {
                        Debug.Assert(args.Count == 1);

                        MethodSymbol isValueMethod = (MethodSymbol)scriptType.GetMember("IsValue");
                        Debug.Assert(isValueMethod != null);

                        methodExpression = new MethodExpression(
                            new TypeExpression(scriptType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                            isValueMethod);
                        methodExpression.AddParameterValue(args[0]);

                        return new UnaryExpression(Operator.LogicalNot, methodExpression);
                    }

                    bool lateBound = false;
                    LateBoundOperation lateBoundOperation = LateBoundOperation.InvokeMethod;

                    if (method.Name.Equals("InvokeMethod", StringComparison.Ordinal))
                    {
                        lateBound = true;
                    }
                    else if (method.Name.Equals("DeleteField", StringComparison.Ordinal))
                    {
                        lateBound = true;
                        lateBoundOperation = LateBoundOperation.DeleteField;
                    }
                    else if (method.Name.Equals("GetField", StringComparison.Ordinal))
                    {
                        lateBound = true;
                        lateBoundOperation = LateBoundOperation.GetField;
                    }
                    else if (method.Name.Equals("SetField", StringComparison.Ordinal))
                    {
                        lateBound = true;
                        lateBoundOperation = LateBoundOperation.SetField;
                    }
                    else if (method.Name.Equals("GetScriptType", StringComparison.Ordinal))
                    {
                        lateBound = true;
                        lateBoundOperation = LateBoundOperation.GetScriptType;
                    }
                    else if (method.Name.Equals("HasField", StringComparison.Ordinal))
                    {
                        lateBound = true;
                        lateBoundOperation = LateBoundOperation.HasField;
                    }
                    else if (method.Name.Equals("HasMethod", StringComparison.Ordinal))
                    {
                        lateBound = true;
                        lateBoundOperation = LateBoundOperation.HasMethod;
                    }

                    if (lateBound)
                    {
                        // Switch explicit late-bound calls into implicit late-bound expressions
                        // in script
                        Debug.Assert(args != null &&
                                     (lateBoundOperation == LateBoundOperation.GetScriptType && args.Count == 1 ||
                                      args.Count >= 2));

                        LateBoundExpression lateBoundExpression = null;
                        Expression instanceExpression = null;
                        Expression nameExpression = null;

                        foreach (Expression paramExpr in args)
                        {
                            if (instanceExpression == null)
                            {
                                instanceExpression = paramExpr;

                                if (lateBoundOperation == LateBoundOperation.GetScriptType)
                                {
                                    // GetScriptType only takes an instance
                                    return new LateBoundExpression(instanceExpression, null,
                                        lateBoundOperation, objectType);
                                }

                                continue;
                            }

                            if (nameExpression == null)
                            {
                                nameExpression = paramExpr;

                                Expression objectExpression = instanceExpression;

                                if (lateBoundOperation == LateBoundOperation.InvokeMethod)
                                {
                                    if (instanceExpression.Type == ExpressionType.Literal &&
                                        ((LiteralExpression)instanceExpression).Value == null)
                                    {
                                        objectExpression = null;

                                        LiteralExpression literalExpression = nameExpression as LiteralExpression;

                                        if (literalExpression == null)
                                        {
                                            errorHandler.ReportExpressionError(DSharpStringResources.SCRIPT_LATE_BOUND_INVALID_METHOD_NAME, argNodes.Expressions[0]);
                                        }
                                        else if (!Utility.IsValidIdentifier((string)literalExpression.Value))
                                        {
                                            errorHandler.ReportExpressionError(DSharpStringResources.SCRIPT_LATE_BOUND_INVALID_METHOD_IDENTIFIER, argNodes.Expressions[0]);
                                        }
                                    }
                                }

                                lateBoundExpression = new LateBoundExpression(objectExpression, nameExpression,
                                    lateBoundOperation, objectType);

                                continue;
                            }

                            lateBoundExpression.AddParameterValue(paramExpr);
                        }

                        Debug.Assert(lateBoundExpression != null);

                        return lateBoundExpression;
                    }
                }
                else if (method.Parent == argsType)
                {
                    if (method.Name.Equals("GetArgument", StringComparison.Ordinal))
                    {
                        // Switch Arguments.GetArgument into Arguments[]
                        Debug.Assert(args.Count == 1);

                        IndexerExpression indexExpression =
                            new IndexerExpression(new LiteralExpression(typeType, method.Parent),
                                ((ClassSymbol)method.Parent).GetIndexer());
                        indexExpression.AddIndexParameterValue(args[0]);

                        return indexExpression;
                    }

                    if (method.Name.Equals("ToArray", StringComparison.Ordinal))
                    {
                        // Switch Arguments.ToArray into Array.ToArray(arguments)

                        TypeSymbol arrayType = symbolSet.ResolveIntrinsicType(IntrinsicType.Array);
                        MethodSymbol toArrayMethod = (MethodSymbol)arrayType.GetMember("ToArray");

                        InlineScriptExpression argsExpression =
                            new InlineScriptExpression("arguments", objectType, /* parenthesize */ false);
                        MethodExpression toArrayExpression =
                            new MethodExpression(
                                new TypeExpression(arrayType, SymbolFilter.Public | SymbolFilter.StaticMembers),
                                toArrayMethod);
                        toArrayExpression.AddParameterValue(argsExpression);

                        return toArrayExpression;
                    }
                }

                methodExpression = new MethodExpression(memberExpression.ObjectReference, method);

                // iterate over the parameters. If the parameter is generic, then get args[i].EvaluatedType
                // add it as SetGenericType and the SymbolTable
                // (method symbol signature might need to be decorated)
            }

            if (methodExpression != null)
            {
                if (methodExpression.Method.HasSelector)
                {
                    LiteralExpression selectorExpression =
                        new LiteralExpression(stringType, methodExpression.Method.Selector);
                    methodExpression.AddParameterValue(selectorExpression);
                }

                if (args != null)
                {
                    foreach (Expression paramExpr in args)
                    {
                        methodExpression.AddParameterValue(paramExpr);
                    }
                }

                if (isDelegateInvoke)
                {
                    return new DelegateInvokeExpression(methodExpression);
                }
            }

            return methodExpression;
        }

        private Expression ProcessThisNode(ThisNode node)
        {
            return new ThisExpression(classContext, /* explicitReference */ true);
        }

        private Expression ProcessTypeofNode(TypeofNode node)
        {
            TypeSymbol referencedType = symbolSet.ResolveType(node.TypeReference, symbolTable, symbolContext);
            Debug.Assert(referencedType != null);

            if (referencedType.Dependency != null)
            {
                symbolSet.AddDependency(referencedType.Dependency);
            }

            TypeSymbol typeSymbol = symbolSet.ResolveIntrinsicType(IntrinsicType.Type);
            Debug.Assert(typeSymbol != null);

            return new LiteralExpression(typeSymbol, referencedType);
        }

        private Expression ProcessUnaryExpressionNode(UnaryExpressionNode node)
        {
            Operator operatorType = Operator.Invalid;

            switch (node.Operator)
            {
                case TokenType.PlusPlus:
                    operatorType = Operator.PostIncrement;

                    break;
                case TokenType.MinusMinus:
                    operatorType = Operator.PostDecrement;

                    break;
                case TokenType.Tilde:
                case TokenType.Bang:
                    operatorType = OperatorConverter.OperatorFromToken(node.Operator);

                    break;
                case TokenType.Minus:
                    operatorType = Operator.Negative;

                    break;
                case TokenType.Plus:
                    operatorType = Operator.Plus;

                    break;
                default:
                    Debug.Fail("Unhandled unary expression with operator " + node.Operator);

                    break;
            }

            if (operatorType != Operator.Invalid)
            {
                Expression childExpression = BuildExpression(node.Child);

                if (childExpression is MemberExpression)
                {
                    childExpression = TransformMemberExpression((MemberExpression)childExpression);
                }

                if (operatorType == Operator.Plus)
                {
                    return childExpression;
                }

                return new UnaryExpression(operatorType, childExpression);
            }

            return null;
        }

        private Expression TransformTypeSymbol(TypeSymbol symbol)
        {
            SymbolFilter memberMask = SymbolFilter.Public | SymbolFilter.StaticMembers;

            if (symbol.Type != SymbolType.Enumeration)
            {
                bool isSameType = classContext == symbol;

                if (isSameType)
                {
                    memberMask |= SymbolFilter.Protected | SymbolFilter.Private;
                }
                else
                {
                    bool isDerived = false;

                    ClassSymbol baseSymbol = classContext.BaseClass;

                    if (baseSymbol != null)
                    {
                        while (!isDerived && baseSymbol != null)
                        {
                            isDerived = baseSymbol == symbol;
                            baseSymbol = baseSymbol.BaseClass;
                        }
                    }

                    if (isDerived)
                    {
                        memberMask |= SymbolFilter.Protected;
                    }
                }
            }

            return new TypeExpression(symbol, memberMask);
        }

        public Expression TransformGetPropertyExpression(Expression expression)
        {
            PropertyExpression property = expression as PropertyExpression;

            if (property != null &&
                property.Type == ExpressionType.PropertyGet)
            {
                return new PropertyExpression(property.ObjectReference, property.Property, false);
            }

            return expression;
        }

        public Expression TransformMemberExpression(MemberExpression expression)
        {
            return TransformMemberExpression(expression, /* getOrAdd */ true, /* isEventAddOrRemove */ false);
        }

        public Expression TransformMemberExpression(MemberExpression expression, bool getOrAdd)
        {
            return TransformMemberExpression(expression, getOrAdd, /* isEventAddOrRemove */ false);
        }

        public Expression TransformMemberExpression(MemberExpression expression, bool getOrAdd, bool isEventAddRemove)
        {
            switch (expression.Member.Type)
            {
                case SymbolType.EnumerationField:

                    if (((EnumerationSymbol)expression.Member.Parent).UseNamedValues)
                    {
                        EnumerationFieldSymbol field = (EnumerationFieldSymbol)expression.Member;
                        string fieldName = ((EnumerationSymbol)expression.Member.Parent).CreateNamedValue(field);

                        return new LiteralExpression(symbolSet.ResolveIntrinsicType(IntrinsicType.String),
                            fieldName);
                    }
                    else if (((TypeSymbol)expression.Member.Parent).IsApplicationType ||
                             ((EnumerationSymbol)expression.Member.Parent).UseNumericValues)
                    {
                        // For enum types defined within the same assembly, simply use the literal value.
                        // Same goes for any enums marked as numeric values
                        return new LiteralExpression(symbolSet.ResolveIntrinsicType(IntrinsicType.Integer),
                            ((EnumerationFieldSymbol)expression.Member).Value);
                    }
                    else
                    {
                        // For enum types imported for another assembly
                        return new EnumerationFieldExpression(expression.ObjectReference,
                            (EnumerationFieldSymbol)expression.Member);
                    }
                case SymbolType.Field:

                    if (((FieldSymbol)expression.Member).IsConstant)
                    {
                        return new LiteralExpression(expression.Member.AssociatedType,
                            ((FieldSymbol)expression.Member).Value);
                    }

                    if (expression.ObjectReference is BaseExpression)
                    {
                        // Create a this expression, because "this" works just as well as base.
                        // It is explicit, because the base was explicit.
                        return new FieldExpression(new ThisExpression(classContext, /* explicitReference */ true),
                            (FieldSymbol)expression.Member);
                    }

                    if ((expression.Member.Visibility & MemberVisibility.Static) != 0 &&
                        expression.Member.Parent != expression.ObjectReference.EvaluatedType)
                    {
                        // Create a new type expression because a static member
                        // of the base type is being used.
                        return new FieldExpression(
                            new TypeExpression((ClassSymbol)expression.Member.Parent, expression.MemberMask),
                            (FieldSymbol)expression.Member);
                    }

                    if (symbolContext.Parent.Type == SymbolType.Record &&
                        expression.ObjectReference.Type == ExpressionType.This)
                    {
                        // Change "this" references inside struct ctor code to "$o"
                        VariableSymbol objectVariable = new VariableSymbol("$o", memberContext, classContext);

                        return new FieldExpression(new LocalExpression(objectVariable),
                            (FieldSymbol)expression.Member);
                    }

                    if ((expression.Member.Visibility & MemberVisibility.Static) != 0 &&
                        expression.Member.Parent == symbolSet.ResolveIntrinsicType(IntrinsicType.String) &&
                        string.CompareOrdinal(expression.Member.Name, "Empty") == 0)
                    {
                        // Convert String.Empty to literal expression
                        return new LiteralExpression(expression.Member.AssociatedType, string.Empty);
                    }

                    return new FieldExpression(expression.ObjectReference,
                        (FieldSymbol)expression.Member);
                case SymbolType.Property:

                    return new PropertyExpression(expression.ObjectReference,
                        (PropertySymbol)expression.Member, getOrAdd);
                case SymbolType.Method:
                    Debug.Assert(getOrAdd);

                    return new DelegateExpression(expression.ObjectReference,
                        (MethodSymbol)expression.Member);
                case SymbolType.Event:

                    if (isEventAddRemove)
                    {
                        return new EventExpression(expression.ObjectReference,
                            (EventSymbol)expression.Member, getOrAdd);
                    }
                    else
                    {
                        Debug.Assert(((EventSymbol)expression.Member).DefaultImplementation);

                        // When the field corresponding to an event whose accessors are auto-generated is
                        // referenced, we need to hunt for a special generated field name (this is the
                        // field that is added to the class).

                        string fieldName = "__" + Utility.CreateCamelCaseName(expression.Member.Name);
                        FieldSymbol fieldSymbol =
                            (FieldSymbol)expression.ObjectReference.EvaluatedType.GetMember(fieldName);
                        Debug.Assert(fieldSymbol != null);

                        if (expression.ObjectReference is BaseExpression)
                        {
                            // Create a this expression, because "this" works just as well as base.
                            // It is explicit, because the base was explicit.
                            return new FieldExpression(new ThisExpression(classContext, /* explicitReference */ true),
                                fieldSymbol);
                        }

                        return new FieldExpression(expression.ObjectReference, fieldSymbol);
                    }
                default:
                    Debug.Fail("Unexpected member type to transform: " + expression.Member.Type);

                    break;
            }

            return expression;
        }
    }
}
