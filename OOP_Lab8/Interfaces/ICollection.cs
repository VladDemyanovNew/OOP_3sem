using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab8
{
    interface ICollection<T>
    {
        void AddItems(params T[] items);
        void DeleteItem(int index);
        T[] GetItems();
    }
}
