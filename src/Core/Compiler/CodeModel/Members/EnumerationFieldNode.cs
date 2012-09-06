// EnumerationFieldNode.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal class EnumerationFieldNode : MemberNode {

        private ParseNodeList _attributes;
        private AtomicNameNode _name;
        private object _value;

        public EnumerationFieldNode(ParseNodeList attributes, AtomicNameNode name,
                                    ParseNode value)
            : base(ParseNodeType.EnumerationFieldDeclaration, name.token) {
            _attributes = GetParentedNodeList(AttributeNode.GetAttributeList(attributes));
            _name = (AtomicNameNode)GetParentedNode(name);

            if (value is LiteralNode) {
                LiteralNode literalNode = (LiteralNode)value;
                _value = ((LiteralToken)literalNode.Token).LiteralValue;
            }
            else {
                // TODO: Clearly we need something more general...
                //       C# allows expressions. Likely expressions to be used
                //       include negative values, binary OR'd values,
                //       expressions involving other enum members (esp. hard to deal with)
                // For now, just adding support for negative numbers, as
                // everything else can be worked around in source code.

                UnaryExpressionNode expressionNode = value as UnaryExpressionNode;
                if ((expressionNode != null) && (expressionNode.Operator == TokenType.Minus) &&
                    (expressionNode.Child is LiteralNode)) {

                    try {
                        LiteralToken literalToken =
                            (LiteralToken)((LiteralNode)expressionNode.Child).Token;
                        int numericValue = (int)Convert.ChangeType(literalToken.LiteralValue, typeof(int));

                        _value = -numericValue;
                    }
                    catch {
                    }
                }
            }
        }

        public override ParseNodeList Attributes {
            get {
                return _attributes;
            }
        }

        public override Modifiers Modifiers {
            get {
                return Modifiers.Public;
            }
        }

        public override string Name {
            get {
                return _name.Name;
            }
        }

        public override ParseNode Type {
            get {
                return null;
            }
        }

        public object Value {
            get {
                return _value;
            }
        }
    }
}
