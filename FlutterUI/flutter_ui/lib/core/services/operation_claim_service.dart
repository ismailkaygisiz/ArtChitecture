import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/operationClaim/operation_claim_add_model.dart';
import 'package:flutter_ui/core/models/operationClaim/operation_claim_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class OperationClaimService extends ServiceRepositoryWithAddModel<
    OperationClaimAddModel, OperationClaimModel> {
  Future<ResponseModel> add(
      OperationClaimAddModel operationClaimAddModel) async {
    var response = await httpClient.post(
      "operationclaims/add",
      body: operationClaimAddModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "operationclaims/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> update(OperationClaimModel operationClaimModel) async {
    var response = await httpClient.post(
      "operationclaims/update",
      body: operationClaimModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<OperationClaimModel>> getAll() async {
    var response = await httpClient.get(
      "operationclaims/getall",
    );

    return ListResponseModel<OperationClaimModel>.fromJson(response);
  }

  Future<SingleResponseModel<OperationClaimModel>> getById(int id) async {
    var response = await httpClient.get(
      "operationclaims/getbyid",
      queryParameters: {"id": id},
    );

    return SingleResponseModel<OperationClaimModel>.fromJson(response);
  }

  Future<SingleResponseModel<OperationClaimModel>> getByName(
      String name) async {
    var response = await httpClient.get(
      "operationclaims/getbyname",
      queryParameters: {"name": name},
    );

    return SingleResponseModel<OperationClaimModel>.fromJson(response);
  }
}
