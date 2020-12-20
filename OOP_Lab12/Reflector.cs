using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OOP_Lab12
{
    static class Reflector
    {
        private static void WriteInJSON<T>(string ex, string description, params T[] value_) 
        {
            JArray array = new JArray();
            array.Add(description);
            array.Add(value_);
            JObject o = new JObject();
            o[ex] = array;

            string json = "";

            using (StreamReader fs = new StreamReader(@"./../../../resources/result.json"))
            {
                string data = fs.ReadToEnd();
                if (data.Trim().Length == 0)
                {
                    List<JObject> items = new List<JObject>();
                    items.Add(o);
                    json = JsonConvert.SerializeObject(items);
                }
                else
                {
                    List<JObject> items = JsonConvert.DeserializeObject<List<JObject>>(data);
                    items.Add(o);
                    json = JsonConvert.SerializeObject(items);
                }
            }

            using (StreamWriter w = new StreamWriter(@"./../../../resources/result.json", false))
                w.WriteLine(json);
        }

        public static void GetAssembly(string type)
        {
            Type MyType = Type.GetType(type, true, true);
            WriteInJSON("a", "Имя сборки, в которой определён класс", MyType.Assembly.ToString());
        }

        public static void CheckPublicConstructos(string type)
        {
            bool flag = false;
            Type MyType = Type.GetType(type, true, true);
            foreach (ConstructorInfo item in MyType.GetConstructors())
                if (item.IsPublic)
                {
                    flag = true;
                    break;
                }

            WriteInJSON("b", "Есть ли публичные конструкторы", flag);
        }

        public static void PublicMethods(string type)
        {
            Type MyType = Type.GetType(type, true, true);
            //MethodInfo[] methods = MyType.GetMethods(BindingFlags.Public);
            List<string> methods = new List<string>();
            foreach (MethodInfo method in MyType.GetMethods())
                if (method.IsPublic)
                    methods.Add(method.ToString());
            WriteInJSON("c", "Публичные методы", methods);
        }

        public static void FieldsAndProperties(string type)
        {
            Type MyType = Type.GetType(type, true, true);

            List<string> result = new List<string>();
            var bf = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

            foreach (MemberInfo item in MyType.GetMembers(bf))
                if (item.MemberType == MemberTypes.Property || item.MemberType == MemberTypes.Field)
                    result.Add(item.ToString());

            WriteInJSON("d", "Поля и свойства класса", result);
        }

        public static void Interfaces(string type)
        {
            Type MyType = Type.GetType(type, true, true);
            List<string> result = new List<string>();
            foreach (Type item in MyType.GetInterfaces())
                result.Add(item.ToString());
            WriteInJSON("e", "Интерфейсы класса", result);
        }

        public static void MethodsByParameter(string type, string param)
        {
            Type MyType = Type.GetType(type, true, true);
            List<string> MethodsNames = new List<string>();
            var bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            foreach (MethodInfo method in MyType.GetMethods(bf))
            {
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                    if (parameters[i].ParameterType.Name == param)
                    {
                        MethodsNames.Add(method.Name);
                        break;
                    }
            }
            WriteInJSON("f", $"Имена методов, которые содержат параметр типа {param}", MethodsNames);
        }

        public static void CallMethod(string type, string methodName)
        {
            Type MyType = Type.GetType(type, true, true);
            object obj = Activator.CreateInstance(MyType);
            MethodInfo method = MyType.GetMethod(methodName);

            ParameterInfo[] parameters = method.GetParameters();
            Random rand = new Random();
            List<object> parms = new List<object>();
            for (int i = 0; i < parameters.Length; i++)
            {
                switch(parameters[i].ParameterType.Name)
                {
                    case "String":
                        parms.Add("key" + rand.Next(0, 5));
                        break;
                    case "Int32":
                        parms.Add(rand.Next(6, 10));
                        break;
                }
                
            }

            object result = method?.Invoke(obj, parms.ToArray());
            WriteInJSON("g", $"Результат выполнения метода {methodName}", result);
        }
    }
}
