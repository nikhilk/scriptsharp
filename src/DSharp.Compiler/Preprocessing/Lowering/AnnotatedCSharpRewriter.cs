using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class AnnotatedCSharpRewriter : CSharpSyntaxRewriter, ILowerer
    {
        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            return Visit(root) as CompilationUnitSyntax;
        }

        public override SyntaxNode Visit(SyntaxNode node)
        {
            if(node is null)
            {
                return base.Visit(node);
            }

            var annotations = new[] {
                GetAnnotation("OriginalLineStart", node, p => p.StartLinePosition.Line),
                GetAnnotation("OriginalLineEnd", node, p => p.EndLinePosition.Line),
                GetAnnotation("OriginalColumnStart", node, p => p.StartLinePosition.Character),
                GetAnnotation("OriginalColumnEnd", node, p => p.EndLinePosition.Character),
            };

            return base.Visit(node).WithAdditionalAnnotations(annotations);
        }

        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            var annotations = new[] {
                GetAnnotation("OriginalLineStart", token, p => p.StartLinePosition.Line),
                GetAnnotation("OriginalLineEnd", token, p => p.EndLinePosition.Line),
                GetAnnotation("OriginalColumnStart", token, p => p.StartLinePosition.Character),
                GetAnnotation("OriginalColumnEnd", token, p => p.EndLinePosition.Character),
            };

            return base.VisitToken(token).WithAdditionalAnnotations(annotations);
        }

        private static SyntaxAnnotation GetAnnotation(string name, SyntaxNode node, Func<FileLinePositionSpan, int?> func)
        {
            var lineSpan = node.GetLocation().GetLineSpan();
            return node.GetAnnotations(name).FirstOrDefault() ?? new SyntaxAnnotation(name, func.Invoke(lineSpan).ToString());
        }

        private static SyntaxAnnotation GetAnnotation(string name, SyntaxToken token, Func<FileLinePositionSpan, int?> func)
        {
            var lineSpan = token.GetLocation().GetLineSpan();
            return token.GetAnnotations(name).FirstOrDefault() ?? new SyntaxAnnotation(name, func.Invoke(lineSpan).ToString());
        }
    }
}
