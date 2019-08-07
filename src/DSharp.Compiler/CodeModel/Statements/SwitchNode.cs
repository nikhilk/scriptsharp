// SwitchNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class SwitchNode : StatementNode
    {
        public SwitchNode(Token token,
                          ParseNode condition,
                          ParseNodeList cases)
            : base(ParseNodeType.Switch, token)
        {
            Condition = GetParentedNode(condition);
            Cases = GetParentedNodeList(cases);
        }

        public ParseNodeList Cases { get; }

        public ParseNode Condition { get; }
    }
}