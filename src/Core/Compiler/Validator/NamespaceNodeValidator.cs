// NamespaceNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class NamespaceNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            NamespaceNode namespaceNode = (NamespaceNode)node;

            bool valid = true;

            foreach (ParseNode childNode in namespaceNode.Members) {
                if (childNode is NamespaceNode) {
                    errorHandler.ReportError("Nested namespaces are not supported.",
                                             childNode.Token.Location);
                    valid = false;
                }
            }

            if (namespaceNode.Name.Equals("System") ||
                namespaceNode.Name.StartsWith("System.")) {

                // Usage of the System namespace is limited to imported types.

                foreach (ParseNode childNode in namespaceNode.Members) {
                    bool allowed = false;

                    if (childNode is UserTypeNode) {
                        ParseNodeList attributes = ((UserTypeNode)childNode).Attributes;
                        if (AttributeNode.FindAttribute(attributes, "ScriptImport") != null 
                            || (AttributeNode.FindAttribute(attributes, "ScriptAllowSystemNamespace") != null)) {
                            allowed = true;
                        }
                    }

                    if (allowed == false) {
                        errorHandler.ReportError("Only types marked as Imported are allowed within the System namespace.",
                                                 namespaceNode.Token.Location);
                        valid = false;
                        break;
                    }
                }
            }

            return valid;
        }
    }
}
