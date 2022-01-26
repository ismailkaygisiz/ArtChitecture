import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/user/user_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class UserService extends ServiceRepository<UserModel, int> {
  @override
  Future<ResponseModel> add(UserModel addModel) async {
    var response = await httpClient.post(
      "users/add",
      body: addModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "users/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> update(UserModel updateModel) async {
    var response = await httpClient.post(
      "users/update",
      body: updateModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ListResponseModel<UserModel>> getAll() async {
    var response = await httpClient.get("users/getall");

    return ListResponseModel<UserModel>.fromJson(response);
  }

  @override
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
