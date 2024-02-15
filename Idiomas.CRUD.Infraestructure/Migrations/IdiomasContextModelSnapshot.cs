﻿// <auto-generated />
using System;
using Idiomas.CRUD.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Idiomas.CRUD.Infraestructure.Migrations
{
    [DbContext(typeof(IdiomasContext))]
    partial class IdiomasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Idiomas.CRUD.Domain.CursoIdiomas.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos", (string)null);
                });

            modelBuilder.Entity("Idiomas.CRUD.Domain.CursoIdiomas.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnoLetivo")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turmas", (string)null);
                });

            modelBuilder.Entity("Idiomas.CRUD.Domain.CursoIdiomas.Aluno", b =>
                {
                    b.HasOne("Idiomas.CRUD.Domain.CursoIdiomas.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Idiomas.CRUD.Domain.CursoIdiomas.ValueObject.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Alunos");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.OwnsOne("Idiomas.CRUD.Domain.CursoIdiomas.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("nvarchar(1024)")
                                .HasColumnName("Email");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Alunos");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Idiomas.CRUD.Domain.CursoIdiomas.Turma", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}