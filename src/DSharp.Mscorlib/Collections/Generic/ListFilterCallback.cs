using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate bool ListFilterCallback<T>(T value, int index, IReadOnlyCollection<T> list);
}
