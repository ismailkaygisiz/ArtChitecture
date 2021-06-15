import '../entity.dart';

@entity
class TokenModel {
  String token;
  String expiration;

  TokenModel(this.token, this.expiration);

  factory TokenModel.fromJson(Map<String, dynamic> json) {
    return TokenModel(
      json["token"] as String,
      json["expiration"] as String,
    );
  }
}
