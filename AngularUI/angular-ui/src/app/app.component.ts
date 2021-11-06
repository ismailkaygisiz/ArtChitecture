import { Title } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { TranslateService } from './core/services/translate.service';
import { ValidationService } from './core/services/validation.service';
import { translates } from 'src/api';
import { AuthService } from './core/services/auth.service';
import { OperationClaimService } from './core/services/operation-claim.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'AngularUI';
  translateKeys: any;

  constructor(
    private titleService: Title,
    private translateService: TranslateService,
    private validationService: ValidationService,
    private authService: AuthService,
    private operationClaimService: OperationClaimService
  ) {}

  ngOnInit(): void {
    this.titleService.setTitle('ArtChitecture AngularUI');
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
    this.translateService.getTranslates(localStorage.getItem('lang')).subscribe(
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
}
