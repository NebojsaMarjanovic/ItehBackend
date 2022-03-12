﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220312182423_addedRezervacije")]
    partial class addedRezervacije
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Grad", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Naseljenost")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valuta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradId");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("Domain.Rezervacija", b =>
                {
                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RezervacijaId")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Polazak")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Povratak")
                        .HasColumnType("datetime2");

                    b.HasKey("GradId", "UserId", "RezervacijaId");

                    b.HasIndex("UserId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Admin", b =>
                {
                    b.HasBaseType("Domain.User");

                    b.Property<int>("Uloga")
                        .HasColumnType("int");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Domain.Klijent", b =>
                {
                    b.HasBaseType("Domain.User");

                    b.Property<string>("BrTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("Domain.Rezervacija", b =>
                {
                    b.HasOne("Domain.Grad", "Grad")
                        .WithMany("Rezervacije")
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Rezervacije")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Admin", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Admin", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Klijent", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Klijent", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Grad", b =>
                {
                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Rezervacije");
                });
#pragma warning restore 612, 618
        }
    }
}
