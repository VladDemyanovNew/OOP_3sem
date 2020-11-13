using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab8
{
    class Printer<T>
    {
        public static void printBasic(T[] items)
        {
            Console.Write("\tarray: ");
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void printCars(Car[] cars)
        {
            Console.Write("\tarray: ");
            foreach (Car car in cars)
            {
                Console.Write(car.Model + " ");
            }
            Console.WriteLine();
        }
    }
}
