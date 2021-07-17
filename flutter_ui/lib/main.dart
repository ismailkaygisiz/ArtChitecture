import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/core/services/translateService.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:reflectable/reflectable.dart';
import 'core/components/auth/login/loginUI.dart';
import 'core/environments/environment.development.dart';
import 'main.reflectable.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  initializeReflectable();
  EnvironmentDev();
  runApp(App());
}

class App extends StatelessWidget {
  TranslateService _translateService = TranslateService();
  SessionService _sessionService = SessionService();

  @override
  Widget build(BuildContext context) {
    _sessionService.set("lang", "tr-Tr");

    _sessionService.get("lang").then((value) {
      if (value != null) {
        _translateService.getTranslates(value).then((dynamic value) {
          TRANSLATES = value["data"];
        });
      }
    });

    return MaterialApp(
        home: TRANSLATES.values.length > 0
            ? LoginUI()
            : Scaffold(
                appBar: AppBar(),
                body: Center(),
              ));
  }
}
