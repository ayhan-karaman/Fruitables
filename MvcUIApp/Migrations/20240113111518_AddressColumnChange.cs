using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcUIApp.Migrations
{
    /// <inheritdoc />
    public partial class AddressColumnChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "Line");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 11, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(3130), new DateTime(2024, 1, 12, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 9, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(3140), new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 8, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4090), new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 6, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4090), new DateTime(2024, 1, 9, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 3, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2024, 1, 3, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 15, 18, 323, DateTimeKind.Utc).AddTicks(4100));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Line",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 11, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(7140), new DateTime(2024, 1, 12, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 9, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(7150), new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 8, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8100), new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 6, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8110), new DateTime(2024, 1, 9, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 3, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2024, 1, 3, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 11, 7, 13, 285, DateTimeKind.Utc).AddTicks(8120));
        }
    }
}
