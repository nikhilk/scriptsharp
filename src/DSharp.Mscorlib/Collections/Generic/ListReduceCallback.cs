using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate TReduced ListReduceCallback<TReduced, TValue>(TReduced previousValue, TValue value, int index, List<TValue> list);
}
