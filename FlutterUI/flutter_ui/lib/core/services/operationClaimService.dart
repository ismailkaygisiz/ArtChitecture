import 'dart:convert';
import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimAddModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/core/utilities/serviceRepository.dart';
import 'package:flutter_ui/environments/api.dart';

class OperationClaimService extends Service
    with ServiceRepository<OperationClaimAddModel, OperationClaimModel> {
  Future<ResponseModel> add(
      OperationClaimAddModel operationClaimAddModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "operationclaims/add"),
      body: operationClaimAddModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "operationclaims/delete"),
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> update(OperationClaimModel operationClaimModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "operationclaims/update"),
      body: operationClaimModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<OperationClaimModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "operationclaims/getall"),
    );

    return ListResponseModel<OperationClaimModel>.fromJson(response);
  }

  Future<SingleResponseModel<OperationClaimModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(
          Environments.API_URL + "operationclaims/getbyid?id=" + id.toString()),
    );

    return SingleResponseModel<OperationClaimModel>.fromJson(response);
  }

  Future<SingleResponseModel<OperationClaimModel>> getByName(
      String name) async {
    var response = await httpClient.get(Uri.parse(
        Environments.API_URL + "operationclaims/getbyname?name=" + name));

    return SingleResponseModel<OperationClaimModel>.fromJson(response);
  }
}
