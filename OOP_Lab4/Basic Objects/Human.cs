using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Human : ISentientBeing
    {
        // Свойства
        public int IQ { get; }

        // Конструкторы
        public Human(int IQ)
        {
            this.IQ = IQ;
        }

        // Методы
        public void Say()
        {
            Console.WriteLine("I'm a human being!");
        }
    }
}
