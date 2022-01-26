import 'package:flutter_ui/core/models/user/user_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:jwt_decode/jwt_decode.dart';

class TokenService {
  decodeToken(String? token) {
    if (token != null && token != "") {
      return Jwt.parseJwt(token);
    }
    return null;
  }

  Future<String?> getToken() async {
    return await storageService.get("token");
  }

  Future<void> setToken(String? token) async {
    await storageService.set('token', token);
  }

  Future<void> removeToken() async {
    await storageService.remove('token');
  }

  Future<String?> getRefreshToken() async {
    return await storageService.get("refresh-token");
  }

  Future<void> setRefreshToken(String? token) async {
    await storageService.set('refresh-token', token);
  }

  Future<void> removeRefreshToken() async {
    await storageService.remove('refresh-token');
  }

  Future<String?> getClientId() async {
    return await storageService.get("client-id");
  }

  Future<void> setClientId(String? clientId) async {
    await storageService.set('client-id', clientId);
  }

  Future<void> removeClientId() async {
    await storageService.remove('client-id');
  }

  Future<bool> isTokenExpired() async {
    String? token = await getToken();

    bool? isExpired;
    if (token != null && token != "") isExpired = Jwt.isExpired(token);

    return isExpired ?? true;
  }

  Future<DateTime?> getTokenExpirationDate() async {
    var token = await getToken();

    if (token != null && token != "") {
      return Jwt.getExpiryDate(token);
    }

    return null;
  }

  Future<List<String>> getUserRolesWithJWT() async {
    var token = decodeToken(await getToken());
    List<String> _roles = [];

    if (token != null) {
      Map t = token;

      t.keys.forEach((element) {
        if (element.endsWith("/role")) {
          if (t[element] is String) {
            _roles.add(t[element]);
          } else if (t[element] is List) {
            for (int i = 0; i < t[element].length; i++) {
              _roles.add(t[element][i]);
            }
          }
        }
      });

      return _roles;
    }

    return _roles;
  }

  Future<UserModel?> getUserWithJWT() async {
    var token = decodeToken(await getToken());

    if (token != null) {
      UserModel userModel = UserModel(0, "", true);
      Map t = token;

      t.forEach((key, dynamic value) {
        String k = key;

        if (k.endsWith("/nameidentifier")) {
          userModel.id = int.parse(value.toString());
        } else if (k.endsWith("email")) {
          userModel.email = value.toString();
        } else if (k.endsWith("status")) {
          userModel.status =
              value.toString().toLowerCase() == "true" ? true : false;
        }
      });

      return userModel;
    }

    return null;
  }
}
