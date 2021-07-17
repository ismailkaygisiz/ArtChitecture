import 'dart:convert';

import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/userOperationClaim/userOperationClaimAddModel.dart';
import 'package:flutter_ui/core/models/userOperationClaim/userOperationClaimModel.dart';
import 'package:flutter_ui/core/services/service.dart';
import 'package:flutter_ui/core/services/serviceRepository.dart';
import 'package:flutter_ui/environments/api.dart';

class UserOperationClaimService extends Service
    with
        ServiceRepository<UserOperationClaimAddModel, UserOperationClaimModel> {
  Future<ResponseModel> add(
      UserOperationClaimAddModel userOperationClaimAddModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "useroperationclaims/add"),
      body: userOperationClaimAddModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "useroperationclaims/delete"),
      body: deleteModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ResponseModel> update(
      UserOperationClaimModel userOperationClaimModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "useroperationclaims/update"),
      body: userOperationClaimModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "useroperationclaims/getall"),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<UserOperationClaimModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<UserOperationClaimModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "useroperationclaims/getbyid?id=" + id.toString()),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<UserOperationClaimModel>.fromJson(jsonData);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getByUserId(
      int userId) async {
    var response = await httpClient.get(
      Uri.parse(API_URL +
          "useroperationclaims/getbyuserid?userId=" +
          userId.toString()),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<UserOperationClaimModel>.fromJson(jsonData);
  }

  Future<ListResponseModel<UserOperationClaimModel>> getByClaimId(
      int claimId) async {
    var response = await httpClient.get(
      Uri.parse(API_URL +
          "useroperationclaims/getbyclaimid?claimId=" +
          claimId.toString()),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<UserOperationClaimModel>.fromJson(jsonData);
  }
}
