import 'package:dio/dio.dart';
import 'package:reflectable/reflectable.dart';

import '../entity.dart';

class SingleResponseModel<T> {
  bool success;
  String? message;
  T? data;
  Map<String, dynamic> jsonData;

  SingleResponseModel(this.success, this.message, this.data, this.jsonData);

  factory SingleResponseModel.fromJson(Response<dynamic>? response) {
    Map<String, dynamic> jsonData = response?.data;

    if (jsonData["success"] as bool == true) {
      var classMirror = entity.reflectType(T) as ClassMirror;

      dynamic d = jsonData["data"];

      var data = classMirror.newInstance("fromJson", [d]) as T;
      return SingleResponseModel(
        jsonData["success"] as bool,
        jsonData["message"] as String?,
        data,
        jsonData,
      );
    }

    return SingleResponseModel(
      jsonData["success"] as bool,
      jsonData["message"] as String,
      null,
      jsonData,
    );
  }
}
