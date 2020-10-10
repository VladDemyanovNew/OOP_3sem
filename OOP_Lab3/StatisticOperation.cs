using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3
{
    static class StatisticOperation
    {
        public static void Sum(this Set type)
        {
            string sum = "";
            foreach (string item in type.Arr)
                sum += item;
            Console.WriteLine($"\tВывод суммы: {sum}");
        }

        public static void deltaBetweenMinMax(this Set type)
        {
            type.Arr.Sort();
            int delta = type.Arr[type.Arr.Count - 1].Length - type.Arr[0].Length;
            Console.WriteLine($"\tРазница между минимальным и максимальным: {delta}");
        }

        public static void lengthOfArr(this Set type)
        {
            Console.WriteLine( $"\tРазмер множества: {type.Arr.Count}");
        }

        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}
