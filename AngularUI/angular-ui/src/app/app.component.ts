import { Component, OnInit } from '@angular/core';
import { TranslateService } from './core/services/translate.service';
import { ValidationService } from './services/validation.service';
import { translates } from 'src/api';
import { AuthService } from './core/services/auth.service';
import { SeoService } from './core/services/seo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'ArtChitecture';
  translateKeys: any;

  constructor(
    private translateService: TranslateService,
    private validationService: ValidationService,
    private authService: AuthService,
    private seoService: SeoService
  ) {}

  ngOnInit(): void {
    this.seoService.updateTitle(this.title);
    this.getTranslates();

    this.authService.setRefreshTokenEvents(
      () => {
        console.log('Failed');
      },
      (token) => {
        console.log('Succeed' + token.expiration);
      }
    );
  }

  getTranslates() {
    var lang = localStorage.getItem('lang');

    if (lang == null) {
      lang = navigator.language;
      localStorage.setItem('lang', lang);
    }

    this.seoService.updateLang(lang);

    this.translateService.getTranslates(lang).subscribe(
      (response) => {
        translates.keys = response.data;
        this.translateKeys = translates;
      },
      (responseError) => {
        this.validationService.showErrors(responseError);

        lang = navigator.language;
        localStorage.setItem('lang', lang);

        this.seoService.updateLang(lang);
        this.translateService.getTranslates(lang).subscribe(
          (response) => {
            translates.keys = response.data;
            this.translateKeys = translates;
          },
          (responseError) => {
            this.validationService.showErrors(responseError);
            this.translateKeys = null;
          }
        );
      }
    );
  }
}
