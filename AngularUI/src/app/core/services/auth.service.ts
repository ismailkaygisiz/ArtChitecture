import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { LoginModel } from '../models/user/loginModel';
import { RegisterModel } from '../models/user/registerModel';
import { TokenModel } from '../models/user/tokenModel';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private jwtHelperService: JwtHelperService = new JwtHelperService();

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
    if (this.isAuthenticated()) {
      this.localStorageService.removeItem('token');
      return true;
    }

    return false;
  }

  isAuthenticated(): boolean {
    if (this.localStorageService.controlItem('token')) {
      return true;
    }

    return false;
  }

  isTokenExpired(): boolean {
    let isExpired = this.jwtHelperService.isTokenExpired(
      this.localStorageService.getToken()
    );

    return isExpired != null ? isExpired : true;
  }
}
