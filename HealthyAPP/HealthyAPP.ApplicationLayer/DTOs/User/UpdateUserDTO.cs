using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.DTOs.User
{
    public class UpdateUserDTO
    {
        public int User_id { get; set; }  // Necesario para identificar el registro a modificar
        public string Name { get; set; }
        public string? Email { get; set; }
        public int? Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string ActivityLevel { get; set; }
    }
}
