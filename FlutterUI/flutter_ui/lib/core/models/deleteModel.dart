import 'dart:convert';

class DeleteModel {
  int id;

  DeleteModel(this.id);
  String toJson() {
    return json.encode({
      "id": id,
    });
  }
}
