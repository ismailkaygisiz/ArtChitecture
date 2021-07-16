import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor(private toastrService: ToastrService) {}

  bootstrapValidate() {
    var forms = document.querySelectorAll('.needs-validation');

    Array.prototype.slice.call(forms).forEach(function (form) {
      form.addEventListener(
        'submit',
        function (event: any) {
          if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
          }

          form.classList.add('was-validated');
        },
        false
      );
    });
  }

  showErrors(responseError: any) {
    if (responseError.error != null) {
      // Validation Control
      if (responseError.error.validationErrors != null) {
        responseError.error.validationErrors.forEach((error: any) => {
          this.toastrService.error(error, responseError.error.message);
        });

        return true;
      }

      // Security Control
      else if (responseError.error.securityError != null) {
        this.toastrService.error(
          responseError.error.securityError,
          responseError.error.message
        );

        return true;
      }

      // Transaction Control
      else if (responseError.error.transactionScopeError != null) {
        this.toastrService.error(
          responseError.error.transactionScopeError,
          responseError.error.message
        );

        return true;
      }

      // System Control
      else if (responseError.error.ErrorMessage != null) {
        this.toastrService.error('', responseError.error.ErrorMessage);

        return true;
      }

      // Error
      else {
        this.toastrService.error('Bir Şeyler Ters Gitti', 'Beklenmedik Hata');

        return true;
      }
    }

    return false;
  }
}
