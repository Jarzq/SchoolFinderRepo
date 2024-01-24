using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFinder.Migrations
{
    public partial class AddedJednostkaSzkolna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JednostkiSzkolne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dzielnica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazwaSzkoly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SymbolOddzialu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazwaOddzialu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimalnePunkty = table.Column<double>(type: "float", nullable: false),
                    MaksymalnePunkty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JednostkiSzkolne", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JednostkiSzkolne");
        }
    }
}
