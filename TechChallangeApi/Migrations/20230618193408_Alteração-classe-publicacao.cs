using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallengeWeb.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçãoclassepublicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlPerfil",
                table: "Publicacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlPerfil",
                table: "Publicacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
