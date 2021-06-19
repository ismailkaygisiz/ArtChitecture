import { Injectable } from '@angular/core';
import { CryptoService } from './crypto.service';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  localStorage: Storage;

  constructor(private cryptoService: CryptoService) {
    this.localStorage = window.localStorage;
  }

  getItem(key: string) {
    return this.cryptoService.get(this.localStorage.getItem(key));
  }

  setItem(key: string, value: string) {
    this.localStorage.setItem(key, this.cryptoService.set(value));
  }

  removeItem(key: string) {
    this.localStorage.removeItem(key);
  }

  clearAll() {
    localStorage.clear();
  }

  controlItem(key: string) {
    if (this.localStorage.getItem(key) != null) {
      return true;
    }

    return false;
  }
}
