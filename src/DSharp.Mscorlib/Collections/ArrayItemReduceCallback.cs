using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate object ArrayItemReduceCallback(object previousValue, object value);
}
