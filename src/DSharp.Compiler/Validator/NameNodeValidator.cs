// NameNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class NameNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            NameNode nameNode = (NameNode)node;

            if(nameNode.Parent is VariableDeclarationNode)
            {
                if(nameNode.Name == "var")
                {
                    return true;
                }
            }

            if (Utility.IsKeyword(nameNode.Name))
            {
                errorHandler.ReportNodeValidationError(string.Format(DSharpStringResources.RESERVED_KEYWORD_ERROR_FORMAT, nameNode.Name), nameNode);
            }

            return true;
        }
    }
}
