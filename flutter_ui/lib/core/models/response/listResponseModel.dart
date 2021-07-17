import 'package:reflectable/reflectable.dart';

import '../entity.dart';

class ListResponseModel<T> {
  bool success;
  String message;
  List<T> data;

  ListResponseModel(this.success, this.message, this.data);

  factory ListResponseModel.fromJson(Map<String, dynamic> json) {
    var classMirror = entity.reflectType(T) as ClassMirror;
    List<dynamic> d = json["data"];

    var data =
        d.map((e) => classMirror.newInstance("fromJson", [e]) as T).toList();

    return ListResponseModel(
      json["success"] as bool,
      json["message"].toString(),
      data,
    );
  }
}
