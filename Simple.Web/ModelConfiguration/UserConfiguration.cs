using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple.Web.Models;

namespace Simple.Web.ModelConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));  
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);  
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(250);

        }
    }
}
