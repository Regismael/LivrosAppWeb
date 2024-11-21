using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrosApp.Infra.DATA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LIVRO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITULO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AUTOR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GENERO = table.Column<int>(type: "int", nullable: false),
                    ANODEPUBLICACAO = table.Column<int>(type: "int", nullable: false),
                    DISPONIBILIDADE = table.Column<bool>(type: "bit", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DATAINCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATARETIRADA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVRO", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LIVRO");
        }
    }
}
