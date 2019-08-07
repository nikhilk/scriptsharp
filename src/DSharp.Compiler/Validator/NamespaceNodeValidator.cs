using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class NamespaceNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            NamespaceNode namespaceNode = (NamespaceNode)node;

            bool valid = true;

            foreach (ParseNode childNode in namespaceNode.Members)
                if (childNode is NamespaceNode)
                {
                    errorHandler.ReportNodeValidationError(DSharpStringResources.UNSUPPORTED_NESTED_NAMESPACE, childNode);
                    valid = false;
                }

            return valid;
        }
    }
}
