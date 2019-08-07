// TryNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class TryNode : StatementNode
    {
        public TryNode(Token token,
                       ParseNode body,
                       ParseNodeList catchClauses,
                       ParseNode finallyClause)
            : base(ParseNodeType.Try, token)
        {
            Body = GetParentedNode(body);
            CatchClauses = GetParentedNodeList(catchClauses);
            FinallyClause = GetParentedNode(finallyClause);
        }

        public ParseNode Body { get; }

        public ParseNodeList CatchClauses { get; }

        public ParseNode FinallyClause { get; }
    }
}