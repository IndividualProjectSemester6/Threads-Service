﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThreadsService.Infrastructure.Contexts;

#nullable disable

namespace ThreadsService.API.Migrations
{
    [DbContext(typeof(ThreadDbContext))]
    [Migration("20221202110518_sqlnew")]
    partial class sqlnew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ThreadsService.Domain.Entities.ThreadDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("threads", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("39b225e4-39fb-4e60-86a4-648cef6a0743"),
                            Author = "calin",
                            Content = "What a bad movie lol",
                            CreatedAt = new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7427),
                            ForumId = new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"),
                            LastEdited = new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7467),
                            TopicName = "Does anyone absolutely hate Harry Potter?"
                        },
                        new
                        {
                            Id = new Guid("d525ef0a-5007-4abd-a0bb-e06d7ecd68f1"),
                            Author = "calin",
                            Content = "kek",
                            CreatedAt = new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7479),
                            ForumId = new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"),
                            LastEdited = new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7481),
                            TopicName = "I think Dune was an amazing movie"
                        },
                        new
                        {
                            Id = new Guid("0a4f8e9d-6dab-402c-81ce-b8662e43e4cd"),
                            Author = "calin",
                            Content = "henry ponmter",
                            CreatedAt = new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7486),
                            ForumId = new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"),
                            LastEdited = new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7488),
                            TopicName = "Voldemort was an amazing villain wow!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
