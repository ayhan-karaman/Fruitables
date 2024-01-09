using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcUIApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryname = table.Column<string>(name: "category_name", type: "text", nullable: false),
                    categorystatus = table.Column<bool>(name: "category_status", type: "boolean", nullable: false, defaultValue: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updateat = table.Column<DateTime>(name: "update_at", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryid = table.Column<int>(name: "category_id", type: "integer", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "text", nullable: false),
                    imageurl = table.Column<string>(name: "image_url", type: "text", nullable: true, defaultValue: "img/default.png"),
                    unitprice = table.Column<decimal>(name: "unit_price", type: "numeric", nullable: false),
                    showcase = table.Column<bool>(name: "show_case", type: "boolean", nullable: false),
                    unitsinstock = table.Column<decimal>(name: "units_in_stock", type: "numeric", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updateat = table.Column<DateTime>(name: "update_at", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "created_at", "category_name", "category_status", "update_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 7, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5650), "Sebze", true, new DateTime(2024, 1, 8, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660) },
                    { 2, new DateTime(2024, 1, 5, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660), "Meyve", true, new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660) },
                    { 3, new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660), "Yeşillik", true, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "category_id", "created_at", "image_url", "product_name", "show_case", "unit_price", "units_in_stock", "update_at" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 1, 4, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6750), "img/default.png", "Elma", true, 29m, 40m, new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6750) },
                    { 2, 2, new DateTime(2024, 1, 2, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760), "img/default.png", "Portakal", true, 19m, 50m, new DateTime(2024, 1, 5, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760) },
                    { 3, 2, new DateTime(2023, 12, 30, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760), "img/default.png", "Mandalina", true, 19m, 37m, null },
                    { 4, 1, new DateTime(2023, 12, 30, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760), "img/default.png", "Patlıcan", true, 39m, 107m, null },
                    { 5, 1, new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760), "img/default.png", "Dolma biber", true, 49m, 87m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
