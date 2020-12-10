using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccsess.Migrations
{
    public partial class dbinit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "People");
        }
    }
}
