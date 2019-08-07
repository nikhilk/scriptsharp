using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class IndexerDeclarationNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            IndexerDeclarationNode indexerNode = (IndexerDeclarationNode)node;

            if ((indexerNode.Modifiers & Modifiers.New) != 0)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.INDEXER_NEW_KEYWORD_NOT_SUPPORTED_ERROR, indexerNode);

                return false;
            }

            if (indexerNode.GetAccessor == null)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.INDEXER_SET_ONLY_NOT_SUPPORTED , indexerNode);

                return false;
            }

            return true;
        }
    }
}
