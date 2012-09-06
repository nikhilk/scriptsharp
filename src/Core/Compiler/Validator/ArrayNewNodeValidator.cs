// ArrayNewNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class ArrayNewNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            ArrayNewNode newNode = (ArrayNewNode)node;

            if (newNode.ExpressionList != null) {
                Debug.Assert(newNode.ExpressionList.NodeType == ParseNodeType.ExpressionList);
                ExpressionListNode argsList = (ExpressionListNode)newNode.ExpressionList;

                if (argsList.Expressions.Count != 1) {
                    errorHandler.ReportError("Only single dimensional arrays are supported.",
                                             newNode.ExpressionList.Token.Location);
                }
            }

            return true;
        }
    }
}
