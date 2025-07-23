using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.DomainLayer.Entities
{
    public  class Routine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Routine_id { get; set; }

        public string Name { get; set; }    

        public string Description { get; set; }

        public int Duration_Minutes { get; set; }

        public string Type { get; set; }

        public DateTime Performed_Date { get; set; }


        // Foreign Key to User
        public int User_id { get; set; }

        // Navigation property to User
        public User User { get; set; }
    }
}
