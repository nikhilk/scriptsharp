using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptIgnoreGenericArguments(UseGenericName = true)]
    public interface IEnumerable<T> : IEnumerable
    {
        [DSharpScriptMemberName("enumerate")]
        new IEnumerator<T> GetEnumerator();
    }
}
