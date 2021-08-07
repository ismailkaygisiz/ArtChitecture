import { TokenService } from './../services/token.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpClient,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { LocalStorageService } from '../services/local-storage.service';
import { AuthService } from '../services/auth.service';
import { apiUrl } from 'src/api';
import { map, filter, mergeMap, catchError, tap } from 'rxjs/operators';
import { TokenModel } from '../models/user/tokenModel';
import { taggedTemplate } from '@angular/compiler/src/output/output_ast';
import { SingleResponseModel } from '../models/response/singleResponseModel';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  token: string;
  refreshToken: string;

  constructor(
    private localStorageService: LocalStorageService,
    private tokenService: TokenService,
    private authService: AuthService,
    private httpClient: HttpClient
  ) {}

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
        method: 'GET',
        url: apiUrl + 'auth/refreshtoken?refreshToken=' + this.refreshToken,
        headers: request.headers
          .set('Authorization', 'Bearer ' + this.token ?? '')
          .append('lang', localStorage.getItem('lang') ?? ''),
      });

      // next.handle(refreshTokenRequest).pipe(
      //   tap((event) => {
      //     if (event instanceof HttpResponse) {
      //       this.tokenService.setToken(event.body.data.token);
      //       this.tokenService.setRefreshToken(event.body.data.refreshToken);
      //       console.log('Set edildi');
      //     } else {
      //       this.tokenService.removeToken();
      //       this.tokenService.removeRefreshToken();
      //       console.log('Kaldırıldı');
      //     }
      //   })
      // );

      next.handle(refreshTokenRequest).subscribe(
        (response) => {
          if (response instanceof HttpResponse) {
            this.tokenService.setToken(response.body.data.token);
            this.tokenService.setRefreshToken(response.body.data.refreshToken);
            console.log('Set edildi');
          } else {
            this.tokenService.removeToken();
            this.tokenService.removeRefreshToken();
            console.log('Kaldırıldı');
          }
        },
        (responseError) => {
          this.tokenService.removeToken();
          this.tokenService.removeRefreshToken();
          console.log('Kaldırıldı');
        }
      );
    }

    return next.handle(newRequest);
  }
}
