import 'dart:convert';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class UserOperationClaimModel {
  int id;
  int userId;
  int claimId;

  UserOperationClaimModel(this.id, this.userId, this.claimId);

  factory UserOperationClaimModel.fromJson(Map<String, dynamic> json) {
    return UserOperationClaimModel(
      json["id"] as int,
      json["userId"] as int,
      json["claimId"] as int,
    );
  }

  String toJson() {
    return json.encode({
      "id": id,
      "userId": userId,
      "claimId": claimId,
    });
  }
}
