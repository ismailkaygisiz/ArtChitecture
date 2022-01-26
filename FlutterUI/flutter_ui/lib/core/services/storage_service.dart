import 'package:get_storage/get_storage.dart';

class StorageService {
  final GetStorage _storage = GetStorage();

  get storage => _storage;

  Future<String?> get(String key) async {
    String? value = _storage.read(key);
    if (value == "") value = null;
    return value;
  }

  Future<void> set(String key, String? value) async {
    _storage.write(key, value);
  }

  Future<void> remove(String key) async {
    _storage.remove(key);
  }

  Future<bool> controlItem(String key) async {
    if (_storage.read(key) != null) return true;

    return false;
  }

  Future<void> clear() async {
    await _storage.erase();
  }
}
