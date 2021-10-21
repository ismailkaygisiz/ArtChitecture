import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor(private toastrService: ToastrService) {}

  showErrors(responseError: any) {
    if (responseError.error != null) {
      // Validation Control
      if (responseError.error.ValidationErrors != null) {
        responseError.error.ValidationErrors.forEach((error: any) => {
          this.toastrService.error(error, responseError.error.ErrorMessage);
        });

        return true;
      }

      // Security Control
      else if (responseError.error.SecurityError != null) {
        this.toastrService.error(
          responseError.error.SecurityError,
          responseError.error.ErrorMessage
        );

        return true;
      }

      // Transaction Control
      else if (responseError.error.TransactionError != null) {
        this.toastrService.error(
          responseError.error.TransactionError,
          responseError.error.ErrorMessage
        );

        return true;
      }

      // System Control
      else if (responseError.error.ErrorMessage != null) {
        this.toastrService.error('', responseError.error.ErrorMessage);

        return true;
      } else if (responseError.error.message != null) {
        this.toastrService.error('', responseError.error.message);
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
