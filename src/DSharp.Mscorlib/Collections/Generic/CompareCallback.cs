using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate int CompareCallback<T>(T x, T y);
}
