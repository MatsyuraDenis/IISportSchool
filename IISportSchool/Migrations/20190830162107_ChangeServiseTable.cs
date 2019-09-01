using Microsoft.EntityFrameworkCore.Migrations;

namespace IISportSchool.Migrations
{
    public partial class ChangeServiseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Services_ServiceId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ServiceId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Sections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ServiceId",
                table: "Sections",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Services_ServiceId",
                table: "Sections",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Services_ServiceId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ServiceId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ServiceId",
                table: "Teachers",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Services_ServiceId",
                table: "Teachers",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
