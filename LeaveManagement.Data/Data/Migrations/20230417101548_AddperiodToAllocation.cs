using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddperiodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8c0565-6343-4447-8396-762c48md5861",
                column: "ConcurrencyStamp",
                value: "371968b2-04bc-40d1-a285-e8e263fc0258");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3u8c0564-6343-4447-8396-762c48fh5889",
                column: "ConcurrencyStamp",
                value: "2c904b3e-7a63-410d-8a02-5279160217fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1u9d0565-6343-5557-8396-762c48hf9811",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c664c5c7-7ef2-4ff6-8a70-b1e824ba7b0c", "AQAAAAEAACcQAAAAEJexgHcoHVfI3fPloD8pTq/4KMYd7YUm+PY3xpwJLNdaS6eu5xFGch8ekxc5X8f8xw==", "a45646a9-6e4d-45d1-af57-aac2a0400299" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8c0565-6343-4b57-8396-762c48bc5853",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22a8a007-0e2a-4033-9b1f-79bc2817c352", "AQAAAAEAACcQAAAAEGVW74fySxGQ3Lati8ZbtIby+zxaDLGpEAfsafRPJJjwO6Qf8r067v3TsONXd2+SsQ==", "0b95df67-3087-4897-9fd3-4aeac96c3c28" });
        }
    }
}
