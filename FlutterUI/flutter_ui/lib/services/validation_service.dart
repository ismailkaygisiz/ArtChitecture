class ValidationService {
  bool? returnValue;

  /// If response has error returns true
  showErrors(Map<String, dynamic> jsonData) {
    if (jsonData["success"] as bool == true) {
      print("İşlem Başarılı");
      return false;
    }

    if (jsonData.containsKey("exceptionType")) {
      switch (jsonData["exceptionType"]) {
        case ExceptionType.TransactionException:
          print(jsonData["transactionError"]);
          print(jsonData["errorMessage"]);

          returnValue = true;
          break;

        case ExceptionType.AuthorizationDeniedException:
          print(jsonData["securityError"]);
          print(jsonData["errorMessage"]);

          returnValue = true;
          break;

        case ExceptionType.ValidationException:
          var validationErrors = jsonData["validationErrors"] as List;

          validationErrors.forEach((error) {
            print(error);
          });
          print(jsonData["errorMessage"]);

          returnValue = true;
          break;

        default:
          if (jsonData.containsKey("errorMessage")) {
            print(jsonData["errorMessage"]);
          }

          returnValue = true;
          break;
      }
    } else if (jsonData.containsKey("message")) {
      print(jsonData["message"]);

      returnValue = true;
    } else {
      print('Bir Şeyler Ters Gitti Beklenmedik Hata');

      returnValue = true;
    }

    return returnValue;
  }
}

enum ExceptionType {
  TransactionException,
  AuthorizationDeniedException,
  LoginRequiredException,
  ValidationException,
  SystemException,
}
