// UnsupportedParseNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    /// <summary>
    ///     Raises errors for unsupported and not-yet-implemented C# constructs.
    /// </summary>
    internal sealed class UnsupportedParseNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            string featureName = string.Empty;

            switch (node.NodeType)
            {
                case ParseNodeType.PointerType:
                    featureName = "Pointer types";

                    break;
                case ParseNodeType.OperatorDeclaration:
                    featureName = "Operator overloads";

                    break;
                case ParseNodeType.DestructorDeclaration:
                    featureName = "Type destructors";

                    break;
                case ParseNodeType.Goto:
                    featureName = "Goto statements";

                    break;
                case ParseNodeType.Lock:
                    featureName = "Lock statements";

                    break;
                case ParseNodeType.UnsafeStatement:
                    featureName = "Unsafe statements";

                    break;
                case ParseNodeType.LabeledStatement:
                    featureName = "Labeled statements";

                    break;
                case ParseNodeType.YieldReturn:
                    featureName = "Yield return statements";

                    break;
                case ParseNodeType.YieldBreak:
                    featureName = "Yield break statements";

                    break;
                case ParseNodeType.Checked:
                    featureName = "Checked expressions";

                    break;
                case ParseNodeType.Unchecked:
                    featureName = "Unchecked expressions";

                    break;
                case ParseNodeType.Sizeof:
                    featureName = "Sizeof expressions";

                    break;
                case ParseNodeType.Fixed:
                    featureName = "Fixed expressions";

                    break;
                case ParseNodeType.StackAlloc:
                    featureName = "Stackalloc expressions";

                    break;
                case ParseNodeType.DefaultValueExpression:
                    featureName = "Default value expressions";

                    break;
                case ParseNodeType.ExternAlias:
                    featureName = "Extern aliases";

                    break;
                case ParseNodeType.AliasQualifiedName:
                    featureName = "Alias-qualified identifiers";

                    break;
                case ParseNodeType.ConstraintClause:
                    featureName = "Generic type constraints";

                    break;
                case ParseNodeType.GenericName:
                    featureName = "Generic types";

                    break;
            }

            errorHandler.ReportUnsupportedFeatureError(featureName, node);

            return false;
        }
    }
}
