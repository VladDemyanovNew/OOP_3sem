using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab11
{
    class Student
    {
        public string Specialty { get; private set; }
        public string Faculty { get; private set; }
        public int Group { get; private set; }
        public int Age { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }

        public Student(string Surname, string Name, int Age, int Group, string Faculty, string Specialty)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Age = Age;
            this.Group = Group;
            this.Faculty = Faculty;
            this.Specialty = Specialty;
        }
    }
}
