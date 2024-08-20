using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "errorMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errorMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "masterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DefaultOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "masterFilters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icons = table.Column<string>(type: "text", nullable: false),
                    DefaultOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterFilters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Roles = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    Background = table.Column<string>(type: "text", nullable: false),
                    Cuisine = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    isEmailVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    OTP = table.Column<int>(type: "integer", nullable: false),
                    OTPUsed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OtpExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    UpdateEmail = table.Column<string>(type: "text", nullable: false),
                    InitialLogin = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CountryCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsMobileVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Password = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    OTP = table.Column<int>(type: "integer", nullable: false),
                    OTPUsed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OtpExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "masterCategoryLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MasterCategoryId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "masterFilterLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MasterFilterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterFilterLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_masterFilterLangs_masterFilters_MasterFilterId",
                        column: x => x.MasterFilterId,
                        principalTable: "masterFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuCategories_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuFilters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuFilters_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restaurantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurantDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_restaurantDetails_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuCategoryLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MenuCategoryId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuCategoryLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuCategoryLangs_menuCategories_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "menuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuCategoryLangs_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PrimaryImage = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<string[]>(type: "text[]", nullable: false),
                    Money = table.Column<decimal>(type: "money", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    MenuFilterIds = table.Column<int[]>(type: "integer[]", nullable: false),
                    InStock = table.Column<bool>(type: "boolean", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    MenuCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuItems_menuCategories_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "menuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuItems_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuFilterLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MenuFiltersId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuFilterLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuFilterLangs_menuFilters_MenuFiltersId",
                        column: x => x.MenuFiltersId,
                        principalTable: "menuFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuFilterLangs_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuItemLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MenuItemsId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItemLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuItemLangs_menuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "menuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuItemLangs_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuItemRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SessionId = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    MenuItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItemRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuItemRatings_menuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "menuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuItemRatings_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
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

            migrationBuilder.CreateIndex(
                name: "IX_masterFilterLangs_MasterFilterId_Code",
                table: "masterFilterLangs",
                columns: new[] { "MasterFilterId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_masterFilters_Name",
                table: "masterFilters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuCategories_Name_RestaurantId",
                table: "menuCategories",
                columns: new[] { "Name", "RestaurantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuCategories_RestaurantId",
                table: "menuCategories",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menuCategories_Uid",
                table: "menuCategories",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuCategoryLangs_MenuCategoryId_RestaurantId_Code",
                table: "menuCategoryLangs",
                columns: new[] { "MenuCategoryId", "RestaurantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuCategoryLangs_RestaurantId",
                table: "menuCategoryLangs",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menuFilterLangs_MenuFiltersId_RestaurantId_Code",
                table: "menuFilterLangs",
                columns: new[] { "MenuFiltersId", "RestaurantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuFilterLangs_RestaurantId",
                table: "menuFilterLangs",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menuFilters_Name_RestaurantId",
                table: "menuFilters",
                columns: new[] { "Name", "RestaurantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuFilters_RestaurantId",
                table: "menuFilters",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menuItemLangs_MenuItemsId_RestaurantId_Code",
                table: "menuItemLangs",
                columns: new[] { "MenuItemsId", "RestaurantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuItemLangs_RestaurantId",
                table: "menuItemLangs",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menuItemRatings_MenuItemId",
                table: "menuItemRatings",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_menuItemRatings_RestaurantId_SessionId_MenuItemId",
                table: "menuItemRatings",
                columns: new[] { "RestaurantId", "SessionId", "MenuItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menuItems_MenuCategoryId",
                table: "menuItems",
                column: "MenuCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_menuItems_RestaurantId",
                table: "menuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurantDetails_RestaurantId_Code",
                table: "restaurantDetails",
                columns: new[] { "RestaurantId", "Code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "errorMessages");

            migrationBuilder.DropTable(
                name: "masterCategoryLangs");

            migrationBuilder.DropTable(
                name: "masterFilterLangs");

            migrationBuilder.DropTable(
                name: "menuCategoryLangs");

            migrationBuilder.DropTable(
                name: "menuFilterLangs");

            migrationBuilder.DropTable(
                name: "menuItemLangs");

            migrationBuilder.DropTable(
                name: "menuItemRatings");

            migrationBuilder.DropTable(
                name: "restaurantDetails");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "masterCategories");

            migrationBuilder.DropTable(
                name: "masterFilters");

            migrationBuilder.DropTable(
                name: "menuFilters");

            migrationBuilder.DropTable(
                name: "menuItems");

            migrationBuilder.DropTable(
                name: "menuCategories");

            migrationBuilder.DropTable(
                name: "restaurants");
        }
    }
}
