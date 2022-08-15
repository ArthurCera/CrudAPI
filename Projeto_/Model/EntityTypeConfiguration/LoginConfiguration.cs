using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace EntityTypeConfiguration
{
    internal class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Username);

            builder.Property(c => c.Password);
        }
    }
}