// MethodDeclarationNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class MethodDeclarationNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            MethodDeclarationNode methodNode = (MethodDeclarationNode)node;

            if (((methodNode.Modifiers & Modifiers.Static) == 0) &&
                ((methodNode.Modifiers & Modifiers.New) != 0)) {
                errorHandler.ReportError("The new modifier is not supported on instance members.",
                                         methodNode.Token.Location);
                return false;
            }

            if ((methodNode.Modifiers & Modifiers.Extern) != 0) {
                CustomTypeNode typeNode = (CustomTypeNode)methodNode.Parent;
                MethodDeclarationNode implMethodNode = null;

                if (methodNode.NodeType == ParseNodeType.MethodDeclaration) {
                    foreach (MemberNode memberNode in typeNode.Members) {
                        if ((memberNode.NodeType == ParseNodeType.MethodDeclaration) &&
                            ((memberNode.Modifiers & Modifiers.Extern) == 0) &&
                            memberNode.Name.Equals(methodNode.Name, StringComparison.Ordinal)) {
                            implMethodNode = (MethodDeclarationNode)memberNode;
                            break;
                        }
                    }
                }
                else if (methodNode.NodeType == ParseNodeType.ConstructorDeclaration) {
                    foreach (MemberNode memberNode in typeNode.Members) {
                        if ((memberNode.NodeType == ParseNodeType.ConstructorDeclaration) &&
                            ((memberNode.Modifiers & Modifiers.Extern) == 0)) {
                            implMethodNode = (MethodDeclarationNode)memberNode;
                            break;
                        }
                    }
                }

                if (implMethodNode == null) {
                    errorHandler.ReportError("Extern methods used to declare alternate signatures should have a corresponding non-extern implementation as well.",
                                             methodNode.Token.Location);
                    return false;
                }

                if ((methodNode.Modifiers & (Modifiers.Static | Modifiers.AccessMask)) !=
                    (implMethodNode.Modifiers & (Modifiers.Static | Modifiers.AccessMask))) {
                    errorHandler.ReportError("The implemenation method and associated alternate signature methods should have the same access type.",
                                             methodNode.Token.Location);
                }
            }

            return true;
        }
    }
}
