using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate TTarget ListMapCallback<TSource, TTarget>(TSource value, int index, IReadOnlyCollection<TSource> list);
}
