using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba_tecnica_net.Migrations
{
    public partial class PrimeraMigración : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceResponsibleParties",
                columns: table => new
                {
                    BrpCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodingScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityStart = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceResponsibleParties", x => x.BrpCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceResponsibleParties");
        }
    }
}
