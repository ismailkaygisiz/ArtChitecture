import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class UserOperationClaimAddModel {
  int userId;
  int claimId;

  UserOperationClaimAddModel(this.userId, this.claimId);

  String toJson() {
    return json.encode({
      "userId": userId,
      "claimId": claimId,
    });
  }
}
