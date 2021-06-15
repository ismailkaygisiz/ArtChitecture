import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class UserOperationClaimModel {
  int id;
  int userId;
  int claimId;

  UserOperationClaimModel(this.id, this.userId, this.claimId);

  String toJson() {
    return json.encode({
      "id": id,
      "userId": userId,
      "claimId": claimId,
    });
  }
}
