using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdiApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCliente = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DuracaoContrato = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    ArquivoContrato = table.Column<string>(nullable: true),
                    ArquivoProposta = table.Column<string>(nullable: true),
                    ClienteID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    DataPagamento = table.Column<DateTime>(nullable: true),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    NroNota = table.Column<int>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    ValorBanco = table.Column<decimal>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    ContratoID = table.Column<Guid>(nullable: true),
                    ClienteID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receitas_Contratos_ContratoID",
                        column: x => x.ContratoID,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_NomeCliente",
                table: "Clientes",
                column: "NomeCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClienteID",
                table: "Contratos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_ClienteID",
                table: "Receitas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_ContratoID",
                table: "Receitas",
                column: "ContratoID");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_NroNota_CNPJ",
                table: "Receitas",
                columns: new[] { "NroNota", "CNPJ" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
