import 'dart:collection';

import 'package:flutter_ui/core/models/entity.dart';

@entity
class Dictionary {
  Map<String, String> _map;

  Dictionary() {
    _map = Map<String, String>();
  }

  set(String key, String value) {
    _map.putIfAbsent(key, () => value);
  }

  get(String key) {
    return _map[key];
  }

  clear() {
    _map.clear();
  }

  keys() {
    return _map.keys;
  }

  factory Dictionary.fromJson(Map<String, dynamic> json) {
    return Dictionary();
  }
}
