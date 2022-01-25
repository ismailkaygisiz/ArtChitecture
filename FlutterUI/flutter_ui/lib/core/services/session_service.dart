import 'package:encrypted_shared_preferences/encrypted_shared_preferences.dart';
import 'package:shared_preferences/shared_preferences.dart';

class SessionService {
  late EncryptedSharedPreferences encryptedSharedPreferences;

  SessionService() {
    encryptedSharedPreferences = EncryptedSharedPreferences();
  }

  Future<String?> get(String key) async {
    encryptedSharedPreferences.prefs = await SharedPreferences.getInstance();
    String? value = await encryptedSharedPreferences.getString(key);
    if (value == "") value = null;
    return value;
  }

  Future<void> set(String key, String? value) async {
    encryptedSharedPreferences.prefs = await SharedPreferences.getInstance();

    if (value != null) await encryptedSharedPreferences.setString(key, value);
  }

  Future<void> remove(String key) async {
    encryptedSharedPreferences.prefs = await SharedPreferences.getInstance();
    await encryptedSharedPreferences.prefs!.remove(key);
  }

  Future<bool> controlItem(String key) async {
    encryptedSharedPreferences.prefs = await SharedPreferences.getInstance();
    if (encryptedSharedPreferences.prefs!.containsKey(key)) return true;

    return false;
  }

  Future<void> clear() async {
    encryptedSharedPreferences.prefs = await SharedPreferences.getInstance();
    await encryptedSharedPreferences.clear();
  }
}
