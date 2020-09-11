using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OOP_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1.  Типы    */
            bool check = false;
            byte bit = 255;                     // 1
            sbyte sbit = -128;
            short snum = -32768;                // 2
            ushort usnum = 65535;
            int inum = -2147483648;             // 4
            uint uinum = 4294967295;
            long lnum = -9223372036854775808;   // 8
            ulong ulnum = 18446744073709551615;
            float fnum = 0.0F;                  // 4
            double dnum = 1.1;                  // 8
            decimal decnum = 2.2M;              // 16
            char a = 'a';                       // 2
            string str = "str";
            object b = "3 && 0.1 && str";       // 4 || 8

            Console.Write("\n\tВведите число: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\tВы ввели: {num}");
            Console.WriteLine($"\n\tПеременная lnum типа long: {lnum}");

            /* Неявные преобразования */
            byte num1 = 1;
            short num2 = num1;
            int num3 = num2;
            long num4 = num3;
            float num5 = num4;
            double num6 = num5;
            /* Явные преобразования */
            decimal num7 = (decimal)num6;   // у decimal имеет большую разрядность чем double, но нужно приводить
            float num8 = (float)num7;
            long num9 = (long)num8;
            int num10 = (int)num9;
            short num11 = (short)num10;
            /* Упаковка значимых типов */
            int num12 = 22;         // Значимый
            Object pnum12 = num12;  // Ссылочный
            /* Распаковка значимых типов */
            int num13 = (int)pnum12;
            /* Неявно типизированные переменные */
            var num14 = 17;
            var str1 = "Str";
            /* Nullable */
            int? num15 = null;
            Nullable<int> num16 = 11;
            Console.WriteLine($"\n\t{num16.HasValue} : {num16.Value}");

            /* 2.  Строки    */
            //a
            string str2 = "Test";
            Console.WriteLine($"\n\t{String.CompareOrdinal(str2, "Test")}");
            Console.WriteLine($"\t{str2.CompareTo("Test")}");
            Console.WriteLine($"\t{str2.Equals("Test")}");
            Console.WriteLine($"\t{String.Equals(str2, "Test")}");
            Console.WriteLine($"\t{str2.StartsWith("Te")}");
            Console.WriteLine($"\t{str2.IndexOf("s")}");
            //b
            string str3 = "Hello";
            string str4 = " ";
            string str5 = "World";
            string str6 = "Word1 Word2 Word3 Word4";
            Console.WriteLine("\n\t" + str3 + str4 + str5);
;           Console.WriteLine($"\t{str3.Substring(0, str3.Length - 2)}");
            Console.WriteLine($"\t{String.Join(", ", str6.Split(new char[] { ' ' }))}");
            Console.WriteLine($"\t{str5.Insert(str3.Length - 2, str3)}");
            Console.WriteLine($"\t{str3.Remove(1, 3)}");
            //c
            string str7 = null;
            string str8 = "";
            Console.WriteLine($"\n\tstr7: {string.IsNullOrEmpty(str7)}");
            Console.WriteLine($"\n\tstr8: {string.IsNullOrEmpty(str8)}");
            //d
            StringBuilder str9 = new StringBuilder("Hello world");
            str9.Remove(2, 6).Append("|").Insert(0, "|");
            Console.WriteLine($"\n\t{str9}");

            /* 3.  Массивы    */
            //a
            int[,] arr1 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            int rows = arr1.GetUpperBound(0) + 1;
            int cols = arr1.Length / rows;
            Console.WriteLine();
            foreach (int i in arr1)
            {
                
                if (i == cols - 1)
                    Console.Write($"\t{i}\n");
                else
                    Console.Write($"\t{i}");
            }
            //b
            string[] arr2 = new string[4] { "word1", "word2", "word3", "word4" };
            int position;
            string value;
            Console.WriteLine("\n");
            foreach (string i in arr2)
            {
                Console.Write($"\t{i}");
            }
            Console.WriteLine($"\n\tДлина{arr2.Length}");
            Console.Write("\tВведите позицию: ");
            position = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tВведите строку: ");
            value = Console.ReadLine();
            arr2[position] = value;
            Console.WriteLine("\n");
            foreach (string i in arr2)
            {
                Console.Write($"\t{i}");
            }
            //c
            double[][] arr3 = new double[3][];
            arr3[0] = new double[2];
            arr3[1] = new double[3];
            arr3[2] = new double[4];
            Console.WriteLine("\n");
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.WriteLine("\tВведите массив значений: ");
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    Console.Write("\tВведите значение: ");
                    arr3[i][j] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            foreach (double[] i in arr3)
            {
                foreach (double j in i)
                {
                    Console.Write($"\t{j}");
                }
                Console.WriteLine();
            }
            //d
            var str10 = "test";
            var arr4 = new[] { 1, 2 };

            /* 4.  Кортежи    */
            //a
            (int, string, char, string, ulong) items = (1, "Test", 'l', "Word", 10);
            (int, string, char, string, ulong) items2 = (1, "Test", 'l', "Word", 10);
            //b
            Console.WriteLine($"\n\t{ items }\titem2 = {items.Item2}");
            //c
            var (k, t, c, d, e) = items;
            (var l, var p, var o, var q, var y) = items;
            Console.WriteLine($"\n\t{t}");
            Console.WriteLine($"\n\t{items.CompareTo(items2)}");

            /* 5. */
            (int min, int max, int sum, string letter) GetMinAndMax(int[]arr, string str)
            {
                var result = (min:arr[0], max:arr[0], sum:0, letter: "");
                result.letter = str.Substring(0, 1);
                foreach (int i in arr)
                {
                    if (i > result.max)
                        result.max = i;
                    if (i < result.min)
                        result.min = i;
                    result.sum += i;
                }
                return result;
            }
        
            Console.WriteLine($"\n\t{GetMinAndMax(new int[]{-1, 2, -9, 15, 3}, "hello")}");

            /* 6. */
            void func1()
            {
                checked //проверка переполнения
                {
                    int a = 10;
                    int i = 2147483647 + a;
                    Console.WriteLine($"\n\t{i}");
                }
            }

            void func2()
            {
                unchecked
                {
                    int a = 10;
                    int i = 2147483647 + a;
                    Console.WriteLine($"\n\t{i}");
                }
            }

            //func1();
            func2();
        }
    }
}
