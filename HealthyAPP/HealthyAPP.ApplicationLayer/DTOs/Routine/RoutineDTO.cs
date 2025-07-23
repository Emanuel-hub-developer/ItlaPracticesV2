using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.DTOs.Routine
{
    public class RoutineDTO
    {
        public int Routine_id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration_Minutes { get; set; }

        public string Type { get; set; }

        public DateTime Performed_Date { get; set; }

        public int User_id { get; set; }
    }
}
