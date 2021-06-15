import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from '../services/local-storage.service';
import { TokenModel } from '../models/user/tokenModel';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  token: string;
  
  constructor(private localStorageService: LocalStorageService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    if (this.localStorageService.controlItem('token')) {
      this.token = this.localStorageService.getItem('token');
    }
    let newRequest: HttpRequest<any>;

    newRequest = request.clone({
      headers: request.headers.set('Authorization', 'Bearer ' + this.token),
    });
    return next.handle(newRequest);
  }
}
