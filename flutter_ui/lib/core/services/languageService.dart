import 'dart:convert';

import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/language/languageAddModel.dart';
import 'package:flutter_ui/core/models/language/languageModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/services/service.dart';
import 'package:flutter_ui/core/services/serviceRepository.dart';
import 'package:flutter_ui/environments/api.dart';

class LanguageService extends Service
    with ServiceRepository<LanguageAddModel, LanguageModel> {
  @override
  Future<ResponseModel> add(LanguageAddModel addModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "languages/add"),
      body: addModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "languages/delete"),
      body: deleteModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  @override
  Future<ListResponseModel<LanguageModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "languages/getall"),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<LanguageModel>.fromJson(jsonData);
  }

  @override
  Future<SingleResponseModel<LanguageModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(
        API_URL + "languages/getbyid?id=" + id.toString(),
      ),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<LanguageModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<LanguageModel>> getByName(String name) async {
    var response = await httpClient.get(
      Uri.parse(
        API_URL + "languages/getbyname?name=" + name,
      ),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<LanguageModel>.fromJson(jsonData);
  }

  Future<SingleResponseModel<LanguageModel>> getByCode(String code) async {
    var response = await httpClient.get(
      Uri.parse(
        API_URL + "languages/getbycode?code=" + code,
      ),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<LanguageModel>.fromJson(jsonData);
  }

  @override
  Future<ResponseModel> update(LanguageModel updateModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "languages/update"),
      body: updateModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }
}
