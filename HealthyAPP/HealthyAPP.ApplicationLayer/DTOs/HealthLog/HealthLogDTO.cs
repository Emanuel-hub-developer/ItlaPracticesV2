using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.DTOs.HealthLog
{
    public class HealthLogDTO
    {
        public int HealthLog_Id { get; set; }
        public DateTime LogDate { get; set; }
        public decimal? Weight { get; set; }
        public string? Blood_Pressure { get; set; }
        public decimal? Glucose { get; set; }
    }
}
