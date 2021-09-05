import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class OperationClaimModel {
  int? id;
  String? name;

  OperationClaimModel(this.id, this.name);

  factory OperationClaimModel.fromJson(Map<String, dynamic> json) {
    return OperationClaimModel(
      json["id"] as int?,
      json["name"] as String?,
    );
  }

  String toJson() {
    return json.encode({
      "id": id,
      "name": name,
    });
  }
}
