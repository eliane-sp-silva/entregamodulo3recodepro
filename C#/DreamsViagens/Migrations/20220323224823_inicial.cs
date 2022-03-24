using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamsViagens.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastrarDestinos",
                columns: table => new
                {
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Casal_Familia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastrarDestinos", x => x.Id_Destino);
                });

            migrationBuilder.CreateTable(
                name: "cadastrarOfertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastrarOfertas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    Id_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.Id_Contato);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Destino = table.Column<int>(type: "int", nullable: false),
                    Id_CadastrarCarro = table.Column<int>(type: "int", nullable: false),
                    CadastrarDestinoId_Destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_compras_CadastrarDestinos_CadastrarDestinoId_Destino",
                        column: x => x.CadastrarDestinoId_Destino,
                        principalTable: "CadastrarDestinos",
                        principalColumn: "Id_Destino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compras_CadastrarDestinoId_Destino",
                table: "compras",
                column: "CadastrarDestinoId_Destino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadastrarOfertas");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "CadastrarDestinos");
        }
    }
}
