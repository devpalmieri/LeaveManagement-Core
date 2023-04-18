using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class addmigrationleave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8c0565-6343-4447-8396-762c48md5861",
                column: "ConcurrencyStamp",
                value: "6042a17b-ae1b-44ca-9ab8-07436b2b3c09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3u8c0564-6343-4447-8396-762c48fh5889",
                column: "ConcurrencyStamp",
                value: "bfea9c47-ba8b-4e95-ace7-86162f81aac5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1u9d0565-6343-5557-8396-762c48hf9811",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aeaf1e8-0f62-438e-b66c-45ef0ac9cba4", "AQAAAAEAACcQAAAAENvLeRY6Ii3N983axZqAKJROI1ZqlaGRrfUHlhUINzpU15UojYM1sgcn++OVFcpRdw==", "8da5a02c-ec60-4235-9803-fdbba69dcc15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8c0565-6343-4b57-8396-762c48bc5853",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "841e6054-e6a8-40a3-94a4-bde474023605", "AQAAAAEAACcQAAAAED4ne1QWgsw0okC8OpZLf6L5gQiV7Xy9CEX8/eUmecrMgLMwiLFpCQLDLzTqHo/ZAg==", "1fef90fa-0c72-48f8-a265-3262c25f5de6" });
        }
    }
}
