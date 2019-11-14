using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    public interface IEnumerable<T> : IEnumerable
    {
        [DSharpScriptMemberName("enumerate")]
        new IEnumerator<T> GetEnumerator();
    }
}
