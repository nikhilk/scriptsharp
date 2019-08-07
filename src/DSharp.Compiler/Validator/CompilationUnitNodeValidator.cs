using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class CompilationUnitNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            CompilationUnitNode compilationUnitNode = (CompilationUnitNode)node;

            foreach (AttributeBlockNode attribBlock in compilationUnitNode.Attributes)
            {
                AttributeNode scriptNamespaceNode =
                    AttributeNode.FindAttribute(attribBlock.Attributes, DSharpStringResources.SCRIPT_NAMESPACE_ATTRIBUTE);

                if (scriptNamespaceNode != null)
                {
                    string scriptNamespace = (string)((LiteralNode)scriptNamespaceNode.Arguments[0]).Value;

                    if (Utility.IsValidScriptNamespace(scriptNamespace) == false)
                    {
                        errorHandler.ReportNodeValidationError(DSharpStringResources.SCRIPT_NAMESPACE_VIOLATION , scriptNamespaceNode);
                    }
                }
            }

            foreach (ParseNode childNode in compilationUnitNode.Members)
                if (!(childNode is NamespaceNode))
                {
                    errorHandler.ReportNodeValidationError(DSharpStringResources.SCRIPT_NAMESPACE_TYPE_VIOLATION, childNode);

                    return false;
                }

            return true;
        }
    }
}
