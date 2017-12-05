// Json.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Serialization {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("JSON")]
    public static class Json {

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <returns>The deserialized object.</returns>
        public static object Parse(string json) {
            return null;
        }

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <returns>The deserialized object.</returns>
        [ScriptName("parse")]
        public static TData ParseData<TData>(string json) {
            return default(TData);
        }

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <param name="parseCallback">A callback to invoke on each value that is deserialized.</param>
        /// <returns>The deserialized object.</returns>
        public static object Parse(string json, JsonParseCallback parseCallback) {
            return null;
        }

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <param name="parseCallback">A callback to invoke on each value that is deserialized.</param>
        /// <returns>The deserialized object.</returns>
        [ScriptName("parse")]
        public static TData ParseData<TData>(string json, JsonParseCallback parseCallback) {
            return default(TData);
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o) {
            return null;
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="serializableMembers">The specific members to serialize and their order.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o, string[] serializableMembers) {
            return null;
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="serializableMembers">The specific members to serialize and their order.</param>
        /// <param name="indentSpaces">The number of spaces to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o, string[] serializableMembers, int indentSpaces) {
            return null;
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="serializableMembers">The specific members to serialize and their order.</param>
        /// <param name="indentText">The string to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o, string[] serializableMembers, string indentText) {
            return null;
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="callback">A callback to invoke for each value being serialized.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o, JsonStringifyCallback callback) {
            return null;
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="callback">A callback to invoke for each value being serialized.</param>
        /// <param name="indentSpaces">The number of spaces to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o, JsonStringifyCallback callback, int indentSpaces) {
            return null;
        }

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="callback">A callback to invoke for each value being serialized.</param>
        /// <param name="indentText">The string to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public static string Stringify(object o, JsonStringifyCallback callback, string indentText) {
            return null;
        }
    }
}
