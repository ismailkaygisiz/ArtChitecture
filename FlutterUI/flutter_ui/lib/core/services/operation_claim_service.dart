import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/operationClaim/operation_claim_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class OperationClaimService
    extends ServiceRepository<OperationClaimModel, int> {
  @override
  Future<ResponseModel> add(OperationClaimModel addModel) async {
    var response = await httpClient.post(
      "operationclaims/add",
      body: addModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "operationclaims/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> update(OperationClaimModel updateModel) async {
    var response = await httpClient.post(
      "operationclaims/update",
      body: updateModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ListResponseModel<OperationClaimModel>> getAll() async {
    var response = await httpClient.get(
      "operationclaims/getall",
    );

    return ListResponseModel<OperationClaimModel>.fromJson(response);
  }

  @override
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
