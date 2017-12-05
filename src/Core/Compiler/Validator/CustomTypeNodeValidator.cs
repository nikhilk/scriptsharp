// CustomTypeNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    internal sealed class CustomTypeNodeValidator : IParseNodeValidator {

        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler) {
            CustomTypeNode typeNode = (CustomTypeNode)node;

            bool extensionRestrictions = false;
            bool moduleRestrictions = false;
            bool recordRestrictions = false;
            bool hasCodeMembers = false;
            ParseNode codeMemberNode = null;

            AttributeNode importedTypeAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "ScriptImport");
            if (importedTypeAttribute != null) {
                // This is an imported type definition... we'll assume its valid, since
                // the set of restrictions for such types is fewer, and different, so
                // for now that translates into skipping the members.

                return false;
            }

            if (((typeNode.Modifiers & Modifiers.Partial) != 0) &&
                (typeNode.Type != TokenType.Class)) {
                errorHandler.ReportError("Partial types can only be classes, not enumerations or interfaces.",
                                         typeNode.Token.Location);
                return false;
            }

            if (typeNode.Type == TokenType.Class) {
                if (typeNode.BaseTypes.Count != 0) {
                    NameNode baseTypeNameNode = typeNode.BaseTypes[0] as NameNode;

                    if (baseTypeNameNode != null) {
                        if (String.CompareOrdinal(baseTypeNameNode.Name, "TestClass") == 0) {
                            if ((typeNode.Modifiers & Modifiers.Internal) == 0) {
                                errorHandler.ReportError("Classes derived from TestClass must be marked as internal.",
                                                         typeNode.Token.Location);
                            }
                            if ((typeNode.Modifiers & Modifiers.Static) != 0) {
                                errorHandler.ReportError("Classes derived from TestClass must not be marked as static.",
                                                         typeNode.Token.Location);
                            }
                            if ((typeNode.Modifiers & Modifiers.Sealed) == 0) {
                                errorHandler.ReportError("Classes derived from TestClass must be marked as sealed.",
                                                         typeNode.Token.Location);
                            }
                            if (typeNode.BaseTypes.Count != 1) {
                                errorHandler.ReportError("Classes derived from TestClass cannot implement interfaces.",
                                                         typeNode.Token.Location);
                            }
                        }
                    }
                }

                AttributeNode objectAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "ScriptObject");
                if (objectAttribute != null) {
                    if ((typeNode.Modifiers & Modifiers.Sealed) == 0) {
                        errorHandler.ReportError("ScriptObject attribute can only be set on sealed classes.",
                                                 typeNode.Token.Location);
                    }

                    if (typeNode.BaseTypes.Count != 0) {
                        errorHandler.ReportError("Classes marked with ScriptObject must not derive from another class or implement interfaces.",
                                                 typeNode.Token.Location);
                    }

                    recordRestrictions = true;
                }

                AttributeNode extensionAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "ScriptExtension");
                if (extensionAttribute != null) {
                    extensionRestrictions = true;

                    if ((typeNode.Modifiers & Modifiers.Static) == 0) {
                        errorHandler.ReportError("ScriptExtension attribute can only be set on static classes.",
                                                 typeNode.Token.Location);
                    }

                    if ((extensionAttribute.Arguments.Count != 1) ||
                        !(extensionAttribute.Arguments[0] is LiteralNode) ||
                        !(((LiteralNode)extensionAttribute.Arguments[0]).Value is string) ||
                        String.IsNullOrEmpty((string)((LiteralNode)extensionAttribute.Arguments[0]).Value)) {
                        errorHandler.ReportError("ScriptExtension attribute declaration must specify the object being extended.",
                                                 typeNode.Token.Location);
                    }
                }

                AttributeNode moduleAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "ScriptModule");
                if (moduleAttribute != null) {
                    moduleRestrictions = true;

                    if (((typeNode.Modifiers & Modifiers.Static) == 0) ||
                        ((typeNode.Modifiers & Modifiers.Internal) == 0)) {
                        errorHandler.ReportError("ScriptModule attribute can only be set on internal static classes.",
                                                 typeNode.Token.Location);
                    }
                }
            }

            if ((typeNode.Members != null) && (typeNode.Members.Count != 0)) {
                Dictionary<string, object> memberNames = new Dictionary<string, object>();
                bool hasCtor = false;

                foreach (ParseNode genericMemberNode in typeNode.Members) {
                    if (!(genericMemberNode is MemberNode)) {
                        errorHandler.ReportError("Only members are allowed inside types. Nested types are not supported.",
                                                 node.Token.Location);
                        continue;
                    }

                    MemberNode memberNode = (MemberNode)genericMemberNode;

                    if ((memberNode.Modifiers & Modifiers.Extern) != 0) {
                        // Extern methods are placeholders for creating overload signatures
                        continue;
                    }

                    if (extensionRestrictions && (memberNode.NodeType != ParseNodeType.MethodDeclaration)) {
                        errorHandler.ReportError("Classes marked with ScriptExtension attribute should only have methods.",
                                                 memberNode.Token.Location);
                    }

                    if (moduleRestrictions && (memberNode.NodeType != ParseNodeType.ConstructorDeclaration)) {
                        errorHandler.ReportError("Classes marked with ScriptModule attribute should only have a static constructor.",
                                                 memberNode.Token.Location);
                    }

                    if (recordRestrictions &&
                        (((memberNode.Modifiers & Modifiers.Static) != 0) ||
                         ((memberNode.NodeType != ParseNodeType.ConstructorDeclaration) &&
                          (memberNode.NodeType != ParseNodeType.FieldDeclaration)))) {
                        errorHandler.ReportError("Classes marked with ScriptObject attribute should only have a constructor and field members.",
                                                 memberNode.Token.Location);
                    }

                    if (memberNode.NodeType == ParseNodeType.ConstructorDeclaration) {
                        if ((memberNode.Modifiers & Modifiers.Static) == 0) {
                            if (hasCtor) {
                                errorHandler.ReportError("Constructor overloads are not supported.",
                                                         memberNode.Token.Location);
                            }
                            hasCtor = true;
                        }
                        continue;
                    }
                    if (memberNode.NodeType == ParseNodeType.OperatorDeclaration) {
                        // Operators don't have a name
                        continue;
                    }

                    string name = memberNode.Name;
                    if (memberNames.ContainsKey(name)) {
                        errorHandler.ReportError("Duplicate-named member. Method overloads are not supported.",
                                                 memberNode.Token.Location);
                    }

                    memberNames[name] = null;

                    string nameToValidate = name;
                    bool preserveCase = false;
                    AttributeNode nameAttribute = AttributeNode.FindAttribute(memberNode.Attributes, "ScriptName");
                    if ((nameAttribute != null) && (nameAttribute.Arguments.Count != 0)) {
                        foreach (ParseNode argNode in nameAttribute.Arguments) {
                            if (argNode.NodeType == ParseNodeType.Literal) {
                                nameToValidate = (string)((LiteralNode)argNode).Value;
                            }
                            else if (argNode.NodeType == ParseNodeType.BinaryExpression) {
                                if (String.CompareOrdinal(((NameNode)((BinaryExpressionNode)argNode).LeftChild).Name, "PreserveCase") == 0) {
                                    preserveCase = (bool)((LiteralNode)((BinaryExpressionNode)argNode).RightChild).Value;
                                }
                            }
                        }
                    }

                    if (Utility.IsKeyword(nameToValidate, /* testCamelCase */ (preserveCase == false))) {
                        errorHandler.ReportError("Invalid member name. Member names should not use keywords.",
                                                 memberNode.Token.Location);
                    }
             
                    if (hasCodeMembers == false) {
                        hasCodeMembers = ((memberNode.NodeType == ParseNodeType.PropertyDeclaration) ||
                                          (memberNode.NodeType == ParseNodeType.MethodDeclaration) ||
                                          (memberNode.NodeType == ParseNodeType.EventDeclaration) ||
                                          (memberNode.NodeType == ParseNodeType.IndexerDeclaration));
                        codeMemberNode = memberNode;
                    }
                }
            }

            return true;
        }
    }
}
