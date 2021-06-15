import 'dart:convert';

import '../entity.dart';

@entity
class LoginModel {
  String email;
  String password;

  LoginModel(this.email, this.password);

  String toJson() {
    return json.encode({
      "email": email,
      "password": password,
    });
  }
}
