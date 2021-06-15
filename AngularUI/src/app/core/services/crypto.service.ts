import { Injectable } from '@angular/core';
import { AES, enc } from 'crypto-js';
import { token } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CryptoService {
  constructor() {}

  set(value: any) {
    var encrypted = AES.encrypt(value, token);

    return encrypted.toString();
  }

  get(value: any) {
    var decrypted = AES.decrypt(value, token);

    return decrypted.toString(enc.Utf8);
  }
}
