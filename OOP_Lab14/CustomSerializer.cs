using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP_Lab14
{
    static class CustomSerializer<T>
    {
        public static void SaveBinaryFormat(object obj)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fs = new FileStream(@"./../../resources/BinData.dat", FileMode.OpenOrCreate))
            {
                binFormat.Serialize(fs, obj);
            }
        }

        public static T LoadFromBinaryFile()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fs = File.OpenRead(@"./../../resources/BinData.dat"))
            {
                T obj = (T)binFormat.Deserialize(fs);
                return obj;
            }
        }

        public static void SoapWriteFile(object obj)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (Stream fs = new FileStream(@"./../../resources/SoapData.dat", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, obj);
            }
        }

        public static T LoadFromSoapFile()
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (Stream fs = File.OpenRead(@"./../../resources/SoapData.dat"))
            {
                T obj = (T)soapFormatter.Deserialize(fs);
                return obj;
            }
        }

        public static void JSONWriteFile(T obj)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (Stream fs = new FileStream(@"./../../resources/JSONData.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, obj);
            }
        }

        public static T LoadFromJSONFile()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (Stream fs = File.OpenRead(@"./../../resources/JSONData.json"))
            {
                T obj = (T)jsonFormatter.ReadObject(fs);
                return obj;
            }
        }

        public static void XMLWriteFile(params Car[] obj)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Car[]));
            using (Stream fs = new FileStream(@"./../../resources/XMLData.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, obj);
            }
        }

        public static Car[] LoadFromXMLFile()
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Car[]));
            using (Stream fs = File.OpenRead(@"./../../resources/XMLData.xml"))
            {
                Car[] obj = (Car[])xSer.Deserialize(fs);
                return obj;
            }
        }

        public static void ArrWriteFile(T[] objects)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T[]));
            using (Stream fs = new FileStream(@"./../../resources/Arr.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, objects);
            }
        }

        public static T[] LoadArrFromFile()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T[]));
            using (Stream fs = File.OpenRead(@"./../../resources/Arr.json"))
            {
                T[] obj = (T[])jsonFormatter.ReadObject(fs);
                return obj;
            }
        }
    }
}
