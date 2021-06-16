import { Injectable } from '@angular/core';
import { AES, enc } from 'crypto-js';
import { token } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class CryptoService {
  constructor() {}

  set(value: any) {
    if (value != null) {
      var encrypted = AES.encrypt(value, token);

      return encrypted.toString();
    }

    return null;
  }

  get(value: any) {
    if (value != null) {
      var decrypted = AES.decrypt(value, token);

      return decrypted.toString(enc.Utf8);
    }

    return null;
  }
}
