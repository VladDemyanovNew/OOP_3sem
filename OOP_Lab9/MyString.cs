using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP_Lab9
{
    
    class MyString
    {
        //  Свойства
        public int Length { get; private set; }
        public string String { get; private protected set; }

        //  Конструкторы
        public MyString()
        {
            this.Length = 0;
        }

        public MyString(string String)
        {
            this.Length = String.Length;
            this.String = String;
        }

        //  Методы
        public void MakeString(Func <string, string> func)
        {
            this.String = func(this.String);
        }

        public void Print()
        {
            Console.WriteLine(this.String);
        }

        //  Перегрузки
        public static MyString operator +(MyString String1, MyString String2)
        {
            string str = String1.String + String2.String;
            MyString result = new MyString(str);
            return result;
        }

        public static MyString operator +(MyString String1, string String2)
        {
            string str = String1.String + String2;
            MyString result = new MyString(str);
            return result;
        }

        public static MyString operator +(string String1, MyString String2)
        {
            string str = String1 + String2.String;
            MyString result = new MyString(str);
            return result;
        }
    }
}
