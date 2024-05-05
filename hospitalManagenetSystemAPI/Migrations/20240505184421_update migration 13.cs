using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_Specialization_SpecializationId",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization");

            migrationBuilder.RenameTable(
                name: "Specialization",
                newName: "specializations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specializations",
                table: "specializations",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specializations_SpecializationId",
                table: "doctors",
                column: "SpecializationId",
                principalTable: "specializations",
                principalColumn: "SpecializationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specializations_SpecializationId",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specializations",
                table: "specializations");

            migrationBuilder.RenameTable(
                name: "specializations",
                newName: "Specialization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_Specialization_SpecializationId",
                table: "doctors",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "SpecializationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
