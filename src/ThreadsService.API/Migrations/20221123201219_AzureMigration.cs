using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreadsService.API.Migrations
{
    /// <inheritdoc />
    public partial class AzureMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "threads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threads", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "threads",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "LastEdited", "TopicName" },
                values: new object[,]
                {
                    { new Guid("158e74d8-361d-451e-a6be-90e8b3bc7720"), "calin", "henry ponmter", new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3458), "Voldemort was an amazing villain wow!" },
                    { new Guid("80d11658-930b-4eed-ac34-66e5058b7ee0"), "calin", "What a bad movie lol", new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3410), new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3445), "Does anyone absolutely hate Harry Potter?" },
                    { new Guid("a77021b5-2fdf-4c75-b798-df88a4231a6b"), "calin", "kek", new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3452), new DateTime(2022, 11, 23, 21, 12, 19, 131, DateTimeKind.Local).AddTicks(3454), "I think Dune was an amazing movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "threads");
        }
    }
}
