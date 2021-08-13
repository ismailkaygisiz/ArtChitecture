import '../entity.dart';

@entity
class TokenModel {
  String token;
  String expiration;
  String refreshToken;
  String clientId;

  TokenModel(this.token, this.expiration, this.refreshToken, this.clientId);

  factory TokenModel.fromJson(Map<String, dynamic> json) {
    return TokenModel(
      json["token"] as String,
      json["expiration"] as String,
      json["refreshToken"]["refreshTokenValue"] as String,
      json["refreshToken"]["clientId"] as String,
    );
  }
}
