import '../entity.dart';

@entity
class TokenModel {
  String token;
  String expiration;
  String refreshToken;

  TokenModel(this.token, this.expiration, this.refreshToken);

  factory TokenModel.fromJson(Map<String, dynamic> json) {
    return TokenModel(
      json["token"] as String,
      json["expiration"] as String,
      json["refreshToken"] as String,
    );
  }
}
