// StatementGenerator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Generator {

    internal static class StatementGenerator {

        private static void GenerateBlockStatement(ScriptGenerator generator, MemberSymbol symbol, BlockStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            foreach (Statement s in statement.Statements) {
                GenerateStatement(generator, symbol, s);
            }
        }

        private static void GenerateBreakStatement(ScriptGenerator generator, MemberSymbol symbol, BreakStatement statement) {
            ScriptTextWriter writer = generator.Writer;
            writer.Write("break;");
            writer.WriteLine();
        }

        private static void GenerateContinueStatement(ScriptGenerator generator, MemberSymbol symbol, ContinueStatement statement) {
            ScriptTextWriter writer = generator.Writer;
            writer.Write("continue;");
            writer.WriteLine();
        }

        private static void GenerateErrorStatement(ScriptGenerator generator, MemberSymbol symbol, ErrorStatement statement) {
            ScriptTextWriter writer = generator.Writer;
            writer.Write("// ERROR: ");
            writer.Write(statement.Message);
            writer.WriteLine();
            writer.Write("// ERROR: at ");
            writer.Write(statement.Location);
            writer.WriteLine();
        }

        private static void GenerateExpressionStatement(ScriptGenerator generator, MemberSymbol symbol, ExpressionStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            ExpressionGenerator.GenerateExpression(generator, symbol, statement.Expression);
            if (statement.IsFragment == false) {
                writer.Write(";");
                writer.WriteLine();
            }
        }

        private static void GenerateForStatement(ScriptGenerator generator, MemberSymbol symbol, ForStatement statement) {
            if (statement.Body == null) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            writer.Write("for ");
            writer.Write("(");
            if (statement.Initializers != null) {
                ExpressionGenerator.GenerateExpressionList(generator, symbol, statement.Initializers);
            }
            else if (statement.Variables != null) {
                GenerateVariableDeclarations(generator, symbol, statement.Variables);
            }
            writer.Write("; ");
            if (statement.Condition != null) {
                ExpressionGenerator.GenerateExpression(generator, symbol, statement.Condition);
            }
            writer.Write("; ");
            if (statement.Increments != null) {
                ExpressionGenerator.GenerateExpressionList(generator, symbol, statement.Increments);
            }
            writer.WriteLine(") {");
            writer.Indent++;
            GenerateStatement(generator, symbol, statement.Body);
            writer.Indent--;
            writer.Write("}");
            writer.WriteLine();
        }

        private static void GenerateForInStatement(ScriptGenerator generator, MemberSymbol symbol, ForInStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            if (statement.IsDictionaryEnumeration) {
                if (statement.DictionaryVariable != null) {
                    writer.Write("var ");
                    writer.Write(statement.DictionaryVariable.GeneratedName);
                    writer.Write(" = ");
                    ExpressionGenerator.GenerateExpression(generator, symbol, statement.CollectionExpression);
                    writer.Write(";");
                    writer.WriteLine();
                }

                writer.Write("for (var ");
                writer.Write(statement.LoopVariable.GeneratedName);
                writer.Write(" in ");
                if (statement.DictionaryVariable != null) {
                    writer.Write(statement.DictionaryVariable.GeneratedName);
                }
                else {
                    ExpressionGenerator.GenerateExpression(generator, symbol, statement.CollectionExpression);
                }
                writer.WriteLine(") {");
                writer.Indent++;
                writer.Write("var ");
                writer.Write(statement.ItemVariable.GeneratedName);
                writer.Write(" = { key: ");
                writer.Write(statement.LoopVariable.GeneratedName);
                writer.Write(", value: ");
                if (statement.DictionaryVariable != null) {
                    writer.Write(statement.DictionaryVariable.GeneratedName);
                }
                else {
                    ExpressionGenerator.GenerateExpression(generator, symbol, statement.CollectionExpression);
                }
                writer.Write("[");
                writer.Write(statement.LoopVariable.GeneratedName);
                writer.WriteLine("] };");
                GenerateStatement(generator, symbol, statement.Body);
                writer.Indent--;
                writer.WriteLine("}");
            }
            else {
                writer.Write("var ");
                writer.Write(statement.LoopVariable.GeneratedName);
                writer.Write(" = ");

                writer.Write("ss.enumerate(");
                ExpressionGenerator.GenerateExpression(generator, symbol, statement.CollectionExpression);
                writer.Write(");");

                writer.WriteLine();

                writer.Write("while (");
                writer.Write(statement.LoopVariable.GeneratedName);
                writer.WriteLine(".moveNext()) {");
                writer.Indent++;

                writer.Write("var ");
                writer.Write(statement.ItemVariable.GeneratedName);
                writer.Write(" = ");
                writer.Write(statement.LoopVariable.GeneratedName);
                writer.Write(".current;");
                writer.WriteLine();

                GenerateStatement(generator, symbol, statement.Body);

                writer.Indent--;
                writer.Write("}");
                writer.WriteLine();
            }
        }

        private static void GenerateIfElseStatement(ScriptGenerator generator, MemberSymbol symbol, IfElseStatement statement) {
            if ((statement.IfStatement == null) && (statement.ElseStatement == null)) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            writer.Write("if (");
            ExpressionGenerator.GenerateExpression(generator, symbol, statement.Condition);
            writer.WriteLine(") {");
            if (statement.IfStatement != null) {
                writer.Indent++;
                GenerateStatement(generator, symbol, statement.IfStatement);
                writer.Indent--;
            }
            writer.Write("}");
            writer.WriteLine();
            if (statement.ElseStatement != null) {
                bool writeEndBlock = false;

                if (statement.ElseStatement is IfElseStatement) {
                    writer.Write("else ");
                }
                else {
                    writer.WriteLine("else {");
                    writeEndBlock = true;
                    writer.Indent++;
                }
                GenerateStatement(generator, symbol, statement.ElseStatement);
                if (writeEndBlock) {
                    writer.Indent--;
                    writer.WriteLine("}");
                }
            }
        }

        private static void GenerateReturnStatement(ScriptGenerator generator, MemberSymbol symbol, ReturnStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            if (statement.Value != null) {
                writer.Write("return ");
                ExpressionGenerator.GenerateExpression(generator, symbol, statement.Value);
                writer.WriteLine(";");
            }
            else {
                writer.WriteLine("return;");
            }
        }

        public static void GenerateStatement(ScriptGenerator generator, MemberSymbol symbol, Statement statement) {
            switch (statement.Type) {
                case StatementType.Block:
                    GenerateBlockStatement(generator, symbol, (BlockStatement)statement);
                    break;
                case StatementType.Empty:
                    break;
                case StatementType.VariableDeclaration:
                    GenerateVariableDeclarationStatement(generator, symbol, (VariableDeclarationStatement)statement);
                    break;
                case StatementType.Return:
                    GenerateReturnStatement(generator, symbol, (ReturnStatement)statement);
                    break;
                case StatementType.Expression:
                    GenerateExpressionStatement(generator, symbol, (ExpressionStatement)statement);
                    break;
                case StatementType.IfElse:
                    GenerateIfElseStatement(generator, symbol, (IfElseStatement)statement);
                    break;
                case StatementType.While:
                    GenerateWhileStatement(generator, symbol, (WhileStatement)statement);
                    break;
                case StatementType.For:
                    GenerateForStatement(generator, symbol, (ForStatement)statement);
                    break;
                case StatementType.ForIn:
                    GenerateForInStatement(generator, symbol, (ForInStatement)statement);
                    break;
                case StatementType.Switch:
                    GenerateSwitchStatement(generator, symbol, (SwitchStatement)statement);
                    break;
                case StatementType.Break:
                    GenerateBreakStatement(generator, symbol, (BreakStatement)statement);
                    break;
                case StatementType.Continue:
                    GenerateContinueStatement(generator, symbol, (ContinueStatement)statement);
                    break;
                case StatementType.Throw:
                    GenerateThrowStatement(generator, symbol, (ThrowStatement)statement);
                    break;
                case StatementType.TryCatchFinally:
                    GenerateTryCatchFinallyStatement(generator, symbol, (TryCatchFinallyStatement)statement);
                    break;
                case StatementType.Error:
                    GenerateErrorStatement(generator, symbol, (ErrorStatement)statement);
                    break;
                default:
                    Debug.Fail("Unexpected statement type: " + statement.Type);
                    break;
            }
        }

        private static void GenerateSwitchStatement(ScriptGenerator generator, MemberSymbol symbol, SwitchStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            writer.Write("switch (");
            ExpressionGenerator.GenerateExpression(generator, symbol, statement.Condition);
            writer.WriteLine(") {");
            writer.Indent++;
            foreach (SwitchGroup group in statement.Groups) {
                if (group.Cases != null) {
                    foreach (Expression caseExpression in group.Cases) {
                        writer.Write("case ");
                        ExpressionGenerator.GenerateExpression(generator, symbol, caseExpression);
                        writer.WriteLine(":");
                    }
                }

                if (group.IncludeDefault) {
                    writer.WriteLine("default:");
                }

                writer.Indent++;
                foreach (Statement childStatement in group.Statements) {
                    GenerateStatement(generator, symbol, childStatement);
                }
                writer.Indent--;
            }
            writer.Indent--;
            writer.WriteLine("}");
        }

        private static void GenerateThrowStatement(ScriptGenerator generator, MemberSymbol symbol, ThrowStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            writer.Write("throw ");
            ExpressionGenerator.GenerateExpression(generator, symbol, statement.Value);
            writer.WriteLine(";");
        }

        private static void GenerateTryCatchFinallyStatement(ScriptGenerator generator, MemberSymbol symbol, TryCatchFinallyStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            writer.WriteLine("try {");
            writer.Indent++;
            GenerateStatement(generator, symbol, statement.Body);
            writer.Indent--;
            writer.WriteLine("}");
            if (statement.Catch != null) {
                writer.Write("catch (");
                writer.Write(statement.ExceptionVariable.GeneratedName);
                writer.WriteLine(") {");
                writer.Indent++;
                GenerateStatement(generator, symbol, statement.Catch);
                writer.Indent--;
                writer.WriteLine("}");
            }
            if (statement.Finally != null) {
                writer.WriteLine("finally {");
                writer.Indent++;
                GenerateStatement(generator, symbol, statement.Finally);
                writer.Indent--;
                writer.WriteLine("}");
            }
        }

        private static void GenerateVariableDeclarations(ScriptGenerator generator, MemberSymbol symbol, VariableDeclarationStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            bool firstVariable = true;

            writer.Write("var ");
            foreach (VariableSymbol variableSymbol in statement.Variables) {
                if (firstVariable == false) {
                    writer.Write(", ");
                }

                writer.Write(variableSymbol.GeneratedName);

                if (variableSymbol.Value != null) {
                    writer.Write(" = ");
                    ExpressionGenerator.GenerateExpression(generator, symbol, variableSymbol.Value);
                }

                firstVariable = false;
            }
        }

        private static void GenerateVariableDeclarationStatement(ScriptGenerator generator, MemberSymbol symbol, VariableDeclarationStatement statement) {
            ScriptTextWriter writer = generator.Writer;

            GenerateVariableDeclarations(generator, symbol, statement);
            writer.WriteLine(";");
        }

        private static void GenerateWhileStatement(ScriptGenerator generator, MemberSymbol symbol, WhileStatement statement) {
            if (statement.Body == null) {
                return;
            }

            ScriptTextWriter writer = generator.Writer;

            if (statement.PreCondition) {
                writer.Write("while (");
                ExpressionGenerator.GenerateExpression(generator, symbol, statement.Condition);
                writer.WriteLine(") {");
            }
            else {
                writer.WriteLine("do {");
            }

            writer.Indent++;
            GenerateStatement(generator, symbol, statement.Body);
            writer.Indent--;

            if (statement.PreCondition) {
                writer.WriteLine("}");
            }
            else {
                writer.Write("} while (");
                ExpressionGenerator.GenerateExpression(generator, symbol, statement.Condition);
                writer.WriteLine(");");
            }
        }
    }
}
