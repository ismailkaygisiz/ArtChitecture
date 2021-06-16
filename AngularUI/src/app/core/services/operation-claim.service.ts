import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { OperationClaimAddModel } from '../models/operation-claim/operationClaimAddModel';
import { OperationClaimModel } from '../models/operation-claim/operationClaimModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';

@Injectable({
  providedIn: 'root'
})
export class OperationClaimService {
  constructor(private httpClient: HttpClient) {}

  add(
    operationClaimAddModel: OperationClaimAddModel
  ): Observable<ResponseModel> {
    let newPath = apiUrl + 'operationclaims/add';
    return this.httpClient.post<ResponseModel>(newPath, operationClaimAddModel);
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'operationclaims/delete';
    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  update(operationClaimModel: OperationClaimModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'operationclaims/update';
    return this.httpClient.post<ResponseModel>(newPath, operationClaimModel);
  }

  getAll(): Observable<ListResponseModel<OperationClaimModel>> {
    let newPath = apiUrl + 'operationclaims/getall';
    return this.httpClient.get<ListResponseModel<OperationClaimModel>>(newPath);
  }

  getById(id: number): Observable<SingleResponseModel<OperationClaimModel>> {
    let newPath = apiUrl + 'operationclaims/getbyid?id=' + id;
    return this.httpClient.get<SingleResponseModel<OperationClaimModel>>(
      newPath
    );
  }

  getByName(
    name: string
  ): Observable<SingleResponseModel<OperationClaimModel>> {
    let newPath = apiUrl + 'operationclaims/getbyname?name=' + name;
    return this.httpClient.get<SingleResponseModel<OperationClaimModel>>(
      newPath
    );
  }
}
