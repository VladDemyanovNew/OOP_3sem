using System;
using System.IO;
using System.Reflection;

namespace OOP_Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.GetAssembly("OOP_Lab12.Class1");
            Reflector.CheckPublicConstructos("OOP_Lab12.Class1");
            Reflector.PublicMethods("OOP_Lab12.Class1");
            Reflector.FieldsAndProperties("OOP_Lab12.Class1");
            Reflector.Interfaces("OOP_Lab12.Class1");
            Reflector.MethodsByParameter("OOP_Lab12.Class1", "String");

            using (StreamReader fs = new StreamReader(@"./../../../resources/data.txt"))
            {
                string line;
                string[] str = new string[] { };
                line = fs.ReadLine();
                str = line.Split(' ');
                Reflector.CallMethod(str[0], str[1]);
            }

        }
    }
}
