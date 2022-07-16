using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace captaApi.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Situação",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "tb_cliente");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "tb_cliente",
                newName: "sexo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_cliente",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "tb_cliente",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_cliente",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_cliente",
                table: "tb_cliente",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_dominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    ClienteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_dominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_dominio_tb_cliente_ClienteFK",
                        column: x => x.ClienteFK,
                        principalTable: "tb_cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_dominio_ClienteFK",
                table: "tb_dominio",
                column: "ClienteFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_dominio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_cliente",
                table: "tb_cliente");

            migrationBuilder.RenameTable(
                name: "tb_cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "sexo",
                table: "Clientes",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Situação",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");
        }
    }
}
