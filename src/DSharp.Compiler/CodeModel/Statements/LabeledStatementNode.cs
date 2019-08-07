// LabeledStatementNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;

namespace DSharp.Compiler.CodeModel.Statements
{
    // NOTE: Not supported in conversion
    internal class LabeledStatementNode : StatementNode
    {
        private AtomicNameNode label;
        private ParseNode statement;

        public LabeledStatementNode(AtomicNameNode label, ParseNode statement)
            : base(ParseNodeType.LabeledStatement, label.Token)
        {
            this.label = (AtomicNameNode) GetParentedNode(label);
            this.statement = GetParentedNode(statement);
        }
    }
}