using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate TReduced ListItemReduceCallback<TReduced, TValue>(TReduced previousValue, TValue value);
}
