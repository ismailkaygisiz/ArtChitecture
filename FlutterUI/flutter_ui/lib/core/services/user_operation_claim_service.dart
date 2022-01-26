import 'package:flutter_ui/core/interceptors/http_client.dart';
import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/userOperationClaim/user_operation_claim_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';
import 'package:get/get.dart';

class UserOperationClaimService
    extends ServiceRepository<UserOperationClaimModel, int> {
  @override
  Future<ResponseModel> add(UserOperationClaimModel addModel) async {
    var response = await httpClient.post(
      "useroperationclaims/add",
      body: addModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "useroperationclaims/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> update(UserOperationClaimModel updateModel) async {
    var response = await httpClient.post(
      "useroperationclaims/update",
      body: updateModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ListResponseModel<UserOperationClaimModel>> getAll() async {
    var response = await httpClient.get("useroperationclaims/getall");

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  @override
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
