using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_gender_GenderName",
                table: "patients");

            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "patients",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_gender_GenderName",
                table: "patients",
                column: "GenderName",
                principalTable: "gender",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_gender_GenderName",
                table: "patients");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "GenderName",
                keyValue: null,
                column: "GenderName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "patients",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_gender_GenderName",
                table: "patients",
                column: "GenderName",
                principalTable: "gender",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
