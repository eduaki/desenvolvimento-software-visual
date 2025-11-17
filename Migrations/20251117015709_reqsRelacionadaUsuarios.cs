using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciador_inventario.Migrations
{
    /// <inheritdoc />
    public partial class reqsRelacionadaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Itens_ItemID",
                table: "Requisicoes");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Requisicoes",
                newName: "ID_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Requisicoes_ItemID",
                table: "Requisicoes",
                newName: "IX_Requisicoes_ID_usuario");

            migrationBuilder.AddColumn<int>(
                name: "ID_item",
                table: "Requisicoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_ID_item",
                table: "Requisicoes",
                column: "ID_item");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Itens_ID_item",
                table: "Requisicoes",
                column: "ID_item",
                principalTable: "Itens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Usuarios_ID_usuario",
                table: "Requisicoes",
                column: "ID_usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Itens_ID_item",
                table: "Requisicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Usuarios_ID_usuario",
                table: "Requisicoes");

            migrationBuilder.DropIndex(
                name: "IX_Requisicoes_ID_item",
                table: "Requisicoes");

            migrationBuilder.DropColumn(
                name: "ID_item",
                table: "Requisicoes");

            migrationBuilder.RenameColumn(
                name: "ID_usuario",
                table: "Requisicoes",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Requisicoes_ID_usuario",
                table: "Requisicoes",
                newName: "IX_Requisicoes_ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Itens_ItemID",
                table: "Requisicoes",
                column: "ItemID",
                principalTable: "Itens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
