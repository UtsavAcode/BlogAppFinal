using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c8065c5-4575-4c81-b3d4-63f662839245");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bee47303-ee29-4dde-b651-cd05c9e3fe5e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf66d0f8-d197-4009-9b27-c1821806372f", "f418ff2d-44ba-443b-a26a-e9a1087d26f8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf66d0f8-d197-4009-9b27-c1821806372f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f418ff2d-44ba-443b-a26a-e9a1087d26f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43614cfd-e6ba-43d8-886b-85fd4be779d8", "3", "User", "USER" },
                    { "9bc56286-96db-4290-a73b-757546808476", "1", "SuperAdmin", "SUPERADMIN" },
                    { "d0f32048-20a0-473c-8e4a-c9535eb5f6a5", "2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "40da5fe7-da5d-4457-a00c-379b4a16e489", 0, "a8ad7f00-792b-4dd0-aaa5-35be4da1fe9f", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAECidK2zrdgQiQ9Q8ZmepMpb5EvhyOgxS5GRhPb+WnVkXWb8q+wuDQIMyYavReH1mUQ==", null, false, "f5bb9e9e-f433-4b2d-ac65-76006c8c3e18", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9bc56286-96db-4290-a73b-757546808476", "40da5fe7-da5d-4457-a00c-379b4a16e489" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43614cfd-e6ba-43d8-886b-85fd4be779d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0f32048-20a0-473c-8e4a-c9535eb5f6a5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9bc56286-96db-4290-a73b-757546808476", "40da5fe7-da5d-4457-a00c-379b4a16e489" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bc56286-96db-4290-a73b-757546808476");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40da5fe7-da5d-4457-a00c-379b4a16e489");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c8065c5-4575-4c81-b3d4-63f662839245", "3", "User", "USER" },
                    { "bee47303-ee29-4dde-b651-cd05c9e3fe5e", "2", "Admin", "ADMIN" },
                    { "cf66d0f8-d197-4009-9b27-c1821806372f", "1", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f418ff2d-44ba-443b-a26a-e9a1087d26f8", 0, "63106037-9803-46f9-bbf1-cd5266e10af8", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAELGdotJ8Y0C3lkUvcVldO8oNKkuLwvUyTnLgwcGDW26oXh9m4bECCtX2W7zr367etA==", null, false, "4701a406-4118-40fd-9258-f14c4c61c505", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cf66d0f8-d197-4009-9b27-c1821806372f", "f418ff2d-44ba-443b-a26a-e9a1087d26f8" });
        }
    }
}
