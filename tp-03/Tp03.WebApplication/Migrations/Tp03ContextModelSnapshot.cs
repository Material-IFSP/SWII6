﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp03.Core.Data;

namespace Tp03.WebApplication.Migrations
{
    [DbContext(typeof(Tp03Context))]
    partial class Tp03ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tp03.Core.Entities.BillOfLading", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Consignee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BillsOfLading");
                });

            modelBuilder.Entity("Tp03.Core.Entities.Container", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillOfLadingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillOfLandingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tamanho")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BillOfLadingId");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("Tp03.Core.Entities.Container", b =>
                {
                    b.HasOne("Tp03.Core.Entities.BillOfLading", "BillOfLading")
                        .WithMany("Containers")
                        .HasForeignKey("BillOfLadingId");

                    b.Navigation("BillOfLading");
                });

            modelBuilder.Entity("Tp03.Core.Entities.BillOfLading", b =>
                {
                    b.Navigation("Containers");
                });
#pragma warning restore 612, 618
        }
    }
}