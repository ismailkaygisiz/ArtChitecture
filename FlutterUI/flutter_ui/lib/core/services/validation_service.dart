import 'package:flutter_ui/core/utilities/service.dart';

class ValidationService extends Service {
  /// If response has error returns true
  showErrors(Map<String, dynamic> jsonData) {
    if (jsonData["success"] as bool == true) {
      print("İşlem Başarılı");
      return false;
    }

    // Validation Control
    if (jsonData.containsKey("ValidationErrors")) {
      var validationErrors = jsonData["ValidationErrors"] as List;

      validationErrors.forEach((error) {
        print(error);
      });

      print(jsonData["ErrorMessage"]);
      return true;
    }

    // Security Control
    else if (jsonData.containsKey("SecurityError")) {
      print(jsonData["SecurityError"]);

      print(jsonData["ErrorMessage"]);
      return true;
    }

    // Transaction Control
    else if (jsonData.containsKey("TransactionError")) {
      print(jsonData["TransactionError"]);
      print(jsonData["ErrorMessage"]);

      return true;
    }

    // System Control
    else if (jsonData.containsKey("ErrorMessage")) {
      print(jsonData["ErrorMessage"]);

      return true;
    }

    // BusinessRule Control
    else if (jsonData.containsKey("message")) {
      print(jsonData["message"]);

      return true;
    }

    // Error
    else {
      print('Bir Şeyler Ters Gitti Beklenmedik Hata');

      return true;
    }
  }
}
