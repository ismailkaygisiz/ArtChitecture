import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/user/refreshTokenModel.dart';
import 'package:flutter_ui/core/models/user/tokenModel.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class AuthInterceptor extends http.BaseClient {
  http.BaseClient _httpClient;

  AuthInterceptor() {
    _httpClient = http.Client();
  }

  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) async {
    var tokenModel = await getTokens();
    var lang = await getLang();
    Map<String, String> headers;

    headers = {
      "content-type": "application/json",
      'Authorization': "Bearer " + "${tokenModel.token}",
      'lang': "$lang",
      "RefreshToken": "${tokenModel.refreshToken.refreshTokenValue}",
      "ClientId": "${tokenModel.refreshToken.clientId}",
      "ClientName": "${tokenModel.refreshToken.clientName}",
    };

    request.headers.addAll(headers);

    if (tokenModel.refreshToken.refreshTokenValue != null &&
        await tokenService.isTokenExpired()) {
      var newRequest = await _httpClient.post(
        Uri.parse(Environments.API_URL + "auth/refreshtoken"),
        headers: headers,
      );

      var response = SingleResponseModel<TokenModel>.fromJson(newRequest);
      if (response.success) {
        authService.onRefreshTokenSucceed(response.data);
        await tokenService.setToken(response.data.token);
        await tokenService
            .setRefreshToken(response.data.refreshToken.refreshTokenValue);
        await tokenService.setClientId(response.data.refreshToken.clientId);
      } else {
        authService.onRefreshTokenFailed();
        await tokenService.removeRefreshToken();
        await tokenService.removeToken();
      }
    }

    return await _httpClient.send(request);
  }

  Future<TokenModel> getTokens() async {
    var prefs = await SharedPreferences.getInstance();

    var token = await prefs.get("token");
    var refreshToken = await prefs.get("refresh-token");
    var clientId = await prefs.get("client-id");

    if (token != null) token = cryptoService.get(token);
    if (refreshToken != null) refreshToken = cryptoService.get(refreshToken);
    if (clientId != null) clientId = cryptoService.get(clientId);

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

  Future<String> getLang() async {
    var prefs = await SharedPreferences.getInstance();

    var lang = await prefs.get("lang");
    if (lang != null) lang = cryptoService.get(lang);

    return lang;
  }
}
