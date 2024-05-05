using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_BloodType_BloodTypeName",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_BloodType_bloodType",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_Gender_GenderName",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_Gender_GenderName1",
                table: "patients");

            migrationBuilder.DropTable(
                name: "BloodType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_patients_bloodType",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_BloodTypeName",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_GenderName",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_GenderName1",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "BloodTypeName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "GenderName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "GenderName1",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "bloodType",
                table: "patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_patients_bloodType",
                table: "patients",
                column: "bloodType");

            migrationBuilder.CreateIndex(
                name: "IX_patients_BloodTypeName",
                table: "patients",
                column: "BloodTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_patients_GenderName",
                table: "patients",
                column: "GenderName");

            migrationBuilder.CreateIndex(
                name: "IX_patients_GenderName1",
                table: "patients",
                column: "GenderName1");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_BloodType_BloodTypeName",
                table: "patients",
                column: "BloodTypeName",
                principalTable: "BloodType",
                principalColumn: "bloodType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_BloodType_bloodType",
                table: "patients",
                column: "bloodType",
                principalTable: "BloodType",
                principalColumn: "bloodType");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_Gender_GenderName",
                table: "patients",
                column: "GenderName",
                principalTable: "Gender",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_Gender_GenderName1",
                table: "patients",
                column: "GenderName1",
                principalTable: "Gender",
                principalColumn: "Name");
        }
    }
}
