using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Human : ISentientBeing
    {
        // Свойства
        public int IQ { get; }
        public int Year { get; set; }
        public string Name { get; }

        // Конструкторы
        public Human(int IQ, int year, string name)
        {
            this.IQ = IQ;
            this.Name = name;
            this.Year = year;
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

