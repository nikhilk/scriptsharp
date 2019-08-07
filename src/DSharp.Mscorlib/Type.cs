using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The Type data type which is mapped to the Function type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed partial class Type : MemberInfo
    {
        [ScriptName("$base")]
        [ScriptField]
        public extern Type BaseType { get; }

        [DSharpScriptMemberName("type")]
        public extern static Type GetType(string typeName);

        [DSharpScriptMemberName("canAssign")]
        public extern bool IsAssignableFrom(Type type);

        [DSharpScriptMemberName("isClass")]
        public extern static bool IsClass(Type type);

        [DSharpScriptMemberName("isInterface")]
        public extern static bool IsInterface(Type type);

        [DSharpScriptMemberName("instanceOf")]
        public extern bool IsInstanceOfType(object instance);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public extern static Type GetTypeFromHandle(RuntimeTypeHandle typeHandle);
    }
}
