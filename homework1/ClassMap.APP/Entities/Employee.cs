using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassMap.APP.AbstractClass;

namespace ClassMap.APP.Entities
{
    public class Employee : CommunityMember
    {

        public decimal Salary { get; set; }

        public string SNS { get; set; }

        public DateTime HireDate { get; set; }
        public Employee(string name, string lastname, string dni, int age, string email, string telephone,
                    string communityID, DateTime joinDate, decimal salary, string sns, DateTime hireDate)
        : base(name, lastname, dni, age, email, telephone, communityID, joinDate)
        {
            Salary = salary;
            SNS = sns;
            HireDate = hireDate;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[EMPLOYEE] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, " +
                              $"Community ID: {CommunityID}, Joined: {JoinDate.ToShortDateString()}, " +
                              $"Salary: ${Salary}, SNS: {SNS}, Hire Date: {HireDate.ToShortDateString()}");
        }
    }
}
