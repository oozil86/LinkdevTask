using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentApp.Persistence.Migrations
{
    public partial class ReplaceDescriptioninDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "JobResponsibility");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "JobResponsibility",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "JobResponsibility");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "JobResponsibility",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
