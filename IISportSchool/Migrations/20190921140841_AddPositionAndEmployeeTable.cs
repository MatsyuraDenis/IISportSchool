using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IISportSchool.Migrations
{
    public partial class AddPositionAndEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Worker");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_GroupId",
                table: "Worker",
                newName: "IX_Worker_GroupId");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Worker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Worker",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Worker",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Worker_SectionId",
                table: "Worker",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PositionId",
                table: "Worker",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Groups_GroupId",
                table: "Worker",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Sections_SectionId",
                table: "Worker",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Positions_PositionId",
                table: "Worker",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Groups_GroupId",
                table: "Worker");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Sections_SectionId",
                table: "Worker");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Positions_PositionId",
                table: "Worker");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_SectionId",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_PositionId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Worker");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "Teachers");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_GroupId",
                table: "Teachers",
                newName: "IX_Teachers_GroupId");

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
