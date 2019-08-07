using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate object ArrayReduceCallback(object previousValue, object value, int index, Array array);
}
