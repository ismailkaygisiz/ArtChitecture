import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/language/languageAddModel.dart';
import 'package:flutter_ui/core/models/language/languageModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/core/utilities/serviceRepository.dart';
import 'package:flutter_ui/environments/api.dart';

class LanguageService extends Service
    with ServiceRepository<LanguageAddModel, LanguageModel> {
  @override
  Future<ResponseModel> add(LanguageAddModel addModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "languages/add"),
      body: addModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "languages/delete"),
      body: deleteModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }

  @override
  Future<ListResponseModel<LanguageModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(Environments.API_URL + "languages/getall"),
    );

    return ListResponseModel<LanguageModel>.fromJson(response);
  }

  @override
  Future<SingleResponseModel<LanguageModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(
        Environments.API_URL + "languages/getbyid?id=" + id.toString(),
      ),
    );

    return SingleResponseModel<LanguageModel>.fromJson(response);
  }

  Future<SingleResponseModel<LanguageModel>> getByName(String name) async {
    var response = await httpClient.get(
      Uri.parse(
        Environments.API_URL + "languages/getbyname?name=" + name,
      ),
    );

    return SingleResponseModel<LanguageModel>.fromJson(response);
  }

  Future<SingleResponseModel<LanguageModel>> getByCode(String code) async {
    var response = await httpClient.get(
      Uri.parse(
        Environments.API_URL + "languages/getbycode?code=" + code,
      ),
    );

    return SingleResponseModel<LanguageModel>.fromJson(response);
  }

  @override
  Future<ResponseModel> update(LanguageModel updateModel) async {
    var response = await httpClient.post(
      Uri.parse(Environments.API_URL + "languages/update"),
      body: updateModel.toJson(),
    );

    return ResponseModel.fromJson(response);
  }
}
