import '../entity.dart';

@entity
class RefreshTokenModel {
  String refreshTokenValue;
  String refreshTokenEndDate;
  String clientId;
  String clientName;
  Map<String, dynamic> jsonData;

  RefreshTokenModel(this.refreshTokenValue, this.refreshTokenEndDate,
      this.clientId, this.clientName);

  RefreshTokenModel.withJson(this.refreshTokenValue, this.refreshTokenEndDate,
      this.clientId, this.clientName, this.jsonData);

  factory RefreshTokenModel.fromJson(Map<String, dynamic> json) {
    return RefreshTokenModel.withJson(
      json["refreshTokenValue"] as String,
      json["refreshTokenEndDate"] as String,
      json["clientId"] as String,
      json["clientName"] as String,
      json,
    );
  }
}
