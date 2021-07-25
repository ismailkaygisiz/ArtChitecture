import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class OperationClaimAddModel {
  String name;

  OperationClaimAddModel(this.name);

  String toJson() {
    return json.encode({
      "name": name,
    });
  }
}
