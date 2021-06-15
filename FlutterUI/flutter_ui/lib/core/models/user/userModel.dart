import 'dart:convert';

import '../entity.dart';

@entity
class UserModel {
  int id;
  String firstName;
  String lastName;
  String email;
  bool status;

  UserModel(this.id, this.firstName, this.lastName, this.email, this.status);

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      json["id"] as int,
      json["firstName"] as String,
      json["lastName"] as String,
      json["email"] as String,
      json["status"] as bool,
    );
  }

  String toJson() {
    return json.encode({
      "id": id,
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "status": status,
    });
  }
}
