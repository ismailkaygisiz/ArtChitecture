import { Title } from '@angular/platform-browser';
import { TokenService } from './core/services/token.service';
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
    private authService: AuthService,
    private titleService: Title
  ) {
    this.titleService.setTitle('Arthitecture');

    if (tokenService.isTokenExpired()) {
      authService.logout();
    }
  }
}
