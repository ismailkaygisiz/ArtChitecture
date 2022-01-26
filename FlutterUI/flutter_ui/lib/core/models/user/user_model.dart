import 'dart:convert';

import '../entity.dart';

@entity
class UserModel {
  int? id;
  String? email;
  bool? status;

  UserModel(this.id, this.email, this.status);

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      json["id"] as int?,
      json["email"] as String?,
      json["status"] as bool?,
    );
  }

  String toJson() {
    return json.encode({
      "id": id,
      "email": email,
      "status": status,
    });
  }
}
