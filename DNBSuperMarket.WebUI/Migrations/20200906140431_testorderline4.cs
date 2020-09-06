using Microsoft.EntityFrameworkCore.Migrations;

namespace DNBSuperMarket.WebUI.Migrations
{
    public partial class testorderline4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderLine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
