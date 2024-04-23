﻿// <auto-generated />
using System;
using ExamensarbeteNy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamensarbeteNy.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240331131237_AddingUnderkategorier")]
    partial class AddingUnderkategorier
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.7.21378.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamensarbeteNy.Models.Användare", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Användarnamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lösenord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Användare");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Bevakning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnvändarId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnvändareId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnvändareId");

                    b.HasIndex("ProduktId");

                    b.ToTable("Bevakningar");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ÖverkategoriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ÖverkategoriId");

                    b.ToTable("Kategorier");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Kundkorg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnvändarId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnvändarId")
                        .IsUnique();

                    b.ToTable("Kundkorgar");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnvändarId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnvändareId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BildUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int?>("KundkorgId")
                        .HasColumnType("int");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pris")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AnvändareId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("KundkorgId");

                    b.ToTable("Produkter");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Bevakning", b =>
                {
                    b.HasOne("ExamensarbeteNy.Models.Användare", "Användare")
                        .WithMany("Bevakningar")
                        .HasForeignKey("AnvändareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamensarbeteNy.Models.Produkt", "Produkt")
                        .WithMany("Bevakningar")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Användare");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Kategori", b =>
                {
                    b.HasOne("ExamensarbeteNy.Models.Kategori", "Överkategori")
                        .WithMany("Underkategorier")
                        .HasForeignKey("ÖverkategoriId");

                    b.Navigation("Överkategori");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Kundkorg", b =>
                {
                    b.HasOne("ExamensarbeteNy.Models.Användare", "Användare")
                        .WithOne("Kundkorg")
                        .HasForeignKey("ExamensarbeteNy.Models.Kundkorg", "AnvändarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Användare");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Produkt", b =>
                {
                    b.HasOne("ExamensarbeteNy.Models.Användare", "Användare")
                        .WithMany()
                        .HasForeignKey("AnvändareId");

                    b.HasOne("ExamensarbeteNy.Models.Kategori", "Kategori")
                        .WithMany("Produkter")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamensarbeteNy.Models.Kundkorg", null)
                        .WithMany("Produkter")
                        .HasForeignKey("KundkorgId");

                    b.Navigation("Användare");

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Användare", b =>
                {
                    b.Navigation("Bevakningar");

                    b.Navigation("Kundkorg")
                        .IsRequired();
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Kategori", b =>
                {
                    b.Navigation("Produkter");

                    b.Navigation("Underkategorier");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Kundkorg", b =>
                {
                    b.Navigation("Produkter");
                });

            modelBuilder.Entity("ExamensarbeteNy.Models.Produkt", b =>
                {
                    b.Navigation("Bevakningar");
                });
#pragma warning restore 612, 618
        }
    }
}
