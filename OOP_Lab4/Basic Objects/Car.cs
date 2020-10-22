using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Car : Vehicle
    {
        // Свойства
        public IEngine Engine { get; set; }

        // Конструкторы
        public Car(int Weight, int MaxSpeed)
        {
            this.MaxSpeed = MaxSpeed;
            this.Weight = Weight;
        }

        // Методы
        public double calculateRate()   // Без полиморфизма подтипов
        {
            return this.Weight / 2;
        }

        public override double calculateRate2()  // С полиморфизмом подтипов
        {
            return this.Weight / 2;
        }
    }
}
