import { TokenService } from './../services/token.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiUrl, clientName } from 'src/api';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  token: string;
  refreshToken: string;

  constructor(private tokenService: TokenService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    let newRequest: HttpRequest<any>;
    this.token = this.tokenService.getToken();
    this.refreshToken = this.tokenService.getRefreshToken();

    newRequest = request.clone({
      headers: request.headers
        .set('Authorization', 'Bearer ' + this.token ?? '')
        .append('lang', localStorage.getItem('lang') ?? ''),
    });

    if (this.refreshToken != null && this.tokenService.isTokenExpired()) {
      let refreshTokenRequest = request.clone({
        method: 'POST',
        url: apiUrl + 'auth/refreshtoken',
        body: {
          refreshToken: this.refreshToken,
          clientName: clientName,
        },
        headers: request.headers
          .set('Authorization', 'Bearer ' + this.token ?? '')
          .append('lang', localStorage.getItem('lang') ?? ''),
      });

      next.handle(refreshTokenRequest).subscribe(
        (response) => {
          if (response instanceof HttpResponse) {
            this.tokenService.setToken(response.body.data.token);
            this.tokenService.setRefreshToken(
              response.body.data.refreshToken.refreshTokenValue
            );
          }
        },
        (responseError) => {
          this.tokenService.removeToken();
          this.tokenService.removeRefreshToken();
        }
      );
    }

    return next.handle(newRequest);
  }
}
