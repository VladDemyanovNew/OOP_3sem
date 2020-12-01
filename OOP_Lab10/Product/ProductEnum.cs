using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab10
{
    public class ProductEnum : IDictionaryEnumerator
    {
        public ArrayList _products;
        int position = -1;

        public ProductEnum(ArrayList list)
        {
            _products = list;
        }

        public bool MoveNext()  // перемещение на одну позицию вперёд в контеёнере элементов
        {
            position++;
            return (position < _products.Count);
        }

        public void Reset() // перемещение в начало контейнера
        {
            position = -1;
        }

        public object Current   // текущий элемент в контейнере
        {
            get
            {
                try
                {
                    return _products[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }

        public object Key
        {
            get
            {
                try
                {
                    return ((Product)_products[position]).Key;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public object Value
        {
            get
            {
                try
                {
                    return ((Product)_products[position]).Value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
