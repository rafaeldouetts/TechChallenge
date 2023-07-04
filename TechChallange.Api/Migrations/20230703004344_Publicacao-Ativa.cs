using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallengeApi.Migrations
{
    /// <inheritdoc />
    public partial class PublicacaoAtiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Publicacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Publicacoes");
        }
    }
}
