using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExemploEF.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutoEAltereiCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "tbClientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbClientes",
                table: "tbClientes",
                column: "ClienteID");

            migrationBuilder.CreateTable(
                name: "tbCategorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "tbProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProdutos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_CategoriaId",
                table: "tbProdutos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbProdutos");

            migrationBuilder.DropTable(
                name: "tbCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbClientes",
                table: "tbClientes");

            migrationBuilder.RenameTable(
                name: "tbClientes",
                newName: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ClienteID");
        }
    }
}
