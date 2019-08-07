using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
    // NOTE: Keep in sync with ArrayList and List
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Array")]
    public sealed partial class Array : IList, ICollection, IEnumerable
    {
        [ScriptField]
        public extern object this[int index]
        {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("length")]
        public extern int Length { get; }

        public extern int Count { get; }

        public extern int Add(object value);

        public extern void Clear();

        public extern bool Contains(object value);

        public extern IEnumerator GetEnumerator();

        public extern int IndexOf(object value);

        public extern void Insert(int index, object value);

        public extern void Remove(object value);

        public extern void RemoveAt(int index);

        public extern static explicit operator List<object>(Array array);
    }
}
