using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [ScriptImport]
    [ScriptName("Queue")]
    public sealed class Queue<T>
    {
        [ScriptField]
        public extern int Count { get; }

        public extern void Clear();

        public extern bool Contains(T item);

        public extern T Dequeue();

        public extern void Enqueue(T item);

        public extern T Peek();
    }
}
