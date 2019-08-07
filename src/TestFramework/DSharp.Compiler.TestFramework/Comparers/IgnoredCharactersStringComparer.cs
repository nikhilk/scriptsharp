using System;
using System.Collections.Generic;
using System.Threading;

namespace DSharp.Compiler.TestFramework.Comparers
{
    public class IgnoredCharactersStringComparer : IEqualityComparer<string>
    {
        private readonly string ignoredCharacters;

        public IgnoredCharactersStringComparer(string ignoredCharacters)
        {
            this.ignoredCharacters = ignoredCharacters;
        }

        public bool Equals(string left, string right)
        {
            if(ReferenceEquals(left, right))
            {
                return true;
            }

            if(left == null || right == null)
            {
                return false;
            }

            int leftIndex = 0;
            int rightIndex = 0;

            while(true)
            {
                while(leftIndex < left.Length && ignoredCharacters.IndexOf(left[leftIndex]) != -1)
                {
                    leftIndex++;
                }

                while (rightIndex < right.Length && ignoredCharacters.IndexOf(right[rightIndex]) != -1)
                {
                    rightIndex++;
                }

                if(leftIndex >= left.Length)
                {
                    return rightIndex >= right.Length;
                }

                if(rightIndex >= right.Length)
                {
                    return false;
                }

                if(left[leftIndex] != right[rightIndex])
                {
                    return false;
                }

                leftIndex++;
                rightIndex++;
            }
        }

        public int GetHashCode(string obj)
        {
            throw new NotImplementedException();
        }
    }
}