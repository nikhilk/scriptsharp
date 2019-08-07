using System.Collections.Generic;

namespace DSharp.Compiler.Tests
{
    public static class IListExtensions
    {
        public static T GetIndexOrDefault<T>(this IList<T> list, int index)
        {
            if(index >= list.Count || index < 0)
            {
                return default(T);
            }

            return list[index];
        }
    }
}
