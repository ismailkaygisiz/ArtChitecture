import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/userOperationClaim/user_operation_claim_add_model.dart';
import 'package:flutter_ui/core/models/userOperationClaim/user_operation_claim_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class UserOperationClaimService extends ServiceRepositoryWithAddModel<
    UserOperationClaimAddModel, UserOperationClaimModel, int> {
  Future<ResponseModel> add(
      UserOperationClaimAddModel userOperationClaimAddModel) async {
    var response = await httpClient.post(
      "useroperationclaims/add",
      body: userOperationClaimAddModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "useroperationclaims/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> update(
      UserOperationClaimModel userOperationClaimModel) async {
    var response = await httpClient.post(
      "useroperationclaims/update",
      body: userOperationClaimModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getAll() async {
    var response = await httpClient.get("useroperationclaims/getall");

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  Future<SingleResponseModel<UserOperationClaimModel>> getById(int id) async {
    var response = await httpClient.get(
      "useroperationclaims/getbyid",
      queryParameters: {"id": id},
    );

    return SingleResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getByUserId(
      int userId) async {
    var response = await httpClient.get(
      "useroperationclaims/getbyuserid",
      queryParameters: {"userId": userId},
    );

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getByClaimId(
      int claimId) async {
    var response = await httpClient.get(
      "useroperationclaims/getbyclaimid",
      queryParameters: {"claimId": claimId},
    );

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }
}
