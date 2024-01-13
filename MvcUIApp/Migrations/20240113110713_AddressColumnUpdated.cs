using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcUIApp.Migrations
{
    /// <inheritdoc />
    public partial class AddressColumnUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HomeNumber",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "HomeNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 11, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(8610), new DateTime(2024, 1, 12, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 9, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(8620), new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 8, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9570), new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "update_at" },
                values: new object[] { new DateTime(2024, 1, 6, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9580), new DateTime(2024, 1, 9, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 1, 3, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2024, 1, 3, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2024, 1, 10, 9, 28, 32, 480, DateTimeKind.Utc).AddTicks(9590));
        }
    }
}
