using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMap.APP.AbstractClass
{
    public  abstract class Person
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string DNI { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public Person(string name, string lastname, string dni, int age, string email, string telephone)
        {
            Name = name;
            Lastname = lastname;
            DNI = dni;
            Age = age;
            Email = email;
            Telephone = telephone;
        }

        public abstract void ShowInfo();
    }
}
