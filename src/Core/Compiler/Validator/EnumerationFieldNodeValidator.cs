// EnumerationFieldNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class EnumerationFieldNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            EnumerationFieldNode enumFieldNode = (EnumerationFieldNode)node;

            object fieldValue = enumFieldNode.Value;
            if (fieldValue == null) {
                errorHandler.ReportError("Enumeration fields must have an explicit constant value specified.",
                                         enumFieldNode.Token.Location);
                return false;
            }

            if ((fieldValue is long) || (fieldValue is ulong)) {
                errorHandler.ReportError("Enumeration fields cannot have long or ulong underlying type.",
                                         enumFieldNode.Token.Location);
            }

            return true;
        }
    }
}
