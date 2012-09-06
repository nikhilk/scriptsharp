// TypeParameterConstraintNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class TypeParameterConstraintNode : ParseNode {

        private AtomicNameNode _typeParameter;
        private ParseNodeList _typeConstraints;
        private bool _hasConstructorConstraint;

        public TypeParameterConstraintNode(AtomicNameNode typeParameter, ParseNodeList typeConstraints,
                                    bool hasConstructorConstraint)
            : base(ParseNodeType.ConstraintClause, typeParameter.token) {
            _typeParameter = typeParameter;
            _typeConstraints = typeConstraints;
            _hasConstructorConstraint = hasConstructorConstraint;
        }
    }
}
