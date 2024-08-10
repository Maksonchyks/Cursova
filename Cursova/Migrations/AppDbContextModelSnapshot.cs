﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cursova.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cursova.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Cursova.Models.SalesDeal", b =>
                {
                    b.Property<int>("DealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FrCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FrStockId")
                        .HasColumnType("int");

                    b.Property<int>("FrSupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuantitySold")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("DealId");

                    b.HasIndex("FrCustomerId");

                    b.HasIndex("FrStockId");

                    b.HasIndex("FrSupplierId");

                    b.ToTable("SalesDeals");
                });

            modelBuilder.Entity("Cursova.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FrSupplierId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StockId");

                    b.HasIndex("FrSupplierId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Cursova.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Cursova.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cursova.Models.SalesDeal", b =>
                {
                    b.HasOne("Cursova.Models.Customer", "Customer")
                        .WithMany("SalesDeals")
                        .HasForeignKey("FrCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cursova.Models.Stock", "Stock")
                        .WithMany("SalesDeal")
                        .HasForeignKey("FrStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cursova.Models.Supplier", "Supplier")
                        .WithMany("SalesDeals")
                        .HasForeignKey("FrSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stock");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Cursova.Models.Stock", b =>
                {
                    b.HasOne("Cursova.Models.Supplier", "Supplier")
                        .WithMany("Stocks")
                        .HasForeignKey("FrSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Cursova.Models.Customer", b =>
                {
                    b.Navigation("SalesDeals");
                });

            modelBuilder.Entity("Cursova.Models.Stock", b =>
                {
                    b.Navigation("SalesDeal");
                });

            modelBuilder.Entity("Cursova.Models.Supplier", b =>
                {
                    b.Navigation("SalesDeals");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
