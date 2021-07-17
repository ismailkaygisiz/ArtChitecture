import 'dart:convert';
import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimDetailsModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/user/userAddModel.dart';
import 'package:flutter_ui/core/models/user/userModel.dart';
import 'package:flutter_ui/environments/api.dart';
import 'service.dart';

class UserService extends Service {
  Future<ResponseModel> add(UserAddModel userAddModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "users/add"),
      body: userAddModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "users/delete"),
      body: deleteModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ResponseModel> update(UserModel userModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "users/update"),
      body: userModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ListResponseModel<UserModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "users/getall"),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<UserModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<UserModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "users/getbyid?id=" + id.toString()),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<UserModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<UserModel>> getByEmail(String email) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "users/getbymail?email=" + email),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<UserModel>.fromJson(jsonData);
  }

  Future<ListResponseModel<UserModel>> getByFirstName(String firstName) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "users/getbyfirstname?firstName=" + firstName),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<UserModel>.fromJson(jsonData);
  }

  Future<ListResponseModel<UserModel>> getByLastName(String lastName) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "users/getbylastname?lastName=" + lastName),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<UserModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<OperationClaimDetailsModel>> getClaims(
      int id) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "users/getclaims?id=" + id.toString()),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<OperationClaimDetailsModel>.fromJson(jsonData);
  }
}
