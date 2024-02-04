using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFinder.Migrations
{
    public partial class addedspecialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "SchoolEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntities_SpecializationId",
                table: "SchoolEntities",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntities_Specializations_SpecializationId",
                table: "SchoolEntities",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntities_Specializations_SpecializationId",
                table: "SchoolEntities");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_SchoolEntities_SpecializationId",
                table: "SchoolEntities");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "SchoolEntities");
        }
    }
}
