import { TokenService } from './../../../services/token.service';
import { ValidationService } from './../../../services/validation.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/core/services/auth.service';
import { Title } from '@angular/platform-browser';
import { translates } from 'src/api';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  translateKeys = translates;

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
    this.titleService.setTitle('Kayıt Ol');
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    if (this.registerForm.valid) {
      let registerModel = Object.assign({}, this.registerForm.value);

      this.authService.register(registerModel).subscribe(
        (response) => {
          this.tokenService.setToken(response.data.token);
          this.tokenService.setRefreshToken(response.data.refreshToken);

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
