import 'package:flutter_ui/core/models/user/loginModel.dart';
import 'package:flutter_ui/core/services/authService.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/core/services/translateService.dart';
import 'package:flutter_ui/core/services/userService.dart';
import 'package:flutter_ui/core/services/validationService.dart';

import '../../../utilities/component.dart';

class LoginComponent implements Component {
  AuthService _authService = AuthService();
  ValidationService _validationService = ValidationService();

  Future<void> login(LoginModel user) async {
    var response = await _authService.login(user);
    _validationService.showErrors(response.jsonData);

    whenComplete();
  }

  @override
  void whenComplete() {
    // TODO: implement whenComplete
  }
}
