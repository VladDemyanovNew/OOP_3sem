using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab14
{
    [Serializable]
    public class Car : Vehicle  // sealed значит что от этого класса нельзя наследовать
    {

        // Конструкторы
        public Car(int Weight, int MaxSpeed, string name)
        {
            this.MaxSpeed = MaxSpeed;
            this.Weight = Weight;
            this.name = name;
        }

        public Car()
        {

        }

        // Методы
        public override double calculateRate2()  // С полиморфизмом подтипов
        {
            return this.Weight / 2;
        }
    }
}
