using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP_Lab14
{
    [Serializable]
    public abstract class Vehicle
    {
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        [NonSerialized]
        private protected string name;

        // С полиморфизмом подтипов
        public virtual double calculateRate2()
        {
            return (this.Weight + 1000) / 2;
        }

        // Переопределнный ToString()
        public override string ToString()
        {
            System.Reflection.PropertyInfo[] properties = this.GetType().GetProperties();
            string result = "Type: " + base.ToString();
            foreach (var value in properties)
            {
                result += " " + value.GetValue(this, null);
            }

            return result;
        }

    }
}
