using Microsoft.EntityFrameworkCore;
using SalesSystemCRUD.API.Models;

namespace SalesSystemCRUD.API.Context
{
    public class SalesSystemContext : DbContext
    {
        public SalesSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set; }

        public DbSet<SupplierModel> Supplier { get; set; }
    }
}
