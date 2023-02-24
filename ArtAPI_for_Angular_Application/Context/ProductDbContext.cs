using ArtAPI_for_Angular_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtAPI_for_Angular_Application.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> artwork { get; set; }

    }
}
