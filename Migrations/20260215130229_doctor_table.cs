using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenMind.Migrations
{
    /// <inheritdoc />
    public partial class doctor_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorsModelId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastActive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_DoctorsModelId",
                table: "users",
                column: "DoctorsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_doctors_DoctorsModelId",
                table: "users",
                column: "DoctorsModelId",
                principalTable: "doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_doctors_DoctorsModelId",
                table: "users");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_users_DoctorsModelId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "DoctorsModelId",
                table: "users");
        }
    }
}
