using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAPIAssessmentCore.Migrations
{
    public partial class AddedOneFIeldCountryISO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryIso",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryIso",
                table: "Users");
        }
    }
}
