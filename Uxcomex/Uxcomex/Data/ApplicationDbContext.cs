using Microsoft.EntityFrameworkCore;
using Uxcomex.Models;

namespace Uxcomex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PersonModel> Tb_Person { get; set; }
        public DbSet<AddressModel> Tb_Address { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
