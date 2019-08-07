// MultiPartNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Names
{
    internal sealed class MultiPartNameNode : NameNode
    {
        public MultiPartNameNode(Token token, ParseNodeList names)
            : base(ParseNodeType.MultiPartName, token)
        {
            List = GetParentedNodeList(names);
        }

        protected override ParseNodeList List { get; }
    }
}