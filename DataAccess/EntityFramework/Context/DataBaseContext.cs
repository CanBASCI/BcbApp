using Entities.Base;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Context
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Logger> Logger { get; set; }
    }
}
