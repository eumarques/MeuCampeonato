using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuCampeonato.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGolMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gols",
                table: "Times");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gols",
                table: "Times",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
