﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module.Entities;

#nullable disable

namespace Module.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Module.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdentityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("Module.Entities.ActivityHistory", b =>
                {
                    b.Property<string>("CallId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Times")
                        .HasColumnType("datetime2");

                    b.HasKey("CallId");

                    b.ToTable("ActivityHistory", (string)null);
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

                    b.ToTable("Calls", (string)null);
                });

            modelBuilder.Entity("Module.Entities.CallDetail", b =>
                {
                    b.Property<string>("CallId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("AnswerDuration")
                        .HasColumnType("bigint");

                    b.Property<long?>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("EndedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndedCause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TimeEnd")
                        .HasColumnType("bigint");

                    b.HasKey("CallId");

                    b.ToTable("CallDetails", (string)null);
                });

            modelBuilder.Entity("Module.Entities.EventConfiguration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListParams")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RouteRule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventConfigurations", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
