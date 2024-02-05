using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFinder.Migrations
{
    public partial class changedLanguageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntityLanguageSubjects_Subjects_LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SchoolEntityLanguageSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntityLanguageSubjects_Subjects_LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects",
                column: "LanguageSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntityLanguageSubjects_Subjects_LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SchoolEntityLanguageSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntityLanguageSubjects_Subjects_LanguageSubjectId",
                table: "SchoolEntityLanguageSubjects",
                column: "LanguageSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
