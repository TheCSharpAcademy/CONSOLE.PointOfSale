using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KebPOS.Migrations
{
    /// <inheritdoc />
    public partial class orderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 27, 1, 2, 22, 751, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 11, 27, 1, 6, 22, 751, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2022, 11, 27, 1, 11, 22, 751, DateTimeKind.Utc).AddTicks(3172));
        }
    }
}
