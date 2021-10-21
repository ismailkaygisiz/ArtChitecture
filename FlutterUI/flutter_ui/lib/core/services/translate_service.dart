import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/models/translate/translate_add_model.dart';
import 'package:flutter_ui/core/models/translate/translate_model.dart';
import 'package:flutter_ui/core/utilities/dependency_resolver.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';

class TranslateService extends ServiceRepositoryWithAddModel<TranslateAddModel,
    TranslateModel, int> {
  @override
  Future<ResponseModel> add(TranslateAddModel addModel) async {
    var response = await httpClient.post(
      "translates/add",
      body: addModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      "translates/delete",
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ListResponseModel<TranslateModel>> getAll() async {
    var response = await httpClient.get("translates/getall");

    return ListResponseModel<TranslateModel>.fromJson(response);
  }

  @override
  Future<SingleResponseModel<TranslateModel>> getById(int id) async {
    var response = await httpClient.get(
      "translates/getbyid",
      queryParameters: {"id": id},
    );

    return SingleResponseModel<TranslateModel>.fromJson(response);
  }

  @override
  Future<ResponseModel> update(TranslateModel updateModel) async {
    var response = await httpClient.post(
      "translates/update",
      body: updateModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  Future<ListResponseModel<TranslateModel>> getByKey(String key) async {
    var response = await httpClient.get(
      "translates/getbykey",
      queryParameters: {"key": key},
    );

    return ListResponseModel<TranslateModel>.fromJson(response);
  }

  Future<ListResponseModel<TranslateModel>> getByLanguageId(
      int languageId) async {
    var response = await httpClient.get(
      "translates/getbylanguageid",
      queryParameters: {"languageId": languageId},
    );

    return ListResponseModel<TranslateModel>.fromJson(response);
  }

  Future<Map?> getTranslates(String? languageCode) async {
    var response = await httpClient.get(
      "translates/gettranslates",
      queryParameters: {"languageCode": languageCode},
    );

    return response?.data;
  }
}
