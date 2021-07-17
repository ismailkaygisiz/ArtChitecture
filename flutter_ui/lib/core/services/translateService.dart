import 'dart:collection';
import 'dart:convert';

import 'package:flutter_ui/core/interceptors/authInterceptor.dart';
import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/models/translate/translateAddModel.dart';
import 'package:flutter_ui/core/models/translate/translateModel.dart';
import 'package:flutter_ui/core/services/service.dart';
import 'package:flutter_ui/core/services/serviceRepository.dart';
import 'package:flutter_ui/core/utilities/dictionary.dart';
import 'package:flutter_ui/environments/api.dart';

class TranslateService extends Service
    with ServiceRepository<TranslateAddModel, TranslateModel> {
  @override
  Future<ResponseModel> add(TranslateAddModel addModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "translates/add"),
      body: addModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "translates/delete"),
      body: deleteModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  @override
  Future<ListResponseModel<TranslateModel>> getAll() async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "translates/getall"),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<TranslateModel>.fromJson(jsonData);
  }

  @override
  Future<SingleResponseModel<TranslateModel>> getById(int id) async {
    var response = await httpClient.get(
      Uri.parse(
        API_URL + "translates/getbyid?id=" + id.toString(),
      ),
    );

    var jsonData = json.decode(response.body);
    return SingleResponseModel<TranslateModel>.fromJson(jsonData);
  }

  @override
  Future<ResponseModel> update(TranslateModel updateModel) async {
    var response = await httpClient.post(
      Uri.parse(API_URL + "translates/add"),
      body: updateModel.toJson(),
    );

    var jsonData = json.decode(response.body);
    return ResponseModel.fromJson(jsonData);
  }

  Future<ListResponseModel<TranslateModel>> getByKey(String key) async {
    var response = await httpClient.get(
      Uri.parse(API_URL + "translates/getbykey?key=" + key),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<TranslateModel>.fromJson(jsonData);
  }

  Future<ListResponseModel<TranslateModel>> getByLanguageId(
      int languageId) async {
    var response = await httpClient.get(
      Uri.parse(API_URL +
          "translates/getbylanguageid?languageId=" +
          languageId.toString()),
    );

    var jsonData = json.decode(response.body);
    return ListResponseModel<TranslateModel>.fromJson(jsonData);
  }

  Future<Map> getTranslates(String languageCode) async {
    var response = await httpClient.get(
      Uri.parse(
          API_URL + "translates/gettranslates?languageCode=" + languageCode),
    );

    var jsonData = json.decode(response.body);
    return Map.from(jsonData);
  }
}
