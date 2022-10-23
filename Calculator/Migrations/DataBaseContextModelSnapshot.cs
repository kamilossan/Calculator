﻿// <auto-generated />
using System;
using Calculator.Utilities.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Calculator.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Calculator.Utilities.SQL.Models.LogEntry", b =>
                {
                    b.Property<string>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Operation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Request")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("RequestId");

                    b.ToTable("LogEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
