import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/user/user_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class UserService extends ServiceRepository<UserModel, int> {
  Future<ResponseModel> add(UserModel userAddModel) async {
    var response = await httpClient.post(
      "users/add",
      body: userAddModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "users/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ResponseModel> update(UserModel userModel) async {
    var response = await httpClient.post(
      "users/update",
      body: userModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<UserModel>> getAll() async {
    var response = await httpClient.get("users/getall");

    return ListResponseModel<UserModel>.fromJson(response);
  }

  Future<SingleResponseModel<UserModel>> getById(int id) async {
    var response = await httpClient.get(
      "users/getbyid",
      queryParameters: {"id": id},
    );

    return SingleResponseModel<UserModel>.fromJson(response);
  }

  Future<SingleResponseModel<UserModel>> getByEmail(String email) async {
    var response = await httpClient.get(
      "users/getbymail",
      queryParameters: {"email": email},
    );

    return SingleResponseModel<UserModel>.fromJson(response);
  }
}
