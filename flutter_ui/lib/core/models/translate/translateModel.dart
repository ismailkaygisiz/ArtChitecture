import 'package:flutter_ui/core/models/entity.dart';

@entity
class TranslateModel {
  int id;
  int languageId;
  String key;
  String value;

  TranslateModel(this.id, this.languageId, this.key, this.value);

  factory TranslateModel.fromJson(Map<String, dynamic> json) {
    return TranslateModel(
      json["id"] as int,
      json["languageId"] as int,
      json["key"] as String,
      json["value"] as String,
    );
  }
}
