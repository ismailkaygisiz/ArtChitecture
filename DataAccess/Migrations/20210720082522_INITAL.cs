using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class INITAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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



            migrationBuilder.InsertData(table: "OperationClaims", column: "Name", value: "Admin");
            migrationBuilder.InsertData(table: "OperationClaims", column: "Name", value: "User");

            migrationBuilder.InsertData(table: "Languages", columns: new string[] {"Id", "LanguageCode", "LanguageName" }, values: new object[] {1, "tr-Tr", "Türkçe" });
            migrationBuilder.InsertData(table: "Languages", columns: new string[] {"Id", "LanguageCode", "LanguageName" }, values: new object[] {2, "en-Us", "English" });

            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 1, "Login_Title_Key", "Giriş Yap" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 2, "Login_Title_Key", "Login" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 1, "Sign_Up_Title_Key ", "Kayıt Ol" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 2, "Sign_Up_Title_Key ", "Sign Up" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 1, "Placeholder_Name_Key", "Ad" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 2, "Placeholder_Name_Key", "Name" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 1, "Placeholder_Surname_Key", "Soyad" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 2, "Placeholder_Surname_Key", "Surname" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 1, "Placeholder_Email_Key", "E-Posta" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 2, "Placeholder_Email_Key", "Email" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 1, "Placeholder_Password_Key", "Parola" });
            migrationBuilder.InsertData(table: "Translates", columns: new string[] { "LanguageId", "Key", "Value" }, values: new object[] { 2, "Placeholder_Password_Key", "Password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Translates");

            migrationBuilder.DropTable(
                "UserOperationClaims");

            migrationBuilder.DropTable(
                "Languages");

            migrationBuilder.DropTable(
                "OperationClaims");

            migrationBuilder.DropTable(
                "Users");
        }
    }
}