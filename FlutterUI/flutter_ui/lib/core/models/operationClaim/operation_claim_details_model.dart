import 'package:flutter_ui/core/models/entity.dart';
import 'package:flutter_ui/core/models/operationClaim/operation_claim_model.dart';

@entity
class OperationClaimDetailsModel {
  int? id;
  List<OperationClaimModel>? claims;
  String? firstName;
  String? lastName;
  String? email;

  OperationClaimDetailsModel(
      this.id, this.claims, this.firstName, this.lastName, this.email);

  factory OperationClaimDetailsModel.fromJson(Map<String, dynamic> json) {
    List<dynamic>? c = json["claims"] as List?;
    var _claims = c?.map((e) => OperationClaimModel.fromJson(e)).toList();

    return OperationClaimDetailsModel(
        json["id"] as int?,
        _claims,
        json["firstName"] as String?,
        json["lastName"] as String?,
        json["email"] as String?);
  }
}
