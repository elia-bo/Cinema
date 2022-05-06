﻿// <auto-generated />
using System;
using Cinema.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20220506091347_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.Domain.Biglietto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fila")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Posto")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Biglietti");
                });

            modelBuilder.Entity("Cinema.Domain.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Durata")
                        .HasColumnType("time");

                    b.Property<int>("Genere")
                        .HasColumnType("int");

                    b.Property<string>("Produttore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitoloFilm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Cinema.Domain.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdFilmInCorso")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumSpettatori")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFilmInCorso")
                        .IsUnique();

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("Cinema.Domain.Spettatore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<int>("Eta")
                        .HasColumnType("int");

                    b.Property<int>("IdBiglietto")
                        .HasColumnType("int");

                    b.Property<bool>("Maggiorenne")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBiglietto")
                        .IsUnique();

                    b.HasIndex("SalaId");

                    b.ToTable("Spettatori");
                });

            modelBuilder.Entity("Cinema.Domain.Sala", b =>
                {
                    b.HasOne("Cinema.Domain.Film", "FilmInCorso")
                        .WithOne("Sala")
                        .HasForeignKey("Cinema.Domain.Sala", "IdFilmInCorso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmInCorso");
                });

            modelBuilder.Entity("Cinema.Domain.Spettatore", b =>
                {
                    b.HasOne("Cinema.Domain.Biglietto", "Biglietto")
                        .WithOne("Spettatore")
                        .HasForeignKey("Cinema.Domain.Spettatore", "IdBiglietto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Domain.Sala", "Sala")
                        .WithMany("Spettatori")
                        .HasForeignKey("SalaId");

                    b.Navigation("Biglietto");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Cinema.Domain.Biglietto", b =>
                {
                    b.Navigation("Spettatore");
                });

            modelBuilder.Entity("Cinema.Domain.Film", b =>
                {
                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Cinema.Domain.Sala", b =>
                {
                    b.Navigation("Spettatori");
                });
#pragma warning restore 612, 618
        }
    }
}
