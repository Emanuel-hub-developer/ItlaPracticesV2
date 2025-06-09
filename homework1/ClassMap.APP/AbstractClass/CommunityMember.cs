using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMap.APP.AbstractClass
{
    public abstract class CommunityMember : Person
    {
       public string CommunityID { get; set; }
        public DateTime JoinDate { get; set; }

        public CommunityMember(string name, string lastname, string dni, int age, string email, string telephone,
                       string communityID, DateTime joinDate)
    : base(name, lastname, dni, age, email, telephone)
        {
            CommunityID = communityID;
            JoinDate = joinDate;
        }


    }
}
