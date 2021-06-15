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
  AuthService _authService = AuthService();
  SessionService _sessionService = SessionService();

  _authService.login(LoginModel("admin@admin.com", "Admin123")).then((value) {
    print(value.success);
    print(value.message);
    print(value.data.token);
    _sessionService.set("token", value.data.token);
    print(value.data.expiration);
  });

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
