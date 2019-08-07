// SwitchSectionNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Statements
{
    internal sealed class SwitchSectionNode : StatementNode
    {
        public SwitchSectionNode(Token token,
                                 ParseNodeList labels,
                                 ParseNodeList statements)
            : base(ParseNodeType.SwitchSection, token)
        {
            Labels = GetParentedNodeList(labels);
            Statements = GetParentedNodeList(statements);
        }

        public ParseNodeList Labels { get; }

        public ParseNodeList Statements { get; }
    }
}