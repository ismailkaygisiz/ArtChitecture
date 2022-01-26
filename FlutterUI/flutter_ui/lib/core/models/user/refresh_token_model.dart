import '../entity.dart';

@entity
class RefreshTokenModel {
  int? refreshTokenId;
  int? userId;
  String? clientId;
  String? clientName;
  String? tokenValue;
  String? refreshTokenValue;
  String? refreshTokenEndDate;

  Map<String, dynamic>? jsonData;

  RefreshTokenModel(
    this.refreshTokenValue,
    this.refreshTokenEndDate,
    this.clientId,
    this.clientName,
  );

  RefreshTokenModel.withJson(
    this.refreshTokenId,
    this.userId,
    this.clientId,
    this.clientName,
    this.tokenValue,
    this.refreshTokenValue,
    this.refreshTokenEndDate,
    this.jsonData,
  );

  factory RefreshTokenModel.fromJson(Map<String, dynamic> json) {
    return RefreshTokenModel.withJson(
      json["refreshTokenId"] as int?,
      json["userId"] as int?,
      json["clientId"] as String?,
      json["clientName"] as String?,
      json["tokenValue"] as String?,
      json["refreshTokenValue"] as String?,
      json["refreshTokenEndDate"] as String?,
      json,
    );
  }
}
