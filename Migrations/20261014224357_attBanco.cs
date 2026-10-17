using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGas.Migrations
{
    /// <inheritdoc />
    public partial class attBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ClientesId",
                table: "OrdemServico",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ColaboradoresId",
                table: "OrdemServico",
                column: "ColaboradoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Clientes_ClientesId",
                table: "OrdemServico",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Colaboradores_ColaboradoresId",
                table: "OrdemServico",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Clientes_ClientesId",
                table: "OrdemServico");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Colaboradores_ColaboradoresId",
                table: "OrdemServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_ClientesId",
                table: "OrdemServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_ColaboradoresId",
                table: "OrdemServico");
        }
    }
}
