import { TranslateModel } from './../models/translate/translateModel';
import { Service } from './service';
import { LocalStorageService } from './local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TranslateAddModel } from '../models/translate/translateAddModel';
import { Observable } from 'rxjs';
import { DeleteModel } from '../models/deleteModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { apiUrl } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class TranslateService
  implements Service<TranslateAddModel, TranslateModel>
{
  constructor(
    private httpClient: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  add(addModel: TranslateAddModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'translates/add';
    return this.httpClient.post<ResponseModel>(newPath, addModel);
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'translates/delete';
    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  update(updateModel: TranslateModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'translates/update';
    return this.httpClient.post<ResponseModel>(newPath, updateModel);
  }

  getById(id: number): Observable<SingleResponseModel<TranslateModel>> {
    let newPath = apiUrl + 'translates/getbyid?id=' + id;
    return this.httpClient.get<SingleResponseModel<TranslateModel>>(newPath);
  }

  getAll(): Observable<ListResponseModel<TranslateModel>> {
    let newPath = apiUrl + 'translates/getall';
    return this.httpClient.get<ListResponseModel<TranslateModel>>(newPath);
  }
}
