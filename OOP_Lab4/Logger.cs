using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_Lab4
{
    class Logger
    {
        public static void FileLogger(string info, string path)
        {
            using (StreamWriter w = new StreamWriter(path, true))
            {
                w.WriteLine($"Data: {DateTime.Now}; Info: {info}");
            }
        }

        public static void ConsoleLogger(string info)
        {
            Console.WriteLine($"Data: {DateTime.Now}; Info: {info}");
        }
    }
}
