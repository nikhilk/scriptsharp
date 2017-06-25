// UnsupportedParseNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    /// <summary>
    /// Raises errors for unsupported and not-yet-implemented C# constructs.
    /// </summary>
    internal sealed class UnsupportedParseNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            string message = String.Empty;
            bool notYetImplemented = false;

            switch (node.NodeType) {
                case ParseNodeType.PointerType:
                    message = "Pointer types";
                    break;
                case ParseNodeType.OperatorDeclaration:
                    message = "Operator overloads";
                    break;
                case ParseNodeType.DestructorDeclaration:
                    message = "Type destructors";
                    break;
                case ParseNodeType.Goto:
                    message = "Goto statements";
                    break;
                case ParseNodeType.Lock:
                    message = "Lock statements";
                    break;
                case ParseNodeType.UnsafeStatement:
                    message = "Unsafe statements";
                    break;
                case ParseNodeType.LabeledStatement:
                    message = "Labeled statements";
                    break;
                case ParseNodeType.YieldReturn:
                    message = "Yield return statements";
                    break;
                case ParseNodeType.YieldBreak:
                    message = "Yield break statements";
                    break;
                case ParseNodeType.Checked:
                    message = "Checked expressions";
                    break;
                case ParseNodeType.Unchecked:
                    message = "Unchecked expressions";
                    break;
                case ParseNodeType.Sizeof:
                    message = "Sizeof expressions";
                    break;
                case ParseNodeType.Fixed:
                    message = "Fixed expressions";
                    break;
                case ParseNodeType.StackAlloc:
                    message = "Stackalloc expressions";
                    break;
                case ParseNodeType.DefaultValueExpression:
                    message = "Default value expressions";
                    break;
                case ParseNodeType.ExternAlias:
                    message = "Extern aliases";
                    break;
                case ParseNodeType.AliasQualifiedName:
                    message = "Alias-qualified identifiers";
                    break;
                case ParseNodeType.TypeParameter:
                    message = "Generic type parameters";
                    break;
                case ParseNodeType.ConstraintClause:
                    message = "Generic type constraints";
                    break;
                case ParseNodeType.GenericName:
                    message = "Generic types";
                    break;
            }

            if (notYetImplemented) {
                message += " are not yet implemented.";
            }
            else {
                message = message + " are not supported.";
            }

            errorHandler.ReportError(message, node.Token.Location);
            return false;
        }
    }
}
