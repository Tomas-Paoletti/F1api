﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using f1api.Models;

#nullable disable

namespace F1api.Migrations
{
    [DbContext(typeof(F1Context))]
    [Migration("20240226202641_driverUpdate")]
    partial class driverUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("f1api.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebutTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DebutYear")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("IdDriverStats")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDriverStats")
                        .IsUnique()
                        .HasFilter("[IdDriverStats] IS NOT NULL");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("f1api.Models.DriverStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FastestLaps")
                        .HasColumnType("int");

                    b.Property<int>("IdDriver")
                        .HasColumnType("int");

                    b.Property<int>("Podiums")
                        .HasColumnType("int");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.Property<int>("Poles")
                        .HasColumnType("int");

                    b.Property<int>("Titles")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DriverStats");
                });

            modelBuilder.Entity("f1api.Models.Driver", b =>
                {
                    b.HasOne("f1api.Models.DriverStats", "DriverStats")
                        .WithOne("Driver")
                        .HasForeignKey("f1api.Models.Driver", "IdDriverStats");

                    b.Navigation("DriverStats");
                });

            modelBuilder.Entity("f1api.Models.DriverStats", b =>
                {
                    b.Navigation("Driver")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
