import 'dart:convert';

import '../entity.dart';

@entity
class RegisterModel {
  String email;
  String password;

  RegisterModel(
    this.email,
    this.password,
  );

  String toJson() {
    return json.encode({
      "email": email,
      "password": password,
    });
  }
}
