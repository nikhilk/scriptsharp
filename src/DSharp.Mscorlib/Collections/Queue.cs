using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptImport]
    public sealed class Queue
    {
        [ScriptField]
        public extern int Count { get; }

        public extern void Clear();

        public extern bool Contains(object item);

        public extern object Dequeue();

        public extern void Enqueue(object item);

        public extern object Peek();
    }
}
