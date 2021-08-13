import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimDetailsModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/user/userAddModel.dart';
import 'package:flutter_ui/core/models/user/userModel.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/core/utilities/serviceRepository.dart';
import 'package:flutter_ui/environments/api.dart';
import '../utilities/service.dart';

class UserService extends Service
    with ServiceRepository<UserAddModel, UserModel> {
  Future<ResponseModel> add(UserAddModel userAddModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "users/add"),
      body: userAddModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "users/delete"),
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> update(UserModel userModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "users/update"),
      body: userModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<UserModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "users/getall"),
    );

    return ListResponseModel<UserModel>.fromJson(response);
  }

  Future<SingleResponseModel<UserModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "users/getbyid?id=" + id.toString()),
    );

    return SingleResponseModel<UserModel>.fromJson(response);
  }

  Future<SingleResponseModel<UserModel>> getByEmail(String email) async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "users/getbymail?email=" + email),
    );

    return SingleResponseModel<UserModel>.fromJson(response);
  }

  Future<ListResponseModel<UserModel>> getByFirstName(String firstName) async {
    var response = await httpClient.get(
      Uri.parse(
          Environments.API_URL + "users/getbyfirstname?firstName=" + firstName),
    );

    return ListResponseModel<UserModel>.fromJson(response);
  }

  Future<ListResponseModel<UserModel>> getByLastName(String lastName) async {
    var response = await httpClient.get(
      Uri.parse(
          Environments.API_URL + "users/getbylastname?lastName=" + lastName),
    );

    return ListResponseModel<UserModel>.fromJson(response);
  }

  Future<SingleResponseModel<OperationClaimDetailsModel>> getClaims(
      int id) async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "users/getclaims?id=" + id.toString()),
    );

    return SingleResponseModel<OperationClaimDetailsModel>.fromJson(response);
  }
}
