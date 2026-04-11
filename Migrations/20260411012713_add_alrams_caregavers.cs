using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenMind.Migrations
{
    /// <inheritdoc />
    public partial class add_alrams_caregavers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareGaverId",
                table: "patiens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "careGavers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Online = table.Column<bool>(type: "bit", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_careGavers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "alarms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    CareGaverId = table.Column<int>(type: "int", nullable: true),
                    Repeat = table.Column<bool>(type: "bit", nullable: false),
                    Discard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alarms_careGavers_CareGaverId",
                        column: x => x.CareGaverId,
                        principalTable: "careGavers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_alarms_patiens_Userid",
                        column: x => x.Userid,
                        principalTable: "patiens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patiens_CareGaverId",
                table: "patiens",
                column: "CareGaverId");

            migrationBuilder.CreateIndex(
                name: "IX_alarms_CareGaverId",
                table: "alarms",
                column: "CareGaverId");

            migrationBuilder.CreateIndex(
                name: "IX_alarms_Userid",
                table: "alarms",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_patiens_careGavers_CareGaverId",
                table: "patiens",
                column: "CareGaverId",
                principalTable: "careGavers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patiens_careGavers_CareGaverId",
                table: "patiens");

            migrationBuilder.DropTable(
                name: "alarms");

            migrationBuilder.DropTable(
                name: "careGavers");

            migrationBuilder.DropIndex(
                name: "IX_patiens_CareGaverId",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "CareGaverId",
                table: "patiens");
        }
    }
}
