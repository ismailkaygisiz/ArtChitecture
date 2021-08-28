import 'dart:io';
import 'package:flutter/material.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:flutter_ui/pages/main/homePage/homePageUI.dart';
import 'core/utilities/dependencyResolver.dart';
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
      title: "ArtChitectureFlutterUI",
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
  String _lang;

  @override
  void initState() {
    super.initState();

    //

    authService.setRefreshTokenEvents(
      refreshTokenFailedEvent:
          () => // It's Works When Token Refresh Operation On Failed
              print("Failed"),
      refreshTokenSucceedEvent:
          (token) => // It's Works When Token Refresh Operation On Succeed
              print(
        "Succeed, Token Expiration : ${token.expiration}",
      ),
    );

    //

    _setLang();
    _getTranslates();
  }

  @override
  Widget build(BuildContext context) {
    sessionService.get("lang").then((String value) {
      if (_lang != value) _getTranslates();
    });

    return translates.values.length > 0
        ? HomePageUI()
        : Scaffold(
            appBar: AppBar(
              title: Text("Loading"),
              centerTitle: true,
            ),
            body: Center(),
          );
  }

  void _getTranslates() {
    sessionService.get("lang").then((value) {
      _lang = value;
      translateService.getTranslates(value).then((dynamic value) {
        setState(() => translates = value["data"]);
      });
    });
  }

  void _setLang() {
    try {
      sessionService.set("lang", Platform.localeName.replaceAll("_", "-"));
    } catch (err) {
      sessionService.set("lang", "en-US");
    }
  }
}
