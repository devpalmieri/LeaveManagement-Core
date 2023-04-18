using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a8c0565-6343-4447-8396-762c48md5861", "371968b2-04bc-40d1-a285-e8e263fc0258", "Administrator", "ADMINISTRATOR" },
                    { "3u8c0564-6343-4447-8396-762c48fh5889", "2c904b3e-7a63-410d-8a02-5279160217fd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1u9d0565-6343-5557-8396-762c48hf9811", 0, "c664c5c7-7ef2-4ff6-8a70-b1e824ba7b0c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEJexgHcoHVfI3fPloD8pTq/4KMYd7YUm+PY3xpwJLNdaS6eu5xFGch8ekxc5X8f8xw==", null, false, "a45646a9-6e4d-45d1-af57-aac2a0400299", null, false, null },
                    { "5e8c0565-6343-4b57-8396-762c48bc5853", 0, "22a8a007-0e2a-4033-9b1f-79bc2817c352", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEGVW74fySxGQ3Lati8ZbtIby+zxaDLGpEAfsafRPJJjwO6Qf8r067v3TsONXd2+SsQ==", null, false, "0b95df67-3087-4897-9fd3-4aeac96c3c28", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a8c0565-6343-4447-8396-762c48md5861", "1u9d0565-6343-5557-8396-762c48hf9811" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3u8c0564-6343-4447-8396-762c48fh5889", "5e8c0565-6343-4b57-8396-762c48bc5853" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a8c0565-6343-4447-8396-762c48md5861", "1u9d0565-6343-5557-8396-762c48hf9811" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3u8c0564-6343-4447-8396-762c48fh5889", "5e8c0565-6343-4b57-8396-762c48bc5853" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8c0565-6343-4447-8396-762c48md5861");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3u8c0564-6343-4447-8396-762c48fh5889");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1u9d0565-6343-5557-8396-762c48hf9811");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8c0565-6343-4b57-8396-762c48bc5853");
        }
    }
}
