using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace OOP_Lab10
{
    class Product
    {
        public object Key;
        public object Value;

        public Product (object Key, object Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Product newUser = e.NewItems[0] as Product;
                    Console.WriteLine($"Добавлен новый объект: {newUser.Key}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Product oldUser = e.OldItems[0] as Product;
                    Console.WriteLine($"Удален объект: {oldUser.Key}");
                    break;
            }
        }
    }
}
