using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Expressions
{
    internal class ObjectInitializerNode : ExpressionNode
    {
        public ObjectInitializerNode(Token token, NewNode typeInitialiser, ParseNodeList objectAssignmentExpressions)
            : base(ParseNodeType.ObjectInitializer, token)
        {
            NewNodeExpression = (NewNode)GetParentedNode(typeInitialiser);
            ObjectAssignmentExpressions = GetParentedNodeList(objectAssignmentExpressions);
        }

        public NewNode NewNodeExpression { get; }

        public ParseNodeList ObjectAssignmentExpressions { get; }
    }
}
