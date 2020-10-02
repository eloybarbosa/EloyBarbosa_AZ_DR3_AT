using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiAmigo.Migrations
{
    public partial class AddPaisAmigoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pais_Amigos_AmigoId",
                table: "Pais");

            migrationBuilder.AlterColumn<Guid>(
                name: "AmigoId",
                table: "Pais",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pais_Amigos_AmigoId",
                table: "Pais",
                column: "AmigoId",
                principalTable: "Amigos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pais_Amigos_AmigoId",
                table: "Pais");

            migrationBuilder.AlterColumn<Guid>(
                name: "AmigoId",
                table: "Pais",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Pais_Amigos_AmigoId",
                table: "Pais",
                column: "AmigoId",
                principalTable: "Amigos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
