import 'package:flutter/material.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/core/services/translateService.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:flutter_ui/pages/main/homePage/homePageUI.dart';
import 'environments/environment.development.dart';
import 'main.reflectable.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  initializeReflectable();
  EnvironmentDev();

  runApp(App());
}

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Home(),
    );
  }
}

class Home extends StatefulWidget {
  const Home({Key key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  TranslateService _translateService = TranslateService();
  SessionService _sessionService = SessionService();

  void getTranslates() {
    _sessionService.set("lang", "tr-Tr");

    _sessionService.get("lang").then((value) {
      if (value != null) {
        _translateService.getTranslates(value).then((dynamic value) {
          TRANSLATES = value["data"];
          setState(() {});
        });
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    getTranslates();
    return TRANSLATES.values.length > 0
        ? HomePageUI()
        : Scaffold(
            appBar: AppBar(),
            body: Center(),
          );
  }
}
