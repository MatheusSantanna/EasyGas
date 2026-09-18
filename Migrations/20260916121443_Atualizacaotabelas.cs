using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGas.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacaotabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoServico",
                table: "OrdemServico",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Colaboradores",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoServico",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Colaboradores");
        }
    }
}
