﻿// <auto-generated />
using Masala1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Masala1.Migrations
{
    [DbContext(typeof(KarraDbContext))]
    [Migration("20221101161623_AddedTable")]
    partial class AddedTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Masala1.Entities.Karra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Natija")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Son")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Karra");
                });
#pragma warning restore 612, 618
        }
    }
}
