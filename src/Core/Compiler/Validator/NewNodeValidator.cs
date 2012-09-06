// NewNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class NewNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            NewNode newNode = (NewNode)node;

            // TODO: This is somewhat hacky - it only looks for any type named Dictionary
            //       rather than resolving the type and checking if its actually
            //       System.Dictionary.
            //       This is because validators don't have a reference to the SymbolSet.

            NameNode typeNode = newNode.TypeReference as NameNode;
            if ((typeNode != null) && (typeNode.Name.Equals("Dictionary"))) {
                if (newNode.Arguments != null) {
                    Debug.Assert(newNode.Arguments is ExpressionListNode);
                    ParseNodeList arguments = ((ExpressionListNode)newNode.Arguments).Expressions;

                    if (arguments.Count != 0) {
                        if (arguments.Count % 2 != 0) {
                            errorHandler.ReportError("Missing value parameter for the last name parameter in Dictionary instantiation.",
                                                     newNode.Token.Location);
                        }

                        for (int i = 0; i < arguments.Count; i += 2) {
                            ParseNode nameArgumentNode = arguments[i];
                            if ((nameArgumentNode.NodeType != ParseNodeType.Literal) ||
                                (((LiteralNode)nameArgumentNode).Literal.LiteralType != LiteralTokenType.String)) {
                                errorHandler.ReportError("Name parameters in Dictionary instantiation must be string literals.",
                                                         nameArgumentNode.Token.Location);
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
