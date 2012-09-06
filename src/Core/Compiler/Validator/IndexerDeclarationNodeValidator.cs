// IndexerDeclarationNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class IndexerDeclarationNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            IndexerDeclarationNode indexerNode = (IndexerDeclarationNode)node;

            if ((indexerNode.Modifiers & Modifiers.New) != 0) {

                errorHandler.ReportError("The new modifier is not supported.",
                                         indexerNode.Token.Location);
                
                return false;
            }

            if (indexerNode.GetAccessor == null) {
                errorHandler.ReportError("Set-only properties are not supported. Use a set method instead.",
                                         indexerNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
