﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.dbcontext;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230607073435_TaoDb")]
    partial class TaoDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("CloseTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("WebApplication1.models.StoreSupplier", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("IntimacyLevel")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SuppliersSupplier");
                });

            modelBuilder.Entity("WebApplication1.models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("WebApplication1.models.StoreSupplier", b =>
                {
                    b.HasOne("WebApplication1.models.Store", "Store")
                        .WithMany("StoreSuppliers")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.models.Supplier", "Supplier")
                        .WithMany("StoreSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WebApplication1.models.Store", b =>
                {
                    b.Navigation("StoreSuppliers");
                });

            modelBuilder.Entity("WebApplication1.models.Supplier", b =>
                {
                    b.Navigation("StoreSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
