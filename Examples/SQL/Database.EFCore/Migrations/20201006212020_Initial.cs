using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book_category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "book_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "book_category",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "Novel" },
                    { 2, "Adventure" },
                    { 3, "Fantasy" },
                    { 4, "History" }
                    
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "Id", "CategoryId", "Rating", "Name" },
                values: new object[,]
                {
                    { 1, 1, 4.6 , "Eugene Onegin" },
                    { 2, 2, 4.3, "Robinson Crusoe" },
                    { 3, 3, 4.8, "Lord of the Rings: The Fellowship of The Ring" },
                    { 4, 4, 4.5, "Comparative biographies"  }
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_CategoryId",
                table: "book",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Summary");
        }
    }
}
