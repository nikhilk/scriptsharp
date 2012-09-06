// PropertyDeclarationNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class PropertyDeclarationNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            PropertyDeclarationNode propertyNode = (PropertyDeclarationNode)node;

            if (((propertyNode.Modifiers & Modifiers.Static) == 0) &&
                ((propertyNode.Modifiers & Modifiers.New) != 0)) {
                errorHandler.ReportError("The new modifier is not supported on instance members.",
                                         propertyNode.Token.Location);
                return false;
            }

            if (propertyNode.GetAccessor == null) {
                errorHandler.ReportError("Set-only properties are not supported. Use a set method instead.",
                                         propertyNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
