import { SingleResponseModel } from './../models/response/singleResponseModel';
import { apiUrl } from './../../../api';
import { ResponseModel } from './../models/response/responseModel';
import { LanguageAddModel } from './../models/language/languageAddModel';
import { Service } from './service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LanguageModel } from '../models/language/languageModel';
import { Observable } from 'rxjs';
import { DeleteModel } from '../models/deleteModel';
import { ListResponseModel } from '../models/response/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class LanguageService
  implements Service<LanguageAddModel, LanguageModel>
{
  constructor(private httpClient: HttpClient) {}

  add(addModel: LanguageAddModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'languages/add';
    return this.httpClient.post<ResponseModel>(newPath, addModel);
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'languages/delete';
    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  update(updateModel: LanguageModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'languages/update';
    return this.httpClient.post<ResponseModel>(newPath, updateModel);
  }

  getById(id: number): Observable<SingleResponseModel<LanguageModel>> {
    let newPath = apiUrl + 'languages/getbyid?id=' + id;
    return this.httpClient.get<SingleResponseModel<LanguageModel>>(newPath);
  }

  getAll(): Observable<ListResponseModel<LanguageModel>> {
    let newPath = apiUrl + 'languages/getall';
    return this.httpClient.get<ListResponseModel<LanguageModel>>(newPath);
  }
}
