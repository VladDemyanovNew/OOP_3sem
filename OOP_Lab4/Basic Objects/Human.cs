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

        // for exercize
        public bool DoClone()
        {
            return true;
        }

        // Переопределнный ToString()
        public override string ToString()
        {
            System.Reflection.PropertyInfo[] properties = this.GetType().GetProperties();
            string result = "Type: " + base.ToString();
            foreach (var value in properties)
            {
                result += " " + value.GetValue(this, null);
            }

            return result;
        }
    }
}

