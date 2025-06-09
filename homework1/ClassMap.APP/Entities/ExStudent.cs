using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassMap.APP.AbstractClass;

namespace ClassMap.APP.Entities
{
    public class ExStudent : CommunityMember
    {
        public DateTime GraduationYear { get; set; }


        public ExStudent(string name, string lastname, string dni, int age, string email, string telephone,
                    string communityID, DateTime joinDate, DateTime graduationYear)
       : base(name, lastname, dni, age, email, telephone, communityID, joinDate)
        {
            GraduationYear = graduationYear;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[EX-STUDENT] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, " +
                              $"ID: {CommunityID}, Joined: {JoinDate.ToShortDateString()}, Graduated: {GraduationYear.Year}");
        }
    }
}
