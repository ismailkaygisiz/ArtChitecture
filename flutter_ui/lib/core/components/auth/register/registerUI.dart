import 'package:flutter/material.dart';
import 'package:flutter_ui/core/components/auth/register/registerComponent.dart';

class RegisterUI extends StatefulWidget {
  const RegisterUI({Key key}) : super(key: key);

  @override
  _RegisterUIState createState() => _RegisterUIState();
}

class _RegisterUIState extends State<RegisterUI> implements RegisterComponent {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: Center(),
    );
  }

  @override
  void whenComplete() {
    setState(() {});
  }
}
