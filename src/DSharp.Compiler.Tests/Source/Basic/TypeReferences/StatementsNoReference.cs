using System;
using System.Collections.Generic;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        public static void Main()
        {
            int[] value = { 60, 100, 120 };
            int[] weight = { 10, ConstantsInLib.NUMBER, 30 };
            int capacity = ConstantsInLib.NUMBER + 18;
            int itemsCount = 3;

            int result = KnapSack(capacity, weight, value, itemsCount);
            Foo();
        }

        private static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[][] K = new int[itemsCount + 1][capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i][w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i][w] = Math.Max(value[i - 1] + K[i - 1][w - weight[i - 1]], K[i - 1][w]);
                    else
                        K[i][w] = K[i - 1][w];
                }
            }

            return K[itemsCount][capacity];
        }

        private void Foo()
        {
            int sum = 0;

            foreach (char character in ConstantsInLib.TEXT + ' ' + typeof(List<string>).Name)
            {
                sum = (int)character;
            }
        }
    }
}
