using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class INITAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Groups",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Groups", x => x.Id); });

            migrationBuilder.CreateTable(
                "Languages",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(nullable: true),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Languages", x => x.Id); });

            migrationBuilder.CreateTable(
                "OperationClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_OperationClaims", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Translates",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        "FK_Translates_Languages_LanguageId",
                        x => x.LanguageId,
                        "Languages",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "GroupOperationClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    OperationClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOperationClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_GroupOperationClaims_Groups_GroupId",
                        x => x.GroupId,
                        "Groups",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_GroupOperationClaims_OperationClaims_OperationClaimId",
                        x => x.OperationClaimId,
                        "OperationClaims",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserOperationClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    OperationClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        x => x.OperationClaimId,
                        "OperationClaims",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserOperationClaims_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_GroupOperationClaims_GroupId",
                "GroupOperationClaims",
                "GroupId");

            migrationBuilder.CreateIndex(
                "IX_GroupOperationClaims_OperationClaimId",
                "GroupOperationClaims",
                "OperationClaimId");

            migrationBuilder.CreateIndex(
                "IX_Translates_LanguageId",
                "Translates",
                "LanguageId");

            migrationBuilder.CreateIndex(
                "IX_UserOperationClaims_OperationClaimId",
                "UserOperationClaims",
                "OperationClaimId");

            migrationBuilder.CreateIndex(
                "IX_UserOperationClaims_UserId",
                "UserOperationClaims",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "GroupOperationClaims");

            migrationBuilder.DropTable(
                "Translates");

            migrationBuilder.DropTable(
                "UserOperationClaims");

            migrationBuilder.DropTable(
                "Groups");

            migrationBuilder.DropTable(
                "Languages");

            migrationBuilder.DropTable(
                "OperationClaims");

            migrationBuilder.DropTable(
                "Users");
        }
    }
}