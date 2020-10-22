using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class TransformerControl : IEngine
    {
        // Свойства
        public int Power { get; }

        // Конструкторы
        public TransformerControl(int Power)
        {
            this.Power = Power;
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
