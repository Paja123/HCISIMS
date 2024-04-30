using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialProject.Migrations
{
    public partial class complexTourRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComplexTourRequestId",
                table: "TourRequest",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComplexTourRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexTourRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplexTourRequestUser",
                columns: table => new
                {
                    ComplexTourRequestsId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuidesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexTourRequestUser", x => new { x.ComplexTourRequestsId, x.GuidesId });
                    table.ForeignKey(
                        name: "FK_ComplexTourRequestUser_ComplexTourRequest_ComplexTourRequestsId",
                        column: x => x.ComplexTourRequestsId,
                        principalTable: "ComplexTourRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplexTourRequestUser_User_GuidesId",
                        column: x => x.GuidesId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourRequest_ComplexTourRequestId",
                table: "TourRequest",
                column: "ComplexTourRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplexTourRequestUser_GuidesId",
                table: "ComplexTourRequestUser",
                column: "GuidesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourRequest_ComplexTourRequest_ComplexTourRequestId",
                table: "TourRequest",
                column: "ComplexTourRequestId",
                principalTable: "ComplexTourRequest",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourRequest_ComplexTourRequest_ComplexTourRequestId",
                table: "TourRequest");

            migrationBuilder.DropTable(
                name: "ComplexTourRequestUser");

            migrationBuilder.DropTable(
                name: "ComplexTourRequest");

            migrationBuilder.DropIndex(
                name: "IX_TourRequest_ComplexTourRequestId",
                table: "TourRequest");

            migrationBuilder.DropColumn(
                name: "ComplexTourRequestId",
                table: "TourRequest");
        }
    }
}
