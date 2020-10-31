using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Transformer : Vehicle, ISentientBeing
    {
        // Свойства
        public IEngine Engine { get; set; }
        public int IQ { get; }
        public int Year { get; }
        public string Name { get; }
        public int Power { get; }

        // Конструкторы
        public Transformer(int Weight, int MaxSpeed, int IQ, int power, string name, int year)
        {
            this.MaxSpeed = MaxSpeed;
            this.Weight = Weight;
            this.IQ = IQ;
            this.Year = year;
            this.Name = name;
            this.Power = power;
        }

        // Методы
        public void Say()
        {
            Console.WriteLine("I'm a transformer being!");
        }

        public override bool DoClone()
        {
            return true;
        }
    }
}
