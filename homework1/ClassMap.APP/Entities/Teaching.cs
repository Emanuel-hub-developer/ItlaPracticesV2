using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMap.APP.Entities
{
    public  class Teaching : Teacher
    {
        public string Certification { get; set; }  
        public int TeachingHours { get; set; }

        public Teaching(string name, string lastname, string dni, int age, string email, string telephone,
                    string communityID, DateTime joinDate, decimal salary, string sns, DateTime hireDate,
                    string educationLevel, string certification, int teachingHours)
        : base(name, lastname, dni, age, email, telephone, communityID, joinDate, salary, sns, hireDate, educationLevel)
        {
            Certification = certification;
            TeachingHours = teachingHours;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[TEACHING] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, " +
                              $"Community ID: {CommunityID}, Joined: {JoinDate.ToShortDateString()}, Hire Date: {HireDate.ToShortDateString()}, " +
                              $"Salary: ${Salary}, SNS: {SNS}, Education Level: {EducationLevel}, " +
                              $"Certification: {Certification}, Teaching Hours: {TeachingHours}");
        }
    }
}
