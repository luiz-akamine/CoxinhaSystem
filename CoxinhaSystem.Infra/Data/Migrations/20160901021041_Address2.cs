using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CoxinhaSystem.Infra.Migrations
{
    public partial class Address2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Address_Customer_CustomerId", table: "Address");
            migrationBuilder.DropForeignKey(name: "FK_Customer_Address_MainAddressId", table: "Customer");
            migrationBuilder.DropForeignKey(name: "FK_Order_Customer_CustomerId", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Order_OrderId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Product_ProductId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_Phone_Customer_CustomerId", table: "Phone");
            migrationBuilder.DropColumn(name: "MainAddressId", table: "Customer");
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Address",
                nullable: false);
            migrationBuilder.AddColumn<bool>(
                name: "MainAddress",
                table: "Address",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customer",
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
            migrationBuilder.DropForeignKey(name: "FK_Address_Customer_CustomerId", table: "Address");
            migrationBuilder.DropForeignKey(name: "FK_Order_Customer_CustomerId", table: "Order");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Order_OrderId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_OrderItem_Product_ProductId", table: "OrderItem");
            migrationBuilder.DropForeignKey(name: "FK_Phone_Customer_CustomerId", table: "Phone");
            migrationBuilder.DropColumn(name: "MainAddress", table: "Address");
            migrationBuilder.AddColumn<int>(
                name: "MainAddressId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Address",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_MainAddressId",
                table: "Customer",
                column: "MainAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
