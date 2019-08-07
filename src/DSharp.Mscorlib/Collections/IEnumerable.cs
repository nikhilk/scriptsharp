using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptImport]
    public interface IEnumerable
    {
        [DSharpScriptMemberName("enumerate")]
        IEnumerator GetEnumerator();
    }
}
