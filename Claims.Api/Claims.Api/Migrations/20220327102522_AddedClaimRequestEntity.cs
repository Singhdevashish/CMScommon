using Microsoft.EntityFrameworkCore.Migrations;

namespace Claim.Api.Migrations
{
    public partial class AddedClaimRequestEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimRequests",
                columns: table => new
                {
                    ClaimId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    ClaimAmount = table.Column<float>(type: "real", nullable: false),
                    ClaimStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRequests", x => x.ClaimId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimRequests");
        }
    }
}
