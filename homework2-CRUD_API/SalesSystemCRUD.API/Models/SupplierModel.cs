using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesSystemCRUD.API.Models
{
    public class SupplierModel
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }

            public string name { get; set; }

            public string contact { get; set; }
    
    }


    

}
