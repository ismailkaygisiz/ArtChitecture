import 'dart:io';
import 'package:encrypt/encrypt.dart';
import 'package:flutter_ui/core/environments/environment.development.dart';
import 'package:flutter_ui/core/services/cryptoService.dart';
import 'package:flutter_ui/core/services/service.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:http/http.dart' as http;
import 'package:http/io_client.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AuthInterceptor extends http.BaseClient {
  HttpClient _ioHttpClient;
  IOClient _httpClient;

  AuthInterceptor() : _ioHttpClient = HttpClient() {
    _httpClient = IOClient(_ioHttpClient);
  }

  set badCertificateCallback(BadCertificateCallback callback) =>
      _ioHttpClient.badCertificateCallback = callback;

  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) async {
    var token = await getToken();

    request.headers.addAll({
      "content-type": "application/json",
      'Authorization': "Bearer " + token
    });

    return await _httpClient.send(request);
  }

  Future<String> getToken() async {
    var token = "";
    var prefs = await SharedPreferences.getInstance();
    final encrypter = Encrypter(AES(Key.fromUtf8(KEY), mode: AESMode.cbc));

    token = prefs.get("token") ?? "";
    if (token != "") {
      token = encrypter.decrypt(Encrypted.fromBase64(token),
          iv: IV.fromUtf8(TOKEN));
    }

    return token;
  }
}

var httpClient = AuthInterceptor();
