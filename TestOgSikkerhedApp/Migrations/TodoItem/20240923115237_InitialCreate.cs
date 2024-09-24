using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOgSikkerhedApp.Migrations.TodoItem
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    cprNum = table.Column<int>(type: "int", nullable: false),
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
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CprUsercprId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_ToDos_Cprs_CprUsercprId",
                        column: x => x.CprUsercprId,
                        principalTable: "Cprs",
                        principalColumn: "cprId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_CprUsercprId",
                table: "ToDos",
                column: "CprUsercprId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Cprs");
        }
    }
}
