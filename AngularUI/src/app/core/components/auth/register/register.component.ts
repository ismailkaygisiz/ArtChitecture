import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserModel } from 'src/app/core/models/user/userModel';
import { AuthService } from 'src/app/core/services/auth.service';
import { LocalStorageService } from 'src/app/core/services/local-storage.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user: UserModel;

  constructor(
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private router: Router,
    private userService: UserService
  ) {}

  ngOnInit(): void {
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
      console.log(this.registerForm.value);
      let registerModel = Object.assign({}, this.registerForm.value);

      this.authService.register(registerModel).subscribe(
        (response) => {
          this.localStorageService.setItem('email', registerModel.email);
          this.localStorageService.setItem('token', response.data.token);

          this.userService
            .getUserByMailUseLocalStorage()
            .subscribe((responseUser) => {
              this.user = responseUser.data;
              this.router.navigate(['']);
            });
        },
        (responseError) => {
          this.toastrService.error(responseError.error.message);
        }
      );
    } else {
      this.toastrService.error('Anlaşılan Formunuz Tamamlanmamış', 'HATA');
    }
  }
}
