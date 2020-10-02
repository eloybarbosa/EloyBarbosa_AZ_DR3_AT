using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiAmigo.Migrations
{
    public partial class AddFotoAmigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Amigos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Amigos");
        }
    }
}
