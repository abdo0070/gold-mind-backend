using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenMind.Migrations
{
    /// <inheritdoc />
    public partial class edit_insome_att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patiens_careGavers_careGaverId",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "patiens");

            migrationBuilder.RenameColumn(
                name: "careGaverId",
                table: "patiens",
                newName: "CareGaverId");

            migrationBuilder.RenameIndex(
                name: "IX_patiens_careGaverId",
                table: "patiens",
                newName: "IX_patiens_CareGaverId");

            migrationBuilder.AlterColumn<int>(
                name: "CareGaverId",
                table: "patiens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "patiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "patiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_patiens_careGavers_CareGaverId",
                table: "patiens",
                column: "CareGaverId",
                principalTable: "careGavers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patiens_careGavers_CareGaverId",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "patiens");

            migrationBuilder.RenameColumn(
                name: "CareGaverId",
                table: "patiens",
                newName: "careGaverId");

            migrationBuilder.RenameIndex(
                name: "IX_patiens_CareGaverId",
                table: "patiens",
                newName: "IX_patiens_careGaverId");

            migrationBuilder.AlterColumn<int>(
                name: "careGaverId",
                table: "patiens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "patiens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_patiens_careGavers_careGaverId",
                table: "patiens",
                column: "careGaverId",
                principalTable: "careGavers",
                principalColumn: "Id");
        }
    }
}
