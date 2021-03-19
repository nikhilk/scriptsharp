using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreGenericArguments(UseGenericName = true)]
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }
}
