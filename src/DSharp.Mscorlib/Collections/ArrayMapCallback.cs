using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate object ArrayMapCallback(object value, int index, Array array);
}
