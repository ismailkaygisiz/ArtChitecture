import 'dart:convert';

import 'package:http/http.dart';
import 'package:reflectable/reflectable.dart';

import '../entity.dart';

class ListResponseModel<T> {
  bool success;
  String message;
  List<T> data;
  Map<String, dynamic> jsonData;

  ListResponseModel(this.success, this.message, this.data, this.jsonData);

  factory ListResponseModel.fromJson(Response response) {
    Map<String, dynamic> jsonData = json.decode(response.body);

    if (jsonData["success"] as bool == true) {
      var classMirror = entity.reflectType(T) as ClassMirror;
      List<dynamic> d = jsonData["data"];

      var data =
          d.map((e) => classMirror.newInstance("fromJson", [e]) as T).toList();

      return ListResponseModel(
        jsonData["success"] as bool,
        jsonData["message"] as String,
        data,
        jsonData,
      );
    }

    return ListResponseModel(
      jsonData["success"] as bool,
      jsonData["message"] as String,
      null,
      jsonData,
    );
  }
}
