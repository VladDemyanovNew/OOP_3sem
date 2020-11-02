using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    sealed class Car : Vehicle  // sealed значит что от этого класса нельзя наследовать
    {
        // Свойства
        public IEngine Engine { get; set; }

        public Color carColor { get; set; }
        public enum Color
        {
            Red = 1,
            White,
            Black,
            Orange
        }

        // Конструкторы
        public Car(int Weight, int MaxSpeed, Color color)
        {
            this.MaxSpeed = MaxSpeed;
            this.Weight = Weight;
            this.carColor = color;
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

        // for exercize
        public override bool DoClone()
        {
            return true;
        }
    }

    //class testSealed : Car    Ошибка - класс Car запечатаный
    //{

    //}
}
