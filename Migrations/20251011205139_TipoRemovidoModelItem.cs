using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciador_inventario.Migrations
{
    /// <inheritdoc />
    public partial class TipoRemovidoModelItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_tipo",
                table: "Itens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_tipo",
                table: "Itens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
