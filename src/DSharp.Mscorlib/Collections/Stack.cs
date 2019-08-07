using System.Runtime.CompilerServices;

namespace System.Collections
{
    [ScriptImport]
    public sealed class Stack
    {
        [ScriptField]
        public extern int Count { get; }

        public extern void Clear();

        public extern bool Contains(object item);

        public extern object Peek();

        public extern object Pop();

        public extern void Push(object item);
    }
}
