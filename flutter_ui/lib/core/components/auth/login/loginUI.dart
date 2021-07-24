import 'package:flutter/material.dart';
import 'package:flutter_ui/environments/api.dart';
import 'loginComponent.dart';

class LoginUI extends StatefulWidget {
  @override
  _LoginUIState createState() => _LoginUIState();
}

class _LoginUIState extends State<LoginUI> with LoginComponent {
  @override
  void initState() {
    super.initState();
  }

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
