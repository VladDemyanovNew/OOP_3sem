﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Transformer : Vehicle, ISentientBeing
    {
        // Свойства
        public IEngine Engine { get; set; }
        public int IQ { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }

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

        public Transformer()
        {
            this.MaxSpeed = 0;
            this.Weight = 0;
            this.IQ = 0;
            this.Year = 0;
            this.Name = "";
            this.Power = 0;
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
