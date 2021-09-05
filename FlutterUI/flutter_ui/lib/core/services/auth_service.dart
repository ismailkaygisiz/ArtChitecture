import 'package:flutter/cupertino.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/user/login_model.dart';
import 'package:flutter_ui/core/models/user/register_model.dart';
import 'package:flutter_ui/core/models/user/token_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service.dart';

class AuthService extends Service {
  Function? _refreshTokenFailedEvent;
  Function? _refreshTokenSucceedEvent;

  Future<SingleResponseModel<TokenModel>> login(LoginModel user) async {
    var response = await httpClient.post(
      "auth/login",
      body: user.toJson(),
    );

    return SingleResponseModel<TokenModel>.fromJson(response);
  }

  Future<SingleResponseModel<TokenModel>> register(RegisterModel user) async {
    var response = await httpClient.post(
      "auth/register",
      body: user.toJson(),
    );

    return SingleResponseModel<TokenModel>.fromJson(response);
  }

  Future<bool> logout() async {
    if (await isAuthenticated()) {
      await tokenService.removeToken();
      await tokenService.removeRefreshToken();

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
    _refreshTokenFailedEvent!();
  }

  onRefreshTokenSucceed(TokenModel? token) {
    _refreshTokenSucceedEvent!(token);
  }

  setRefreshTokenEvents({
    @required refreshTokenFailedEvent()?,
    @required refreshTokenSucceedEvent(TokenModel? token)?,
  }) {
    _refreshTokenFailedEvent = refreshTokenFailedEvent;
    _refreshTokenSucceedEvent = refreshTokenSucceedEvent;
  }
}
