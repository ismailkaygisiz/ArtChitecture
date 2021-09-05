import 'package:dio/dio.dart';

class ResponseModel {
  bool success;
  String? message;
  Map<String, dynamic> jsonData;

  ResponseModel(this.success, this.message, this.jsonData);

  factory ResponseModel.fromJson(Response<dynamic>? response) {
    Map<String, dynamic> jsonData = response?.data;
    return ResponseModel(
      jsonData["success"] as bool,
      jsonData["message"] as String?,
      jsonData,
    );
  }
}
