import { UserModel } from 'src/app/core/models/user/userModel';
import { LocalStorageService } from 'src/app/core/services/local-storage.service';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private jwtHelperService: JwtHelperService = new JwtHelperService();

  constructor(private localStorageService: LocalStorageService) {}

  decodeToken(token: string) {
    return this.jwtHelperService.decodeToken(token);
  }

  getToken() {
    return this.localStorageService.getItem('token');
  }

  setToken(token: string) {
    this.localStorageService.setItem('token', token);
  }

  removeToken() {
    this.localStorageService.removeItem('token');
  }

  isTokenExpired(): boolean {
    let isExpired = this.jwtHelperService.isTokenExpired(this.getToken());

    return isExpired != null ? isExpired : true;
  }

  getTokenExpirationDate(): Date {
    return this.jwtHelperService.getTokenExpirationDate(this.getToken());
  }

  getUserRolesWithJWT(): string[] {
    let token = this.jwtHelperService.decodeToken(this.getToken());

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

  getUserWithJWT(): UserModel {
    let token = this.jwtHelperService.decodeToken(this.getToken());

    if (token != null) {
      let userModel = {
        id: +token[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ],
        email: token.email,
        firstName:
          token['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
        lastName:
          token[
            'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname'
          ],
        status: Boolean(token.status),
      };

      return userModel;
    }

    return null;
  }
}
