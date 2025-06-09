using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMap.APP.Entities
{
    public class Administrative : Employee
    {
        public string Area { get; set; }
    public string OfficeNumber { get; set; }

    public Administrative(string name, string lastname, string dni, int age, string email, string telephone,
                          string communityID, DateTime joinDate, decimal salary, string sns, DateTime hireDate,
                          string area, string officeNumber)
        : base(name, lastname, dni, age, email, telephone, communityID, joinDate, salary, sns, hireDate)
    {
        Area = area;
        OfficeNumber = officeNumber;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[ADMINISTRATIVE] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, " +
                          $"Community ID: {CommunityID}, Joined: {JoinDate.ToShortDateString()}, Hire Date: {HireDate.ToShortDateString()}, " +
                          $"Salary: ${Salary}, SNS: {SNS}, Area: {Area}, Office #: {OfficeNumber}");
    }
    }
}
