using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace OOP_Lab10
{
    class Products : IOrderedDictionary
    {
        private ArrayList _products;

        public Products(int numItems)
        {
            _products = new ArrayList(numItems);
        }

        //  Вернуть индекс по ключу
        public int IndexOfKey(object key)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                //  public struct DictionaryEntry
                if (((Product)_products[i]).Key == key)
                    return i;
            }
            //  Ключ не найден
            return -1;
        }

        //  Найти или установить значние в ключ
        public object this[object key]
        {
            get
            {
                return ((Product)_products[IndexOfKey(key)]).Value;
            }
            set
            {
                _products[IndexOfKey(key)] = new Product(key, value);
            }
        }

        //  IOrderedDictionary
        public IDictionaryEnumerator GetEnumerator()
        {
            return new ProductEnum(_products);
        }

        //  Вставка новой пары ключ-значение в коллекцию по индексу index
        public void Insert(int index, object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("Элемент с таким ключём уже содержится в коллекции.");
            }
            _products.Insert(index, new Product(key, value));
        }

        //  Удаляет из списка элемент по индексу index
        public void RemoveAt(int index)
        {
            _products.RemoveAt(index);
        }

        //  Найти или установить по индексу значение
        public object this[int index]
        {
            get
            {
                return ((Product)_products[index]).Value;
            }
            set
            {
                object key = ((Product)_products[index]).Key;
                _products[index] = new Product(key, value);
            }
        }

        //  IDictionary
        //  Добавить пару ключ-значение
        public void Add(object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("Элемент с таким ключём уже содержится в коллекции.");
            }
            _products.Add(new Product(key, value));
        }

        //  Удаляет из списка все элементы
        public void Clear()
        {
            _products.Clear();
        }

        //  Проверка содержится ли элемент с ключём key в коллекции
        public bool Contains(object key)
        {
            if (IndexOfKey(key) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        //  Достать коллекцию ключей
        public ICollection Keys
        {
            get
            {
                ArrayList KeyCollection = new ArrayList(_products.Count);
                for (int i = 0; i < _products.Count; i++)
                {
                    KeyCollection.Add(((Product)_products[i]).Key);
                }
                return KeyCollection;
            }
        }

        //  Достать коллекцию значений
        public ICollection Values
        {
            get
            {
                ArrayList ValueCollection = new ArrayList(_products.Count);
                for (int i = 0; i < _products.Count; i++)
                {
                    ValueCollection.Add(((Product)_products[i]).Value);
                }
                return ValueCollection;
            }
        }

        //  Удаляет из списка элемент по ключу key
        public void Remove(object key)
        {
            _products.RemoveAt(IndexOfKey(key));
        }

        //  ICollection
        //  Копирует элементы списка начиная с индекса index в массив array
        public void CopyTo(Array array, int index)
        {
            _products.CopyTo(array, index);
        }

        //  Возвращает размер коллекции
        public int Count
        {
            get
            {
                return _products.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return _products.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return _products.SyncRoot;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() // метод интерфейса IEnumerable возвращает ссылку на перечеслитель
        {
            return new ProductEnum(_products);
        }

        public void DisplayCollection()
        {
            Console.WriteLine("Пары ключ-значение в коллекции:");
            foreach (Product de in this)
            {
                Console.WriteLine($"{ de.Key} {de.Value}");
            }
        }
    }

}