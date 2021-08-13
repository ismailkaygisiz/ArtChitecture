import 'dart:convert';

import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/environments/api.dart';

import '../entity.dart';

@entity
class LoginModel {
  String email;
  String password;

  LoginModel(
    this.email,
    this.password,
  );

  Future<String> toJson() async {
    var clientId = await sessionService.get("client-id");

    return json.encode({
      "email": email,
      "password": password,
      "clientName": Environments.CLIENT_NAME,
      "clientId": clientId,
    });
  }
}
