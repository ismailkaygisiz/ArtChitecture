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

  getToken(): string {
    return this.localStorageService.getItem('token');
  }

  setToken(token: string): void {
    this.localStorageService.setItem('token', token);
  }

  removeToken(): void {
    this.localStorageService.removeItem('token');
  }

  setRefreshToken(refreshToken: string): void {
    this.localStorageService.setItem('refresh-token', refreshToken);
  }

  getRefreshToken(): string {
    return this.localStorageService.getItem('refresh-token');
  }

  removeRefreshToken(): void {
    this.localStorageService.removeItem('refresh-token');
  }

  setClientId(clientId: string): void {
    this.localStorageService.setItem('client-id', clientId);
  }

  getClientId(): string {
    return this.localStorageService.getItem('client-id');
  }

  removeClientId(): void {
    this.localStorageService.removeItem('client-id');
  }

  isTokenExpired(): boolean {
    let isExpired = this.jwtHelperService.isTokenExpired(this.getToken());

    return isExpired != null ? isExpired : true;
  }

  getTokenExpirationDate(): Date {
    return this.jwtHelperService.getTokenExpirationDate(this.getToken());
  }

  getUserRolesWithJWT(): string[] {
    let token = this.decodeToken(this.getToken());

    if (token != null) {
      let roles =
        token[Object.keys(token).filter((r) => r.endsWith('/role'))[0]];

      if (!Array.isArray(roles)) {
        let array = [];
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
          Object.keys(token).filter((t) => t.endsWith('nameidentifier'))[0]
        ],
        email: token.email,
        firstName:
          token[Object.keys(token).filter((t) => t.endsWith('name'))[0]],
        lastName:
          token[Object.keys(token).filter((t) => t.endsWith('surname'))[0]],
        status: Boolean(token.status),
      };

      return userModel;
    }

    return null;
  }
}
