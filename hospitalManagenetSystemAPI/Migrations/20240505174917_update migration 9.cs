using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenderName",
                table: "patients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "bloodType",
                table: "patients",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bloodTypes",
                columns: table => new
                {
                    bloodType = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodTypes", x => x.bloodType);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_patients_bloodType",
                table: "patients",
                column: "bloodType");

            migrationBuilder.CreateIndex(
                name: "IX_patients_GenderName",
                table: "patients",
                column: "GenderName");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_bloodTypes_bloodType",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_genders_GenderName",
                table: "patients");

            migrationBuilder.DropTable(
                name: "bloodTypes");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropIndex(
                name: "IX_patients_bloodType",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_GenderName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "GenderName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "bloodType",
                table: "patients");
        }
    }
}
