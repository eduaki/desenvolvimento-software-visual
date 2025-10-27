using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciador_inventario.Migrations
{
    /// <inheritdoc />
    public partial class adicionandotabelarequisicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requisicoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DataRequisicao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Itens_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Itens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_ItemID",
                table: "Requisicoes",
                column: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requisicoes");
        }
    }
}
