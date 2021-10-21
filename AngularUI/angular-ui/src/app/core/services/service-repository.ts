import { ListResponseModel } from '../models/response/listResponseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { DeleteModel } from '../models/deleteModel';
import { Observable } from 'rxjs';
import { Service } from './service';

export interface ServiceRepository<TModel, TId> extends Service {
  add(addModel: TModel): Observable<ResponseModel>;

  // DeleteModel sadece backend tarafında id bazlı silme işlemi varsa tercih edilmedilir.
  delete(deleteModel: DeleteModel): Observable<ResponseModel>;

  update(updateModel: TModel): Observable<ResponseModel>;

  getById(id: TId): Observable<SingleResponseModel<TModel>>;

  getAll(): Observable<ListResponseModel<TModel>>;
}

export interface ServiceRepositoryWithAddModel<TAddModel, TModel, TId>
  extends Service {
  add(addModel: TAddModel): Observable<ResponseModel>;

  // DeleteModel sadece backend tarafında id bazlı silme işlemi varsa tercih edilmedilir.
  delete(deleteModel: DeleteModel): Observable<ResponseModel>;

  update(updateModel: TModel): Observable<ResponseModel>;

  getById(id: TId): Observable<SingleResponseModel<TModel>>;

  getAll(): Observable<ListResponseModel<TModel>>;
}
