import 'dart:convert';

import '../entity.dart';

@entity
class UserAddModel {
  String firstName;
  String lastName;
  String email;
  bool status;

  UserAddModel(this.firstName, this.lastName, this.email, this.status);

  String toJson() {
    return json.encode({
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "status": status,
    });
  }
}
