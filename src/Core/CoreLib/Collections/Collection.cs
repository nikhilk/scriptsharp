using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;

namespace System.Collections.ObjectModel
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Array")]
    public abstract class Collection<T> : IEnumerable, IEnumerable<T>, ICollection<T>
    {
        public static implicit operator Array(Collection<T> collection) { return null; }
        public static implicit operator List<T>(Collection<T> collection) { return null; }

        public Collection() { }

        [ScriptField]
        [ScriptName("length")]
        public abstract int Count { get; }

        [ScriptField]
        public abstract T this[int index] { get; set; }

        public IEnumerator GetEnumerator()
        {
            return null;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return null;
        }

        [ScriptName("push")]
        public abstract void Add(T item);

        [ScriptName("push")]
        public abstract void AddRange(params T[] items);

        public abstract void Clear();

        public abstract bool Contains(T item);

        public abstract void CopyTo(T[] array, int index);

        public abstract int IndexOf(T item);

        public abstract void Insert(int index, T item);
        
        [ScriptAlias("ss.remove")]
        public abstract bool Remove(T item);

        public abstract void RemoveAt(int index);

        [ScriptName("map")]
        public abstract Collection<TResult> Select<TSource, TResult>(Func<TSource, TResult> selector);

        [ScriptAlias("sse.TypeExtension.Cast")]
        public abstract T[] ToArray();

        [ScriptAlias("sse.TypeExtension.Cast")]
        public abstract List<T> ToList();
    }
}
