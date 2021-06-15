import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserModel } from 'src/app/core/models/user/userModel';
import { AuthService } from 'src/app/core/services/auth.service';
import { LocalStorageService } from 'src/app/core/services/local-storage.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  user: UserModel;

  constructor(
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (this.loginForm.valid) {
      let loginModel = Object.assign({}, this.loginForm.value);

      this.authService.login(loginModel).subscribe(
        (response) => {
          this.localStorageService.setItem('email', loginModel.email);
          this.localStorageService.setItem('token', response.data.token);

          this.getUser();
          this.router.navigate(['']).then((c) => {
            window.location.reload();
          });
        },
        (responseError) => {
          console.log(responseError);

          this.toastrService.error(responseError.error.message, 'Hata');
        }
      );
    } else {
      this.toastrService.error('Anlaşılan Formunuz Tamamlanmamış', 'HATA');
    }
  }

  getUser() {
    this.userService.getUserByMailUseLocalStorage().subscribe((response) => {
      this.user = response.data;
    });
  }
}
