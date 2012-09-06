// ArrayTypeNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class ArrayTypeNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            ArrayTypeNode typeNode = (ArrayTypeNode)node;

            if (typeNode.Rank != 1) {
                errorHandler.ReportError("Only single dimensional arrays are supported.",
                                         typeNode.Token.Location);
            }

            return true;
        }
    }
}
