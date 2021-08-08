import { ListResponseModel } from './../models/response/listResponseModel';
import { SingleResponseModel } from './../models/response/singleResponseModel';
import { ResponseModel } from './../models/response/responseModel';
import { DeleteModel } from './../models/deleteModel';
import { Observable } from 'rxjs';

export interface Service<TAddModel, TModel> {
  add(addModel: TAddModel): Observable<ResponseModel>;

  // DeleteModel sadece backend tarafında id bazlı silme işlemi varsa tercih edilmedilir.
  delete(deleteModel: DeleteModel): Observable<ResponseModel>;

  update(updateModel: TModel): Observable<ResponseModel>;

  getById(id: number): Observable<SingleResponseModel<TModel>>;

  getAll(): Observable<ListResponseModel<TModel>>;
}
