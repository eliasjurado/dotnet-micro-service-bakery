using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.OrderAPI.Migrations
{
    public partial class Sellv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellHeaderIdSellHeader",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SellDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSellHeader = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellHeaders",
                columns: table => new
                {
                    IdSellHeader = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellHeaders", x => x.IdSellHeader);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_SellHeaders_SellHeaderIdSellHeader",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "SellDetails");

            migrationBuilder.DropTable(
                name: "SellHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SellHeaderIdSellHeader",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SellHeaderIdSellHeader",
                table: "OrderDetails");
        }
    }
}
