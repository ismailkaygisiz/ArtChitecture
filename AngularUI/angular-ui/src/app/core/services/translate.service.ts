import { TranslateModel } from './../models/translate/translateModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { apiUrl } from 'src/api';
import { ServiceRepository } from './service-repository';
import { DeleteModel } from '../models/deleteModel';

@Injectable({
  providedIn: 'root',
})
export class TranslateService
  implements ServiceRepository<TranslateModel, number>
{
  constructor(private httpClient: HttpClient) {}

  add(addModel: TranslateModel): Observable<ResponseModel> {
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

  getByKey(key: string): Observable<ListResponseModel<TranslateModel>> {
    let newPath = apiUrl + 'translates/getbykey?key=' + key;
    return this.httpClient.get<ListResponseModel<TranslateModel>>(newPath);
  }

  getByLanguageId(
    languageId: number
  ): Observable<ListResponseModel<TranslateModel>> {
    let newPath =
      apiUrl + 'translates/getbylanguageid?languageId=' + languageId;
    return this.httpClient.get<ListResponseModel<TranslateModel>>(newPath);
  }

  getTranslates(languageCode: string): Observable<SingleResponseModel<any>> {
    let newPath =
      apiUrl + 'translates/gettranslates?languageCode=' + languageCode;
    return this.httpClient.get<SingleResponseModel<any>>(newPath);
  }
}
