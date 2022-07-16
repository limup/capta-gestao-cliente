using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using captaApi.Model;

namespace captaApi.Data
{
    public partial class CaptaContext : DbContext
    {
        public CaptaContext()
        {
        }

        public CaptaContext(DbContextOptions<CaptaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCliente> TbClientes { get; set; } = null!;
        public virtual DbSet<TbDominio> TbDominios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.ToTable("tb_cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf).HasColumnName("cpf");

                entity.Property(e => e.Nome).HasColumnName("nome");

                entity.Property(e => e.Sexo).HasColumnName("sexo");
            });

            modelBuilder.Entity<TbDominio>(entity =>
            {
                entity.ToTable("tb_dominio");

                entity.HasIndex(e => e.ClienteIdFk, "IX_tb_dominio_ClienteId_FK");

                entity.Property(e => e.ClienteIdFk).HasColumnName("ClienteId_FK");

                entity.HasOne(d => d.ClienteIdFkNavigation)
                    .WithMany(p => p.TbDominios)
                    .HasForeignKey(d => d.ClienteIdFk)
                    .IsRequired(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
