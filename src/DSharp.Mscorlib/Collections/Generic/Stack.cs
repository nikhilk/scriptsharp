using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptImport]
    [ScriptName("Stack")]
    public sealed class Stack<T>
    {
        [ScriptField]
        public extern int Count { get; }

        public extern void Clear();

        public extern bool Contains(T item);

        public extern T Peek();

        public extern T Pop();

        public extern void Push(T item);
    }
}
