import { TokenService } from './core/services/token.service';
import { UserService } from 'src/app/core/services/user.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'AngularUI';

  constructor(
    private tokenService: TokenService,
    private authService: AuthService
  ) {
    if (tokenService.isTokenExpired()) {
      authService.logout();
    }
  }
}
