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

        // Конструкторы
        public Transformer(int Weight, int MaxSpeed, int IQ)
        {
            this.MaxSpeed = MaxSpeed;
            this.Weight = Weight;
            this.IQ = IQ;
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
