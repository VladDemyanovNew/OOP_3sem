using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class CarControl : IEngine
    {
        // Свойства
        public int Power { get; }

        // Конструкторы
        public CarControl(int power)
        {
            this.Power = power;
        }

        // Методы
        public void Start()
        {
            Console.WriteLine("\tЗапуск двигателя машины...");
        }
        public void Stop()
        {
            Console.WriteLine("\tОстановка двигателя машины...");
        }
    }
}
