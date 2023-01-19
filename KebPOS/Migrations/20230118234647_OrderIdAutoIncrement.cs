using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KebPOS.Migrations
{
    /// <inheritdoc />
    public partial class OrderIdAutoIncrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 1, 18, 23, 46, 47, 836, DateTimeKind.Utc).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 1, 18, 23, 50, 47, 836, DateTimeKind.Utc).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 1, 18, 23, 55, 47, 836, DateTimeKind.Utc).AddTicks(9121));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 27, 6, 34, 3, 450, DateTimeKind.Utc).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 11, 27, 6, 38, 3, 450, DateTimeKind.Utc).AddTicks(645));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2022, 11, 27, 6, 43, 3, 450, DateTimeKind.Utc).AddTicks(655));
        }
    }
}
