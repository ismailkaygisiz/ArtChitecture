import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/language/language_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class LanguageService extends ServiceRepository<LanguageModel, int> {
  @override
  Future<ResponseModel> add(LanguageModel addModel) async {
    var response = await httpClient.post(
      "languages/add",
      body: addModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "languages/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ListResponseModel<LanguageModel>> getAll() async {
    var response = await httpClient.get("languages/getall");

    return ListResponseModel<LanguageModel>.fromJson(response);
  }

  @override
  Future<SingleResponseModel<LanguageModel>> getById(int id) async {
    var response = await httpClient.get(
      "languages/getbyid",
      queryParameters: {"id": id},
    );

    return SingleResponseModel<LanguageModel>.fromJson(response);
  }

  Future<SingleResponseModel<LanguageModel>> getByName(String name) async {
    var response = await httpClient.get(
      "languages/getbyname",
      queryParameters: {"name": name},
    );

    return SingleResponseModel<LanguageModel>.fromJson(response);
  }

  Future<SingleResponseModel<LanguageModel>> getByCode(String code) async {
    var response = await httpClient.get(
      "languages/getbycode",
      queryParameters: {"code": code},
    );

    return SingleResponseModel<LanguageModel>.fromJson(response);
  }

  @override
  Future<ResponseModel> update(LanguageModel updateModel) async {
    var response = await httpClient.post(
      "languages/update",
      body: updateModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }
}
