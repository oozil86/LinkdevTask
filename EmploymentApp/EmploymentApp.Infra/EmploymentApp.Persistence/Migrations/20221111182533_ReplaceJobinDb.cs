using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentApp.Persistence.Migrations
{
    public partial class ReplaceJobinDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobCategory_CategoryId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropTable(
                name: "JobCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobResponsibility",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobSkill",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Job_CategoryId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Responsibilities",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                schema: "dbo",
                table: "Job",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Responsibilities",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Skills",
                schema: "dbo",
                table: "Job");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobResponsibility",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobResponsibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobResponsibility_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkill_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_CategoryId",
                schema: "dbo",
                table: "Job",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibility_JobId",
                schema: "dbo",
                table: "JobResponsibility",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobId",
                schema: "dbo",
                table: "JobSkill",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobCategory_CategoryId",
                schema: "dbo",
                table: "Job",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "JobCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
