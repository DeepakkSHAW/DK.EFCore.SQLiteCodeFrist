﻿// <auto-generated />
using System;
using DK.EFCore.SQLiteCodeFrist.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DK.EFCore.SQLiteCodeFrist.Data.Migrations
{
    [DbContext(typeof(AMCDBContext))]
    partial class AMCDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("DK.EFCore.SQLiteCodeFrist.DataModel.AMC", b =>
                {
                    b.Property<int>("AMCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AMCTitle")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("InDate")
                        .HasColumnName("inDate")
                        .HasColumnType("TEXT");

                    b.HasKey("AMCId");

                    b.ToTable("T_AMC");

                    b.HasData(
                        new
                        {
                            AMCId = 1,
                            AMCTitle = "OM test AMC",
                            InDate = new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("DK.EFCore.SQLiteCodeFrist.DataModel.MutualFund", b =>
                {
                    b.Property<int>("MutualFundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AMCId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("InDate")
                        .HasColumnName("inDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MutualFundName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("MutualFundId");

                    b.HasIndex("AMCId");

                    b.ToTable("T_MF");
                });

            modelBuilder.Entity("DK.EFCore.SQLiteCodeFrist.DataModel.MutualFund", b =>
                {
                    b.HasOne("DK.EFCore.SQLiteCodeFrist.DataModel.AMC", "AMC")
                        .WithMany("MutualFunds")
                        .HasForeignKey("AMCId");
                });
#pragma warning restore 612, 618
        }
    }
}
