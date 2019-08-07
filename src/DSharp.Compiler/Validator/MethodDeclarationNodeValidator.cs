using System;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class MethodDeclarationNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            MethodDeclarationNode methodNode = (MethodDeclarationNode)node;

            if ((methodNode.Modifiers & Modifiers.Static) == 0 &&
                (methodNode.Modifiers & Modifiers.New) != 0)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.STATIC_NEW_KEYWORD_UNSUPPORTED, methodNode);

                return false;
            }

            if ((methodNode.Modifiers & Modifiers.Extern) != 0)
            {
                CustomTypeNode typeNode = (CustomTypeNode)methodNode.Parent;
                MethodDeclarationNode implMethodNode = null;

                if (methodNode.NodeType == ParseNodeType.MethodDeclaration)
                {
                    foreach (MemberNode memberNode in typeNode.Members)
                        if (memberNode.NodeType == ParseNodeType.MethodDeclaration &&
                            (memberNode.Modifiers & Modifiers.Extern) == 0 &&
                            memberNode.Name.Equals(methodNode.Name, StringComparison.Ordinal))
                        {
                            implMethodNode = (MethodDeclarationNode)memberNode;

                            break;
                        }
                }
                else if (methodNode.NodeType == ParseNodeType.ConstructorDeclaration)
                {
                    foreach (MemberNode memberNode in typeNode.Members)
                        if (memberNode.NodeType == ParseNodeType.ConstructorDeclaration &&
                            (memberNode.Modifiers & Modifiers.Extern) == 0)
                        {
                            implMethodNode = (MethodDeclarationNode)memberNode;

                            break;
                        }
                }

                if (implMethodNode == null)
                {
                    errorHandler.ReportNodeValidationError(DSharpStringResources.EXTERN_IMPLEMENTATION_FOUND_ERROR, methodNode);

                    return false;
                }

                if ((methodNode.Modifiers & (Modifiers.Static | Modifiers.AccessMask)) !=
                    (implMethodNode.Modifiers & (Modifiers.Static | Modifiers.AccessMask)))
                {
                    errorHandler.ReportNodeValidationError(DSharpStringResources.EXTERN_STATIC_MEMBER_MISMATCH_ERROR, methodNode);
                }
            }


            return true;
        }
    }
}
