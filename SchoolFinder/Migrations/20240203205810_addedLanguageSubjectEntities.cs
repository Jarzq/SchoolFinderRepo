using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFinder.Migrations
{
    public partial class addedLanguageSubjectEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolEntityLanguageSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolEntityId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEntityLanguageSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolEntityLanguageSubjects_SchoolEntities_SchoolEntityId",
                        column: x => x.SchoolEntityId,
                        principalTable: "SchoolEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolEntityLanguageSubjects_Subjects_LanguageSubjectId",
                        column: x => x.LanguageSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntityLanguageSubjects_LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects",
                column: "LanguageSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntityLanguageSubjects_SchoolEntityId",
                table: "SchoolEntityLanguageSubjects",
                column: "SchoolEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolEntityLanguageSubjects");
        }
    }
}
