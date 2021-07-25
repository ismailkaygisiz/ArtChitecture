import 'dart:convert';

import 'package:http/http.dart';

class ResponseModel {
  bool success;
  String message;
  Map<String, dynamic> jsonData;

  ResponseModel(this.success, this.message, this.jsonData);

  factory ResponseModel.fromJson(Response response) {
    Map<String, dynamic> jsonData = json.decode(response.body);
    return ResponseModel(
      jsonData["success"] as bool,
      jsonData["message"] as String,
      jsonData,
    );
  }
}
