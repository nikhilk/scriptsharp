// CompilationUnitNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class CompilationUnitNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            CompilationUnitNode compilationUnitNode = (CompilationUnitNode)node;

            foreach (AttributeBlockNode attribBlock in compilationUnitNode.Attributes) {
                AttributeNode scriptNamespaceNode = AttributeNode.FindAttribute(attribBlock.Attributes, "ScriptNamespace");
                if (scriptNamespaceNode != null) {
                    string scriptNamespace = (string)((LiteralNode)scriptNamespaceNode.Arguments[0]).Value;

                    if (Utility.IsValidScriptNamespace(scriptNamespace) == false) {
                        errorHandler.ReportError("A script namespace must be a valid script identifier.",
                                                 scriptNamespaceNode.Token.Location);
                    }
                }
            } 

            foreach (ParseNode childNode in compilationUnitNode.Members) {
                if (!(childNode is NamespaceNode)) {
                    errorHandler.ReportError("Non-namespaced types are not supported.",
                                             childNode.Token.Location);
                    return false;
                }
            }

            return true;
        }
    }
}
