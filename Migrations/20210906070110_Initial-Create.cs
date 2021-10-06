using Microsoft.EntityFrameworkCore.Migrations;

namespace _08312021_Empite_Co_Solution.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MProducts",
                columns: table => new
                {
                    ItemCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    UnitofMeasure = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierCode = table.Column<int>(type: "int", nullable: false)
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MProducts", x => x.ItemCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MProducts");
        }
    }
}
