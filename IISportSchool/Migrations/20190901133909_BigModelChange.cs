using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IISportSchool.Migrations
{
    public partial class BigModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_Sections_SectionId",
                table: "Childrens");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Services_ServiceId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Teachers_TeacherId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ServiceId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MonthCost",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Sections",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_TeacherId",
                table: "Sections",
                newName: "IX_Sections_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Childrens",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Childrens_SectionId",
                table: "Childrens",
                newName: "IX_Childrens_GroupId");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MinChildAge = table.Column<int>(nullable: false),
                    MaxChildAge = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    PricePerMonth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherProxies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    SectionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherProxies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers",
                column: "GroupId",
                unique: true,
                filter: "[GroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SectionId",
                table: "Groups",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_Groups_GroupId",
                table: "Childrens",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Departments_DepartmentId",
                table: "Sections",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_Groups_GroupId",
                table: "Childrens");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Departments_DepartmentId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "TeacherProxies");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Sections",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_DepartmentId",
                table: "Sections",
                newName: "IX_Sections_TeacherId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Childrens",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Childrens_GroupId",
                table: "Childrens",
                newName: "IX_Childrens_SectionId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MonthCost",
                table: "Sections",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ServiceId",
                table: "Sections",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_Sections_SectionId",
                table: "Childrens",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Services_ServiceId",
                table: "Sections",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Teachers_TeacherId",
                table: "Sections",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
