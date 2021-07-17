import 'package:flutter_ui/core/models/user/userModel.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/core/services/userService.dart';

import '../../component.dart';

class LoginComponent implements Component {
  UserService _userService = UserService();
  List<UserModel> users;

  Future<void> getAll() async {
    var userResponseModel = await _userService.getAll();

    users = userResponseModel.data;
    whenComplete();
  }

  @override
  void whenComplete() {
    // TODO: implement whenComplete
  }
}
