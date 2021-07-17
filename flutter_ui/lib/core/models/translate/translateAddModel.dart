import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class TranslateAddModel {
  int languageId;
  String key;
  String value;

  TranslateAddModel(this.languageId, this.key, this.value);

  String toJson() {
    return json.encode({
      "languageId": languageId,
      "key": key,
      "value": value,
    });
  }
}
