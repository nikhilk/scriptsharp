using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void ListCallback<T>(T value, int index, IReadOnlyCollection<T> list);
}
