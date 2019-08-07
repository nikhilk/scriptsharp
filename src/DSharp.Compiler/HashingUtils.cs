namespace DSharp.Compiler
{
    public static class HashingUtils
    {
        //These have come from a useful stack overflow answer: https://stackoverflow.com/questions/1646807/quick-and-simple-hash-code-combinations#answer-34006336
        private const int DEFAULT_SEED = 1009;
        private const int DEFAULT_FACTOR = 9176;

        public static int CombineHashCodes(params object[] items)
        {
            return CombineHashCodes(DEFAULT_SEED, DEFAULT_FACTOR, items);
        }

        public static int CombineHashCodes(int seed, int factor, params object[] items)
        {
            if(items.Length == 0)
            {
                return 0;
            }

            int hashCode = seed;

            foreach (object item in items)
            {
                hashCode = (hashCode * factor) + item.GetHashCode();
            }

            return hashCode;
        }
    }
}
