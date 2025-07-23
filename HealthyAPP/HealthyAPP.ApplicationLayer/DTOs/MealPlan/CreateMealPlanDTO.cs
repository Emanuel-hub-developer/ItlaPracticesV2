using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.DTOs.MealPlan
{
    public class CreateMealPlanDTO
    {
        public string Name { get; set; }
        public string MealType { get; set; }
        public int Calories { get; set; }
        public DateTime MealDate { get; set; }
    }
}
