import { Title } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RouterService {
  constructor(
    private router: Router,
    private toastrService: ToastrService,
    private titleService: Title
  ) {}

  pageNotFoundRoute() {
    this.titleService.setTitle('Sayfa Bulunamadı');

    this.router.navigate(['']).then(() => {
      this.toastrService.error('Sayfa Bulunamadı', 'Hata');
    });
  }
}
