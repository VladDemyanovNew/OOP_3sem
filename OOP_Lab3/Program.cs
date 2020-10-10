using System;
using System.Collections.Generic;

namespace OOP_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Set element1 = new Set();
            Set element2 = new Set();
            element1 = element1 + "string";                                     //  перегрузка + на добавление элемента
            element2 = element2 + "int";
            Console.WriteLine("\t" + element1.GetListItem(0));
            element1 = element1 + element2;                                     //  объединение множеств
            element1.OutputList();
            element2 = element2 + "char";
            element1 = element1 + "object";
            element1.OutputList();
            element2.OutputList();
            element1 = element1 * element2;                                     //  пересечение множеств
            element1.OutputList();
            Console.WriteLine($"\tМощность множества: {(int)element1}");        //  мощность множества
            if (element1)                                                       //  перегрузка true false
                Console.WriteLine("\tРазмер массива > 0");
            else
                Console.WriteLine("\tРазмер массива = 0");
            element1.Arr.AddRange(new List<string>() { "el1", "el2", "el1", "el1", "el3" });
            element1.AddComma();
            element1.OutputList();                                              //  расширяющий метод
            element1.DeleteRepeated();
            element1.OutputList();

            string testStr = "Hello";
            char c = 'l';
            Console.WriteLine($"\tсимвол {c} входит в строку {testStr} {testStr.CharCount(c)} раз(а)");
            element1.Sum();
            element1.deltaBetweenMinMax();
            element1.lengthOfArr();

            Set man1 = new Set(1, "Vlad", "BSTU");
            man1.OutputOwner();
        }
    }
}
