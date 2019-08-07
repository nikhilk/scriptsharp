// TypeParameterConstraintNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.CodeModel.Names;

namespace DSharp.Compiler.CodeModel.Types
{
    internal sealed class TypeParameterConstraintNode : ParseNode
    {
        private bool hasConstructorConstraint;
        private ParseNodeList typeConstraints;

        private AtomicNameNode typeParameter;

        public TypeParameterConstraintNode(AtomicNameNode typeParameter, ParseNodeList typeConstraints,
                                           bool hasConstructorConstraint)
            : base(ParseNodeType.ConstraintClause, typeParameter.Token)
        {
            this.typeParameter = typeParameter;
            this.typeConstraints = typeConstraints;
            this.hasConstructorConstraint = hasConstructorConstraint;
        }

        internal ParseNodeList TypeConstraints => typeConstraints;

        internal AtomicNameNode TypeParameter => typeParameter;
    }
}
