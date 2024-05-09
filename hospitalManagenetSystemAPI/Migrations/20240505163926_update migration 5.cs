using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenderName1",
                table: "patients",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "bloodType",
                table: "patients",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_patients_bloodType",
                table: "patients",
                column: "bloodType");

            migrationBuilder.CreateIndex(
                name: "IX_patients_GenderName1",
                table: "patients",
                column: "GenderName1");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_BloodType_bloodType",
                table: "patients",
                column: "bloodType",
                principalTable: "BloodType",
                principalColumn: "bloodType");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_Gender_GenderName1",
                table: "patients",
                column: "GenderName1",
                principalTable: "Gender",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_BloodType_bloodType",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_Gender_GenderName1",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_bloodType",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_GenderName1",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "GenderName1",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "bloodType",
                table: "patients");
        }
    }
}
