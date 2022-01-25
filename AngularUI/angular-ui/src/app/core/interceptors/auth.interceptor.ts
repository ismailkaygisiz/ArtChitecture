import { TokenService } from './../services/token.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpClient,
} from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { apiUrl, clientName } from 'src/api';
import { AuthService } from '../services/auth.service';
import { catchError, filter, switchMap, take, tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  token: string;
  refreshToken: string;
  clientId: string;

  constructor(
    private tokenService: TokenService,
    private authService: AuthService,
    private router: Router,
    private httpClient: HttpClient
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    this.token = this.tokenService.getToken();
    this.refreshToken = this.tokenService.getRefreshToken();
    this.clientId = this.tokenService.getClientId();

    req = this.addToken(req);

    return next.handle(req).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          this.router.navigate(['/auth/login']);
          return throwError(error);
        } else if (error instanceof HttpErrorResponse && error.status === 403) {
          if (this.refreshToken != null) {
            return this.handle403Error(req, next);
          }

          return throwError(error);
        } else {
          return throwError(error);
        }
      })
    );
  }
  private addToken(req: HttpRequest<any>) {
    return req.clone({
      setHeaders: {
        Authorization: `Bearer ${this.token ?? ''}`,
        lang: localStorage.getItem('lang') ?? '',
        ClientId: this.clientId ?? '',
        RefreshToken: this.refreshToken ?? '',
        ClientName: clientName,
      },
    });
  }

  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(
    null
  );

  private handle403Error(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.httpClient
        .post<any>(
          apiUrl + 'auth/refreshToken',
          {},
          {
            headers: {
              Authorization: 'Bearer ' + this.token ?? '',
              lang: localStorage.getItem('lang') ?? '',
              clientId: this.clientId ?? '',
              refreshToken: this.refreshToken ?? '',
              clientName: clientName,
            },
          }
        )
        .pipe(
          tap((response) => {
            if (response.success) {
              this.tokenService.setToken(response.data.token);
              this.tokenService.setRefreshToken(
                response.data.refreshToken.refreshTokenValue
              );
              this.tokenService.setClientId(
                response.data.refreshToken.clientId
              );
              this.authService.onRefreshTokenSucceed(response.data);
            }
          }),
          catchError((error) => {
            this.tokenService.removeRefreshToken();
            this.tokenService.removeToken();
            this.authService.onRefreshTokenFailed();
            return throwError(error);
          })
        )
        .pipe(
          switchMap((response: any) => {
            this.tokenService.setToken(response.data.token);
            this.tokenService.setRefreshToken(
              response.data.refreshToken.refreshTokenValue
            );
            this.tokenService.setClientId(response.data.refreshToken.clientId);
            this.authService.onRefreshTokenSucceed(response.data);

            this.isRefreshing = false;
            this.refreshTokenSubject.next(response.data.token);
            return next.handle(this.addToken(request));
          }),
          catchError((error) => {
            this.tokenService.removeRefreshToken();
            this.tokenService.removeToken();
            this.authService.onRefreshTokenFailed();
            return throwError(error);
          })
        );
    } else {
      return this.refreshTokenSubject.pipe(
        filter((token) => token != null),
        take(1),
        switchMap((jwt) => {
          return next.handle(this.addToken(request));
        })
      );
    }
  }
}
