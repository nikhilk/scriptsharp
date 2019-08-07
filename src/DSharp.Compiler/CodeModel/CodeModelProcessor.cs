// CodeModelProcessor.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Reflection;

namespace DSharp.Compiler.CodeModel
{
    internal sealed class CodeModelProcessor
    {
        private readonly object context;

        private readonly IParseNodeHandler nodeHandler;
        private readonly bool notifyChildren;

        public CodeModelProcessor(IParseNodeHandler nodeHandler, object context)
        {
            this.nodeHandler = nodeHandler;
            this.context = context;
            notifyChildren = nodeHandler.RequiresChildrenGrouping;
        }

        private void EndChildren()
        {
            if (notifyChildren)
            {
                nodeHandler.EndChildren();
            }
        }

        public void Process(ParseNode node)
        {
            Visit(node);
        }

        private bool ProcessNode(ParseNode node)
        {
            return nodeHandler.HandleNode(node, context);
        }

        private void StartChildren(string identifier)
        {
            if (notifyChildren)
            {
                nodeHandler.StartChildren(identifier);
            }
        }

        private void Visit(ParseNode node)
        {
            if (!ProcessNode(node))
            {
                return;
            }

            StartChildren(string.Empty);

            Type nodeType = node.GetType();

            foreach (PropertyInfo propertyInfo in nodeType.GetProperties())
            {
                string propertyName = propertyInfo.Name;

                if (propertyName.Equals("NodeType"))
                {
                    continue;
                }

                if (propertyName.Equals("Parent"))
                {
                    continue;
                }

                if (propertyName.Equals("Token"))
                {
                    continue;
                }

                Visit(node, propertyInfo);
            }

            EndChildren();
        }

        private void Visit(ParseNode node, PropertyInfo propertyInfo)
        {
            string name = propertyInfo.Name;
            object value = propertyInfo.GetValue(node, null);

            string text = name + " (" + propertyInfo.PropertyType.Name + ")";

            if (value != null)
            {
                if (value is ParseNodeList nodeList)
                {
                    if (nodeList.Count == 0)
                    {
                        text += " : Empty";
                    }
                    else
                    {
                        text += " : " + nodeList.Count;
                    }

                    StartChildren(text);
                    foreach (ParseNode nodeItem in nodeList) Visit(nodeItem);
                    EndChildren();
                }
                else if (value is ParseNode parseNode)
                {
                    StartChildren(text);
                    Visit(parseNode);
                    EndChildren();
                }
                else
                {
                    if (value is string @string)
                    {
                        text += " : \"" + @string + "\"";
                    }
                    else
                    {
                        text += " : " + value;
                    }

                    StartChildren(text);
                    EndChildren();
                }
            }
            else
            {
                text += " : null";
                StartChildren(text);
                EndChildren();
            }
        }
    }
}