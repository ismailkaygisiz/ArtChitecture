import 'package:flutter_ui/core/models/deleteModel.dart';
import 'package:flutter_ui/core/models/response/listResponseModel.dart';
import 'package:flutter_ui/core/models/response/responseModel.dart';
import 'package:flutter_ui/core/models/response/singleResponseModel.dart';
import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/core/utilities/serviceRepository.dart';
import 'package:flutter_ui/models/artChitectureEntityModel.dart';

class ArtChitectureService extends Service
    with ServiceRepository<ArtChitectureModel, ArtChitectureModel> {
  /// This is a custom service for ArtChitecture
  ArtChitectureService();

  @override
  Future<ResponseModel> add(ArtChitectureModel addModel) {
    // TODO: implement add
    throw UnimplementedError();
  }

  @override
  Future<ResponseModel> delete(DeleteModel deleteModel) {
    // TODO: implement delete
    throw UnimplementedError();
  }

  @override
  Future<ListResponseModel<ArtChitectureModel>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<SingleResponseModel<ArtChitectureModel>> getById(int id) {
    // TODO: implement getById
    throw UnimplementedError();
  }

  @override
  Future<ResponseModel> update(ArtChitectureModel updateModel) {
    // TODO: implement update
    throw UnimplementedError();
  }
}
