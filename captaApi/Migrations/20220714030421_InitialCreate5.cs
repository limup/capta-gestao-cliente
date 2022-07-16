using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace captaApi.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<long>(type: "bigint", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_dominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_dominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_dominio_tb_cliente_ClienteId_FK",
                        column: x => x.ClienteId_FK,
                        principalTable: "tb_cliente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_dominio_ClienteId_FK",
                table: "tb_dominio",
                column: "ClienteId_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_dominio");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
