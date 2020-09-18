using System.Linq;
using DSharp.Compiler.Errors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class LambdaRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private SemanticModel sem;
        private readonly IErrorHandler errorHandler;

        public LambdaRewriter(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            return Visit(root) as CompilationUnitSyntax;
        }

        public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            var symb = sem.GetSymbolInfo(node).Symbol as IMethodSymbol;
            var newNode = (SimpleLambdaExpressionSyntax)base.VisitSimpleLambdaExpression(node);
            return AnonymousMethodExpression(
                parameterList: ParameterList(SingletonSeparatedList(FormatParam(node.Parameter, 0, symb))),
                 body: GetFunctionBody(node.Body, newNode.Body)
            );
        }

        public override SyntaxNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            var symb = sem.GetSymbolInfo(node).Symbol as IMethodSymbol;
            var newNode = (ParenthesizedLambdaExpressionSyntax)base.VisitParenthesizedLambdaExpression(node);
            var paramSyntax = node.ParameterList.Parameters.Select((p, i) => FormatParam(p, i, symb));
            return AnonymousMethodExpression(
                parameterList: node.ParameterList.WithParameters(SeparatedList(paramSyntax)),
                body: GetFunctionBody(node.Body, newNode.Body)
            );
        }

        private CSharpSyntaxNode GetFunctionBody(CSharpSyntaxNode node, CSharpSyntaxNode newNode)
        {
            if (newNode is ExpressionSyntax expression)
            {
                if (ExpressionHasType((ExpressionSyntax)node))
                {
                    return Block(ReturnStatement(expression.WithLeadingTrivia(Whitespace(" "))));
                }
                else
                {
                    return Block(ExpressionStatement(expression));
                }
            }

            if (newNode is BlockSyntax block)
            {
                return block;
            }

            if (newNode is StatementSyntax statement)
            {
                return Block(statement);
            }

            errorHandler.ReportExpressionError("unable to rewrite lambda body", node);
            return node;
        }

        private bool ExpressionHasType(ExpressionSyntax expression)
        {
            return sem.GetTypeInfo(expression).ConvertedType is ITypeSymbol ts && ts.Kind != SymbolKind.ErrorType;
        }

        private static ParameterSyntax FormatParam(ParameterSyntax p, int i, IMethodSymbol symb)
        {
            var displayFormat = new SymbolDisplayFormat(genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters);
            var typeName = symb.Parameters[i].Type.ToDisplayString(displayFormat);
            return p.WithType(ParseTypeName(typeName).WithTrailingTrivia(Whitespace(" ")));
        }
    }
}
