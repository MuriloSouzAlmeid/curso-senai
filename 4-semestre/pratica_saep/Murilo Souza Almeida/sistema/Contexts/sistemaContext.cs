using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sistema.Models;

namespace sistema.Contexts;

public partial class sistemaContext : DbContext
{
    public sistemaContext()
    {
    }

    public sistemaContext(DbContextOptions<sistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atividade> Atividades { get; set; }

    public virtual DbSet<Professor> Professores { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE07-SALA19; initial catalog=dev_db; User Id=sa; Pwd=Senai@134;  TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atividade>(entity =>
        {
            entity.HasKey(e => e.AtividadeId).HasName("PK__Atividad__742A5DF449F2BD16");

            entity.ToTable("Atividade");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Turma).WithMany(p => p.Atividades)
                .HasForeignKey(d => d.TurmaId)
                .HasConstraintName("FK__Atividade__Turma__4E88ABD4");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK__Professo__900359496AFA01D6");

            entity.ToTable("Professor");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.TurmaId).HasName("PK__Turma__BABB9304B41BFFF0");

            entity.ToTable("Turma");

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Professor).WithMany(p => p.Turmas)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK__Turma__Professor__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
