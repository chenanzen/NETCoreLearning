using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiredBrainCoffeeAdmin.Migrations
{
    public partial class imagefile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Products");
        }
    }
}
