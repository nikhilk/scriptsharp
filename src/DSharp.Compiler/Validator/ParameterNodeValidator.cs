using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class ParameterNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            ParameterNode paramNode = (ParameterNode)node;

            if (paramNode.Flags == ParameterFlags.Ref || paramNode.Flags == ParameterFlags.Out)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.UNSUPPORTED_PARAMETER_TYPE, paramNode);

                return false;
            }

            return true;
        }
    }
}
