using System.Runtime.CompilerServices;

namespace System
{
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Function")]
    public abstract class Delegate
    {
        protected Delegate(object target, string method) { }

        protected Delegate(Type target, string method) { }

        [DSharpScriptMemberName("bindAdd")]
        public extern static Delegate Combine(Delegate a, Delegate b);

        [DSharpScriptMemberName("bind")]
        public extern static Delegate Create(Function f, object instance);

        [DSharpScriptMemberName("bindSub")]
        public extern static Delegate Remove(Delegate source, Delegate value);
    }
}
