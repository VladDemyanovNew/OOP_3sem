using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab16
{
    class Warehouse
    {
        private BlockingCollection<string> goods;

        public Warehouse()
        {
            goods = new BlockingCollection<string>();
        }

        public void Producer(int count)
        {
            string productName = "product";
            for (int i = 0; i < count; i++)
                goods.Add(productName + i);
            Console.WriteLine($"На склад добавлено: {count} продукт(ов).");
            goods.CompleteAdding();
            CurrentState();
        }

        public void Consumer()
        {
            string productName;
            while (!goods.IsCompleted)
            {
                if (goods.TryTake(out productName))
                    Console.WriteLine("Купили: " + productName);
            }
            CurrentState();
        }

        private void CurrentState()
        {
            Console.WriteLine();
            Console.WriteLine("Состояние склада.");
            Console.WriteLine($"Продукты на складе: {String.Join(", ", goods.ToArray())}");
            Console.WriteLine();
        }
    }
}
