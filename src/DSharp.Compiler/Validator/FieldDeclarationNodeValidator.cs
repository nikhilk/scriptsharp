using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class FieldDeclarationNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            FieldDeclarationNode fieldNode = (FieldDeclarationNode)node;

            if (fieldNode.Initializers.Count > 1)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.DUPLICATE_FIELD_DECLARATION, fieldNode);

                return false;
            }

            return true;
        }
    }
}
