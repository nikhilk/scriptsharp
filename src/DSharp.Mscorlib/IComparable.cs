using System.Runtime.CompilerServices;

namespace System
{
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }
}
