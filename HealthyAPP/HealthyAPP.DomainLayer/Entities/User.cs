using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.DomainLayer.Entities
{
    public  class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_id { get; set; }

        public string Name { get; set; }

        public string? Email { get; set; }

        public int? Password { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public string? Activity_Level { get; set; }


        // One-to-many relationships (1:N)
        public ICollection<Routine> Routines { get; set; } = new List<Routine>();
        public ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
        public ICollection<HealthLog> HealthLogs { get; set; } = new List<HealthLog>();

    }
}
