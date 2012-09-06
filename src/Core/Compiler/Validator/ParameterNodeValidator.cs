// ParameterNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class ParameterNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            ParameterNode paramNode = (ParameterNode)node;

            if (paramNode.Flags != ParameterFlags.None) {
                errorHandler.ReportError("Out, Ref and Params style of parameters are not yet implemented.",
                                         paramNode.Token.Location);
                return false;
            }

            return true;
        }
    }
}
