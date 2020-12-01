using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab11
{
    class Type
    {
        public string Quarantine { get; private set; }
        public string Specialty { get; private set; }
        public Type(string Quarantine, string Specialty)
        {
            this.Specialty = Specialty;
            this.Quarantine = Quarantine;
        }
    }
}
