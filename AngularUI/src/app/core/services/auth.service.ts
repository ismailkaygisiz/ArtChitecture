import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/environments/environment';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { LoginModel } from '../models/user/loginModel';
import { RegisterModel } from '../models/user/registerModel';
import { TokenModel } from '../models/user/tokenModel';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  login(user: LoginModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/login';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  register(user: RegisterModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/register';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  logout() {
    if (
      this.localStorageService.getItem('token') &&
      this.localStorageService.getItem('email')
    ) {
      this.localStorageService.removeItem('token');
      this.localStorageService.removeItem('email');
      return true;
    }

    return false;
  }

  isAuthenticated() {
    if (
      this.localStorageService.controlItem('token') &&
      this.localStorageService.controlItem('email')
    ) {
      return true;
    }

    return false;
  }
}
