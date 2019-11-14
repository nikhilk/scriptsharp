// StatementBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.Errors;
using DSharp.Compiler.ScriptModel.Expressions;
using DSharp.Compiler.ScriptModel.Statements;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Compiler
{
    internal sealed class StatementBuilder
    {
        private readonly IErrorHandler errorHandler;

        private readonly ExpressionBuilder expressionBuilder;
        private readonly CodeMemberSymbol memberContext;
        private readonly SymbolSet symbolSet;

        private readonly ILocalSymbolTable symbolTable;

        public StatementBuilder(ILocalSymbolTable symbolTable, CodeMemberSymbol memberContext,
                                IErrorHandler errorHandler, CompilerOptions options)
        {
            this.symbolTable = symbolTable;
            this.memberContext = memberContext;
            symbolSet = memberContext.SymbolSet;
            this.errorHandler = errorHandler;

            expressionBuilder = new ExpressionBuilder(symbolTable, memberContext, errorHandler, options);
        }

        public Statement BuildStatement(StatementNode statementNode)
        {
            Statement statement = null;

            try
            {
                statement = BuildStatementCore(statementNode);
            }
            catch(ExpressionBuildException expressionBuildException)
            {
                string message = expressionBuildException.Message + Environment.NewLine + expressionBuildException.StackTrace;
                errorHandler.ReportExpressionError(message, expressionBuildException.Node);
            }
            catch (Exception e) 
            {
                errorHandler.ReportGeneralError(e);
            }

            return statement;
        }

        private Statement BuildStatementCore(StatementNode statementNode)
        {
            Statement statement = null;

            switch (statementNode.NodeType)
            {
                case ParseNodeType.Block:
                    statement = ProcessBlockStatement((BlockStatementNode) statementNode);

                    break;
                case ParseNodeType.EmptyStatement:
                    statement = new EmptyStatement();

                    break;
                case ParseNodeType.VariableDeclaration:
                case ParseNodeType.ConstDeclaration:
                    statement = ProcessVariableDeclarationStatement((VariableDeclarationNode) statementNode);

                    break;
                case ParseNodeType.Return:
                    statement = ProcessReturnStatement((ReturnNode) statementNode);

                    break;
                case ParseNodeType.ExpressionStatement:
                    statement = ProcessExpressionStatement((ExpressionStatementNode) statementNode);

                    break;
                case ParseNodeType.IfElse:
                    statement = ProcessIfElseStatement((IfElseNode) statementNode);

                    break;
                case ParseNodeType.While:
                    statement = ProcessWhileStatement((WhileNode) statementNode);

                    break;
                case ParseNodeType.DoWhile:
                    statement = ProcessDoWhileStatement((DoWhileNode) statementNode);

                    break;
                case ParseNodeType.For:
                    statement = ProcessForStatement((ForNode) statementNode);

                    break;
                case ParseNodeType.Foreach:
                    statement = ProcessForeachStatement((ForeachNode) statementNode);

                    break;
                case ParseNodeType.Switch:
                    statement = ProcessSwitchStatement((SwitchNode) statementNode);

                    break;
                case ParseNodeType.Break:
                    statement = new BreakStatement();

                    break;
                case ParseNodeType.Continue:
                    statement = new ContinueStatement();

                    break;
                case ParseNodeType.Throw:
                    statement = ProcessThrowStatement((ThrowNode) statementNode);

                    break;
                case ParseNodeType.Try:
                    statement = ProcessTryCatchFinallyStatement((TryNode) statementNode);

                    break;
                case ParseNodeType.Using:
                    statement = ProcessUsingStatement((UsingNode) statementNode);

                    break;
            }

            return statement;
        }

        private Statement ProcessBlockStatement(BlockStatementNode node)
        {
            BlockStatement statement = new BlockStatement();

            symbolTable.PushScope();

            foreach (StatementNode childStatementNode in node.Statements)
            {
                Statement childStatement = BuildStatement(childStatementNode);

                if (childStatement != null)
                {
                    statement.AddStatement(childStatement);
                }
            }

            symbolTable.PopScope();

            return statement;
        }

        private Statement ProcessDoWhileStatement(DoWhileNode node)
        {
            Expression condition = expressionBuilder.BuildExpression(node.Condition);

            if (condition is MemberExpression)
            {
                condition = expressionBuilder.TransformMemberExpression((MemberExpression) condition);
            }

            Statement body = BuildStatement((StatementNode) node.Body);

            return new WhileStatement(condition, body, /* preCondition */ false);
        }

        private Statement ProcessExpressionStatement(ExpressionStatementNode node)
        {
            Expression expression = expressionBuilder.BuildExpression(node.Expression);

            if (expression == null)
            {
                // This happens when the expression is a method call, and the method
                // is debug conditional
                return null;
            }

            return new ExpressionStatement(expression);
        }

        private Statement ProcessForStatement(ForNode node)
        {
            ForStatement statement = new ForStatement();

            symbolTable.PushScope();

            if (node.Initializer != null)
            {
                if (node.Initializer is VariableDeclarationNode)
                {
                    VariableDeclarationStatement initializer =
                        (VariableDeclarationStatement) BuildStatement((StatementNode) node.Initializer);
                    statement.AddInitializer(initializer);
                }
                else
                {
                    Debug.Assert(node.Initializer is ExpressionListNode);

                    ICollection<Expression> initializers =
                        expressionBuilder.BuildExpressionList((ExpressionListNode) node.Initializer);
                    foreach (Expression initializer in initializers) statement.AddInitializer(initializer);
                }
            }

            if (node.Condition != null)
            {
                Expression condition = expressionBuilder.BuildExpression(node.Condition);

                if (condition is MemberExpression)
                {
                    condition = expressionBuilder.TransformMemberExpression((MemberExpression) condition);
                }

                statement.AddCondition(condition);
            }

            if (node.Increment != null)
            {
                Debug.Assert(node.Increment is ExpressionListNode);

                ICollection<Expression> increments =
                    expressionBuilder.BuildExpressionList((ExpressionListNode) node.Increment);
                foreach (Expression increment in increments) statement.AddIncrement(increment);
            }

            Statement body = BuildStatement((StatementNode) node.Body);
            statement.AddBody(body);

            symbolTable.PopScope();

            return statement;
        }

        private Statement ProcessForeachStatement(ForeachNode node)
        {
            TypeSymbol type = symbolSet.ResolveType(node.Type, symbolTable, memberContext);
            Debug.Assert(type != null);

            bool dictionaryContainer = type.Name == typeof(DictionaryEntry).Name || type.Name == typeof(KeyValuePair<,>).Name;

            Expression collectionExpression = expressionBuilder.BuildExpression(node.Container);

            if (collectionExpression is MemberExpression)
            {
                collectionExpression =
                    expressionBuilder.TransformMemberExpression((MemberExpression) collectionExpression);
            }

            ForInStatement statement;

            if (dictionaryContainer)
            {
                VariableSymbol dictionaryVariable = null;

                if (collectionExpression.Type != ExpressionType.Local)
                {
                    string dictionaryVariableName = symbolTable.CreateSymbolName("dict");
                    dictionaryVariable = new VariableSymbol(dictionaryVariableName, memberContext,
                        collectionExpression.EvaluatedType);
                }

                statement = new ForInStatement(collectionExpression, dictionaryVariable);

                string keyVariableName = symbolTable.CreateSymbolName("key");
                VariableSymbol keyVariable = new VariableSymbol(keyVariableName, memberContext,
                    symbolSet.ResolveIntrinsicType(IntrinsicType.String));
                statement.SetLoopVariable(keyVariable);
            }
            else
            {
                statement = new ForInStatement(collectionExpression);

                string enumeratorVariableName = symbolTable.CreateSymbolName("enum");
                VariableSymbol enumVariable = new VariableSymbol(enumeratorVariableName, memberContext,
                    symbolSet.ResolveIntrinsicType(IntrinsicType.Enumerator));
                statement.SetLoopVariable(enumVariable);
            }

            symbolTable.PushScope();

            VariableSymbol itemVariable = new VariableSymbol(node.Name.Name, memberContext, type);
            symbolTable.AddSymbol(itemVariable);
            statement.SetItemVariable(itemVariable);

            Statement body = BuildStatement((StatementNode) node.Body);
            statement.AddBody(body);

            symbolTable.PopScope();

            return statement;
        }

        private Statement ProcessIfElseStatement(IfElseNode node)
        {
            Expression condition = expressionBuilder.BuildExpression(node.Condition);

            if (condition is MemberExpression)
            {
                condition = expressionBuilder.TransformMemberExpression((MemberExpression) condition);
            }

            Statement ifStatement = BuildStatement((StatementNode) node.IfBlock);
            Statement elseStatement = null;

            if (node.ElseBlock != null)
            {
                elseStatement = BuildStatement((StatementNode) node.ElseBlock);
            }

            return new IfElseStatement(condition, ifStatement, elseStatement);
        }

        private Statement ProcessReturnStatement(ReturnNode node)
        {
            Expression returnValue = null;

            if (node.Value != null)
            {
                returnValue = expressionBuilder.BuildExpression(node.Value);

                if (returnValue is MemberExpression)
                {
                    returnValue = expressionBuilder.TransformMemberExpression((MemberExpression) returnValue);
                }
            }

            return new ReturnStatement(returnValue);
        }

        private Statement ProcessSwitchStatement(SwitchNode node)
        {
            Expression condition = expressionBuilder.BuildExpression(node.Condition);

            if (condition is MemberExpression)
            {
                condition = expressionBuilder.TransformMemberExpression((MemberExpression) condition);
            }

            SwitchStatement statement = new SwitchStatement(condition);

            foreach (SwitchSectionNode switchSectionNode in node.Cases)
            {
                SwitchGroup group = new SwitchGroup();

                foreach (StatementNode caseNode in switchSectionNode.Labels)
                    if (caseNode is CaseLabelNode)
                    {
                        CaseLabelNode labelNode = (CaseLabelNode) caseNode;
                        Expression labelValue = expressionBuilder.BuildExpression(labelNode.Value);

                        if (labelValue is MemberExpression)
                        {
                            labelValue = expressionBuilder.TransformMemberExpression((MemberExpression) labelValue);
                        }

                        group.AddCase(labelValue);
                    }
                    else
                    {
                        Debug.Assert(caseNode is DefaultLabelNode);
                        group.AddDefaultCase();
                    }

                foreach (StatementNode statementNode in switchSectionNode.Statements)
                {
                    Statement childStatement = BuildStatement(statementNode);

                    if (childStatement != null)
                    {
                        group.AddStatement(childStatement);
                    }
                }

                statement.AddSwitchGroup(group);
            }

            return statement;
        }

        private Statement ProcessThrowStatement(ThrowNode node)
        {
            Debug.Assert(node.Value != null);

            Expression valueExpression = expressionBuilder.BuildExpression(node.Value);

            if (valueExpression is MemberExpression)
            {
                valueExpression = expressionBuilder.TransformMemberExpression((MemberExpression) valueExpression);
            }

            return new ThrowStatement(valueExpression);
        }

        private Statement ProcessTryCatchFinallyStatement(TryNode node)
        {
            Debug.Assert(node.CatchClauses.Count < 2);
            Debug.Assert(node.CatchClauses.Count == 1 || node.FinallyClause != null);

            TryCatchFinallyStatement statement = new TryCatchFinallyStatement();

            Statement body = BuildStatement((StatementNode) node.Body);
            statement.AddBody(body);

            if (node.CatchClauses.Count == 1)
            {
                CatchNode catchNode = (CatchNode) node.CatchClauses[0];

                VariableSymbol exceptionVariableSymbol = null;

                if (catchNode.Name != null)
                {
                    TypeSymbol exceptionVariableType =
                        symbolSet.ResolveType(catchNode.Type, symbolTable, memberContext);
                    Debug.Assert(exceptionVariableType != null);

                    exceptionVariableSymbol =
                        new VariableSymbol(catchNode.Name.Name, memberContext, exceptionVariableType);
                }
                else
                {
                    TypeSymbol exceptionVariableType =
                        symbolSet.ResolveIntrinsicType(IntrinsicType.Exception);
                    Debug.Assert(exceptionVariableType != null);

                    exceptionVariableSymbol =
                        new VariableSymbol(symbolTable.CreateSymbolName("e"), memberContext, exceptionVariableType);
                }

                symbolTable.PushScope();
                symbolTable.AddSymbol(exceptionVariableSymbol);

                Statement catchStatement = BuildStatement((StatementNode) catchNode.Body);
                statement.AddCatch(exceptionVariableSymbol, catchStatement);

                symbolTable.PopScope();
            }

            if (node.FinallyClause != null)
            {
                Statement finallyStatement = BuildStatement((StatementNode) node.FinallyClause);
                statement.AddFinally(finallyStatement);
            }

            return statement;
        }

        private Statement ProcessUsingStatement(UsingNode node)
        {
            UsingStatement statement = new UsingStatement();
            statement.AddGuard(
                (VariableDeclarationStatement) ProcessVariableDeclarationStatement(
                    (VariableDeclarationNode) node.Guard));
            statement.AddBody(BuildStatement((StatementNode) node.Body));

            return statement;
        }

        private Statement ProcessVariableDeclarationStatement(VariableDeclarationNode node)
        {
            VariableDeclarationStatement statement = new VariableDeclarationStatement();
            TypeSymbol variableType = symbolSet.ResolveType(node.Type, symbolTable, memberContext);

            foreach (VariableInitializerNode initializerNode in node.Initializers)
            {
                string name = initializerNode.Name.Name;

                VariableSymbol symbol = new VariableSymbol(name, memberContext, variableType);

                if (initializerNode.Value != null)
                {
                    Expression value = expressionBuilder.BuildExpression(initializerNode.Value);

                    if (value is MemberExpression)
                    {
                        value = expressionBuilder.TransformMemberExpression((MemberExpression) value);
                    }

                    symbol.SetValue(value);
                }

                symbolTable.AddSymbol(symbol);

                statement.AddVariable(symbol);
            }

            return statement;
        }

        private Statement ProcessWhileStatement(WhileNode node)
        {
            Expression condition = expressionBuilder.BuildExpression(node.Condition);

            if (condition is MemberExpression)
            {
                condition = expressionBuilder.TransformMemberExpression((MemberExpression) condition);
            }

            Statement body = BuildStatement((StatementNode) node.Body);

            return new WhileStatement(condition, body, /* preCondition */ true);
        }
    }
}
