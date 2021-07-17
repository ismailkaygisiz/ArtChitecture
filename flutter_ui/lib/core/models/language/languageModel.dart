import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class LanguageModel {
  int id;
  String languageCode;
  String languageName;

  LanguageModel(this.id, this.languageCode, this.languageName);

  factory LanguageModel.fromJson(Map<String, dynamic> json) {
    return LanguageModel(json["id"] as int, json["languageCode"] as String,
        json["languageName"] as String);
  }

  String toJson() {
    return json.encode({
      "id": id,
      "languageCode": languageCode,
      "languageName": languageName,
    });
  }
}
