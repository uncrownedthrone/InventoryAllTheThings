﻿// <auto-generated />
using System;
using InventoryAllTheThings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InventoryAllTheThings.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("InventoryAllTheThings.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumberInStock")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("SKU")
                        .HasColumnType("integer");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
