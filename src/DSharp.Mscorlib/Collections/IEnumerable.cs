using System.Runtime.CompilerServices;

namespace System.Collections
{
    public interface IEnumerable
    {
        [DSharpScriptMemberName("enumerate")]
        IEnumerator GetEnumerator();
    }
}
