import 'package:reflectable/reflectable.dart';
import '../entity.dart';

class SingleResponseModel<T> {
  bool success;
  String message;
  T data;

  SingleResponseModel(this.success, this.message, this.data);

  factory SingleResponseModel.fromJson(Map<String, dynamic> json) {
    var classMirror = entity.reflectType(T) as ClassMirror;

    dynamic d = json["data"];

    var data = classMirror.newInstance("fromJson", [d]) as T;
    return SingleResponseModel(
      json["success"] as bool,
      json["message"].toString(),
      data,
    );
  }
}
