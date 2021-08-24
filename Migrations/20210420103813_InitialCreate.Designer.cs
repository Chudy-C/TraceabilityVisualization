﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using TraceabilityVisualization.Data;

namespace TraceabilityVisualization.Migrations
{
    [DbContext(typeof(KomoraContext))]
    [Migration("20210420103813_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TraceabilityVisualization.Models.KomoraWozek", b =>
                {
                    b.Property<int>("ID_Trace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kolor_cewki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_wozka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TS_KOM1")
                        .HasColumnType("datetime2");

                    b.Property<string>("Typ_cewki")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Trace");

                    b.ToTable("KomoraWozek");
                });
#pragma warning restore 612, 618
        }
    }
}
