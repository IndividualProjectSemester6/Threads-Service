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
    [Migration("20221123201219_AzureMigration")]
    partial class AzureMigration
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
                            Id = new Guid("80d11658-930b-4eed-ac34-66e5058b7ee0"),
                            Author = "calin",
                            Content = "What a bad movie lol",
                            CreatedAt = new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3410),
                            LastEdited = new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3445),
                            TopicName = "Does anyone absolutely hate Harry Potter?"
                        },
                        new
                        {
                            Id = new Guid("a77021b5-2fdf-4c75-b798-df88a4231a6b"),
                            Author = "calin",
                            Content = "kek",
                            CreatedAt = new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3452),
                            LastEdited = new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3454),
                            TopicName = "I think Dune was an amazing movie"
                        },
                        new
                        {
                            Id = new Guid("158e74d8-361d-451e-a6be-90e8b3bc7720"),
                            Author = "calin",
                            Content = "henry ponmter",
                            CreatedAt = new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3457),
                            LastEdited = new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3458),
                            TopicName = "Voldemort was an amazing villain wow!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
