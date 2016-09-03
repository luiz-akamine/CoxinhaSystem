using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace CoxinhaSystem.Infra.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Order_Customer_CustomerId", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Order_OrderId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Product_ProductId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_Phone_Customer_CustomerId", table: "Phone");
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressName = table.Column<string>(type: "VARCHAR(300)", nullable: false),
                    CEP = table.Column<int>(nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    District = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Number = table.Column<int>(nullable: false),
                    State = table.Column<string>(type: "VARCHAR(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<int>(
                name: "MainAddressId",
                table: "Customer",
                nullable: true,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_MainAddressId",
                table: "Customer",
                column: "MainAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Customer_CustomerId",
                table: "Phone",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Customer_Address_MainAddressId", table: "Customer");
            migrationBuilder.DropForeignKey(name: "FK_Order_Customer_CustomerId", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Order_OrderId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Product_ProductId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_Phone_Customer_CustomerId", table: "Phone");
            migrationBuilder.DropColumn(name: "MainAddressId", table: "Customer");
            migrationBuilder.DropTable("Address");
            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Customer_CustomerId",
                table: "Phone",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
