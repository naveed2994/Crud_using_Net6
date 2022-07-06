﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Presistance;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("508c1066-566f-4b54-ba7f-5379f0be491a"),
                            CreatedBy = new Guid("c6041666-f220-4eda-a1e4-baa3023bb857"),
                            CreatedOn = new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4601),
                            Fname = "Khan",
                            Name = "Ali",
                            Phone = "023204902843"
                        },
                        new
                        {
                            Id = new Guid("8f6f8513-4e0e-4d52-ba23-b3b2898ae619"),
                            CreatedBy = new Guid("3619196f-8a50-45fb-ab1b-f00a5fc682de"),
                            CreatedOn = new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4642),
                            Fname = "Mustaq",
                            Name = "Faisal",
                            Phone = "023204902843"
                        },
                        new
                        {
                            Id = new Guid("80aeda5b-9b3c-4f41-9634-d356107673bd"),
                            CreatedBy = new Guid("2e1319be-a22e-4abd-9054-05c02e35422a"),
                            CreatedOn = new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4654),
                            Fname = "Shahzad",
                            Name = "Hanif",
                            Phone = "023204902843"
                        },
                        new
                        {
                            Id = new Guid("ad0c07ed-db07-431b-bfef-cdac9212b380"),
                            CreatedBy = new Guid("0819b03e-c449-4f4a-bf0e-f2fac63e14c0"),
                            CreatedOn = new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4662),
                            Fname = "Khan",
                            Name = "Saif",
                            Phone = "023204902843"
                        },
                        new
                        {
                            Id = new Guid("141f916d-0d14-41dd-981e-05ad591373e8"),
                            CreatedBy = new Guid("37494a26-3ae0-45e6-a44d-90ac41d87039"),
                            CreatedOn = new DateTime(2022, 7, 4, 8, 54, 29, 230, DateTimeKind.Utc).AddTicks(4674),
                            Fname = "Khan",
                            Name = "Sohail",
                            Phone = "023204902843"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
