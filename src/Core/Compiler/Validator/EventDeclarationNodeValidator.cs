// EventDeclarationNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class EventDeclarationNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            EventDeclarationNode eventNode = (EventDeclarationNode)node;

            if (((eventNode.Modifiers & Modifiers.Static) == 0) &&
                ((eventNode.Modifiers & Modifiers.New) != 0)) {
                errorHandler.ReportError("The new modifier is not supported on instance members.",
                                         eventNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
