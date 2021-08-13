using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class INITAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(nullable: true),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
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
                        name: "FK_Translates_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    RefreshTokenValue = table.Column<string>(nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
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
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Translates_LanguageId",
                table: "Translates",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");




            // OperationClaims
            migrationBuilder.InsertData("OperationClaims", "Name", "Admin");
            migrationBuilder.InsertData("OperationClaims", "Name", "User");


            // Languages
            migrationBuilder.InsertData("Languages", new[] { "Id", "LanguageCode", "LanguageName" },
                new object[] { 1, "tr-Tr", "Türkçe" });
            migrationBuilder.InsertData("Languages", new[] { "Id", "LanguageCode", "LanguageName" },
                new object[] { 2, "en-Us", "English" });


            // Errors
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Authorization_Denied_Message_Key", "Yetkiniz Yok" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Authorization_Denied_Message_Key", "You are not Authorized" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Validation_Error_Message_Key", "Doğrulama Hatası" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Validation_Error_Message_Key", "Validation Error" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Is_Not_A_Validation_Class_Message_Key", "Bu Bir Doğrulama Sınıfı Değil" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Is_Not_A_Validation_Class_Message_Key", "This is not a Validation Class" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Transaction_Scope_Error_Message_Key", "İstek İşlenemedi" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Transaction_Scope_Error_Message_Key", "Request Failed to Process" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Cannot_Cal_Property_Error_Key", "Özelliği Çağıramazsınız" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Cannot_Cal_Property_Error_Key", "Cannot Call Property" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                    {1, "Transaction_Error_Key", "Beklenmedik Bir Hata Meydana Geldi Yapılan İşlem Geri Alınıyor"});
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    2, "Transaction_Error_Key", "An Unexpected Error Occurred While Running Transaction Rolling Back"
                });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Internal_Server_Error_Key", "Beklenmeyen Sunucu Hatası" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Internal_Server_Error_Key", "Internal Server Error" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "User_Is_Already_Exists_Key", "Kullanıcı Zaten Mevcut" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "User_Is_Already_Exists_Key", "User is Already Exists" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Email_Or_Password_Is_Not_Valid_Key", "E-Posta veya Parola Hatalı" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Email_Or_Password_Is_Not_Valid_Key", "Email or Password is not Valid" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Password_Changed_Key", "Parola Değiştirildi" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Password_Changed_Key", "Password Changed" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                    {1, "New_Password_Cannot_Be_Same_As_The_Old_Password_Key", "Yeni Parola Eskisiyle Aynı Olamaz"});
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    2, "New_Password_Cannot_Be_Same_As_The_Old_Password_Key",
                    "New Password Cannot be Same as the Old Password"
                });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Successful_Login_Key", "Giriş Başarılı" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Successful_Login_Key", "Successful Login" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Successful_Register_Key", "Kayıt İşlemi Başarılı" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Successful_Register_Key", "Successful Register" });


            // Validations
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Email_Cannot_Be_Empty_Key", "E-Posta Boş Olamaz" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Email_Cannot_Be_Empty_Key", "Email Cannot be Empty" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Password_Cannot_Be_Empty_Key", "Parola Boş Olamaz" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Password_Cannot_Be_Empty_Key", "Password Cannot be Empty" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Email_Is_Not_A_Real_Email_Key", "E-Posta Gerçek Bir E-Posta Değil" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Email_Is_Not_A_Real_Email_Key", "Email is not a Real Email" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    1, "Password_Must_Be_At_Least_8_Characters_Long", "Parola Minimum 8 Karakter Uzunluğunda Olmalıdır"
                });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                    {2, "Password_Must_Be_At_Least_8_Characters_Long", "Password Must be at Least 8 Characters Long"});

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    1, "Password_Must_Contain_At_Least_1_Lowercase_Letter", "Parola Minimum 1 Küçük Harf İçermelidir"
                });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    2, "Password_Must_Contain_At_Least_1_Lowercase_Letter",
                    "Password Must Contain at Least 1 Lowercase Letter"
                });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    1, "Password_Must_Contain_At_Least_1_Uppercase_Letter", "Parola Minimum 1 Büyük Harf İçermelidir"
                });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    2, "Password_Must_Contain_At_Least_1_Uppercase_Letter",
                    "Password Must Contain at Least 1 Uppercase Letter"
                });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    1, "Password_Must_Contain_At_Least_1_Special_Character",
                    "Parola Minimum 1 Özel Karakter İçermelidir"
                });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    2, "Password_Must_Contain_At_Least_1_Special_Character",
                    "Password Must Contain at Least 1 Special Character"
                });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Password_Must_Contain_At_Least_1_Digit", "Parola Minimum 1 Rakam İçermelidir" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Password_Must_Contain_At_Least_1_Digit", "Password Must Contain at Least 1 Digit" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    1, "Role_Name_Must_Be_At_Least_2_Characters_Long",
                    "Rol Adı Minimum 2 Karakter Uzunluğunda Olmalıdır"
                });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[]
                {
                    2, "Role_Name_Must_Be_At_Least_2_Characters_Long", "Role Name Must be at Least 2 Characters Long"
                });


            // AngularUI
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Login_Title_Key", "Giriş Yap" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Login_Title_Key", "Login" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Sign_Up_Title_Key", "Kayıt Ol" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Sign_Up_Title_Key", "Sign Up" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Placeholder_Name_Key", "Ad" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Placeholder_Name_Key", "Name" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Placeholder_Surname_Key", "Soyad" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Placeholder_Surname_Key", "Surname" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Placeholder_Email_Key", "E-Posta" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Placeholder_Email_Key", "Email" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Placeholder_Password_Key", "Parola" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Placeholder_Password_Key", "Password" });


            // FlutterUI
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Hello_World_Key", "Merhaba Dünya" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Hello_World_Key", "Hello World" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Welcome_Key", "ArtChitecture'a Hoş Geldiniz" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Welcome_Key", "Welcome to ArtChitecture" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Increment_Key", "Artır" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Increment_Key", "Increse" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Value_Key", "Değer" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Value_Key", "Value" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Reset_Key", "Sıfırla" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Reset_Key", "Reset" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Translates");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
