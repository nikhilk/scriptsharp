// Name.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Text;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     An identifier or keyword. Symbols are stored in a shared NameTable
    ///     so there is only one instance of a given Name around at a time.
    ///     You can use the == operator to test if two names from the same
    ///     NameTable are equal.
    /// </summary>
    internal sealed class Name
    {
        private readonly int hashValue;

        internal Name(string value)
        {
            Text = value;
            hashValue = NameTable.NameHasher.Hash(Text);
        }

        internal Name(StringBuilder value)
            : this(value.ToString())
        {
        }

        public int Length => Text.Length;

        public string Text { get; }

        public override int GetHashCode()
        {
            return hashValue;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}