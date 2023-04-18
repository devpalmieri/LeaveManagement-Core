using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8c0565-6343-4447-8396-762c48md5861",
                column: "ConcurrencyStamp",
                value: "1c0bd9a9-4cb6-44bd-96cb-c03d542e35eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3u8c0564-6343-4447-8396-762c48fh5889",
                column: "ConcurrencyStamp",
                value: "d3bc2435-65f8-4586-8b39-bca6080cbcff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1u9d0565-6343-5557-8396-762c48hf9811",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8512baf-b959-4b04-9d03-f3e9737791e6", "AQAAAAEAACcQAAAAEIj0xE7KimZHY3NFxoQ2i3Q8Ufts+TT1cYN40Dh1jjmnLmDK0z27DC8RfPkQqR4zEw==", "543ac41d-c27c-4a9d-b9cd-ac0a11724af3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8c0565-6343-4b57-8396-762c48bc5853",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa5d9886-9870-421e-a5d9-37fd5792d9de", "AQAAAAEAACcQAAAAECaKVFB38PbjymwxWckBB5cdS8ZyNSMLAZkF4nl9McvT8VrPIzqcnVFe5TXzrDhD2g==", "c9e89ee8-108c-4e25-9363-05adfebb3c84" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8c0565-6343-4447-8396-762c48md5861",
                column: "ConcurrencyStamp",
                value: "b6824cd0-f3a0-4c62-9ab8-169b57846e46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3u8c0564-6343-4447-8396-762c48fh5889",
                column: "ConcurrencyStamp",
                value: "06e9e753-3604-4a7a-89b4-e479737b638f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1u9d0565-6343-5557-8396-762c48hf9811",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "983e43fb-6d1b-4b2b-82ed-e927dbc83d2d", "AQAAAAEAACcQAAAAEG7PqVoBT8tzuzb10clecqcGx7aqXQQhxb16ruGhFfj3in28vcV2A4vsGTzlZ/TpCg==", "37a0f601-9908-40f1-a8dc-85e300a6cda2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8c0565-6343-4b57-8396-762c48bc5853",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628484e6-850e-4fc7-b063-b03b57707f8e", "AQAAAAEAACcQAAAAEG6DqizBP5yhlDFqveOpKTgSMmVV+ZK0BFLaPDTbZelVNHGWnFBaV/OtP2VGyrPWkQ==", "a61c8358-5bb7-4f08-8705-784648c9bc71" });
        }
    }
}
