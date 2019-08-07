using System;

namespace DSharp.Compiler
{
    internal static class StringExtensions
    {
        internal static string RemoveEnd(this string str, string word, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if(!str.EndsWith(word, stringComparison))
            {
                return str;
            }

            int index = str.LastIndexOf(word, stringComparison);
            return str.Remove(index);
        }
    }
}
