using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAPIAssessmentCore.Migrations
{
    public partial class crudAssessmentUserFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    MidleName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    LocationOfElection = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    OtherNationality = table.Column<bool>(nullable: false),
                    PassportPath = table.Column<string>(nullable: true),
                    ProfilePath = table.Column<string>(nullable: true),
                    SelfiePath = table.Column<string>(nullable: true),
                    UtilityBillPath = table.Column<string>(nullable: true),
                    FacebookSocialLink = table.Column<string>(nullable: true),
                    LinkedInSocialLink = table.Column<string>(nullable: true),
                    TweeterSocialLink = table.Column<string>(nullable: true),
                    InstaSocialLink = table.Column<string>(nullable: true),
                    YoutubeSocialLink = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
