import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css'],
})
export class ErrorComponent implements OnInit {
  constructor(private toastrService: ToastrService, private router: Router) {}

  ngOnInit(): void {
    this.router.navigate(['']).then(() => {
      this.toastrService.error('Sayfa Bulunamadı', 'HATA');
    });
  }
}
