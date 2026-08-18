using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyGas.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacoesBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazaoSocial = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false),
                    Idade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faturamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalQuinzenal = table.Column<decimal>(type: "numeric", nullable: false),
                    DataFaturamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusPagamento = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false),
                    ColaboradoresId = table.Column<int>(type: "integer", nullable: false),
                    ClientesId = table.Column<int>(type: "integer", nullable: false),
                    NumeroOs = table.Column<int>(type: "integer", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    OsFinalizada = table.Column<bool>(type: "boolean", nullable: false),
                    FaturamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Colaboradores_ColaboradoresId",
                        column: x => x.ColaboradoresId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Faturamento_FaturamentoId",
                        column: x => x.FaturamentoId,
                        principalTable: "Faturamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ClientesId",
                table: "OrdemServico",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ColaboradoresId",
                table: "OrdemServico",
                column: "ColaboradoresId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_FaturamentoId",
                table: "OrdemServico",
                column: "FaturamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Faturamento");
        }
    }
}
