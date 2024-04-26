using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upcoursework.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class changecommentconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_orders_OrderId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_buyers_BuyerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_comments_OrderId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "comments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "orders",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_buyers_BuyerId",
                table: "orders",
                column: "BuyerId",
                principalTable: "buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_buyers_BuyerId",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_OrderId",
                table: "comments",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_orders_OrderId",
                table: "comments",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_buyers_BuyerId",
                table: "orders",
                column: "BuyerId",
                principalTable: "buyers",
                principalColumn: "Id");
        }
    }
}
