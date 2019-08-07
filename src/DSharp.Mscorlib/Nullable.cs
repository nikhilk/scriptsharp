using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public struct Nullable<T> where T : struct
    {
        public Nullable(T value) { }

        public extern bool HasValue { get; }

        public extern T Value { get; }

        public extern T GetValueOrDefault();

        public extern static implicit operator T? (T value);

        public extern static explicit operator T(T? value);
    }
}
