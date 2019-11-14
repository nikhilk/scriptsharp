// ExpressionGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using DSharp.Compiler.Extensions;
using DSharp.Compiler.ScriptModel.Expressions;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Generator
{
    internal static class ExpressionGenerator
    {
        private static readonly StringComparer stringComparer = StringComparer.InvariantCultureIgnoreCase;

        private static void GenerateBaseInitializerExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                              BaseInitializerExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            Debug.Assert(symbol.Parent is ClassSymbol);

            ClassSymbol baseClass = ((ClassSymbol)symbol.Parent).BaseClass;
            Debug.Assert(baseClass != null);

            if(baseClass.GenericArguments?.Any() ?? false)
            {
                writer.Write(DSharpStringResources.ScriptExportMember("getGenericConstructor"));
                writer.Write("(");
                writer.Write(baseClass.FullGeneratedName);
                writer.Write(", ");
                generator.WriteGenericTypeArgumentsMap(baseClass.GenericArguments, baseClass.GenericParameters);
                writer.Write(")");
            }
            else
            {
                writer.Write(baseClass.FullGeneratedName);
            }

            writer.Write(".call(this");

            if (expression.Parameters != null)
            {
                writer.Write(", ");
                GenerateExpressionList(generator, symbol, expression.Parameters);
            }

            writer.Write(")");
        }

        private static void GenerateBinaryExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                     BinaryExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Operator == Operator.Equals)
            {
                if (expression.LeftOperand is PropertyExpression propExpression)
                {
                    Debug.Assert(propExpression.Type == ExpressionType.PropertySet);

                    if (propExpression.ObjectReference is BaseExpression)
                    {
                        ClassSymbol classSymbol = (ClassSymbol)symbol.Parent;
                        writer.Write($"{DSharpStringResources.ScriptExportMember("baseProperty")}(");
                        writer.Write(classSymbol.FullGeneratedName);
                        writer.Write(", '");
                        writer.Write(propExpression.Property.GeneratedName);
                        writer.Write("').set.call(");
                        writer.Write(generator.CurrentImplementation.ThisIdentifier);
                        writer.Write(", ");
                        GenerateExpression(generator, symbol, expression.RightOperand);
                        writer.Write(")");
                    }
                    else
                    {
                        GenerateExpression(generator, symbol, propExpression.ObjectReference);
                        writer.Write(".");
                        writer.Write(propExpression.Property.GeneratedName);
                        writer.Write(" = ");
                        GenerateExpression(generator, symbol, expression.RightOperand);
                    }

                    propExpression.Property.IncrementReferenceCount();
                    return;
                }

                if (expression.LeftOperand is IndexerExpression indexExpression)
                {
                    IndexerSymbol indexerSymbol = indexExpression.Indexer;

                    if (!indexerSymbol.UseScriptIndexer)
                    {
                        Debug.Assert(indexExpression.Type == ExpressionType.Indexer);

                        if (indexExpression.ObjectReference is BaseExpression objectReference)
                        {
                            writer.Write(objectReference.EvaluatedType.FullGeneratedName);
                            writer.Write(".prototype.set_");
                            writer.Write(indexerSymbol.GeneratedName);
                            writer.Write(".call(");
                            writer.Write(generator.CurrentImplementation.ThisIdentifier);
                            writer.Write(", ");
                            GenerateExpressionList(generator, symbol, indexExpression.Indices);
                            writer.Write(", ");
                            GenerateExpression(generator, symbol, expression.RightOperand);
                            writer.Write(")");
                        }
                        else
                        {
                            GenerateExpression(generator, symbol, indexExpression.ObjectReference);
                            writer.Write(".set_");
                            writer.Write(indexerSymbol.GeneratedName);
                            writer.Write("(");
                            GenerateExpressionList(generator, symbol, indexExpression.Indices);
                            writer.Write(", ");
                            GenerateExpression(generator, symbol, expression.RightOperand);
                            writer.Write(")");
                        }

                        indexExpression.Indexer.IncrementReferenceCount();
                        return;
                    }
                    else if (indexerSymbol.Parent is TypeSymbol typeSymbol && !typeSymbol.IsNativeArray)
                    {
                        writer.Write($"ss.setItem(");
                        GenerateExpression(generator, symbol, indexExpression.ObjectReference);
                        writer.Write(", ");
                        GenerateExpressionList(generator, symbol, indexExpression.Indices);
                        writer.Write(", ");
                        GenerateExpression(generator, symbol, expression.RightOperand);
                        writer.Write(")");

                        return;
                    }
                }
            }
            else if (expression.Operator == Operator.PlusEquals ||
                     expression.Operator == Operator.MinusEquals ||
                     expression.Operator == Operator.MultiplyEquals ||
                     expression.Operator == Operator.DivideEquals ||
                     expression.Operator == Operator.ModEquals ||
                     expression.Operator == Operator.BitwiseOrEquals ||
                     expression.Operator == Operator.BitwiseAndEquals ||
                     expression.Operator == Operator.BitwiseXorEquals ||
                     expression.Operator == Operator.ShiftLeftEquals ||
                     expression.Operator == Operator.ShiftRightEquals ||
                     expression.Operator == Operator.UnsignedShiftRightEquals)
            {
                if (expression.LeftOperand is PropertyExpression propExpression)
                {
                    Debug.Assert(propExpression.Type == ExpressionType.PropertyGet);

                    GenerateExpression(generator, symbol, propExpression.ObjectReference);
                    writer.Write(".");
                    writer.Write(propExpression.Property.GeneratedName);
                    writer.Write(" = ");
                    GenerateExpression(generator, symbol, propExpression.ObjectReference);
                    writer.Write(OperatorConverter.OperatorToString(expression.Operator - 1));
                    GenerateExpression(generator, symbol, expression.RightOperand);

                    propExpression.Property.IncrementReferenceCount();
                    return;
                }
            }
            else if (expression.Operator == Operator.Is ||
                     expression.Operator == Operator.As)
            {
                TypeExpression typeExpression = expression.RightOperand as TypeExpression;
                Debug.Assert(typeExpression != null);

                writer.Write(DSharpStringResources.ScriptExportMember(string.Empty));

                if (expression.Operator == Operator.Is)
                {
                    writer.Write("canCast(");
                }
                else
                {
                    writer.Write("safeCast(");
                }

                GenerateExpression(generator, symbol, expression.LeftOperand);

                writer.Write(", ");
                writer.Write(typeExpression.AssociatedType.FullGeneratedName);
                writer.Write(")");
                typeExpression.AssociatedType.IncrementReferenceCount();
                return;
            }
            else if (expression.Operator == Operator.EqualEqualEqual ||
                     expression.Operator == Operator.NotEqualEqual)
            {
                if (expression.RightOperand is LiteralExpression literalExpression)
                {
                    // Optimize generated script to perform loose equality checks for false-y values
                    // (null, false, 0, empty string)

                    // TODO: This should really be happening at compilation time, rather than generation
                    //       time. Because this is happening at generation time, we get something like
                    //       if (!!x) when if(x) would suffice just so we can get
                    //       foo(!!x) where foo is a method expecting a boolean.
                    //       Doing this at compilation time would allow handling if scenarios specially.

                    bool optimizable = false;
                    bool checkForFalse = false;

                    if (literalExpression.Value is bool compareValue)
                    {
                        optimizable = true;

                        if (compareValue && expression.Operator == Operator.NotEqualEqual ||
                            !compareValue && expression.Operator == Operator.EqualEqualEqual)
                        {
                            checkForFalse = true;
                        }
                    }
                    else if (literalExpression.Value is int i && i == 0)
                    {
                        optimizable = true;
                        checkForFalse = expression.Operator == Operator.EqualEqualEqual;
                    }
                    else if (literalExpression.Value is string s && s == string.Empty)
                    {
                        optimizable = true;
                        checkForFalse = expression.Operator == Operator.EqualEqualEqual;
                    }

                    if (optimizable)
                    {
                        bool parenthesize = false;

                        writer.Write(checkForFalse ? "!" : "!!");

                        if (expression.LeftOperand.Parenthesized == false &&
                            (expression.LeftOperand.Type == ExpressionType.Binary ||
                             expression.LeftOperand.Type == ExpressionType.Conditional ||
                             expression.LeftOperand.Type == ExpressionType.InlineScript))
                        {
                            parenthesize = true;
                            writer.Write("(");
                        }

                        GenerateExpression(generator, symbol, expression.LeftOperand);

                        if (parenthesize)
                        {
                            writer.Write(")");
                        }

                        return;
                    }
                }
            }

            GenerateExpression(generator, symbol, expression.LeftOperand);
            writer.Write(OperatorConverter.OperatorToString(expression.Operator));
            GenerateExpression(generator, symbol, expression.RightOperand);
        }

        private static void GenerateConditionalExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                          ConditionalExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Condition.Parenthesized == false)
            {
                writer.Write("(");
            }

            GenerateExpression(generator, symbol, expression.Condition);

            if (expression.Condition.Parenthesized == false)
            {
                writer.Write(")");
            }

            writer.Write(" ? ");
            GenerateExpression(generator, symbol, expression.TrueValue);
            writer.Write(" : ");
            GenerateExpression(generator, symbol, expression.FalseValue);
        }

        private static void GenerateDelegateExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                       DelegateExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Method is AnonymousMethodSymbol anonymousMethod)
            {
                writer.Write("function(");

                if (anonymousMethod.Parameters != null && anonymousMethod.Parameters.Count != 0)
                {
                    int paramIndex = 0;

                    foreach (ParameterSymbol parameterSymbol in anonymousMethod.Parameters)
                    {
                        if (paramIndex > 0)
                        {
                            writer.Write(", ");
                        }

                        writer.Write(parameterSymbol.GeneratedName);

                        paramIndex++;
                    }
                }

                writer.WriteLine(") {");
                writer.Indent++;
                CodeGenerator.GenerateScript(generator, anonymousMethod);
                writer.Indent--;
                writer.Write("}");
            }
            else if ((expression.Method.Visibility & MemberVisibility.Static) != 0)
            {
                GenerateExpression(generator, symbol, expression.ObjectReference);
                writer.Write(".");
                writer.Write(expression.Method.GeneratedName);
            }
            else
            {
                //Todo: Fix chain `base` calls when binding-> `base.base.base.SomeMethod`,
                //Just need to know how deep the hierarchy is and pass that depth in to the `baseBind` function
                string bindingFunctionName = GetExpressionBindingFunctionName(expression.ObjectReference);
                writer.Write($"{DSharpStringResources.ScriptExportMember(bindingFunctionName)}('");
                writer.Write(expression.Method.GeneratedName);
                writer.Write("', ");
                if (expression.ObjectReference is BaseExpression)
                {
                    GenerateThisExpression(generator);
                }
                else
                {
                    GenerateExpression(generator, symbol, expression.ObjectReference);
                }
                writer.Write(")");
            }
        }

        private static string GetExpressionBindingFunctionName(Expression expression)
        {
            if (expression is BaseExpression)
            {
                return "baseBind";
            }

            return "bind";
        }

        private static void GenerateEnumerationFieldExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                               EnumerationFieldExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            GenerateExpression(generator, symbol, expression.ObjectReference);
            writer.Write(".");
            writer.Write(expression.Field.GeneratedName);
        }

        private static void GenerateEventExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                    EventExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            EventSymbol eventSymbol = expression.Event;

            GenerateExpression(generator, symbol, expression.ObjectReference);

            if (eventSymbol.HasCustomAccessors)
            {
                writer.Write(".");

                if (expression.Type == ExpressionType.EventAdd)
                {
                    writer.Write(eventSymbol.AddAccessor);
                }
                else
                {
                    writer.Write(eventSymbol.RemoveAccessor);
                }

                writer.Write("('");
                writer.Write(expression.Event.GeneratedName);
                writer.Write("', ");
                GenerateExpression(generator, symbol, expression.Handler);
                writer.Write(")");
            }
            else
            {
                if (expression.Type == ExpressionType.EventAdd)
                {
                    writer.Write(".add_");
                }
                else
                {
                    writer.Write(".remove_");
                }

                writer.Write(expression.Event.GeneratedName);
                writer.Write("(");
                GenerateExpression(generator, symbol, expression.Handler);
                writer.Write(")");
            }

            expression.Event.IncrementReferenceCount();
        }

        public static void GenerateExpression(ScriptGenerator generator, MemberSymbol symbol, Expression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Parenthesized)
            {
                writer.Write("(");
            }

            switch (expression.Type)
            {
                case ExpressionType.Literal:
                    GenerateLiteralExpression(generator, symbol, (LiteralExpression)expression);
                    break;
                case ExpressionType.Local:
                    GenerateLocalExpression(generator, symbol, (LocalExpression)expression);
                    break;
                case ExpressionType.Member:
                    GenerateMemberExpression(generator, symbol, (MemberExpression)expression);
                    break;
                case ExpressionType.Field:
                    GenerateFieldExpression(generator, symbol, (FieldExpression)expression);
                    break;
                case ExpressionType.EnumerationField:
                    GenerateEnumerationFieldExpression(generator, symbol, (EnumerationFieldExpression)expression);
                    break;
                case ExpressionType.PropertyGet:
                    GeneratePropertyExpression(generator, symbol, (PropertyExpression)expression);
                    break;
                case ExpressionType.PropertySet:
                    throw new ScriptGeneratorException(symbol, "PropertyExpression(set) should be covered as part of BinaryExpression logic.");
                case ExpressionType.MethodInvoke:
                case ExpressionType.DelegateInvoke:
                    GenerateMethodExpression(generator, symbol, (MethodExpression)expression);
                    break;
                case ExpressionType.BaseInitializer:
                    GenerateBaseInitializerExpression(generator, symbol, (BaseInitializerExpression)expression);
                    break;
                case ExpressionType.EventAdd:
                case ExpressionType.EventRemove:
                    GenerateEventExpression(generator, symbol, (EventExpression)expression);
                    break;
                case ExpressionType.Indexer:
                    GenerateIndexerExpression(generator, symbol, (IndexerExpression)expression);
                    break;
                case ExpressionType.This:
                    GenerateThisExpression(generator);
                    break;
                case ExpressionType.Base:
                    throw new ScriptGeneratorException(symbol, "BaseExpression not handled by container expression");
                case ExpressionType.New:
                    GenerateNewExpression(generator, symbol, (NewExpression)expression);
                    break;
                case ExpressionType.Unary:
                    GenerateUnaryExpression(generator, symbol, (UnaryExpression)expression);
                    break;
                case ExpressionType.Binary:
                    GenerateBinaryExpression(generator, symbol, (BinaryExpression)expression);
                    break;
                case ExpressionType.Conditional:
                    GenerateConditionalExpression(generator, symbol, (ConditionalExpression)expression);
                    break;
                case ExpressionType.Type:
                    GenerateTypeExpression(generator, symbol, (TypeExpression)expression);
                    break;
                case ExpressionType.Delegate:
                    GenerateDelegateExpression(generator, symbol, (DelegateExpression)expression);
                    break;
                case ExpressionType.LateBound:
                    GenerateLateBoundExpression(generator, symbol, (LateBoundExpression)expression);
                    break;
                case ExpressionType.InlineScript:
                    GenerateInlineScriptExpression(generator, symbol, (InlineScriptExpression)expression);
                    break;
                case ExpressionType.NewDelegate:
                    GenerateExpression(generator, symbol, ((NewDelegateExpression)expression).TypeExpression);
                    break;
                case ExpressionType.Object:
                    GenerateObjectExpression(generator, symbol, ((ObjectExpression)expression).Properties);
                    break;
                case ExpressionType.ObjectInitializer:
                    GenerateObjectInitializerExpression(generator, symbol, (ObjectInitializerExpression)expression);
                    break;
                default:
                    throw new ScriptGeneratorException(symbol, "Unexpected expression type: " + expression.Type);
            }

            if (expression.Parenthesized)
            {
                writer.Write(")");
            }
        }

        private static void GenerateMemberExpression(ScriptGenerator generator, MemberSymbol symbol, MemberExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            GenerateExpression(generator, symbol, expression.ObjectReference);
            writer.Write(".");
            writer.Write(expression.Member.GeneratedName);
        }

        private static void GenerateObjectExpression(ScriptGenerator generator, MemberSymbol symbol, IDictionary<string, Expression> properties)
        {
            ScriptTextWriter writer = generator.Writer;

            writer.Write("{");
            bool commaNeeded = false;

            foreach (var property in properties)
            {
                if(commaNeeded)
                {
                    writer.Write(", ");
                }

                writer.Write(property.Key);
                writer.Write(": ");
                GenerateExpression(generator, symbol, property.Value);

                commaNeeded = true;
            }

            writer.Write("}");
        }

        public static void GenerateObjectInitializerExpression(
            ScriptGenerator generator,
            MemberSymbol symbol,
            ObjectInitializerExpression initializerExpression)
        {
            ScriptTextWriter writer = generator.Writer;

            var type = initializerExpression.NewExpression.EvaluatedType;

            if(type.IsReservedType())
            {
                //TODO: Implement Dictionary initializer + List Initializer + Custom initializers
                GenerateNewExpression(generator, symbol, initializerExpression.NewExpression);
            }
            else
            {
                writer.Write($"{DSharpStringResources.ScriptExportMember("initializeObject")}");
                writer.Write("(");
                GenerateNewExpression(generator, symbol, initializerExpression.NewExpression);
                writer.Write(", ");
                var properties = initializerExpression.Initializers.ToDictionary(
                    item => (((BinaryExpression)item).LeftOperand as PropertyExpression).Property.GeneratedName,
                    item => ((BinaryExpression)item).RightOperand);
                GenerateObjectExpression(generator, symbol, properties);
                writer.Write(")");
            }
        }

        public static void GenerateExpressionList(ScriptGenerator generator, MemberSymbol symbol,
                                                  ICollection<Expression> expressions)
        {
            ScriptTextWriter writer = generator.Writer;

            bool firstExpression = true;

            foreach (Expression expression in expressions)
            {
                if (firstExpression == false)
                {
                    writer.Write(", ");
                }

                GenerateExpression(generator, symbol, expression);
                firstExpression = false;
            }
        }

        private static void GenerateExpressionListAsNameValuePairs(ScriptGenerator generator, MemberSymbol symbol,
                                                                   ICollection<Expression> expressions)
        {
            Debug.Assert(expressions.Count % 2 == 0);

            ScriptTextWriter writer = generator.Writer;

            bool firstExpression = true;
            bool valueExpression = false;

            foreach (Expression expression in expressions)
            {
                if (firstExpression == false && valueExpression == false)
                {
                    writer.Write(", ");
                }

                if (valueExpression)
                {
                    writer.Write(": ");
                    GenerateExpression(generator, symbol, expression);

                    valueExpression = false;
                }
                else
                {
                    Debug.Assert(expression.Type == ExpressionType.Literal);
                    Debug.Assert(((LiteralExpression)expression).Value is string);

                    string name = (string)((LiteralExpression)expression).Value;

                    if (Utility.IsValidIdentifier(name))
                    {
                        writer.Write(name);
                    }
                    else
                    {
                        writer.Write(Utility.QuoteString(name));
                    }

                    valueExpression = true;
                }

                firstExpression = false;
            }
        }

        private static void GenerateFieldExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                    FieldExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Field.IsGlobalField)
            {
                writer.Write(expression.Field.GeneratedName);
            }
            else if (expression.Field.IsConstant)
            {
                GenerateLiteralExpression(generator, symbol,
                    new LiteralExpression(expression.Field.AssociatedType, expression.Field.Value));
            }
            else
            {
                GenerateExpression(generator, symbol, expression.ObjectReference);
                writer.Write(".");
                writer.Write(expression.Field.GeneratedName);
            }

            expression.Field.IncrementReferenceCount();
        }

        private static void GenerateIndexerExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                      IndexerExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Indexer.UseScriptIndexer)
            {
                if (expression.Indexer.Parent is TypeSymbol typeSymbol && typeSymbol.IsNativeArray)
                {
                    GenerateExpression(generator, symbol, expression.ObjectReference);
                    writer.Write("[");
                    GenerateExpressionList(generator, symbol, expression.Indices);
                    writer.Write("]");
                }
                else
                {
                    writer.Write($"ss.getItem(");
                    GenerateExpression(generator, symbol, expression.ObjectReference);
                    writer.Write(", ");
                    GenerateExpressionList(generator, symbol, expression.Indices);
                    writer.Write(")");
                }
            }
            else if (expression.ObjectReference is BaseExpression baseExpression)
            {
                writer.Write(baseExpression.EvaluatedType.FullGeneratedName);
                writer.Write(".prototype.get_");
                writer.Write(expression.Indexer.GeneratedName);
                writer.Write(".call(");
                writer.Write(generator.CurrentImplementation.ThisIdentifier);
                writer.Write(", ");
                GenerateExpressionList(generator, symbol, expression.Indices);
                writer.Write(")");
            }
            else if (expression.Indexer.Parent is TypeSymbol typeSymbol && typeSymbol.IsNativeObject())
            {
                GenerateExpression(generator, symbol, expression.ObjectReference);
                writer.Write("[");
                GenerateExpressionList(generator, symbol, expression.Indices);
                writer.Write("]");
            }
            else
            {
                GenerateExpression(generator, expression.Indexer, expression.ObjectReference);
                writer.Write(".get_");
                writer.Write(expression.Indexer.GeneratedName);
                writer.Write("(");
                GenerateExpressionList(generator, expression.Indexer, expression.Indices);
                writer.Write(")");
            }

            expression.Indexer.IncrementReferenceCount();
        }

        private static void GenerateInlineScriptExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                           InlineScriptExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            string script = expression.Script;
            ICollection<Expression> parameters = expression.Parameters;

            if (parameters != null)
            {
                Debug.Assert(parameters.Count != 0);

                string[] parameterScripts = new string[parameters.Count];
                int i = 0;

                foreach (Expression parameterExpression in parameters)
                {
                    StringWriter sw = new StringWriter();

                    try
                    {
                        writer.StartLocalWriting(sw);
                        GenerateExpression(generator, symbol, parameterExpression);

                        parameterScripts[i] = sw.ToString();
                        i++;
                    }
                    finally
                    {
                        writer.StopLocalWriting();
                    }
                }

                script = string.Format(CultureInfo.InvariantCulture, script, parameterScripts);
            }

            writer.Write(script);
        }

        private static void GenerateLateBoundExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                        LateBoundExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;
            string name = null;

            if (expression.NameExpression is LiteralExpression literalNameExpression && literalNameExpression.Value is string s)
            {
                name = s;
                Debug.Assert(string.IsNullOrEmpty(name) == false);
            }

            if (expression.Operation == LateBoundOperation.DeleteField)
            {
                writer.Write("delete ");
            }

            if (expression.Operation == LateBoundOperation.GetScriptType)
            {
                writer.Write("typeof(");
            }
            else if (expression.Operation == LateBoundOperation.HasMethod)
            {
                writer.Write("(typeof(");
            }
            else if (expression.Operation == LateBoundOperation.HasField)
            {
                writer.Write("(");
                GenerateExpression(generator, symbol, expression.NameExpression);
                writer.Write(" in ");
            }

            if (expression.ObjectReference != null)
            {
                GenerateExpression(generator, symbol, expression.ObjectReference);
            }

            switch (expression.Operation)
            {
                case LateBoundOperation.InvokeMethod:

                    if (Utility.IsValidIdentifier(name))
                    {
                        if (expression.ObjectReference != null)
                        {
                            writer.Write(".");
                        }

                        writer.Write(name);
                    }
                    else
                    {
                        writer.Write("[");
                        GenerateExpression(generator, symbol, expression.NameExpression);
                        writer.Write("]");
                    }

                    writer.Write("(");

                    if (expression.Parameters.Count != 0)
                    {
                        GenerateExpressionList(generator, symbol, expression.Parameters);
                    }

                    writer.Write(")");

                    break;
                case LateBoundOperation.GetField:

                    if (Utility.IsValidIdentifier(name))
                    {
                        writer.Write(".");
                        writer.Write(name);
                    }
                    else
                    {
                        writer.Write("[");
                        GenerateExpression(generator, symbol, expression.NameExpression);
                        writer.Write("]");
                    }

                    break;
                case LateBoundOperation.SetField:

                    if (Utility.IsValidIdentifier(name))
                    {
                        writer.Write(".");
                        writer.Write(name);
                    }
                    else
                    {
                        writer.Write("[");
                        GenerateExpression(generator, symbol, expression.NameExpression);
                        writer.Write("]");
                    }

                    writer.Write(" = ");
                    GenerateExpressionList(generator, symbol, expression.Parameters);

                    break;
                case LateBoundOperation.DeleteField:

                    if (Utility.IsValidIdentifier(name))
                    {
                        writer.Write(".");
                        writer.Write(name);
                    }
                    else
                    {
                        writer.Write("[");
                        GenerateExpression(generator, symbol, expression.NameExpression);
                        writer.Write("]");
                    }

                    break;
                case LateBoundOperation.GetScriptType:
                    writer.Write(")");

                    break;
                case LateBoundOperation.HasField:
                    writer.Write(")");

                    break;
                case LateBoundOperation.HasMethod:

                    if (Utility.IsValidIdentifier(name))
                    {
                        if (expression.ObjectReference != null)
                        {
                            writer.Write(".");
                        }

                        writer.Write(name);
                    }
                    else
                    {
                        writer.Write("[");
                        GenerateExpression(generator, symbol, expression.NameExpression);
                        writer.Write("]");
                    }

                    writer.Write(") === 'function')");

                    break;
            }
        }

        private static void GenerateLiteralExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                      LiteralExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            object value = expression.Value;
            string textValue = null;

            if (value == null)
            {
                textValue = "null";
            }
            else
            {
                if (value is bool b)
                {
                    if (b)
                    {
                        textValue = "true";
                    }
                    else
                    {
                        textValue = "false";
                    }
                }
                else if (value is char || value is string)
                {
                    if (expression.EvaluatedType is TypeSymbol typeSymbol && typeSymbol.IsNativeObject())
                    {
                        textValue = value.ToString();
                    }
                    else
                    {
                        textValue = Utility.QuoteString(value.ToString());
                    }
                }
                else if (value is TypeSymbol typeSymbol)
                {
                    textValue = typeSymbol.FullGeneratedName;
                }
                else if (value is Expression[] values)
                {
                    if (values.Length == 0)
                    {
                        textValue = "[]";
                    }
                    else
                    {
                        writer.Write("[ ");
                        GenerateExpressionList(generator, symbol, values);
                        writer.Write(" ]");
                    }
                }
                else
                {
                    textValue = Convert.ToString(value, CultureInfo.InvariantCulture);
                }
            }

            if (textValue != null)
            {
                writer.Write(textValue);
            }
        }

        private static void GenerateLocalExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                    LocalExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;
            writer.Write(expression.Symbol.GeneratedName);
        }

        private static void GenerateMethodExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                     MethodExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Method.SkipGeneration)
            {
                // If this method is to be skipped from generation, just generate the
                // left-hand-side object reference, and skip everything past it, including
                // the dot.

                GenerateExpression(generator, symbol, expression.ObjectReference);

                return;
            }

            if (expression.ObjectReference is BaseExpression baseExpression)
            {
                writer.Write(baseExpression.EvaluatedType.FullGeneratedName);
                writer.Write(".prototype.");
                writer.Write(expression.Method.GeneratedName);
                writer.Write(".call(");
                writer.Write(generator.CurrentImplementation.ThisIdentifier);

                if (expression.Parameters != null && expression.Parameters.Count != 0)
                {
                    writer.Write(", ");
                    GenerateExpressionList(generator, symbol, expression.Parameters);
                }

                writer.Write(")");
            }
            else
            {
                if (expression.Method.IsAliased)
                {
                    writer.Write(expression.Method.TransformName);
                    writer.Write("(");

                    if ((expression.Method.Visibility & MemberVisibility.Static) == 0)
                    {
                        GenerateExpression(generator, symbol, expression.ObjectReference);

                        if (expression.Parameters != null && expression.Parameters.Count != 0)
                        {
                            writer.Write(", ");
                        }
                    }

                    if (expression.Parameters != null && expression.Parameters.Count != 0)
                    {
                        GenerateExpressionList(generator, symbol, expression.Parameters);
                    }

                    writer.Write(")");
                }
                else
                {
                    GenerateExpression(generator, symbol, expression.ObjectReference);

                    if (expression.Method.GeneratedName.Length != 0)
                    {
                        writer.Write(".");
                    }

                    if (expression.Method.GeneratedName.Length != 0)
                    {
                        writer.Write(expression.Method.GeneratedName);
                    }

                    writer.Write("(");

                    if (expression.Parameters != null)
                    {
                        GenerateExpressionList(generator, symbol, expression.Parameters);
                    }

                    writer.Write(")");
                }
            }

            expression.Method.IncrementReferenceCount();
        }

        private static void GenerateNewExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                  NewExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.IsSpecificType)
            {
                string type = expression.AssociatedType.FullGeneratedName;

                if (type.Equals("Array"))
                {
                    if (expression.Parameters == null)
                    {
                        writer.Write("[]");
                    }
                    else if (expression.Parameters.Count == 1 &&
                             expression.Parameters[0].EvaluatedType ==
                             symbol.SymbolSet.ResolveIntrinsicType(IntrinsicType.Integer))
                    {
                        writer.Write("new Array(");
                        GenerateExpression(generator, symbol, expression.Parameters[0]);
                        writer.Write(")");
                    }
                    else
                    {
                        writer.Write("[");
                        GenerateExpressionList(generator, symbol, expression.Parameters);
                        writer.Write("]");
                    }

                    return;
                }

                if (type.Equals("Object"))
                {
                    if (expression.Parameters == null)
                    {
                        writer.Write("{}");
                    }
                    else
                    {
                        writer.Write("{ ");
                        GenerateExpressionListAsNameValuePairs(generator, symbol, expression.Parameters);
                        writer.Write(" }");
                    }

                    return;
                }

                if (type.Equals("Tuple"))
                {
                    if (expression.Parameters == null || expression.Parameters.Count == 0)
                    {
                        writer.Write("{ }");
                    }
                    else
                    {
                        writer.Write("{ ");

                        for (int i = 0; i < expression.Parameters.Count; i++)
                        {
                            if (i != 0)
                            {
                                writer.Write(", ");
                            }

                            writer.Write("item");
                            writer.Write(i + 1);
                            writer.Write(": ");
                            GenerateExpression(generator, symbol, expression.Parameters[i]);
                        }

                        writer.Write(" }");
                    }

                    return;
                }

                if (expression.AssociatedType.Type == SymbolType.Record)
                {
                    if (expression.AssociatedType.IsApplicationType &&
                        ((RecordSymbol)expression.AssociatedType).Constructor == null)
                    {
                        writer.Write("{ }");

                        return;
                    }

                    writer.Write(expression.AssociatedType.FullGeneratedName);
                    writer.Write("(");

                    if (expression.Parameters != null)
                    {
                        GenerateExpressionList(generator, symbol, expression.Parameters);
                    }

                    writer.Write(")");

                    return;
                }
            }

            if (expression.AssociatedType.IsGeneric
                && expression.AssociatedType.GenericType.IsApplicationType
                && (expression.AssociatedType.GenericArguments?.Any() ?? false))
            {
                writer.Write(DSharpStringResources.ScriptExportMember("createGenericType"));
                writer.Write("(");

                if (expression.IsSpecificType)
                {
                    writer.Write(expression.AssociatedType.FullGeneratedName);
                }
                else
                {
                    GenerateExpression(generator, symbol, expression.TypeExpression);
                }

                writer.Write(", ");
                generator.WriteGenericTypeArgumentsMap(expression.AssociatedType.GenericArguments, expression.AssociatedType.GenericParameters);
                
                if (expression.Parameters != null)
                {
                    writer.Write(", ");
                    GenerateExpressionList(generator, symbol, expression.Parameters);
                }

                writer.Write(")");
            }
            else
            {
                writer.Write("new ");

                if (expression.IsSpecificType)
                {
                    writer.Write(expression.AssociatedType.FullGeneratedName);
                }
                else
                {
                    GenerateExpression(generator, symbol, expression.TypeExpression);
                }

                writer.Write("(");

                if (expression.Parameters != null)
                {
                    GenerateExpressionList(generator, symbol, expression.Parameters);
                }

                writer.Write(")");
                expression.AssociatedType.IncrementReferenceCount();
            }
        }

        private static void GeneratePropertyExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                       PropertyExpression expression)
        {
            Debug.Assert(expression.Type == ExpressionType.PropertyGet);
            ScriptTextWriter writer = generator.Writer;

            if (expression.ObjectReference is BaseExpression)
            {
                Debug.Assert(symbol.Parent is ClassSymbol);

                ClassSymbol classSymbol = (ClassSymbol)symbol.Parent;
                Debug.Assert(classSymbol.BaseClass != null);
                writer.Write($"{DSharpStringResources.ScriptExportMember("baseProperty")}(");
                writer.Write(classSymbol.FullGeneratedName);
                writer.Write(", '");
                writer.Write(expression.Property.GeneratedName);
                writer.Write("').get.call(");
                writer.Write(generator.CurrentImplementation.ThisIdentifier);
                writer.Write(")");
            }
            else
            {
                GenerateExpression(generator, symbol, expression.ObjectReference);
                writer.Write(".");
                writer.Write(expression.Property.GeneratedName);
            }

            expression.Property.IncrementReferenceCount();
        }


        private static void GenerateThisExpression(ScriptGenerator generator)
        {
            ScriptTextWriter writer = generator.Writer;
            writer.Write(generator.CurrentImplementation.ThisIdentifier);
        }

        private static void GenerateTypeExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                   TypeExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;
            writer.Write(expression.AssociatedType.FullGeneratedName);
            expression.AssociatedType.IncrementReferenceCount();
        }

        private static void GenerateUnaryExpression(ScriptGenerator generator, MemberSymbol symbol,
                                                    UnaryExpression expression)
        {
            ScriptTextWriter writer = generator.Writer;

            if (expression.Operator == Operator.PreIncrement ||
                expression.Operator == Operator.PreDecrement)
            {
                GenerateExpression(generator, symbol, expression.Operand);
                writer.Write(OperatorConverter.OperatorToString(expression.Operator));
            }
            else
            {
                writer.Write(OperatorConverter.OperatorToString(expression.Operator));
                GenerateExpression(generator, symbol, expression.Operand);
            }
        }
    }
}
