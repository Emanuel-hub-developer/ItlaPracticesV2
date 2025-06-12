using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesSystemCRUD.API.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? name { get; set; }

        public decimal price { get; set; }

        public int stock { get; set; }

        [ForeignKey("Supplier")]
        public int? idSupplier { get; set; }
        public SupplierModel Supplier { get; set; }
    }
}
