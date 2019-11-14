using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    public interface IEnumerator<T> : IEnumerator
    {
        [ScriptField]
        new T Current { get; }
    }
}
