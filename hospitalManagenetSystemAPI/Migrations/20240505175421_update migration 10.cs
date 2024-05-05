using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_bloodTypes_bloodType",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_genders_GenderName",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genders",
                table: "genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bloodTypes",
                table: "bloodTypes");

            migrationBuilder.RenameTable(
                name: "genders",
                newName: "gender");

            migrationBuilder.RenameTable(
                name: "bloodTypes",
                newName: "bloodType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gender",
                table: "gender",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bloodType",
                table: "bloodType",
                column: "bloodType");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_bloodType_bloodType",
                table: "patients",
                column: "bloodType",
                principalTable: "bloodType",
                principalColumn: "bloodType");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_gender_GenderName",
                table: "patients",
                column: "GenderName",
                principalTable: "gender",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_bloodType_bloodType",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_gender_GenderName",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gender",
                table: "gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bloodType",
                table: "bloodType");

            migrationBuilder.RenameTable(
                name: "gender",
                newName: "genders");

            migrationBuilder.RenameTable(
                name: "bloodType",
                newName: "bloodTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genders",
                table: "genders",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bloodTypes",
                table: "bloodTypes",
                column: "bloodType");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_bloodTypes_bloodType",
                table: "patients",
                column: "bloodType",
                principalTable: "bloodTypes",
                principalColumn: "bloodType");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_genders_GenderName",
                table: "patients",
                column: "GenderName",
                principalTable: "genders",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
