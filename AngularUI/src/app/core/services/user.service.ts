import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { OperationClaimDetailsModel } from '../models/operation-claim/operationClaimDetailsModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { UserModel } from '../models/user/userModel';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private jwtHelperService: JwtHelperService = new JwtHelperService();

  constructor(
    private localStorageService: LocalStorageService,
    private httpClient: HttpClient,
    private authService: AuthService
  ) {}

  getUserByEmailUseLocalStorage(): Observable<SingleResponseModel<UserModel>> {
    let email = this.jwtHelperService.decodeToken(
      this.localStorageService.getToken()
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

  getUserRolesWithJWT(): string[] {
    let token = this.jwtHelperService.decodeToken(
      this.localStorageService.getToken()
    );

    if (token != null) {
      let roles =
        token['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

      if (!Array.isArray(roles)) {
        let array = new Array();
        array.push(roles);

        return array;
      }

      return roles;
    }

    return [];
  }
}
