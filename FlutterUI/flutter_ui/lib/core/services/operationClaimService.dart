import 'dart:convert';
import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimAddModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/services/service.dart';

class OperationClaimService extends Service {
  var http = AuthInterceptor();

  Future<ResponseModel> add(
      OperationClaimAddModel operationClaimAddModel) async {
    var response = await http.post(
      Uri.parse(API_URL + "operationclaims/add"),
      body: operationClaimAddModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await http.post(
      Uri.parse(API_URL + "operationclaims/delete"),
      body: deleteModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ResponseModel> update(OperationClaimModel operationClaimModel) async {
    var response = await http.post(
      Uri.parse(API_URL + "operationclaims/update"),
      body: operationClaimModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ListResponseModel<OperationClaimModel>> getAll() async {
    var response = await http.get(
      Uri.parse(API_URL + "operationclaims/getall"),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<OperationClaimModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<OperationClaimModel>> getById(int id) async {
    var response = await http.get(
      Uri.parse(API_URL + "operationclaims/getbyid?id=" + id.toString()),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<OperationClaimModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<OperationClaimModel>> getByName(
      String name) async {
    var response = await http
        .get(Uri.parse(API_URL + "operationclaims/getbyname?name=" + name));

    var jsonData = json.decode(response.body);
    return SingleResponseModel<OperationClaimModel>.fromJson(jsonData);
  }
}
