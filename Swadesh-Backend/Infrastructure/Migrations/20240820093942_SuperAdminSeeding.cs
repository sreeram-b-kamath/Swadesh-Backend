using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SuperAdminSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsMobileVerified",
                table: "users");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Active", "Email", "FirstName", "IsEmailVerified", "LastLogin", "LastName", "Mobile", "OTP", "OtpExpiry", "Password" },
                values: new object[] { 1, true, "sreerambkamath@gmail.com", "Sreeram", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamath", "9497158008", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sreeram@1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsMobileVerified",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
