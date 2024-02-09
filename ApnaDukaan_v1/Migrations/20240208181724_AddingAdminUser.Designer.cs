﻿// <auto-generated />
using System;
using ApnaDukaan_v1.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApnaDukaan_v1.Migrations
{
    [DbContext(typeof(ApnaDukaanContext))]
    [Migration("20240208181724_AddingAdminUser")]
    partial class AddingAdminUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Landmark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cosmetics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Furniture"
                        });
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StockAvailable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Customer"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "GM"
                        });
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime")
                        .HasColumnName("DOB");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Username" }, "UQ__Users__536C85E4816D808D")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D105342DE4E41C")
                        .IsUnique();

                    b.HasIndex(new[] { "PhoneNo" }, "UQ__Users__F3EE33E2DC867CA5")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mak.thevar@outlook.com",
                            FirstName = "Mak",
                            LastName = "Thevar",
                            PasswordHash = "AQAAAAEAACcQAAAAEB612RH/X0CfAJ85yOS2FS2XSZp81H+9VUfcpJi/2+Uxu3VW5SdKjnKC+eH741oKjw==",
                            PhoneNo = "9888888888",
                            RoleId = 2,
                            Username = "mkthevar"
                        });
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Address", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Addresses__UserI__2E1BDC42");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Cart", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Carts__UserId__3B75D760");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.CartDetail", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .IsRequired()
                        .HasConstraintName("FK__CartDetai__CartI__3E52440B");

                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Product", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__CartDetai__Produ__3F466844");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Order", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__AddressI__34C8D9D1");

                    b.HasOne("ApnaDukaan_v1.DAL.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__UserId__33D4B598");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.OrderDetail", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Order__37A5467C");

                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Produ__38996AB5");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Product", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Products__Catego__30F848ED");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.User", b =>
                {
                    b.HasOne("ApnaDukaan_v1.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Users__RoleId__2B3F6F97");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Product", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ApnaDukaan_v1.DAL.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
