// NameNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class NameNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            NameNode nameNode = (NameNode)node;

            if (Utility.IsKeyword(nameNode.Name)) {
                errorHandler.ReportError(nameNode.Name + " is a reserved word.",
                                         nameNode.Token.Location);
            }

            return true;
        }
    }
}
