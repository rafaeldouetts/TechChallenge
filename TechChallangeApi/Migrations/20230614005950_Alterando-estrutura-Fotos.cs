using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallengeWeb.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoestruturaFotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extensao",
                table: "Fotos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extensao",
                table: "Fotos");
        }
    }
}
