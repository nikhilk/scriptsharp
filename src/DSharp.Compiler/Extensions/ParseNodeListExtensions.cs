using System.Diagnostics;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;

namespace DSharp.Compiler.Extensions
{
    internal static class ParseNodeListExtensions
    {
        internal static string GetNodeTransformName(this ParseNodeList parseNodeList)
        {
            string dsharpMemberName = parseNodeList?.GetAttributeValue(DSharpStringResources.DSHARP_MEMBER_NAME_ATTRIBUTE);

            if(!string.IsNullOrEmpty(dsharpMemberName))
            {
                return DSharpStringResources.ScriptExportMember(dsharpMemberName);
            }

            return parseNodeList?.GetAttributeValue(DSharpStringResources.SCRIPT_ALIAS_ATTRIBUTE);
        }

        internal static string GetAttributeValue(this ParseNodeList parseNodeList, string attributeName)
        {
            AttributeNode node = AttributeNode.FindAttribute(parseNodeList, attributeName);

            if (node != null && node.Arguments.Count != 0 && node.Arguments[0].NodeType == ParseNodeType.Literal)
            {
                Debug.Assert(((LiteralNode)node.Arguments[0]).Value is string);

                return (string)((LiteralNode)node.Arguments[0]).Value;
            }

            return null;
        }
    }
}
