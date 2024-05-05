using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "patients");

            migrationBuilder.AddColumn<string>(
                name: "BloodTypeName",
                table: "patients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GenderName",
                table: "patients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BloodType",
                columns: table => new
                {
                    bloodType = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodType", x => x.bloodType);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_patients_BloodTypeName",
                table: "patients",
                column: "BloodTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_patients_GenderName",
                table: "patients",
                column: "GenderName");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_BloodType_BloodTypeName",
                table: "patients",
                column: "BloodTypeName",
                principalTable: "BloodType",
                principalColumn: "bloodType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_Gender_GenderName",
                table: "patients",
                column: "GenderName",
                principalTable: "Gender",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_BloodType_BloodTypeName",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_Gender_GenderName",
                table: "patients");

            migrationBuilder.DropTable(
                name: "BloodType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_patients_BloodTypeName",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_GenderName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "BloodTypeName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "GenderName",
                table: "patients");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
