using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOgSikkerhedApp.Migrations.TodoItem
{
    /// <inheritdoc />
    public partial class initialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cprs",
                columns: table => new
                {
                    cprId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cprNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cprs", x => x.cprId);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.userName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cprs");

            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
