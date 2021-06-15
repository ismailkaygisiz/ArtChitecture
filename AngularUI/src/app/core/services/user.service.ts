import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/environments/environment';
import { DeleteModel } from '../models/deleteModel';
import { OperationClaimDetailsModel } from '../models/operation-claim/operationClaimDetailsModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { UserModel } from '../models/user/userModel';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(
    private localStorageService: LocalStorageService,
    private httpClient: HttpClient
  ) {}

  getUserByMailUseLocalStorage(): Observable<SingleResponseModel<UserModel>> {
    let newPath =
      apiUrl +
      'users/getbyemail?email=' +
      this.localStorageService.getItem('email');

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getUserByMail(email: string): Observable<SingleResponseModel<UserModel>> {
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

  getClaims(
    user: UserModel
  ): Observable<SingleResponseModel<OperationClaimDetailsModel>> {
    let newPath = apiUrl + 'users/getclaims';

    return this.httpClient.post<SingleResponseModel<OperationClaimDetailsModel>>(
      newPath,
      user
    );
  }
}
