using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMap.APP.Entities
{
    public class Administrator : Employee
    {
        public int NumberOfStaffSupervised { get; set; }

        public Administrator(string name, string lastname, string dni, int age, string email, string telephone,
                             string communityID, DateTime joinDate, decimal salary, string sns, DateTime hireDate,
                             int numberOfStaffSupervised)
            : base(name, lastname, dni, age, email, telephone, communityID, joinDate, salary, sns, hireDate)
        {
            NumberOfStaffSupervised = numberOfStaffSupervised;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[ADMINISTRATOR] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, " +
                              $"Community ID: {CommunityID}, Joined: {JoinDate.ToShortDateString()}, Hire Date: {HireDate.ToShortDateString()}, " +
                              $"Salary: ${Salary}, SNS: {SNS}, Staff Supervised: {NumberOfStaffSupervised}");
        }
    }
}
