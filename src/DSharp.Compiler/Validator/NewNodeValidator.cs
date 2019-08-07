using System.Diagnostics;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class NewNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            NewNode newNode = (NewNode)node;

            // TODO: This is somewhat hacky - it only looks for any type named Dictionary
            //       rather than resolving the type and checking if its actually
            //       System.Dictionary.
            //       This is because validators don't have a reference to the SymbolSet.

            NameNode typeNode = newNode.TypeReference as NameNode;

            if (typeNode != null && typeNode.Name.Equals("Dictionary"))
            {
                if (newNode.Arguments != null)
                {
                    Debug.Assert(newNode.Arguments is ExpressionListNode);
                    ParseNodeList arguments = ((ExpressionListNode)newNode.Arguments).Expressions;

                    if (arguments.Count != 0)
                    {
                        if (arguments.Count % 2 != 0)
                        {
                            errorHandler.ReportNodeValidationError(DSharpStringResources.INVALID_DICTIONARY_INTIALIZATION_PARAMETER_VALUE, newNode);
                        }

                        for (int i = 0; i < arguments.Count; i += 2)
                        {
                            ParseNode nameArgumentNode = arguments[i];

                            if (nameArgumentNode.NodeType != ParseNodeType.Literal ||
                                ((LiteralNode)nameArgumentNode).Literal.LiteralType != LiteralTokenType.String)
                            {
                                errorHandler.ReportNodeValidationError(DSharpStringResources.INVALID_DICTIONARY_PARAMETER_TYPE, nameArgumentNode);
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
