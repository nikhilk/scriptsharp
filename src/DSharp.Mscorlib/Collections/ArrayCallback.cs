using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void ArrayCallback(object value, int index, Array array);
}
