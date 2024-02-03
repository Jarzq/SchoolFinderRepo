using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFinder.Migrations
{
    public partial class editeddbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntitySubject_JednostkiSzkolne_SchoolEntityId",
                table: "SchoolEntitySubject");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntitySubject_Subject_SubjectId",
                table: "SchoolEntitySubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolEntitySubject",
                table: "SchoolEntitySubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JednostkiSzkolne",
                table: "JednostkiSzkolne");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "SchoolEntitySubject",
                newName: "SchoolEntitySubjects");

            migrationBuilder.RenameTable(
                name: "JednostkiSzkolne",
                newName: "SchoolEntities");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolEntitySubject_SubjectId",
                table: "SchoolEntitySubjects",
                newName: "IX_SchoolEntitySubjects_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolEntitySubject_SchoolEntityId",
                table: "SchoolEntitySubjects",
                newName: "IX_SchoolEntitySubjects_SchoolEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolEntitySubjects",
                table: "SchoolEntitySubjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolEntities",
                table: "SchoolEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntitySubjects_SchoolEntities_SchoolEntityId",
                table: "SchoolEntitySubjects",
                column: "SchoolEntityId",
                principalTable: "SchoolEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntitySubjects_Subjects_SubjectId",
                table: "SchoolEntitySubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntitySubjects_SchoolEntities_SchoolEntityId",
                table: "SchoolEntitySubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntitySubjects_Subjects_SubjectId",
                table: "SchoolEntitySubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolEntitySubjects",
                table: "SchoolEntitySubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolEntities",
                table: "SchoolEntities");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "SchoolEntitySubjects",
                newName: "SchoolEntitySubject");

            migrationBuilder.RenameTable(
                name: "SchoolEntities",
                newName: "JednostkiSzkolne");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolEntitySubjects_SubjectId",
                table: "SchoolEntitySubject",
                newName: "IX_SchoolEntitySubject_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolEntitySubjects_SchoolEntityId",
                table: "SchoolEntitySubject",
                newName: "IX_SchoolEntitySubject_SchoolEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolEntitySubject",
                table: "SchoolEntitySubject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JednostkiSzkolne",
                table: "JednostkiSzkolne",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntitySubject_JednostkiSzkolne_SchoolEntityId",
                table: "SchoolEntitySubject",
                column: "SchoolEntityId",
                principalTable: "JednostkiSzkolne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntitySubject_Subject_SubjectId",
                table: "SchoolEntitySubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
