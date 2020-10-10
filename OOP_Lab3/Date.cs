using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3
{
    class Date
    {
        private DateTime dateCreated;

        public Date()
        {
            this.dateCreated = DateTime.Now;
        }

        public void OutputDate()
        {
            Console.WriteLine($"\tДата создания {this.dateCreated}");
        }
    }
}
