using System;
using System.Collections.Generic;
using Atividade2.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade2.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Situacao> Situacaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.ProdutoID).HasName("PK__Produto__9C8800C3FFA4FD8B");

            entity.ToTable("Produto");

            entity.Property(e => e.Nome).HasMaxLength(50);

            entity.HasOne(d => d.Situacao).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.SituacaoID)
                .HasConstraintName("fk_situacao_produto");
        });

        modelBuilder.Entity<Situacao>(entity =>
        {
            entity.HasKey(e => e.SituacaoID).HasName("PK__Situacao__624445948D429542");

            entity.ToTable("Situacao");

            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE7989D2A1905");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Senha).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
