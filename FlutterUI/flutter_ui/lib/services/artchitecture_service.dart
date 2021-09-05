import 'package:flutter_ui/core/models/delete_model.dart';
import 'package:flutter_ui/core/models/response/list_response_model.dart';
import 'package:flutter_ui/core/models/response/response_model.dart';
import 'package:flutter_ui/core/models/response/single_response_model.dart';
import 'package:flutter_ui/core/utilities/service_repository.dart';
import 'package:flutter_ui/models/artchitecture_entity_model.dart';

class ArtChitectureService extends ServiceRepository<ArtChitectureModel> {
  /// This is a custom service for ArtChitecture
  ArtChitectureService();

  @override
  Future<ResponseModel> add(ArtChitectureModel addModel) {
    throw UnimplementedError();
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) {
    throw UnimplementedError();
  }

  @override
  Future<ListResponseModel<ArtChitectureModel>> getAll() {
    throw UnimplementedError();
  }

  @override
  Future<SingleResponseModel<ArtChitectureModel>> getById(int id) {
    throw UnimplementedError();
  }

  @override
  Future<ResponseModel> update(ArtChitectureModel updateModel) {
    throw UnimplementedError();
  }
}
