using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.OrderAPI.Migrations
{
    public partial class Sellv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_SellHeaders_SellHeaderIdSellHeader",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SellHeaderIdSellHeader",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SellHeaderIdSellHeader",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "SellHeaderIdSellHeader",
                table: "SellDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellDetails_SellHeaderIdSellHeader",
                table: "SellDetails",
                column: "SellHeaderIdSellHeader");

            migrationBuilder.AddForeignKey(
                name: "FK_SellDetails_SellHeaders_SellHeaderIdSellHeader",
                table: "SellDetails",
                column: "SellHeaderIdSellHeader",
                principalTable: "SellHeaders",
                principalColumn: "IdSellHeader",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellDetails_SellHeaders_SellHeaderIdSellHeader",
                table: "SellDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellDetails_SellHeaderIdSellHeader",
                table: "SellDetails");

            migrationBuilder.DropColumn(
                name: "SellHeaderIdSellHeader",
                table: "SellDetails");

            migrationBuilder.AddColumn<int>(
                name: "SellHeaderIdSellHeader",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SellHeaderIdSellHeader",
                table: "OrderDetails",
                column: "SellHeaderIdSellHeader");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_SellHeaders_SellHeaderIdSellHeader",
                table: "OrderDetails",
                column: "SellHeaderIdSellHeader",
                principalTable: "SellHeaders",
                principalColumn: "IdSellHeader",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
