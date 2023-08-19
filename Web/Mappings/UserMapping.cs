using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Web.Mappings
{
   public class UserMapping : IEntityTypeConfiguration<User>
   {
      public void Configure(EntityTypeBuilder<User> builder)
      {
         builder.ToTable("users");
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
         builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
         builder.OwnsOne(x => x.Email, o =>
         {
            o.Property(p => p.Value).IsRequired().HasColumnName("email").HasMaxLength(100);
         });
      }
   }
}

