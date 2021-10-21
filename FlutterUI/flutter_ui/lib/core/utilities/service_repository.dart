import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/utilities/service.dart';

abstract class ServiceRepository<TModel, TId> extends Service {
  Future<ResponseModel> add(TModel addModel);

  Future<ResponseModel> delete(DeleteModel deleteModel);

  Future<ResponseModel> update(TModel updateModel);

  Future<ListResponseModel<TModel>> getAll();

  Future<SingleResponseModel<TModel>> getById(TId id);
}

abstract class ServiceRepositoryWithAddModel<TAddModel, TModel, TId>
    extends Service {
  Future<ResponseModel> add(TAddModel addModel);

  Future<ResponseModel> delete(DeleteModel deleteModel);

  Future<ResponseModel> update(TModel updateModel);

  Future<ListResponseModel<TModel>> getAll();

  Future<SingleResponseModel<TModel>> getById(TId id);
}
