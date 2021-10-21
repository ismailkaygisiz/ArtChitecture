import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { UserOperationClaimAddModel } from '../models/user-operation-claim/userOperationClaimAddModel';
import { UserOperationClaimModel } from '../models/user-operation-claim/userOperationClaimModel';
import { ServiceRepositoryWithAddModel } from './service-repository';

@Injectable({
  providedIn: 'root',
})
export class UserOperationClaimService
  implements
    ServiceRepositoryWithAddModel<
      UserOperationClaimAddModel,
      UserOperationClaimModel,
      number
    >
{
  constructor(private httpClient: HttpClient) {}

  add(
    userOperationClaimAddModel: UserOperationClaimAddModel
  ): Observable<ResponseModel> {
    let newPath = apiUrl + 'useroperationclaims/add';
    return this.httpClient.post<ResponseModel>(
      newPath,
      userOperationClaimAddModel
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'useroperationclaims/delete';
    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  update(
    userOperationClaimModel: UserOperationClaimModel
  ): Observable<ResponseModel> {
    let newPath = apiUrl + 'useroperationclaims/update';
    return this.httpClient.post<ResponseModel>(
      newPath,
      userOperationClaimModel
    );
  }

  getAll(): Observable<ListResponseModel<UserOperationClaimModel>> {
    let newPath = apiUrl + 'useroperationclaims/getall';
    return this.httpClient.get<ListResponseModel<UserOperationClaimModel>>(
      newPath
    );
  }

  getByUserId(
    userId: number
  ): Observable<ListResponseModel<UserOperationClaimModel>> {
    let newPath = apiUrl + 'useroperationclaims/getbyuserid?userId=' + userId;
    return this.httpClient.get<ListResponseModel<UserOperationClaimModel>>(
      newPath
    );
  }

  getByClaimId(
    claimId: number
  ): Observable<ListResponseModel<UserOperationClaimModel>> {
    let newPath =
      apiUrl + 'useroperationclaims/getbyclaimid?claimId=' + claimId;
    return this.httpClient.get<ListResponseModel<UserOperationClaimModel>>(
      newPath
    );
  }

  getById(
    id: number
  ): Observable<SingleResponseModel<UserOperationClaimModel>> {
    let newPath = apiUrl + 'useroperationclaims/getbyid?id=' + id;
    return this.httpClient.get<SingleResponseModel<UserOperationClaimModel>>(
      newPath
    );
  }
}
