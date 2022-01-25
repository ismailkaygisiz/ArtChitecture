import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { UserModel } from '../models/user/userModel';
import { ServiceRepository } from './service-repository';

@Injectable({
  providedIn: 'root',
})
export class UserService implements ServiceRepository<UserModel, number> {
  constructor(private httpClient: HttpClient) {}
  add(addModel: UserModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'users/add';

    return this.httpClient.post<ResponseModel>(newPath, addModel);
  }

  getByEmail(email: string): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getbyemail?email=' + email;

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getById(id: number): Observable<SingleResponseModel<UserModel>> {
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
}
