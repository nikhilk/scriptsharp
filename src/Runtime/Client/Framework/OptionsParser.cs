// OptionsParser.cs
// Script#/Runtime/Client/Framework
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Serialization;

namespace Sharpen {

    internal static class OptionsParser {

        // Find the following types of string sequences:
        // Literals (true, false, null, numbers
        // Strings (either single-quoted, or double-quoted)
        //         (note, we don't handle nested quotes)
        // Element references (either #id, or .class)
        // Syntax (comma for name/value separators, square brackets
        //         for arrays, curly braces for nested objects)
        // Names (sequence of alphanumerics followed by a ':')
        private static readonly RegularExpression _optionsParserRegex =
            new RegularExpression("(true|false|null|-?[0-9.]+)|('[^']*'|\\\"[^\"]*\\\")|([#\\.][a-z][a-z0-9]*)|(\\,|\\[|\\]|\\{|\\})|([a-z][a-z0-9]*\\:)", "gi");

        public static Dictionary<string, object> GetOptions(Element element, string name) {
            // Options can be specified using a pseudo-JSON/css-esque syntax
            // as the value of a data-<name> attribute on the element.

            string optionsText = (string)element.GetAttribute("data-" + name);
            if (String.IsNullOrEmpty(optionsText) == false) {
                return Parse(optionsText);
            }
            else {
                // Create an empty object if no options were declaratively specified
                // so that behaviors always get an object instance in the call to
                // Initialize.

                return new Dictionary<string, object>();
            }
        }

        private static Dictionary<string, object> Parse(string optionsText) {
            Debug.Assert(String.IsNullOrEmpty(optionsText) == false);

            bool resolveElements = false;
            optionsText = optionsText.ReplaceRegex(_optionsParserRegex,
                delegate(string match /*, string simpleValue, string stringValue, string elementReference, string separator, string name */) {
                    string stringValue = (string)Arguments.GetArgument(2);
                    string elementReference = (string)Arguments.GetArgument(3);
                    string nameValue = (string)Arguments.GetArgument(5);
                    if (Script.IsValue(stringValue)) {
                        // Matches single and double quoted strings
                        // JSON strings are always double quoted, and additionally
                        // escape any double quotes within.

                        return '"' + stringValue.Substr(1, stringValue.Length - 2).Replace("\"", "\\\"") + '"';
                    }
                    else if (Script.IsValue(elementReference)) {
                        // ID references require resolution at JSON parse time
                        // Convert them to strings, so they can be parsed as valid JSON first.

                        resolveElements = true;
                        return '"' + elementReference + '"';
                    }
                    else if (Script.IsValue(nameValue)) {
                        // Matches a name followed by ":"
                        // In JSON, names must be double quoted

                        return '"' + nameValue.Substr(0, nameValue.Length - 1) + "\":";
                    }
                    return match;
                });

            // Finally turn this into a JSON object, by wrapping with curly braces

            string optionsJson = "{" + optionsText + "}";

            JsonParseCallback parseCallback = null;
            if (resolveElements) {
                parseCallback = ResolveElementReferences;
            }

            return Json.ParseData<Dictionary<string, object>>(optionsJson, parseCallback);
        }

        private static object ResolveElementReferences(string name, object value) {
            if (value is String) {
                if (((string)value).CharAt(0) == '#') {
                    return Document.QuerySelector((string)value);
                }
                else if (((string)value).CharAt(0) == '.') {
                    return Document.QuerySelectorAll((string)value);
                }
            }
            return value;
        }
    }
}
