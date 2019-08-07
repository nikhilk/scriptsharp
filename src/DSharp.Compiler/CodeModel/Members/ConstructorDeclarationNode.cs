// ConstructorDeclarationNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.CodeModel.Members
{
    internal sealed class ConstructorDeclarationNode : MethodDeclarationNode
    {
        public ConstructorDeclarationNode(Token token,
                                          ParseNodeList attributes,
                                          Modifiers modifiers,
                                          AtomicNameNode name,
                                          ParseNodeList formals,
                                          bool callBase,
                                          ParseNode baseArguments,
                                          BlockStatementNode body)
            : base(ParseNodeType.ConstructorDeclaration, token, attributes, modifiers, /* return type */ null, name,
                formals, body)
        {
            CallBase = callBase;
            BaseArguments = GetParentedNode(baseArguments);
        }

        public ParseNode BaseArguments { get; }

        public bool CallBase { get; }
    }
}