import 'package:flutter_ui/core/services/cryptoService.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'service.dart';

class SessionService extends Service {
  var crypto = CryptoService();

  Future<String> get(String key) async {
    SharedPreferences _session = await SharedPreferences.getInstance();
    if (_session.get(key) != null) {
      return crypto.get(_session.get(key) as String);
    }

    return null;
  }

  Future<void> set(String key, String value) async {
    SharedPreferences _session = await SharedPreferences.getInstance();
    _session.setString(key, crypto.set(value));
  }

  Future<void> remove(String key) async {
    SharedPreferences _session = await SharedPreferences.getInstance();
    _session.remove(key);
  }

  Future<bool> controlItem(String key) async {
    SharedPreferences _session = await SharedPreferences.getInstance();

    var item = _session.get(key);

    if (item != null) {
      return true;
    }

    return false;
  }
}
