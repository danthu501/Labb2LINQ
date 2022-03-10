﻿// <auto-generated />
using System;
using Labb2LINQ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb2LINQ.Migrations
{
    [DbContext(typeof(DBContextLabb2LINQ))]
    [Migration("20220310092746_JAJA4")]
    partial class JAJA4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb2LINQ.Model.Kurs", b =>
                {
                    b.Property<int>("KursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KursNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KursId");

                    b.ToTable("Kurser");
                });

            modelBuilder.Entity("Labb2LINQ.Model.KursÄmne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("fKurserKursId")
                        .HasColumnType("int");

                    b.Property<int?>("fÄmneÄmneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fKurserKursId");

                    b.HasIndex("fÄmneÄmneId");

                    b.ToTable("KursÄmne");
                });

            modelBuilder.Entity("Labb2LINQ.Model.Lärare", b =>
                {
                    b.Property<int>("LärareID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Efternamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Förnamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LärareID");

                    b.ToTable("Lärare");
                });

            modelBuilder.Entity("Labb2LINQ.Model.LärareÄmne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LärareID")
                        .HasColumnType("int");

                    b.Property<int?>("ÄmneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LärareID");

                    b.HasIndex("ÄmneId");

                    b.ToTable("LärareÄmnen");
                });

            modelBuilder.Entity("Labb2LINQ.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Efternamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Förnamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KursId")
                        .HasColumnType("int");

                    b.Property<int?>("ÄmnenÄmneId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("KursId");

                    b.HasIndex("ÄmnenÄmneId");

                    b.ToTable("Studenter");
                });

            modelBuilder.Entity("Labb2LINQ.Model.Ämne", b =>
                {
                    b.Property<int>("ÄmneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ÄmneNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ÄmneId");

                    b.ToTable("Ämnen");
                });

            modelBuilder.Entity("Labb2LINQ.Model.KursÄmne", b =>
                {
                    b.HasOne("Labb2LINQ.Model.Kurs", "fKurser")
                        .WithMany()
                        .HasForeignKey("fKurserKursId");

                    b.HasOne("Labb2LINQ.Model.Ämne", "fÄmne")
                        .WithMany()
                        .HasForeignKey("fÄmneÄmneId");
                });

            modelBuilder.Entity("Labb2LINQ.Model.LärareÄmne", b =>
                {
                    b.HasOne("Labb2LINQ.Model.Lärare", "Lärare")
                        .WithMany()
                        .HasForeignKey("LärareID");

                    b.HasOne("Labb2LINQ.Model.Ämne", "Ämne")
                        .WithMany()
                        .HasForeignKey("ÄmneId");
                });

            modelBuilder.Entity("Labb2LINQ.Model.Student", b =>
                {
                    b.HasOne("Labb2LINQ.Model.Kurs", null)
                        .WithMany("Studenter")
                        .HasForeignKey("KursId");

                    b.HasOne("Labb2LINQ.Model.Ämne", "Ämnen")
                        .WithMany()
                        .HasForeignKey("ÄmnenÄmneId");
                });
#pragma warning restore 612, 618
        }
    }
}
