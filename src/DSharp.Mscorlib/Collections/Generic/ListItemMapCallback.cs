using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate TTarget ListItemMapCallback<TSource, TTarget>(TSource value);
}
