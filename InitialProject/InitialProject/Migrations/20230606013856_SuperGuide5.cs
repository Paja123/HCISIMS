using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class SuperGuide5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Voucher",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_GuideId",
                table: "Voucher",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_User_GuideId",
                table: "Voucher",
                column: "GuideId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_User_GuideId",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_GuideId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Voucher");
        }
    }
}
