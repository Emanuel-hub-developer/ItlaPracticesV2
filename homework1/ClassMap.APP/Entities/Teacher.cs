using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMap.APP.Entities
{
    public class Teacher : Employee
    {
     
        public string EducationLevel { get; set; }

        public Teacher(string name, string lastname, string dni, int age, string email, string telephone,
                       string communityID, DateTime joinDate, decimal salary, string sns, DateTime hireDate,
                       string educationLevel)
            : base(name, lastname, dni, age, email, telephone, communityID, joinDate, salary, sns, hireDate)
        {
            EducationLevel = educationLevel;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[TEACHER] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, " +
                              $"Community ID: {CommunityID}, Joined: {JoinDate.ToShortDateString()}, Hire Date: {HireDate.ToShortDateString()}, " +
                              $"Salary: ${Salary}, SNS: {SNS}, Education Level: {EducationLevel}");
        }
    }
}
