using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostToMenuDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "menuItems");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "menuItems");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "menuItems");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "menuItems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "menuItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "menuItems",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "menuItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "menuItems",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "menuItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "menuItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
