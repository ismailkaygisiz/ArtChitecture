import 'package:flutter_ui/core/models/user/refreshTokenModel.dart';

import '../entity.dart';

@entity
class TokenModel {
  String token;
  String expiration;
  RefreshTokenModel refreshToken;

  TokenModel(this.token, this.expiration, this.refreshToken);

  factory TokenModel.fromJson(Map<String, dynamic> json) {
    return TokenModel(
      json["token"] as String,
      json["expiration"] as String,
      RefreshTokenModel.fromJson(json["refreshToken"]),
    );
  }
}
