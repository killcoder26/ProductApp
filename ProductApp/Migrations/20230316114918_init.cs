using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CProductInfo",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productStockQty = table.Column<int>(type: "int", nullable: false),
                    productAvailQty = table.Column<int>(type: "int", nullable: false),
                    productPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CProductInfo", x => x.productId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CProductInfo");
        }
    }
}
