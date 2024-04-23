using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    /// <inheritdoc />
    public partial class editEntidadesUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Altura",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Idade",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
