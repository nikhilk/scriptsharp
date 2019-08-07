using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptImport]
    [ScriptName("IEnumerable")]
    public interface IEnumerable<T> : IEnumerable
    {
        [DSharpScriptMemberName("enumerate")]
        new IEnumerator<T> GetEnumerator();
    }
}
