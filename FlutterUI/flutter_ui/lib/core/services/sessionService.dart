import 'package:flutter_ui/core/services/cryptoService.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../utilities/service.dart';

class SessionService extends Service {
  Future<String> get(String key) async {
    SharedPreferences _session = await SharedPreferences.getInstance();
    if (await _session.get(key) != null) {
      return cryptoService.get(await _session.get(key) as String);
    }

    return null;
  }

  Future<void> set(String key, String value) async {
    SharedPreferences _session = await SharedPreferences.getInstance();
    await _session.setString(key, cryptoService.set(value));
  }

  Future<void> remove(String key) async {
    SharedPreferences _session = await SharedPreferences.getInstance();
    await _session.remove(key);
  }

  Future<bool> controlItem(String key) async {
    SharedPreferences _session = await SharedPreferences.getInstance();

    var item = await _session.get(key);

    if (item != null) {
      return true;
    }

    return false;
  }

  Future<void> clear() async {
    SharedPreferences _session = await SharedPreferences.getInstance();

    await _session.clear();
  }
}
