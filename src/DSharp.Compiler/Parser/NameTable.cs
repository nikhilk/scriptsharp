// NameTable.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Diagnostics;
using System.Text;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     A container for unique Names
    /// </summary>
    internal class NameTable : IEnumerable
    {
        private readonly Hashtable values;

        public NameTable()
        {
            values = new Hashtable(new NameHasher());
        }

        /// <summary>
        ///     The number of Names in the table
        /// </summary>
        public int Count => values.Count;

        /// <summary>
        ///     Returns an iterator over the Names in the table
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return values.Keys.GetEnumerator();
        }

        /// <summary>
        ///     Creates or returns the Name for a string.
        /// </summary>
        public Name Add(StringBuilder value)
        {
            Name name = Find(value);

            if (name == null)
            {
                name = new Name(value);
                values.Add(name, name);
            }

            return name;
        }

        /// <summary>
        ///     Creates or returns the Name for a string.
        /// </summary>
        public Name Add(string value)
        {
            Name name = Find(value);

            if (name == null)
            {
                name = new Name(value);
                values.Add(name, name);
            }

            return name;
        }

        /// <summary>
        ///     Returns a Name if it exists for value
        ///     or null if the NameTable doesn't contain value
        /// </summary>
        public Name Find(StringBuilder value)
        {
            return (Name) values[value];
        }

        /// <summary>
        ///     Returns a Name if it exists for value
        ///     or null if the NameTable doesn't contain value
        /// </summary>
        public Name Find(string value)
        {
            return (Name) values[value];
        }

        /// <summary>
        ///     Returns true if a Name exists for the string.
        /// </summary>
        public bool IsName(string value)
        {
            return values[value] != null;
        }

        /// <summary>
        ///     Returns true if a Name exists for the string.
        /// </summary>
        public bool IsSymbol(StringBuilder value)
        {
            return values[value] != null;
        }

        /// <summary>
        ///     Provides a common Hash function for strings and Names
        ///     A Utility class for Name and NameTable classes
        /// </summary>
        internal sealed class NameHasher : IEqualityComparer
        {
            /// <summary>
            ///     This must match with the string versino below.
            /// </summary>
            public static int Hash(StringBuilder value)
            {
                const uint hashStart = 0xB16357FF;

                uint hash = hashStart;

                // Hash two characters/one dword at a time.
                int length = value.Length;
                int index = 0;
                int length2 = length & ~1;

                while (index < length2)
                {
                    hash += (uint) (value[index + 1] << 16) | value[index];
                    hash += hash << 10;
                    hash ^= hash >> 6;
                    index += 2;
                }

                // Hash the last character, if any.
                if (index < length)
                {
                    hash += value[index];
                    hash += hash << 10;
                    hash ^= hash >> 6;
                }

                hash += hash << 3;
                hash ^= hash >> 11;
                hash += hash << 15;

                return (int) HashUInt(hash);
            }

            /// <summary>
            ///     This must match with the StringBuilder version above.
            /// </summary>
            public static int Hash(string value)
            {
                const uint hashStart = 0xB16357FF;

                uint hash = hashStart;

                // Hash two characters/one dword at a time.
                int length = value.Length;
                int index = 0;
                int length2 = length & ~1;

                while (index < length2)
                {
                    hash += (uint) (value[index + 1] << 16) | value[index];
                    hash += hash << 10;
                    hash ^= hash >> 6;
                    index += 2;
                }

                // Hash the last character, if any.
                if (index < length)
                {
                    hash += value[index];
                    hash += hash << 10;
                    hash ^= hash >> 6;
                }

                hash += hash << 3;
                hash ^= hash >> 11;
                hash += hash << 15;

                return (int) HashUInt(hash);
            }

            /// <summary>
            ///     A generally useful hashing function. Uses no state.
            ///     Hash a 32-bit value to get a much more randomized
            ///     32-bit value.
            /// </summary>
            private static uint HashUInt(uint u)
            {
                // Randomize the hash value further by multiplying by a large prime,
                // then adding the hi and lo DWORDs of the 64-bit result together. This
                // produces an excellent randomization very efficiently.

                ulong l = u * (ulong) 0x7ff19519; // this number is prime.

                return (uint) l + (uint) (l >> 32);
            }

            #region IEqualityComparer Members

            bool IEqualityComparer.Equals(object a, object b)
            {
                Debug.Assert(a != null && b != null);
                Debug.Assert(b is Name || a is Name);
                Debug.Assert(a != b);

                if (!(b is Name))
                {
                    object temp = b;
                    b = a;
                    a = temp;
                }

                StringBuilder sba = a as StringBuilder;
                string sb = b.ToString();

                if (sba != null)
                {
                    int diff = sba.Length - sb.Length;

                    for (int i = 0; diff == 0 && i < sb.Length; i += 1)
                    {
                        diff = sba[i] - sb[i];
                        i += 1;
                    }

                    return diff == 0;
                }
                else
                {
                    string sa = a.ToString();

                    int diff = sa.Length - sb.Length;

                    for (int i = 0; diff == 0 && i < sb.Length; i += 1)
                    {
                        diff = sa[i] - sb[i];
                        i += 1;
                    }

                    return diff == 0;
                }
            }

            int IEqualityComparer.GetHashCode(object obj)
            {
                Name n = obj as Name;

                if (n != null)
                {
                    return n.GetHashCode();
                }

                StringBuilder sb = obj as StringBuilder;

                if (sb != null)
                {
                    return Hash(sb);
                }

                return Hash((string) obj);
            }

            #endregion
        }
    }
}