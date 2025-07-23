using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.DomainLayer.Entities
{
    public class HealthLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HealthLog_id { get; set; }

        public DateTime LogDate { get; set; }

        public decimal? Weight { get; set; }

        public string Blood_Pressure { get; set; }

        public decimal? Glucose {  get; set; }


        // Foreign Key to User
        public int User_id { get; set; }

        // Navigation property to User
        public User User { get; set; }


    }
}
