import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';

abstract class ServiceRepository<TModel, TId> {
  Future<ResponseModel> add(TModel addModel);

  Future<ResponseModel> delete(DeleteModel deleteModel);

  Future<ResponseModel> update(TModel updateModel);

  Future<ListResponseModel<TModel>> getAll();

  Future<SingleResponseModel<TModel>> getById(TId id);
}
