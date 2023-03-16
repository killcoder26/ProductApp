using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Migrations
{
    public partial class addcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CCartInfo",
                columns: table => new
                {
                    productId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productQty = table.Column<int>(type: "int", nullable: false),
                    productPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCartInfo", x => x.productId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CCartInfo");
        }
    }
}
