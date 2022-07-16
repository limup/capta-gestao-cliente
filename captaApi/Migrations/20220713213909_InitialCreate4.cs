using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace captaApi.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_dominio_tb_cliente_ClienteFK",
                table: "tb_dominio");

            migrationBuilder.RenameColumn(
                name: "ClienteFK",
                table: "tb_dominio",
                newName: "ClienteId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_tb_dominio_ClienteFK",
                table: "tb_dominio",
                newName: "IX_tb_dominio_ClienteId_FK");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "tb_dominio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_dominio_tb_cliente_ClienteId_FK",
                table: "tb_dominio",
                column: "ClienteId_FK",
                principalTable: "tb_cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_dominio_tb_cliente_ClienteId_FK",
                table: "tb_dominio");

            migrationBuilder.RenameColumn(
                name: "ClienteId_FK",
                table: "tb_dominio",
                newName: "ClienteFK");

            migrationBuilder.RenameIndex(
                name: "IX_tb_dominio_ClienteId_FK",
                table: "tb_dominio",
                newName: "IX_tb_dominio_ClienteFK");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "tb_dominio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_dominio_tb_cliente_ClienteFK",
                table: "tb_dominio",
                column: "ClienteFK",
                principalTable: "tb_cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
