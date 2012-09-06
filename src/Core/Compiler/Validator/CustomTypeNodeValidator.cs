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

            bool restrictToMethodMembers = false;
            bool hasCodeMembers = false;
            ParseNode codeMemberNode = null;

            AttributeNode importedTypeAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "Imported");
            if (importedTypeAttribute != null) {
                // This is an imported type definition... we'll assume its valid, since
                // the set of restrictions for such types is fewer, and different, so
                // for now that translates into skipping the members.

                return false;
            }

            AttributeNode scriptNamespaceNode = AttributeNode.FindAttribute(typeNode.Attributes, "ScriptNamespace");
            if (scriptNamespaceNode != null) {
                string scriptNamespace = (string)((LiteralNode)scriptNamespaceNode.Arguments[0]).Value;

                if (Utility.IsValidScriptNamespace(scriptNamespace) == false) {
                    errorHandler.ReportError("A script namespace must be a valid script identifier.",
                                             scriptNamespaceNode.Token.Location);
                }
            }

            if (typeNode.Type == TokenType.Struct) {
                errorHandler.ReportError("Struct types are not supported. Use classes annotated with the Record metadata attribute.",
                                         typeNode.Token.Location);
                return false;
            }

            if (((typeNode.Modifiers & Modifiers.Partial) != 0) &&
                (typeNode.Type != TokenType.Class)) {
                errorHandler.ReportError("Partial types can only be classes, not enumerations or interfaces.",
                                         typeNode.Token.Location);
                return false;
            }

            if ((typeNode.Type == TokenType.Interface) &&
                (typeNode.BaseTypes.Count != 0)) {
                errorHandler.ReportError("Derived interface types are not supported.",
                                         typeNode.Token.Location);
                return false;
            }

            if (typeNode.Type == TokenType.Class) {
                if (typeNode.BaseTypes.Count != 0) {
                    NameNode baseTypeNameNode = typeNode.BaseTypes[0] as NameNode;

                    if (baseTypeNameNode != null) {
                        if (String.CompareOrdinal(baseTypeNameNode.Name, "Record") == 0) {
                            if ((typeNode.Modifiers & Modifiers.Sealed) == 0) {
                                errorHandler.ReportError("Classes derived from the Record base class must be marked as sealed.",
                                                         typeNode.Token.Location);
                            }

                            if (typeNode.BaseTypes.Count != 1) {
                                errorHandler.ReportError("Classes derived from the Record base class cannot implement interfaces.",
                                                         typeNode.Token.Location);
                            }
                        }
                        else if (String.CompareOrdinal(baseTypeNameNode.Name, "TestClass") == 0) {
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

                AttributeNode globalMethodsAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "GlobalMethods");
                if (globalMethodsAttribute != null) {
                    restrictToMethodMembers = true;

                    if ((typeNode.Modifiers & Modifiers.Static) == 0) {
                        errorHandler.ReportError("GlobalMethods attribute can only be set on static classes.",
                                                 typeNode.Token.Location);
                    }
                }

                AttributeNode mixinAttribute = AttributeNode.FindAttribute(typeNode.Attributes, "Mixin");
                if (mixinAttribute != null) {
                    restrictToMethodMembers = true;

                    if ((typeNode.Modifiers & Modifiers.Static) == 0) {
                        errorHandler.ReportError("Mixin attribute can only be set on static classes.",
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

                    if (restrictToMethodMembers &&
                        (memberNode.NodeType != ParseNodeType.MethodDeclaration) &&
                        (memberNode.NodeType != ParseNodeType.ConstructorDeclaration)) {
                        errorHandler.ReportError("Classes marked with GlobalMethods or Mixin attribute should only have methods.",
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

                    bool preserveCase = (AttributeNode.FindAttribute(memberNode.Attributes, "PreserveCase") != null);
                    if (Utility.IsKeyword(name, /* testCamelCase */ (preserveCase == false))) {
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

            if ((typeNode.Type == TokenType.Struct) && hasCodeMembers) {
                errorHandler.ReportError("A struct type is limited to field and constructor members.",
                                         codeMemberNode.Token.Location);
            }

            return true;
        }
    }
}
