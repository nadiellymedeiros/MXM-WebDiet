using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<string>(type: "TEXT", nullable: false),
                    Altura = table.Column<string>(type: "TEXT", nullable: false),
                    Peso = table.Column<string>(type: "TEXT", nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.Cpf);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dietas");
        }
    }
}
