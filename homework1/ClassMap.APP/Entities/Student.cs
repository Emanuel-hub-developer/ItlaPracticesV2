using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassMap.APP.AbstractClass;

namespace ClassMap.APP.Entities
{
    public class Student : CommunityMember
    {
        public string Major { get; set; }

        public int CurrentSemester { get; set; }

        public Student(string name, string lastname, string dni, int age, string email, string telephone,
                   string communityID, DateTime joinDate, string major, int currentSemester)
        : base(name, lastname, dni, age, email, telephone, communityID, joinDate)
    {
        Major = major;
        CurrentSemester = currentSemester;
    }
        public override void ShowInfo()
        {
            Console.WriteLine($"[STUDENT] {Name} {Lastname}, DNI: {DNI}, Age: {Age}, Email: {Email}, Phone: {Telephone}, ID: {CommunityID}, Join: {JoinDate.ToShortDateString()}, Major: {Major}, Semester: {CurrentSemester}");
        }

       
    }
}
