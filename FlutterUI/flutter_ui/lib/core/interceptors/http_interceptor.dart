import 'package:dio/dio.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/user/refresh_token_model.dart';
import 'package:flutter_ui/core/models/user/token_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/environments/api.dart';

/// Sets Headers
/// Sends RefreshToken to API
/// Extends [Interceptor]
class HttpInterceptor extends Interceptor {
  @override
  void onRequest(
    RequestOptions options,
    RequestInterceptorHandler handler,
  ) async {
    options.headers = await setHeaders();
    await tokenRefresh();

    super.onRequest(options, handler);
  }

  /// It sets headers for http requests
  Future<Map<String, dynamic>> setHeaders() async {
    var tokenModel = await getTokens();
    var lang = await storageService.get("lang");
    Map<String, String> headers;

    headers = {
      "content-type": "application/json",
      'Authorization': "Bearer " + "${tokenModel.token}",
      'lang': "$lang",
      "RefreshToken": "${tokenModel.refreshToken?.refreshTokenValue}",
      "ClientId": "${tokenModel.refreshToken?.clientId}",
      "ClientName": "${tokenModel.refreshToken?.clientName}",
    };

    return headers;
  }

  Future<void> tokenRefresh() async {
    if (await tokenService.getRefreshToken() != null &&
        await tokenService.isTokenExpired()) {
      httpClient.httpClient.interceptors.requestLock.lock();
      var response = await Dio().post(
        Environments.API_URL + "auth/refreshtoken",
        options: Options(
          headers: await setHeaders(),
          validateStatus: (status) => true,
        ),
      );

      var parsedResponse = SingleResponseModel<TokenModel>.fromJson(response);
      if (parsedResponse.success) {
        tokenService.setToken(parsedResponse.data?.token);
        tokenService.setRefreshToken(
            parsedResponse.data?.refreshToken?.refreshTokenValue);
        tokenService.setClientId(parsedResponse.data?.refreshToken?.clientId);
        authService.onRefreshTokenSucceed(parsedResponse.data);
      } else {
        tokenService.removeToken();
        tokenService.removeRefreshToken();
        authService.onRefreshTokenFailed();
      }
    }

    httpClient.httpClient.interceptors.requestLock.unlock();
  }

  Future<TokenModel> getTokens() async {
    var token = await storageService.get("token");
    var refreshToken = await storageService.get("refresh-token");
    var clientId = await storageService.get("client-id");

    return TokenModel(
      token,
      null,
      RefreshTokenModel(
        refreshToken,
        null,
        clientId,
        Environments.CLIENT_NAME,
      ),
    );
  }
}
