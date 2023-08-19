using Microsoft.EntityFrameworkCore;
using Models;
using Web.Mappings;

namespace Web.DataAccess
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<User> User { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new UserMapping());
      }
   }
}
