using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFinder.Migrations
{
    public partial class setNullableInEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntities_Specializations_SpecializationId",
                table: "SchoolEntities");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "SchoolEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntities_Specializations_SpecializationId",
                table: "SchoolEntities",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntities_Specializations_SpecializationId",
                table: "SchoolEntities");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "SchoolEntities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntities_Specializations_SpecializationId",
                table: "SchoolEntities",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
