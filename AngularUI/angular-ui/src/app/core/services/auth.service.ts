import { TokenService } from './token.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl, clientName } from 'src/api';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { LoginModel } from '../models/user/loginModel';
import { RegisterModel } from '../models/user/registerModel';
import { TokenModel } from '../models/user/tokenModel';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _refreshTokenFailedEvent: () => any;
  private _refreshTokenSucceedEvent: (token: TokenModel) => any;

  constructor(
    private httpClient: HttpClient,
    private localStorageService: LocalStorageService,
    private tokenService: TokenService
  ) {}

  login(user: LoginModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/login';

    let userForLoginDto = {
      email: user.email,
      password: user.password,
      clientName: clientName,
      clientId: this.tokenService.getClientId(),
    };

    return this.httpClient.post<SingleResponseModel<TokenModel>>(
      newPath,
      userForLoginDto
    );
  }

  register(user: RegisterModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/register';

    let userForRegisterDto = {
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      password: user.password,
      clientName: clientName,
    };

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  logout() {
    if (this.isAuthenticated()) {
      this.tokenService.removeToken();
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

  onRefreshTokenFailed() {
    if (this._refreshTokenFailedEvent != null) this._refreshTokenFailedEvent();
  }

  onRefreshTokenSucceed(token: TokenModel) {
    if (this._refreshTokenSucceedEvent != null)
      this._refreshTokenSucceedEvent(token);
  }

  setRefreshTokenEvents(
    refreshTokenFailedEvent: () => any,
    refreshTokenSucceedEvent: (token: TokenModel) => any
  ): void {
    this._refreshTokenFailedEvent = refreshTokenFailedEvent;
    this._refreshTokenSucceedEvent = refreshTokenSucceedEvent;
  }
}
