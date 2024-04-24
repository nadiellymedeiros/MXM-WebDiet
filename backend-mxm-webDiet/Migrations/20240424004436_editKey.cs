using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    /// <inheritdoc />
    public partial class editKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dietas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dietas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas",
                column: "UserCpf");
        }
    }
}
