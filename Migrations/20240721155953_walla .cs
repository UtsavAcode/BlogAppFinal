using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class walla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3af7c5da-7110-46ee-8dcc-d2d8f693ae45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70764479-84a2-4d89-8f96-ab14c7fdc389");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6f0319e-c444-4ef8-ac9c-9ca5564c3136", "63ae39a9-23f7-479a-a08f-e3240d0a7f72" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6f0319e-c444-4ef8-ac9c-9ca5564c3136");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63ae39a9-23f7-479a-a08f-e3240d0a7f72");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69980429-db3b-4ac5-b9d7-424172acc5ff", "3", "User", "USER" },
                    { "d9c565be-cae3-43c3-8503-f6bdfa1bc6a6", "2", "Admin", "ADMIN" },
                    { "e1a0b826-7229-487f-acc5-76286e747e83", "1", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92033513-df76-4930-be59-4f23f1d8330d", 0, "09b5fd74-e039-451a-9f69-1f06c1c18ac6", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEKU/1sAQCXvR4LV0BX3bV9BbT9/IeSPCxXXTFl6XnFjZEUe06bK/iMfUt4rle/EbqA==", null, false, "6ad2d64e-97af-4770-8a74-0df41a121b1b", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1a0b826-7229-487f-acc5-76286e747e83", "92033513-df76-4930-be59-4f23f1d8330d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69980429-db3b-4ac5-b9d7-424172acc5ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9c565be-cae3-43c3-8503-f6bdfa1bc6a6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1a0b826-7229-487f-acc5-76286e747e83", "92033513-df76-4930-be59-4f23f1d8330d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a0b826-7229-487f-acc5-76286e747e83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92033513-df76-4930-be59-4f23f1d8330d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3af7c5da-7110-46ee-8dcc-d2d8f693ae45", "2", "Admin", "ADMIN" },
                    { "70764479-84a2-4d89-8f96-ab14c7fdc389", "3", "User", "USER" },
                    { "e6f0319e-c444-4ef8-ac9c-9ca5564c3136", "1", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "63ae39a9-23f7-479a-a08f-e3240d0a7f72", 0, "da196078-3067-4b98-a341-1f3ab67d8076", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEPYoYcEpcI1Jwc/JHc4exWv9v2Uz3dyTug10Ed9ohuheSDm1d1sd4sx/PH2PImaXYA==", null, false, "b5063250-a05d-419e-9525-8dc28b2e76d7", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e6f0319e-c444-4ef8-ac9c-9ca5564c3136", "63ae39a9-23f7-479a-a08f-e3240d0a7f72" });
        }
    }
}
