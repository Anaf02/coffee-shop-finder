using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShopDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCoffeeShopsTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeShop",
                table: "CoffeeShop");

            migrationBuilder.RenameTable(
                name: "CoffeeShop",
                newName: "CoffeeShops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeShops",
                table: "CoffeeShops",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeShops",
                table: "CoffeeShops");

            migrationBuilder.RenameTable(
                name: "CoffeeShops",
                newName: "CoffeeShop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeShop",
                table: "CoffeeShop",
                column: "Id");
        }
    }
}
