using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Siimple.DAL.Migrations
{
    public partial class addingBlog2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Blogs");
        }
    }
}
