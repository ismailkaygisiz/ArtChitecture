import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor(private toastrService: ToastrService) {}

  validate() {
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

  showErrors(response: any) {
    if (response.error != null) {
      if (response.error.data != null) {
        if (response.error.data.validationErrors != null) {
          response.error.data.validationErrors.forEach((error: any) => {
            this.toastrService.error(error, response.error.message);
          });

          return true;
        }
      } else if (response.error.message != null) {
        this.toastrService.error(response.error.message, 'Hata');

        return true;
      } else {
        this.toastrService.error(response.error, 'Hata');

        return true;
      }
    }
    return false;
  }
}
