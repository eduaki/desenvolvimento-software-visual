using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciador_inventario.Migrations
{
    /// <inheritdoc />
    public partial class tipoAddToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_tipo",
                table: "Itens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ID_tipo",
                table: "Itens",
                column: "ID_tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Tipos_ID_tipo",
                table: "Itens",
                column: "ID_tipo",
                principalTable: "Tipos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Tipos_ID_tipo",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_ID_tipo",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "ID_tipo",
                table: "Itens");
        }
    }
}
