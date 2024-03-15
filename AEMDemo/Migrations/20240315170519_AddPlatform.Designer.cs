﻿// <auto-generated />
using System;
using AEMDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AEMDemo.Migrations
{
    [DbContext(typeof(AEMDemoContext))]
    [Migration("20240315170519_AddPlatform")]
    partial class AddPlatform
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AEMDemo.PlatformDto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("uniqueName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("PlatformDto");
                });

            modelBuilder.Entity("AEMDemo.WellDto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("PlatformDtoid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<int>("platformId")
                        .HasColumnType("int");

                    b.Property<string>("uniqueName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("PlatformDtoid");

                    b.ToTable("WellDto");
                });

            modelBuilder.Entity("AEMDemo.WellDto", b =>
                {
                    b.HasOne("AEMDemo.PlatformDto", null)
                        .WithMany("well")
                        .HasForeignKey("PlatformDtoid");
                });

            modelBuilder.Entity("AEMDemo.PlatformDto", b =>
                {
                    b.Navigation("well");
                });
#pragma warning restore 612, 618
        }
    }
}