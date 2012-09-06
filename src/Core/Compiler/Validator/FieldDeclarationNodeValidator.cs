// FieldDeclarationNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class FieldDeclarationNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            FieldDeclarationNode fieldNode = (FieldDeclarationNode)node;

            if (fieldNode.Initializers.Count > 1) {
                errorHandler.ReportError("Field declarations are limited to a single field per declaration.",
                                         fieldNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
