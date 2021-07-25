import 'dart:convert';
import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/user/loginModel.dart';
import 'package:flutter_ui/core/models/user/registerModel.dart';
import 'package:flutter_ui/core/models/user/tokenModel.dart';
import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/environments/api.dart';

class AuthService extends Service {
  SessionService _sessionService = SessionService();

  Future<SingleResponseModel<TokenModel>> login(LoginModel user) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "auth/login"),
      body: user.toJson(),
    );

    return SingleResponseModel<TokenModel>.fromJson(response);
  }

  Future<SingleResponseModel<TokenModel>> register(RegisterModel user) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "auth/register"),
      body: user.toJson(),
    );

    return SingleResponseModel<TokenModel>.fromJson(response);
  }

  bool logout() {
    if (isAuthenticated() == true) {
      _sessionService.remove("token");

      return true;
    }

    return false;
  }

  bool isAuthenticated() {
    bool token;

    _sessionService
        .get("token")
        .then((value) => value != null ? token = true : token = false);

    if (token) {
      return true;
    }

    return false;
  }
}
