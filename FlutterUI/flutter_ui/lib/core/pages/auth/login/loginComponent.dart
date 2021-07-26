import 'package:flutter_ui/core/models/user/loginModel.dart';
import 'package:flutter_ui/core/models/user/registerModel.dart';
import 'package:flutter_ui/core/services/authService.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/core/services/translateService.dart';
import 'package:flutter_ui/core/services/userService.dart';
import 'package:flutter_ui/core/services/validationService.dart';
import 'package:flutter_ui/core/utilities/dependencyResolver.dart';

import '../../../utilities/component.dart';

class LoginComponent implements Component {
  Future<void> login(LoginModel user) async {
    var response = await authService.login(user);
    if (!validationService.showErrors(response.jsonData)) {
      tokenService.setToken(response.data.token);
    }

    whenComplete();
  }

  @override
  void whenComplete() {
    // TODO: implement whenComplete
  }
}
