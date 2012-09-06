// TryNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class TryNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            TryNode tryNode = (TryNode)node;

            if ((tryNode.CatchClauses != null) && (tryNode.CatchClauses.Count > 1)) {
                errorHandler.ReportError("Try/Catch statements are limited to a single catch clause.",
                                         tryNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
