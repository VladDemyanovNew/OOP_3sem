using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Printer
    {
        public virtual void IAmPrinting(Vehicle obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
