import { AuthService } from './../services/auth.service';
import { TokenService } from './../services/token.service';
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard implements CanActivate {
  constructor(
    private tokenService: TokenService,
    private authService: AuthService,
    private router: Router
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    if (this.authService.isAuthenticated()) {
      for (let i = 0; i < this.tokenService.getUserRolesWithJWT().length; i++) {
        const role = this.tokenService.getUserRolesWithJWT()[i];
        if (role == 'Admin') {
          return true;
        }
      }
    }

    this.router.navigate(['/']);
    return false;
  }
}
