import { LocalStorageService } from './core/services/local-storage.service';
import { ToastrService } from 'ngx-toastr';
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
    private titleService: Title,
    private toastrService: ToastrService,
    private localStorageService: LocalStorageService
  ) {
    this.titleService.setTitle('Arthitecture');

    setInterval(() => {
      if (tokenService.isTokenExpired()) {
        if (
          tokenService.getTokenExpirationDate() < new Date() &&
          localStorageService.getItem('tV') != '1'
        ) {
          toastrService.info(
            'Oturumunuzun Süresi Doldu Lütfen Tekrar Giriş Yapın',
            'Bilgilendirme'
          );

          localStorageService.setItem('tV', '1');
        }

        authService.logout();
      } else {
        localStorageService.removeItem('tV');
      }
    }, 25000);
  }
}
