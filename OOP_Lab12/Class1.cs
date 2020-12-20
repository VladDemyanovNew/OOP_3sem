using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab12
{
    class Class1 : ICloneable
    {
        public string Str { get; set; }
        private int Num { get; set; }

        public int a;
        private string b;

        public Class1() { }
        public Class1(int i) { }

        public Class1(string i) { }

        private Class1(float i) { }

        public void Method1() { }

        private void Method2(string s) { }

        public void Method3(string g) { }

        public string MethodG(string a, int b, string c, int d)
        {
            return a + b + " " + c + d; 
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
