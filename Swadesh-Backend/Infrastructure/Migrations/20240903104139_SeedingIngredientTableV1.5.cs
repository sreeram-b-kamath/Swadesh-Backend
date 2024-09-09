using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingIngredientTableV15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menuCategories_restaurants_RestaurantId",
                table: "menuCategories");

            migrationBuilder.DropIndex(
                name: "IX_menuCategories_Name_RestaurantId",
                table: "menuCategories");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "menuCategories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_menuCategories_restaurants_RestaurantId",
                table: "menuCategories",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menuCategories_restaurants_RestaurantId",
                table: "menuCategories");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "menuCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuCategories_Name_RestaurantId",
                table: "menuCategories",
                columns: new[] { "Name", "RestaurantId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_menuCategories_restaurants_RestaurantId",
                table: "menuCategories",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
