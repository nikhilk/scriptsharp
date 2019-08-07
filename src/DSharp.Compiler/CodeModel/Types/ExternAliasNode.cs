// ExternAliasNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Types
{
    // NOTE: This is supported in conversion
    internal sealed class ExternAliasNode : ParseNode
    {
        private NameNode aliasName;

        public ExternAliasNode(Token token, AtomicNameNode aliasName)
            : base(ParseNodeType.ExternAlias, token)
        {
            this.aliasName = (AtomicNameNode) GetParentedNode(aliasName);
        }
    }
}