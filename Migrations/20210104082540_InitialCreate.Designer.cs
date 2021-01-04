﻿// <auto-generated />
using System;
using EFC4RESTAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFC4RESTAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210104082540_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EFC4RESTAPI.Models.Config", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId", "Name")
                        .IsUnique()
                        .HasDatabaseName("UIX_Configs_Pid_Name");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("EFC4RESTAPI.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("InvalidTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<double>("Score")
                        .HasColumnType("double");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Score");

                    b.ToTable("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}