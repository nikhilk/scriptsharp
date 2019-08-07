using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class ArrayTypeNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            ArrayTypeNode typeNode = (ArrayTypeNode)node;

            if (typeNode.Rank != 1)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.UNSUPPORTED_MULTIPLE_DIMENSIONAL_ARRAYS, typeNode);
            }

            return true;
        }
    }
}
