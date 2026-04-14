using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenMind.Migrations
{
    /// <inheritdoc />
    public partial class edit_user_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alarms_careGavers_CareGaverId",
                table: "alarms");

            migrationBuilder.DropIndex(
                name: "IX_alarms_CareGaverId",
                table: "alarms");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "CareGaverId",
                table: "alarms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "patiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CareGaverId",
                table: "alarms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_alarms_CareGaverId",
                table: "alarms",
                column: "CareGaverId");

            migrationBuilder.AddForeignKey(
                name: "FK_alarms_careGavers_CareGaverId",
                table: "alarms",
                column: "CareGaverId",
                principalTable: "careGavers",
                principalColumn: "Id");
        }
    }
}
