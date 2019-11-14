using System.Runtime.CompilerServices;

namespace System.Serialization
{
    //TODO: Move this file into a browser definition library
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("JSON")]
    public static class Json
    {
        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <returns>The deserialized object.</returns>
        public extern static object Parse(string json);

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <returns>The deserialized object.</returns>
        [ScriptName("parse")]
        [ScriptIgnoreGenericArgumentsAttribute]
        public extern static TData ParseData<TData>(string json);

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <param name="parseCallback">A callback to invoke on each value that is deserialized.</param>
        /// <returns>The deserialized object.</returns>
        public extern static object Parse(string json, JsonParseCallback parseCallback);

        /// <summary>
        /// Parses the specified JSON text.
        /// </summary>
        /// <param name="json">The JSON text to be parsed.</param>
        /// <param name="parseCallback">A callback to invoke on each value that is deserialized.</param>
        /// <returns>The deserialized object.</returns>
        [ScriptName("parse")]
        [ScriptIgnoreGenericArgumentsAttribute]
        public extern static TData ParseData<TData>(string json, JsonParseCallback parseCallback);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="serializableMembers">The specific members to serialize and their order.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o, string[] serializableMembers);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="serializableMembers">The specific members to serialize and their order.</param>
        /// <param name="indentSpaces">The number of spaces to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o, string[] serializableMembers, int indentSpaces);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="serializableMembers">The specific members to serialize and their order.</param>
        /// <param name="indentText">The string to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o, string[] serializableMembers, string indentText);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="callback">A callback to invoke for each value being serialized.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o, JsonStringifyCallback callback);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="callback">A callback to invoke for each value being serialized.</param>
        /// <param name="indentSpaces">The number of spaces to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o, JsonStringifyCallback callback, int indentSpaces);

        /// <summary>
        /// Serializes the specified object into JSON representation.
        /// </summary>
        /// <param name="o">The object to serialize.</param>
        /// <param name="callback">A callback to invoke for each value being serialized.</param>
        /// <param name="indentText">The string to use for indentation.</param>
        /// <returns>The serialized value as JSON text.</returns>
        public extern static string Stringify(object o, JsonStringifyCallback callback, string indentText);
    }
}
