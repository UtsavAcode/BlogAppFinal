using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class fdfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "45229544-af1d-4470-9563-ac9519478351", "3", "User", "USER" },
                    { "bce4737d-d510-48c6-8258-a1b683789b8f", "2", "Admin", "ADMIN" },
                    { "c7fb24df-7316-4a20-9627-c172465d1919", "1", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba0ffca9-244b-4c87-9d22-40ac66079310", 0, "dad166f2-5b1a-4339-a9a0-f49e7c946ff9", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEN12+rYw5CjglYdfX0bMX8aSZx7f+z1jIqV/LrSAa5CYf7gmrlYZ2epgcs4IFou3/w==", null, false, "d9ce2588-587f-4d21-b005-24687e81cf88", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7fb24df-7316-4a20-9627-c172465d1919", "ba0ffca9-244b-4c87-9d22-40ac66079310" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45229544-af1d-4470-9563-ac9519478351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bce4737d-d510-48c6-8258-a1b683789b8f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7fb24df-7316-4a20-9627-c172465d1919", "ba0ffca9-244b-4c87-9d22-40ac66079310" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fb24df-7316-4a20-9627-c172465d1919");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba0ffca9-244b-4c87-9d22-40ac66079310");

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
    }
}
