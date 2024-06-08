using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospitalManagenetSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class newmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppoimentId",
                table: "medicalCheckUps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Appoiments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_medicalCheckUps_AppoimentId",
                table: "medicalCheckUps",
                column: "AppoimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalCheckUps_Appoiments_AppoimentId",
                table: "medicalCheckUps",
                column: "AppoimentId",
                principalTable: "Appoiments",
                principalColumn: "AppoimentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalCheckUps_Appoiments_AppoimentId",
                table: "medicalCheckUps");

            migrationBuilder.DropIndex(
                name: "IX_medicalCheckUps_AppoimentId",
                table: "medicalCheckUps");

            migrationBuilder.DropColumn(
                name: "AppoimentId",
                table: "medicalCheckUps");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appoiments");
        }
    }
}
