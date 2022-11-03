using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lang.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrequencyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequencySource = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrequencyData_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordListWords",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false),
                    WordListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordListWords", x => new { x.WordId, x.WordListId });
                    table.ForeignKey(
                        name: "FK_WordListWords_WordLists_WordListId",
                        column: x => x.WordListId,
                        principalTable: "WordLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordListWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WordLists",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Void" },
                    { 2, "Alfa" },
                    { 3, "Babel" },
                    { 4, "2021" },
                    { 5, "2022" },
                    { 6, "2023" },
                    { 7, "WON" },
                    { 8, "REM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrequencyData_WordId",
                table: "FrequencyData",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordListWords_WordListId",
                table: "WordListWords",
                column: "WordListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrequencyData");

            migrationBuilder.DropTable(
                name: "WordListWords");

            migrationBuilder.DropTable(
                name: "WordLists");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
