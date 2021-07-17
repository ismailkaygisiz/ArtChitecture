import 'package:flutter/material.dart';
import 'package:flutter_ui/core/models/user/loginModel.dart';
import 'package:flutter_ui/core/services/authService.dart';
import 'package:reflectable/reflectable.dart';
import 'core/components/auth/login/loginUI.dart';
import 'core/environments/environment.development.dart';
import 'core/services/sessionService.dart';
import 'main.reflectable.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  initializeReflectable();
  EnvironmentDev();
  runApp(App());
}

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: LoginUI(),
    );
  }
}
