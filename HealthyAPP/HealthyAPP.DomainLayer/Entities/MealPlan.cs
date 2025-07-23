using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.DomainLayer.Entities
{
    public class MealPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int MealPlan_id { get; set; }

        public string Name { get; set; }    

        public string MealType { get; set; } 

        public int Calories { get; set; }

        public DateTime MealDate { get; set; }


        // Foreign Key to User
        public int User_id { get; set; }

        // Navigation property to User
        public User User { get; set; }
    }
}
 