﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickPickWebApi.Core;

namespace QuickPickWebApi.Core.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201013161918_ff")]
    partial class ff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category_Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Address2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Address3")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ContactNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EmailId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InvoiceDetal")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("InvoiceStatusCodeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceStatusCodeId");

                    b.HasIndex("OrderId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.InvoiceStatusCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("InvoiceStaus_Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("InvoiceStatusCodes");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OrderStatus_Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataOrder_Placed")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OrderDetail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Product_Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Product_Color")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Product_Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Product_Model")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Product_Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Product_Price")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Product_Size")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Shop_Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Category", b =>
                {
                    b.HasOne("QuickPickWebApi.Core.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Invoice", b =>
                {
                    b.HasOne("QuickPickWebApi.Core.Models.InvoiceStatusCode", "InvoiceStatusCode")
                        .WithMany()
                        .HasForeignKey("InvoiceStatusCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickPickWebApi.Core.Models.Orders", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Orders", b =>
                {
                    b.HasOne("QuickPickWebApi.Core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickPickWebApi.Core.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickPickWebApi.Core.Models.Product", b =>
                {
                    b.HasOne("QuickPickWebApi.Core.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}