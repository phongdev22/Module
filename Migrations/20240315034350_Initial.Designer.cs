﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module.Entities;

#nullable disable

namespace Module.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240315034350_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Module.Entities.ActivityHistory", b =>
                {
                    b.Property<string>("CallId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("CallId");

                    b.ToTable("ActivityHistory");
                });

            modelBuilder.Entity("Module.Entities.Call", b =>
                {
                    b.Property<string>("CallId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountSid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TimeStart")
                        .HasColumnType("bigint");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallId");

                    b.ToTable("Calls");
                });
#pragma warning restore 612, 618
        }
    }
}
