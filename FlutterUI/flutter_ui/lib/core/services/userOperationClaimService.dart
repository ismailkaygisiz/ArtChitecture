import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/userOperationClaim/userOperationClaimAddModel.dart';
import 'package:flutter_ui/core/models/userOperationClaim/userOperationClaimModel.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/core/utilities/serviceRepository.dart';
import 'package:flutter_ui/environments/api.dart';

class UserOperationClaimService extends Service
    with
        ServiceRepository<UserOperationClaimAddModel, UserOperationClaimModel> {
  Future<ResponseModel> add(
      UserOperationClaimAddModel userOperationClaimAddModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "useroperationclaims/add"),
      body: userOperationClaimAddModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "useroperationclaims/delete"),
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> update(
      UserOperationClaimModel userOperationClaimModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "useroperationclaims/update"),
      body: userOperationClaimModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "useroperationclaims/getall"),
    );

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  Future<SingleResponseModel<UserOperationClaimModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL +
          "useroperationclaims/getbyid?id=" +
          id.toString()),
    );

    return SingleResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getByUserId(
      int userId) async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL +
          "useroperationclaims/getbyuserid?userId=" +
          userId.toString()),
    );

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getByClaimId(
      int claimId) async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL +
          "useroperationclaims/getbyclaimid?claimId=" +
          claimId.toString()),
    );

    return ListResponseModel<UserOperationClaimModel>.fromJson(response);
  }
}
