using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myPosGift.Infrastructure.Migrations
{
    public partial class cha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Transactions_TransactionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TransactionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TransactionId",
                table: "AspNetUsers",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Transactions_TransactionId",
                table: "AspNetUsers",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
