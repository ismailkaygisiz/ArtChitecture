class ResponseModel {
  bool success;
  String message;

  ResponseModel(this.success, this.message);

  factory ResponseModel.fromJson(Map<String, dynamic> json) {
    return ResponseModel(json["success"] as bool, json["message"] as String);
  }
}
