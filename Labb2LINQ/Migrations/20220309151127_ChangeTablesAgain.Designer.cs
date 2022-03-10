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
    [Migration("20220309151127_ChangeTablesAgain")]
    partial class ChangeTablesAgain
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

                    b.Property<int?>("LärareID")
                        .HasColumnType("int");

                    b.HasKey("KursId");

                    b.HasIndex("LärareID");

                    b.ToTable("Kurser");
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

                    b.Property<int>("fKursenId")
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

                    b.Property<int?>("LärareID")
                        .HasColumnType("int");

                    b.Property<string>("ÄmneNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ÄmneId");

                    b.HasIndex("LärareID");

                    b.ToTable("Ämnen");
                });

            modelBuilder.Entity("Labb2LINQ.Model.Kurs", b =>
                {
                    b.HasOne("Labb2LINQ.Model.Lärare", "Lärare")
                        .WithMany()
                        .HasForeignKey("LärareID");
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

            modelBuilder.Entity("Labb2LINQ.Model.Ämne", b =>
                {
                    b.HasOne("Labb2LINQ.Model.Lärare", "Lärare")
                        .WithMany("Ämnen")
                        .HasForeignKey("LärareID");
                });
#pragma warning restore 612, 618
        }
    }
}
