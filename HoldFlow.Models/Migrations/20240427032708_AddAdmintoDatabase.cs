using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoldFlow.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmintoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdminId",
                table: "Orders",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_AdminId",
                table: "Borrows",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_AdminId",
                table: "Borrows",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AdminId",
                table: "Orders",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_AdminId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AdminId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AdminId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_AdminId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Borrows");
        }
    }
}
