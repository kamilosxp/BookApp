using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "Offers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BuyerId",
                table: "Offers",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_BuyerId",
                table: "Offers",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_BuyerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_BuyerId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "Offers");
        }
    }
}
