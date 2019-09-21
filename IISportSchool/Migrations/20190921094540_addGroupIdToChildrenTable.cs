using Microsoft.EntityFrameworkCore.Migrations;

namespace IISportSchool.Migrations
{
    public partial class addGroupIdToChildrenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_Groups_GroupId",
                table: "Childrens");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Childrens",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_Groups_GroupId",
                table: "Childrens",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_Groups_GroupId",
                table: "Childrens");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Childrens",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_Groups_GroupId",
                table: "Childrens",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
