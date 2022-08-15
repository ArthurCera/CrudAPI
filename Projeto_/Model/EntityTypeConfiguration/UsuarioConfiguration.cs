using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace EntityTypeConfiguration
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Nome)
                .HasMaxLength(100);

            builder.Property(c => c.Idade);

            builder.Property(c => c.Sexo);


            //endereço
            builder.Property(c => c.Numero);

            builder.Property(c => c.Rua)
                .HasMaxLength(100);

            builder.Property(c => c.Complemento)
                .HasMaxLength(100);

            builder.Property(c => c.Bairro)
                .HasMaxLength(100);

            builder.Property(c => c.Cidade)
                .HasMaxLength(100);

            builder.Property(c => c.Estado)
                .HasMaxLength(100);

            builder.Property(c => c.Pais)
                .HasMaxLength(100);

            //Documento
            builder.Property(c => c.DocumentoTipo);

            builder.Property(c => c.Documento)
                .HasMaxLength(20);
        }
    }
}