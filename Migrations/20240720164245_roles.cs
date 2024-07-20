using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0657b5ac-124b-46f7-9b84-cb2723ce909d", "1", "SuperAdmin", "SUPERADMIN" },
                    { "1951f4c8-8808-49f7-94f7-86767dbb4fe4", "2", "Admin", "ADMIN" },
                    { "c83653ab-d402-4e26-8acc-76e296782139", "3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c33be6bc-22e6-4d64-ab47-6e115db7ff4e", 0, "bfb31c5b-bf26-45d7-ae79-b53b580d854a", "superadmin@gmail.com", false, true, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAENPcKCcGM0yaPhYjfI9Ba3DVLj8R/4bz+jxTK4lVwrlYEmAzv8htzWVVKDHOhhBCmQ==", null, false, "843222d5-baec-414f-bb78-5c525ecb747e", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0657b5ac-124b-46f7-9b84-cb2723ce909d", "c33be6bc-22e6-4d64-ab47-6e115db7ff4e" },
                    { "1951f4c8-8808-49f7-94f7-86767dbb4fe4", "c33be6bc-22e6-4d64-ab47-6e115db7ff4e" },
                    { "c83653ab-d402-4e26-8acc-76e296782139", "c33be6bc-22e6-4d64-ab47-6e115db7ff4e" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0657b5ac-124b-46f7-9b84-cb2723ce909d", "c33be6bc-22e6-4d64-ab47-6e115db7ff4e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1951f4c8-8808-49f7-94f7-86767dbb4fe4", "c33be6bc-22e6-4d64-ab47-6e115db7ff4e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c83653ab-d402-4e26-8acc-76e296782139", "c33be6bc-22e6-4d64-ab47-6e115db7ff4e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0657b5ac-124b-46f7-9b84-cb2723ce909d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1951f4c8-8808-49f7-94f7-86767dbb4fe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c83653ab-d402-4e26-8acc-76e296782139");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c33be6bc-22e6-4d64-ab47-6e115db7ff4e");
        }
    }
}
