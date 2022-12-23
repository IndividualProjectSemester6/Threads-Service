using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThreadsService.API.Migrations
{
    /// <inheritdoc />
    public partial class sqlnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "threads",
                keyColumn: "Id",
                keyValue: new Guid("158e74d8-361d-451e-a6be-90e8b3bc7720"));

            migrationBuilder.DeleteData(
                table: "threads",
                keyColumn: "Id",
                keyValue: new Guid("80d11658-930b-4eed-ac34-66e5058b7ee0"));

            migrationBuilder.DeleteData(
                table: "threads",
                keyColumn: "Id",
                keyValue: new Guid("a77021b5-2fdf-4c75-b798-df88a4231a6b"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForumId",
                table: "threads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "threads",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "ForumId", "LastEdited", "TopicName" },
                values: new object[,]
                {
                    { new Guid("0a4f8e9d-6dab-402c-81ce-b8662e43e4cd"), "calin", "henry ponmter", new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7486), new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7488), "Voldemort was an amazing villain wow!" },
                    { new Guid("39b225e4-39fb-4e60-86a4-648cef6a0743"), "calin", "What a bad movie lol", new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7427), new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7467), "Does anyone absolutely hate Harry Potter?" },
                    { new Guid("d525ef0a-5007-4abd-a0bb-e06d7ecd68f1"), "calin", "kek", new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7479), new Guid("f2e9d7e3-a591-4e51-ad20-eb4b4d492b68"), new DateTime(2022, 12, 2, 12, 5, 17, 983, DateTimeKind.Local).AddTicks(7481), "I think Dune was an amazing movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "threads",
                keyColumn: "Id",
                keyValue: new Guid("0a4f8e9d-6dab-402c-81ce-b8662e43e4cd"));

            migrationBuilder.DeleteData(
                table: "threads",
                keyColumn: "Id",
                keyValue: new Guid("39b225e4-39fb-4e60-86a4-648cef6a0743"));

            migrationBuilder.DeleteData(
                table: "threads",
                keyColumn: "Id",
                keyValue: new Guid("d525ef0a-5007-4abd-a0bb-e06d7ecd68f1"));

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "threads");

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
    }
}
