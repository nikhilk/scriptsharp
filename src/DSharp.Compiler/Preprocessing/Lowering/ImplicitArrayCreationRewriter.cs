using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class ImplicitArrayCreationRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private static readonly SymbolDisplayFormat displayFormat = new SymbolDisplayFormat(
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable | SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        );

        private SemanticModel sem;

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            var newRoot = Visit(root) as CompilationUnitSyntax;
            return newRoot;
        }

        public override SyntaxNode VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            var type = sem.GetTypeInfo(node).Type;
            var newNode = (ImplicitArrayCreationExpressionSyntax)base.VisitImplicitArrayCreationExpression(node);

            var arrayType = ArrayType(ParseTypeName(type.ToDisplayString(displayFormat)).WithLeadingTrivia(Space));
            return ArrayCreationExpression(arrayType)
                .WithInitializer(newNode.Initializer)
                .WithTriviaFrom(newNode);
        }
    }
}
