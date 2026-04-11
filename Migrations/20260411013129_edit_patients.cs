using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenMind.Migrations
{
    /// <inheritdoc />
    public partial class edit_patients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alarms_patiens_Userid",
                table: "alarms");

            migrationBuilder.DropForeignKey(
                name: "FK_patiens_careGavers_CareGaverId",
                table: "patiens");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "patiens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "patiens",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "CareGaverId",
                table: "patiens",
                newName: "careGaverId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "patiens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "patiens",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_patiens_CareGaverId",
                table: "patiens",
                newName: "IX_patiens_careGaverId");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "alarms",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_alarms_Userid",
                table: "alarms",
                newName: "IX_alarms_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "patiens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "patiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "patiens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "patiens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "patiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_alarms_patiens_UserId",
                table: "alarms",
                column: "UserId",
                principalTable: "patiens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patiens_careGavers_careGaverId",
                table: "patiens",
                column: "careGaverId",
                principalTable: "careGavers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alarms_patiens_UserId",
                table: "alarms");

            migrationBuilder.DropForeignKey(
                name: "FK_patiens_careGavers_careGaverId",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "patiens");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "patiens");

            migrationBuilder.RenameColumn(
                name: "careGaverId",
                table: "patiens",
                newName: "CareGaverId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "patiens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "patiens",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "patiens",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "patiens",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_patiens_careGaverId",
                table: "patiens",
                newName: "IX_patiens_CareGaverId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "alarms",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_alarms_UserId",
                table: "alarms",
                newName: "IX_alarms_Userid");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "patiens",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_alarms_patiens_Userid",
                table: "alarms",
                column: "Userid",
                principalTable: "patiens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patiens_careGavers_CareGaverId",
                table: "patiens",
                column: "CareGaverId",
                principalTable: "careGavers",
                principalColumn: "Id");
        }
    }
}
