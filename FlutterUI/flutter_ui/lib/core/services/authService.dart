import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/user/loginModel.dart';
import 'package:flutter_ui/core/models/user/registerModel.dart';
import 'package:flutter_ui/core/models/user/tokenModel.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/environments/api.dart';

class AuthService extends Service {
  Function _refreshTokenFailedEvent;
  Function _refreshTokenSucceedEvent;

  Future<SingleResponseModel<TokenModel>> login(LoginModel user) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "auth/login"),
      body: await user.toJson(),
    );

    return SingleResponseModel<TokenModel>.fromJson(response);
  }

  Future<SingleResponseModel<TokenModel>> register(RegisterModel user) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "auth/register"),
      body: user.toJson(),
    );

    return SingleResponseModel<TokenModel>.fromJson(response);
  }

  Future<bool> logout() async {
    if (await isAuthenticated()) {
      await sessionService.remove("token");

      return true;
    }

    return false;
  }

  Future<bool> isAuthenticated() async {
    bool token;

    var data = await sessionService.get("token");
    data != null ? token = true : token = false;

    return token;
  }

  onRefreshTokenFailed() {
    if (_refreshTokenFailedEvent != null) _refreshTokenFailedEvent();
  }

  onRefreshTokenSucceed(TokenModel token) {
    if (_refreshTokenSucceedEvent != null) _refreshTokenSucceedEvent(token);
  }

  setRefreshTokenEvents(
    refreshTokenFailedEvent(),
    refreshTokenSucceedEvent(TokenModel token),
  ) {
    _refreshTokenFailedEvent = refreshTokenFailedEvent;
    _refreshTokenSucceedEvent = refreshTokenSucceedEvent;
  }
}
