import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

/// If response has error returns true
export class ValidationService {
  returnValue: boolean;

  constructor(private toastrService: ToastrService) {}

  showErrors(responseError: any) {
    if (responseError.error != null) {
      if (responseError.error.data != null) {
        switch (responseError.error.data.exceptionType) {
          case +ExceptionType.TransactionException:
            this.toastrService.error(
              responseError.error.data.transactionError,
              responseError.error.message
            );

            this.returnValue = true;
            return true;

          case +ExceptionType.AuthorizationDeniedException:
            this.toastrService.error(
              responseError.error.data.securityError,
              responseError.error.message
            );

            this.returnValue = true;
            return true;

          case +ExceptionType.ValidationException:
            responseError.error.data.validationErrors.forEach((error: any) => {
              this.toastrService.error(error, responseError.error.message);
            });

            this.returnValue = true;
            return true;

          default:
            this.toastrService.error(responseError.error.data?.errorMessage);

            this.returnValue = true;
            return true;
        }
      } else if (responseError.error.message != null) {
        this.toastrService.error(responseError.error.message);
        this.returnValue = true;
      } else {
        this.toastrService.error('Bir Şeyler Ters Gitti', 'Beklenmedik Hata');
        this.returnValue = true;
      }

      return this.returnValue;
    }

    return false;
  }
}

export enum ExceptionType {
  TransactionException,
  AuthorizationDeniedException,
  LoginRequiredException,
  ValidationException,
  SystemException,
}
