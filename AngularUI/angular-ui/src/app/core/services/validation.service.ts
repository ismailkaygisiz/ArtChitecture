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
      if (responseError.error.data?.validationErrors != null) {
        responseError.error.data.validationErrors.forEach((error: any) => {
          this.toastrService.error(error, responseError.error.message);
        });

        return true;
      }

      // Security Control
      else if (responseError.error.data?.securityError != null) {
        this.toastrService.error(
          responseError.error.data.securityError,
          responseError.error.message
        );

        return true;
      }

      // Transaction Control
      else if (responseError.error.data?.transactionError != null) {
        this.toastrService.error(
          responseError.error.data.transactionError,
          responseError.error.message
        );

        return true;
      }

      // System Control
      else if (responseError.error.data?.errorMessage != null) {
        this.toastrService.error('', responseError.error.data.errorMessage);

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
