using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;

namespace DSharp.Compiler.CodeModel.Members
{
    internal static class MethodDeclarationNodeExtensions
    {
        internal static bool IsGenericReturnType(this MethodDeclarationNode methodDeclarationNode)
        {
            if (methodDeclarationNode?.Type == null)
            {
                return false;
            }

            var returnType = ResolveReturnType(methodDeclarationNode.Type);

            var collectedReturnTokens = CollectReturnTokens(returnType)
                .Where(token => token is IdentifierToken)
                .Cast<IdentifierToken>();

            return AreIdentifiersInTypeParameters(collectedReturnTokens, methodDeclarationNode.TypeParameters.Cast<TypeParameterNode>());
        }

        private static IEnumerable<Token> CollectReturnTokens(ParseNode returnType)
        {
            List<Token> tokens = new List<Token>();
            if (returnType is GenericNameNode genericNameNode)
            {
                tokens.Add(genericNameNode.Identifier);
                foreach (var genericTypeNode in genericNameNode.TypeArguments)
                {
                    var genericReturnTokens = CollectReturnTokens(genericTypeNode);
                    tokens.AddRange(genericReturnTokens);
                }
            }
            else if (returnType.Token is IdentifierToken returnIdentifierToken)
            {
                tokens.Add(returnIdentifierToken);
            }

            return tokens;
        }

        private static bool AreIdentifiersInTypeParameters(IEnumerable<IdentifierToken> identifiers, IEnumerable<TypeParameterNode> typeParameterNodes)
        {
            if(!typeParameterNodes.Any())
            {
                return false;
            }

            foreach (var typeParameter in typeParameterNodes)
            {
                var typeParameterToken = (IdentifierToken)typeParameter.NameNode.Token;

                if(!identifiers.Any(identifier => identifier.Symbol.Text == typeParameterToken.Symbol.Text))
                {
                    return false;
                }
            }

            return true;
        }

        private static ParseNode ResolveReturnType(ParseNode type)
        {
            if (type is ArrayTypeNode arrayTypeNode)
            {
                return arrayTypeNode.BaseType;
            }

            return type;
        }
    }
}
