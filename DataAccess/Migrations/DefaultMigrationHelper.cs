using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public static class DefaultMigrationHelper
    {
        public static void InsertDefaultData(MigrationBuilder migrationBuilder)
        {
            // OperationClaims
            migrationBuilder.InsertData("OperationClaims", new[] { "OperationClaimId", "Name" },
                new object[] { 1, "Admin" });
            migrationBuilder.InsertData("OperationClaims", new[] { "OperationClaimId", "Name" },
                new object[] { 2, "User" });


            // Languages
            migrationBuilder.InsertData("Languages", new[] { "LanguageId", "LanguageCode", "LanguageName" },
                new object[] { 1, "tr-Tr", "Türkçe" });
            migrationBuilder.InsertData("Languages", new[] { "LanguageId", "LanguageCode", "LanguageName" },
                new object[] { 2, "en-Us", "English" });


            // Errors
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Authorization_Denied_Message_Key", "Yetkiniz Yok" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Authorization_Denied_Message_Key", "You are not Authorized" });

            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 1, "Login_Required_Message_Key", "Giriş Yapmanız Gerekiyor" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "Login_Required_Message_Key", "Login Required" });

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
                new object[] { 1, "You_Are_Redirecting_To_The_Login_Screen_Key", "Giriş Yapma Sayfasına Yönlendiriliyorsunuz" });
            migrationBuilder.InsertData("Translates", new[] { "LanguageId", "Key", "Value" },
                new object[] { 2, "You_Are_Redirecting_To_The_Login_Screen_Key", "You are Redirecting to the Login Screen" });

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
        }
    }
}
