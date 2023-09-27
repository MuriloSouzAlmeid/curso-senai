﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.health.clinic.project.Contexts;

#nullable disable

namespace webapi.health.clinic.project.Migrations
{
    [DbContext(typeof(HealthClinicContext))]
    partial class HealthClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.Property<DateTime?>("HorarioAbertura")
                        .IsRequired()
                        .HasColumnType("TIME");

                    b.Property<DateTime?>("HorarioEncerramento")
                        .IsRequired()
                        .HasColumnType("TIME");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("IdClinica");

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.ComentarioConsulta", b =>
                {
                    b.Property<Guid>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Exibicao")
                        .IsRequired()
                        .HasColumnType("BIT");

                    b.Property<Guid?>("IdConsulta")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdComentario");

                    b.HasIndex("IdConsulta");

                    b.ToTable("ComentarioConsulta");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataConsulta")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("IdClinica")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdMedico")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPaciente")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Situacao")
                        .IsRequired()
                        .HasColumnType("BIT");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Especialidade", b =>
                {
                    b.Property<Guid>("IdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdEspecialidade");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("CHAR(9)");

                    b.Property<string>("EstadoCRM")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("CHAR(2)");

                    b.Property<Guid?>("IdEspecialidade")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdMedico");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.Property<Guid?>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("CHAR(9)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.ProntuarioConsulta", b =>
                {
                    b.Property<Guid>("IdProntuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("IdConsulta")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProntuario");

                    b.HasIndex("IdConsulta")
                        .IsUnique();

                    b.ToTable("ProntuarioConsulta");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.TiposUsuario", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TiposUsuario");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid?>("IdTipoUsuario")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("CHAR(60)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.ComentarioConsulta", b =>
                {
                    b.HasOne("webapi.health.clinic.project.Domains.Consulta", "Consulta")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Consulta", b =>
                {
                    b.HasOne("webapi.health.clinic.project.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.project.Domains.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.project.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Medico", b =>
                {
                    b.HasOne("webapi.health.clinic.project.Domains.Especialidade", "Especialidade")
                        .WithMany("ListaDeMedicos")
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.project.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Paciente", b =>
                {
                    b.HasOne("webapi.health.clinic.project.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.ProntuarioConsulta", b =>
                {
                    b.HasOne("webapi.health.clinic.project.Domains.Consulta", "Consulta")
                        .WithOne("Prontuario")
                        .HasForeignKey("webapi.health.clinic.project.Domains.ProntuarioConsulta", "IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Usuario", b =>
                {
                    b.HasOne("webapi.health.clinic.project.Domains.TiposUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Consulta", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Prontuario");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.Especialidade", b =>
                {
                    b.Navigation("ListaDeMedicos");
                });

            modelBuilder.Entity("webapi.health.clinic.project.Domains.TiposUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
