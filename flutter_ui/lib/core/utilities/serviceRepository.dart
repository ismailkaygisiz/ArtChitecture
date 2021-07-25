import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/operationClaim/operationClaimAddModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';

abstract class ServiceRepository<TAddModel, TModel> {
  Future<ResponseModel> add(TAddModel addModel);

  Future<ResponseModel> delete(DeleteModel deleteModel);

  Future<ResponseModel> update(TModel updateModel);

  Future<ListResponseModel<TModel>> getAll();

  Future<SingleResponseModel<TModel>> getById(int id);
}
