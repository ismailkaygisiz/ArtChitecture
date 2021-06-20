import { Title } from '@angular/platform-browser';
import { TokenService } from './../../../services/token.service';
import { ValidationService } from './../../../services/validation.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router,
    private validationService: ValidationService,
    private titleService: Title
  ) {}

  ngOnInit(): void {
    this.titleService.setTitle('Giriş Yap');
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
          this.tokenService.setToken(response.data.token);

          this.toastrService.success(response.message, 'İşlem Başarılı');
          this.router.navigate(['']);
        },
        (responseError) => {
          this.validationService.showErrors(responseError);
        }
      );
    } else {
      this.toastrService.error('Anlaşılan Formunuz Tamamlanmamış', 'Hata');
    }
  }
}
