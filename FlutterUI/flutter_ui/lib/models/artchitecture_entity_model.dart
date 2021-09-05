import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class ArtChitectureModel {
  /// This is a custom entity model for ArtChitecture
  ArtChitectureModel();

  factory ArtChitectureModel.fromJson(Map<String, dynamic> json) {
    return ArtChitectureModel();
  }

  String toJson() {
    return json.encode({});
  }
}
