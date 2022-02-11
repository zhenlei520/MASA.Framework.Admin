﻿// <auto-generated />
using System;
using MASA.Framework.Admin.Configuration.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MASA.Framework.Admin.Configuration.Migrations
{
    [DbContext(typeof(ConfigurationDbContext))]
    [Migration("20220211155858_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MASA.BuildingBlocks.Dispatcher.IntegrationEvents.Logs.IntegrationEventLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TimesSent")
                        .HasColumnType("int");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("integration_event_log", "configuration");
                });

            modelBuilder.Entity("MASA.Framework.Admin.Configuration.Domain.Aggregate.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_time");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("creator");

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("describe");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("icon");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("modifier_time");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("modifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("parent_id");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("parent_name");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasColumnName("sort");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("menus", "configuration");
                });
#pragma warning restore 612, 618
        }
    }
}
