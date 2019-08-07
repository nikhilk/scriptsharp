using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate bool ArrayFilterCallback(object value, int index, Array array);
}
