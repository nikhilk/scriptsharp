// GenericNameNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Names
{
    internal sealed class GenericNameNode : AtomicNameNode
    {
        public GenericNameNode(IdentifierToken name, ParseNodeList typeArguments)
            : base(ParseNodeType.GenericName, name)
        {
            TypeArguments = typeArguments;
        }

        public ParseNodeList TypeArguments { get; }

        public string FullGenericName
            => $"{Name}`{TypeArguments.Count}";
    }
}
