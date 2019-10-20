using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.DatabaseContext.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Amount", "CreateDate", "Description", "TotalAmount", "Type", "UpdateDate" },
                values: new object[] { 1, 1000m, new DateTime(2019, 10, 20, 21, 51, 1, 23, DateTimeKind.Local), "Initial Debit", 1000m, 1, null });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Amount", "CreateDate", "Description", "TotalAmount", "Type", "UpdateDate" },
                values: new object[] { 2, 100m, new DateTime(2019, 10, 20, 21, 51, 1, 25, DateTimeKind.Local), "Initial Credit", 900m, 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
