using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class EventDeclarationNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            EventDeclarationNode eventNode = (EventDeclarationNode)node;

            if ((eventNode.Modifiers & Modifiers.Static) == 0 &&
                (eventNode.Modifiers & Modifiers.New) != 0)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.STATIC_NEW_KEYWORD_UNSUPPORTED, eventNode);

                return false;
            }

            return true;
        }
    }
}
