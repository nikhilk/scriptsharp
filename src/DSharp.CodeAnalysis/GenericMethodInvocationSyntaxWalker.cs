using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DSharp.CodeAnalysis.Diagnostics
{
    public class GenericMethodInvocationSyntaxWalker : CSharpSyntaxWalker
    {
        private readonly SemanticModel semanticModel;

        public List<GenericMethodInvocation> FoundInvocations { get; } = new List<GenericMethodInvocation>();

        public GenericMethodInvocationSyntaxWalker(SemanticModel semanticModel, SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node)
            : base(depth)
        {
            this.semanticModel = semanticModel;
        }

        public GenericMethodInvocationSyntaxWalker(SemanticModel semanticModel)
        {
            this.semanticModel = semanticModel;
        }

        public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            var symbolInfo = semanticModel.GetSymbolInfo(node);
            IMethodSymbol methodSymbol = symbolInfo.Symbol as IMethodSymbol;

            if (methodSymbol != null && methodSymbol.IsGenericMethod)
            {
                FoundInvocations.Add(new GenericMethodInvocation
                {
                    Name = node.Name,
                    HasScriptIgnoreGenericArgumentsAttribute = methodSymbol.HasAttributeWithName(Consts.ScriptIgnoreGenericArgumentsAttribute),
                    Node = node
                });
            }

            base.VisitMemberAccessExpression(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var symbolInfo = semanticModel.GetSymbolInfo(node);
            IMethodSymbol methodSymbol = symbolInfo.Symbol as IMethodSymbol;

            if (methodSymbol.IsGenericMethod && node.Expression is NameSyntax nameSyntax)
            {
                FoundInvocations.Add(new GenericMethodInvocation
                {
                    Name = nameSyntax,
                    HasScriptIgnoreGenericArgumentsAttribute = methodSymbol.HasAttributeWithName(Consts.ScriptIgnoreGenericArgumentsAttribute),
                    Node = node
                });
            }

            base.VisitInvocationExpression(node);
        }

        public class GenericMethodInvocation
        {
            public NameSyntax Name { get; set; }

            public CSharpSyntaxNode Node { get; set; }

            public bool HasScriptIgnoreGenericArgumentsAttribute { get; set; }
        }
    }
}
