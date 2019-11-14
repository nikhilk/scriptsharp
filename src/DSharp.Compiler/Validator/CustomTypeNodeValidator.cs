using System.Collections.Generic;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal sealed class CustomTypeNodeValidator : IParseNodeValidator
    {
        bool IParseNodeValidator.Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler)
        {
            CustomTypeNode typeNode = (CustomTypeNode)node;

            bool recordRestrictions = false;
            bool hasCodeMembers = false;
            ParseNode codeMemberNode = null;

            AttributeNode importedTypeAttribute = AttributeNode.FindAttribute(typeNode.Attributes, DSharpStringResources.SCRIPT_IMPORT_ATTRIBUTE);

            if (importedTypeAttribute != null)
            {
                // This is an imported type definition... we'll assume its valid, since
                // the set of restrictions for such types is fewer, and different, so
                // for now that translates into skipping the members.

                return false;
            }

            if ((typeNode.Modifiers & Modifiers.New) != 0)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.NEW_KEYWORD_ON_TYPE_UNSUPPORTED, typeNode);

                return false;
            }

            if ((typeNode.Modifiers & (Modifiers.Private | Modifiers.Protected)) != 0)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.ACCESS_MODIFIER_ON_TYPE_UNSUPPORTED, typeNode);

                return false;
            }

            if ((typeNode.Modifiers & Modifiers.Partial) != 0 &&
                typeNode.Type != TokenType.Class)
            {
                errorHandler.ReportNodeValidationError(DSharpStringResources.UNSUPPORTED_PARTIAL_TYPE, typeNode);

                return false;
            }

            if (typeNode.Type == TokenType.Class)
            {
                AttributeNode objectAttribute = AttributeNode.FindAttribute(typeNode.Attributes, DSharpStringResources.SCRIPT_OBJECT_ATTRIBUTE);

                if (objectAttribute != null)
                {
                    if ((typeNode.Modifiers & Modifiers.Sealed) == 0)
                    {
                        errorHandler.ReportNodeValidationError(DSharpStringResources.SCRIPT_OBJECT_ATTRIBUTE_ERROR, typeNode);
                    }

                    if (typeNode.BaseTypes.Count != 0)
                    {
                        errorHandler.ReportNodeValidationError(DSharpStringResources.SCRIPT_OBJECT_CLASS_INHERITENCE_ERROR, typeNode);
                    }

                    recordRestrictions = true;
                }
            }

            if (typeNode.Members != null && typeNode.Members.Count != 0)
            {
                Dictionary<string, object> memberNames = new Dictionary<string, object>();
                bool hasCtor = false;

                foreach (ParseNode genericMemberNode in typeNode.Members)
                {
                    if (!(genericMemberNode is MemberNode))
                    {
                        continue;
                    }

                    MemberNode memberNode = (MemberNode)genericMemberNode;

                    if ((memberNode.Modifiers & Modifiers.Extern) != 0)
                    {
                        // Extern methods are placeholders for creating overload signatures
                        continue;
                    }

                    if (recordRestrictions &&
                        ((memberNode.Modifiers & Modifiers.Static) != 0 ||
                         memberNode.NodeType != ParseNodeType.ConstructorDeclaration &&
                         memberNode.NodeType != ParseNodeType.FieldDeclaration))
                    {
                        errorHandler.ReportNodeValidationError(DSharpStringResources.SCRIPT_OBJECT_MEMBER_VIOLATION_ERROR, memberNode);
                    }

                    if (memberNode.NodeType == ParseNodeType.ConstructorDeclaration)
                    {
                        if ((memberNode.Modifiers & Modifiers.Static) == 0)
                        {
                            if (hasCtor)
                            {
                                errorHandler.ReportNodeValidationError(DSharpStringResources.UNSUPPORTED_CONSTRUCTOR_OVERLOAD, memberNode);
                            }

                            hasCtor = true;
                        }

                        continue;
                    }

                    if (memberNode is MethodDeclarationNode methodDeclaration)
                    {
                        if(methodDeclaration.IsExensionMethod && (!methodDeclaration.Modifiers.HasFlag(Modifiers.Static) || !typeNode.Modifiers.HasFlag(Modifiers.Static)))
                        {
                            errorHandler.ReportNodeValidationError(DSharpStringResources.EXTENSION_TYPE_AND_METHOD_SHOULD_BE_STATIC, methodDeclaration);
                        }
                    }
            
                    if (memberNode.NodeType == ParseNodeType.OperatorDeclaration)
                    {
                        // Operators don't have a name
                        continue;
                    }

                    string name = memberNode.Name;
                    AttributeNode ignoreAttribute = AttributeNode.FindAttribute(memberNode.Attributes, DSharpStringResources.SCRIPT_IGNORE_ATTRIBUTE);

                    if (ignoreAttribute == null && memberNames.ContainsKey(name))
                    {
                        errorHandler.ReportNodeValidationError(DSharpStringResources.UNSUPPORTED_METHOD_OVERLOAD, memberNode);
                    }

                    // remember the method overload only if it wasn't ignored
                    if (ignoreAttribute == null)
                    {
                        memberNames[name] = null;
                    }

                    string nameToValidate = name;
                    bool preserveCase = false;
                    AttributeNode nameAttribute = AttributeNode.FindAttribute(memberNode.Attributes, DSharpStringResources.SCRIPT_NAME_ATTRIBUTE);

                    if (nameAttribute != null && nameAttribute.Arguments.Count != 0)
                    {
                        foreach (ParseNode argNode in nameAttribute.Arguments)
                            if (argNode.NodeType == ParseNodeType.Literal)
                            {
                                nameToValidate = (string)((LiteralNode)argNode).Value;
                            }
                            else if (argNode.NodeType == ParseNodeType.BinaryExpression)
                            {
                                if (string.CompareOrdinal(((NameNode)((BinaryExpressionNode)argNode).LeftChild).Name,
                                        "PreserveCase") == 0)
                                {
                                    preserveCase = (bool)((LiteralNode)((BinaryExpressionNode)argNode).RightChild)
                                        .Value;
                                }
                            }
                    }

                    if (Utility.IsKeyword(nameToValidate, /* testCamelCase */ preserveCase == false))
                    {
                        errorHandler.ReportNodeValidationError(DSharpStringResources.RESERVED_KEYWORD_ON_MEMBER_ERROR, memberNode);
                    }

                    if (hasCodeMembers == false)
                    {
                        hasCodeMembers = memberNode.NodeType == ParseNodeType.PropertyDeclaration ||
                                         memberNode.NodeType == ParseNodeType.MethodDeclaration ||
                                         memberNode.NodeType == ParseNodeType.EventDeclaration ||
                                         memberNode.NodeType == ParseNodeType.IndexerDeclaration;
                        codeMemberNode = memberNode;
                    }
                }
            }

            return true;
        }
    }
}
