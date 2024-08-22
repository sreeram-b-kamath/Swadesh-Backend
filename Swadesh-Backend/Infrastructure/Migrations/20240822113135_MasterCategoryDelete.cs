using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MasterCategoryDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "masterCategoryLangs");

            migrationBuilder.DropTable(
                name: "masterCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "masterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefaultOrder = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "masterCategoryLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterCategoryLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_masterCategoryLangs_masterCategories_MasterCategoryId",
                        column: x => x.MasterCategoryId,
                        principalTable: "masterCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_masterCategories_Name",
                table: "masterCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_masterCategoryLangs_MasterCategoryId_Code",
                table: "masterCategoryLangs",
                columns: new[] { "MasterCategoryId", "Code" },
                unique: true);
        }
    }
}
