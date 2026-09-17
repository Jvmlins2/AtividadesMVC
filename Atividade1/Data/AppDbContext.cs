using System;
using System.Collections.Generic;
using AtividadeBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadeBiblioteca.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.LivroID).HasName("PK__Livro__548655DD52CD1B73");

            entity.ToTable("Livro");

            entity.Property(e => e.Autor).HasMaxLength(50);
            entity.Property(e => e.DataPublicacao).HasColumnType("datetime");
            entity.Property(e => e.Nome).HasMaxLength(50);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Livros)
                .HasForeignKey(d => d.UsuarioID)
                .HasConstraintName("fk_livro_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE7982A247884");

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
