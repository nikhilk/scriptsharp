using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class ThrowNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            ThrowNode throwNode = (ThrowNode)node;

            if (throwNode.Value == null)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.THROW_NODE_VALIDATION_ERROR, throwNode);

                return false;
            }

            return true;
        }
    }
}
