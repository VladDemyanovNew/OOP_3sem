using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3
{
    class Owner
    {
        private int id;
        private string name;
        private string organization;
        public Owner (int id, string name, string organization)
        {
            this.id = id;
            this.name = name;
            this.organization = organization;
        }

        public void OutputOwner()
        {
            Console.WriteLine($"\tid={this.id} name={this.name} organization={organization}");
        }
    }
}
