import { Title } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { TranslateService } from './core/services/translate.service';
import { ValidationService } from './core/services/validation.service';
import { translates } from 'src/api';

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
    private validationService: ValidationService
  ) {}
  ngOnInit(): void {
    this.titleService.setTitle('ArtChitecture AngularUI');
    this.translateService
      .getTranslates(
        localStorage.getItem('lang') != null
          ? localStorage.getItem('lang')
          : 'en-Us'
      )
      .subscribe(
        (response) => {
          translates.keys = response.data;
          this.translateKeys = translates;
        },
        (responseError) => {
          this.validationService.showErrors(responseError);
        }
      );
  }
}
