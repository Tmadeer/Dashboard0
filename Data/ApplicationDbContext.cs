using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        
        {
        
        
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Costumers> costumers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<PaymentAccept> paymentAccepts { get; set; }

        public DbSet<Cart> carts { get; set; }
    }
}
