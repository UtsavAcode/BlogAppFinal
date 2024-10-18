using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    public partial class jhfjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1230bed-6c57-4bfc-a708-851c3cd23f2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fef32a5b-ede7-4901-8515-9a420a69367d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc4eb031-5c61-4293-adeb-b2dece019a49", "264c5371-fedc-49d8-b313-918fab5bcca2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc4eb031-5c61-4293-adeb-b2dece019a49");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "264c5371-fedc-49d8-b313-918fab5bcca2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "727d52fd-d912-48a5-82db-6e06fcc2d009", "3", "User", "USER" },
                    { "bdf2adb3-e060-449f-b7e0-7b4a765e7da6", "2", "Admin", "ADMIN" },
                    { "f437c219-0967-4e33-9693-171fe9eeb110", "1", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eea6319b-7d83-46d0-8755-9f7e7dcbc31a", 0, "8ed02d75-b48f-43d3-8ef6-7654a8df95cd", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEFP8059cyo7OqiNFaxuoBpKdhrWPT11pbbZkMpel16Lxj4CW5RA8zZafcJB3cGZsnw==", null, false, "9bb49e72-4786-44a3-adce-c5d63a9ea3d5", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f437c219-0967-4e33-9693-171fe9eeb110", "eea6319b-7d83-46d0-8755-9f7e7dcbc31a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "727d52fd-d912-48a5-82db-6e06fcc2d009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdf2adb3-e060-449f-b7e0-7b4a765e7da6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f437c219-0967-4e33-9693-171fe9eeb110", "eea6319b-7d83-46d0-8755-9f7e7dcbc31a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f437c219-0967-4e33-9693-171fe9eeb110");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eea6319b-7d83-46d0-8755-9f7e7dcbc31a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f1230bed-6c57-4bfc-a708-851c3cd23f2b", "2", "Admin", "ADMIN" },
                    { "fc4eb031-5c61-4293-adeb-b2dece019a49", "1", "SuperAdmin", "SUPERADMIN" },
                    { "fef32a5b-ede7-4901-8515-9a420a69367d", "3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "264c5371-fedc-49d8-b313-918fab5bcca2", 0, "a647a905-6f36-46b6-a77e-91fd27554ba2", "superadmin@gmail.com", false, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEKTiECwe65YuKj9/+FTfxvkuxd602FzsWtGMxl+RYHJR2Hx0A45FfRMmwsWFRsnmiA==", null, false, "ac094474-cff5-4507-8780-61359656e0fe", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc4eb031-5c61-4293-adeb-b2dece019a49", "264c5371-fedc-49d8-b313-918fab5bcca2" });
        }
    }
}
