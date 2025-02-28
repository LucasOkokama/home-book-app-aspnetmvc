using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeBookApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "\\images\\VillaImage\\9a94b90b-f4de-48af-a2be-3062f46ed318.jpg", "Royal Villa", 4, 200.0, 550, null },
                    { 2, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "\\images\\VillaImage\\ea29a3ae-32cb-4587-adb3-b8d832f6e002.jpg", "Premium Pool Villa", 5, 300.0, 600, null },
                    { 3, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "\\images\\VillaImage\\7cbe3bba-c159-47dd-9ee3-ab11fdb1e03f.jpg", "Luxury Pool Villa", 7, 400.0, 750, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
