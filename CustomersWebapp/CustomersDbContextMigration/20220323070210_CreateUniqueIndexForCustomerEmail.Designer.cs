﻿// <auto-generated />
using CustomersWebapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomersWebapp.CustomersDbContextMigration
{
    [DbContext(typeof(CustomersDbContext))]
    [Migration("20220323070210_CreateUniqueIndexForCustomerEmail")]
    partial class CreateUniqueIndexForCustomerEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomersWebapp.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Department = "Department",
                            Email = "elkadim@email.com",
                            ManagerId = 0,
                            Name = "Wael Elkadim",
                            Phone = "01324213"
                        },
                        new
                        {
                            ID = 2,
                            Department = "Department",
                            Email = "amohamed@email.com",
                            ManagerId = 0,
                            Name = "Ahmed Mohamed",
                            Phone = "01322213"
                        },
                        new
                        {
                            ID = 3,
                            Department = "Department",
                            Email = "alimohamed@email.com",
                            ManagerId = 0,
                            Name = "Ali Mohamed",
                            Phone = "01324223"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
