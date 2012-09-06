// ThrowNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class ThrowNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            ThrowNode throwNode = (ThrowNode)node;

            if (throwNode.Value == null) {
                errorHandler.ReportError("Throw statements must specify an exception object.",
                                         throwNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
