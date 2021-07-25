import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class LanguageAddModel {
  String languageCode;
  String languageName;

  LanguageAddModel(this.languageCode, this.languageName);

  String toJson() {
    return json.encode({
      "languageCode": languageCode,
      "languageName": languageName,
    });
  }
}
