// ResXParser.cs
// Script#/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DSharp
{
    internal static class ResXParser
    {
        public static List<ResXItem> ParseResxMarkup(string resxMarkup)
        {
            List<ResXItem> items = new List<ResXItem>();

            XmlTextReader resxReader = new XmlTextReader(new StringReader(resxMarkup));

            while (resxReader.Read())
                if (resxReader.NodeType == XmlNodeType.Element &&
                    string.CompareOrdinal(resxReader.LocalName, "data") == 0)
                {
                    string name = resxReader["name"];
                    string value = null;
                    string comment = null;

                    while (resxReader.Read())
                        if (resxReader.NodeType == XmlNodeType.Element)
                        {
                            if (string.CompareOrdinal(resxReader.LocalName, "value") == 0)
                            {
                                WhitespaceHandling oldWhitespace = resxReader.WhitespaceHandling;
                                resxReader.WhitespaceHandling = WhitespaceHandling.Significant;

                                value = resxReader.ReadString();
                                resxReader.WhitespaceHandling = oldWhitespace;
                            }
                            else if (string.CompareOrdinal(resxReader.LocalName, "comment") == 0)
                            {
                                comment = resxReader.ReadString();
                            }
                        }
                        else if (resxReader.NodeType == XmlNodeType.EndElement &&
                                 string.CompareOrdinal(resxReader.LocalName, "data") == 0)
                        {
                            break;
                        }

                    items.Add(new ResXItem(name, value, comment));
                }

            return items;
        }
    }
}