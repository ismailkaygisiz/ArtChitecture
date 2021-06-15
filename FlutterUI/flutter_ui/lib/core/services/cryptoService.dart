import 'service.dart';
import 'package:encrypt/encrypt.dart';

class CryptoService extends Service {
  var _key; //32 chars
  var _iv;

  CryptoService() {
    _key = Key.fromUtf8(KEY);
    _iv = IV.fromUtf8(TOKEN);
  }

  String set(String text) {
    final encrypter = Encrypter(AES(_key, mode: AESMode.cbc));
    final encryptedData = encrypter.encrypt(text, iv: _iv);
    return encryptedData.base64;
  }

  String get(String text) {
    final encrypter = Encrypter(AES(_key, mode: AESMode.cbc));
    final decryptedData =
        encrypter.decrypt(Encrypted.fromBase64(text), iv: _iv);
    return decryptedData;
  }
}
