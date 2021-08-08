import { TokenService } from './token.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { OperationClaimDetailsModel } from '../models/operation-claim/operationClaimDetailsModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { UserModel } from '../models/user/userModel';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(
    private httpClient: HttpClient,
    private tokenService: TokenService
  ) {}

  getUserByEmailUseLocalStorage(): Observable<SingleResponseModel<UserModel>> {
    let email = this.tokenService.decodeToken(
      this.tokenService.getToken()
    ).email;

    let newPath = apiUrl + 'users/getbyemail?email=' + email;

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getUserByEmail(email: string): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getbyemail?email=' + email;

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getUserById(id: number): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getbyid?id=' + id;

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getAll(): Observable<ListResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getall';

    return this.httpClient.get<ListResponseModel<UserModel>>(newPath);
  }

  update(user: UserModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'users/update';

    return this.httpClient.post<ResponseModel>(newPath, user);
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'users/delete';

    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  getClaimsWithDetails(
    user: UserModel
  ): Observable<SingleResponseModel<OperationClaimDetailsModel>> {
    let newPath = apiUrl + 'users/getclaims';

    return this.httpClient.post<
      SingleResponseModel<OperationClaimDetailsModel>
    >(newPath, user);
  }
}
