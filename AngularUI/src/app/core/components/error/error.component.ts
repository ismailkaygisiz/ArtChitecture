import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RouterService } from '../../services/router.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css'],
})
export class ErrorComponent implements OnInit {
  constructor(private routerService: RouterService) {}

  ngOnInit(): void {
    this.routerService.pageNotFoundRoute();
  }
}
