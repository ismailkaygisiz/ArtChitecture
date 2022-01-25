import 'dart:convert';

class DeleteModel {
  int? id;
  String? uuid;

  DeleteModel(this.id);

  String toJson() {
    return json.encode({
      "id": id,
      "uuid": uuid,
    });
  }
}
