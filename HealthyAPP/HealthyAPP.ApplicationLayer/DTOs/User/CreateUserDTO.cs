using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.DTOs.User
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public int? Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string? Activity_Level { get; set; }
    }
}
