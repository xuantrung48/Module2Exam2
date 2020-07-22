using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam2.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    CakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Ingredient = table.Column<string>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    ManufacturingDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.CakeId);
                    table.ForeignKey(
                        name: "FK_Cakes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "ABC" },
                    { 2, "DEF" },
                    { 3, "GHI" },
                    { 4, "JKL" },
                    { 5, "MNO" }
                });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "CakeId", "CategoryId", "ExpiryDate", "Ingredient", "IsDeleted", "ManufacturingDate", "Name", "Price" },
                values: new object[] { 1, 1, new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bột mì, sữa", false, new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bánh ngọt", 5000 });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "CakeId", "CategoryId", "ExpiryDate", "Ingredient", "IsDeleted", "ManufacturingDate", "Name", "Price" },
                values: new object[] { 2, 2, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bột mì, muối", false, new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bánh mặn", 10000 });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "CakeId", "CategoryId", "ExpiryDate", "Ingredient", "IsDeleted", "ManufacturingDate", "Name", "Price" },
                values: new object[] { 3, 3, new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bột mì, trứng", false, new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bánh kem", 20000 });

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CategoryId",
                table: "Cakes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
