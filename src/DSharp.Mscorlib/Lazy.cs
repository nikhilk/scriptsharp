using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreGenericArguments]
    public class Lazy<T>
    {
        [ScriptAlias("IsValueCreated")]
        public extern bool IsValueCreated { get; }

        [ScriptAlias("Value")]
        public extern T Value { get; }

        public extern Lazy(Func<T> factory);
    }
}
