using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcFriends.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[,]
                {
                    { 1, "mary@gmail.com", "09123456", "Mary" },
                    { 2, "tom@gmail.com", "09789640", "Tom" },
                    { 3, "john@gmail.com", "09889111", "John" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
