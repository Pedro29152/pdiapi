using Microsoft.EntityFrameworkCore;
using PdiApi.Models.Contratos;
using PdiApi.Models.NotasFiscais;

namespace PdiApi.Repository
{
    public class PdiContext : DbContext
    {
        public PdiContext(DbContextOptions options) : base(options)
        {   }

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>().ToTable("Receitas");
            modelBuilder.Entity<Receita>().HasOne(r => r.Contrato)
                .WithMany(c => c.Receitas)
                .HasForeignKey(r => r.ContratoID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receita>()
                .HasIndex(r => new { r.NroNota, r.CNPJ })
                .IsUnique();
            modelBuilder.Entity<Receita>().HasOne(r => r.Cliente)
                .WithMany(cl => cl.Receitas)
                .HasForeignKey(c => c.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contrato>().ToTable("Contratos");
            modelBuilder.Entity<Contrato>()
                .HasMany(c => c.Receitas)
                .WithOne(n => n.Contrato);
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.NomeCliente)
                .IsUnique();
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Receitas)
                .WithOne(n => n.Cliente);

        }
    }
}
