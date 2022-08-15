using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProjetoContext : DbContext
    {

        public ProjetoContext(DbContextOptions<ProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.LoginConfiguration());
        }
    }
}
