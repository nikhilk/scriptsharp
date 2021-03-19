using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreGenericArguments(UseGenericName = true)]
    public interface IEquatable<T>
    {
        bool Equals(T other);
    }
}
