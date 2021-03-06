﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DNBSuperMarket.WebUI.Migrations
{
    public partial class testorderline6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderLine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Orders_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Orders_OrderId",
                table: "OrderLine");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderLine");
        }
    }
}
