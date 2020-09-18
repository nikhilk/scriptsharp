using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class EnumValueRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private SemanticModel sem;

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            var newRoot = Visit(root) as CompilationUnitSyntax;
            return newRoot;
        }

        public override SyntaxNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            if (node.EqualsValue is null)
            {
                if (sem.GetDeclaredSymbol(node) is IFieldSymbol fieldSymbol)
                {
                    int value = Convert.ToInt32(fieldSymbol.ConstantValue);
                    return node.WithEqualsValue(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value))));
                }
            }

            return base.VisitEnumMemberDeclaration(node);
        }
    }
}
