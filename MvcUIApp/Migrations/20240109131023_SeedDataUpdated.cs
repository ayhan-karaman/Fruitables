using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcUIApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 7, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1600), new DateTime(2024, 1, 8, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 5, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610), new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 4, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670), new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 2, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670), new DateTime(2024, 1, 5, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2023, 12, 30, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2023, 12, 30, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "category_id", "created_at", "image_url", "product_name", "show_case", "unit_price", "units_in_stock", "update_at" },
                values: new object[,]
                {
                    { 6, 1, new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680), "img/default.png", "Patates", true, 43m, 17m, null },
                    { 7, 1, new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680), "img/default.png", "Brokoli", true, 73m, 57m, null },
                    { 8, 2, new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680), "img/default.png", "Muz", true, 13m, 87m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 7, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5650), new DateTime(2024, 1, 8, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 5, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660), new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 4, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6750), new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 2, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760), new DateTime(2024, 1, 5, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2023, 12, 30, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2023, 12, 30, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 1, 6, 9, 17, 26, 935, DateTimeKind.Utc).AddTicks(6760));
        }
    }
}
