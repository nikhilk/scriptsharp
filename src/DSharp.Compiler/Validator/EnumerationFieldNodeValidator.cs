using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class EnumerationFieldNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            EnumerationFieldNode enumFieldNode = (EnumerationFieldNode)node;

            object fieldValue = enumFieldNode.Value;

            if (fieldValue == null)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.ENUM_CONSTANT_VALUE_MISSING_ERROR, enumFieldNode);

                return false;
            }

            if (fieldValue is long || fieldValue is ulong)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.ENUM_VALUE_TYPE_ERROR, enumFieldNode);
            }

            return true;
        }
    }
}
