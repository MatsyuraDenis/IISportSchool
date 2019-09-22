using Microsoft.EntityFrameworkCore.Migrations;

namespace IISportSchool.Migrations
{
    public partial class MoveTeacherFromGroupToSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_TeacherProxies_TeacherProxyId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Worker_GroupId",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Groups_TeacherProxyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TeacherProxyId",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_GroupId",
                table: "Worker",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worker_GroupId",
                table: "Worker");

            migrationBuilder.AddColumn<int>(
                name: "TeacherProxyId",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_GroupId",
                table: "Worker",
                column: "GroupId",
                unique: true,
                filter: "[GroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherProxyId",
                table: "Groups",
                column: "TeacherProxyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_TeacherProxies_TeacherProxyId",
                table: "Groups",
                column: "TeacherProxyId",
                principalTable: "TeacherProxies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
