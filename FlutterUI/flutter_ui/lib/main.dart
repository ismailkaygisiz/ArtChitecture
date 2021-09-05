import 'package:flutter/material.dart';
import 'package:flutter_ui/home.dart';
import 'package:flutter_ui/utilities/theme.dart';

import 'core/utilities/configure_nonweb.dart'
    if (dart.library.html) 'core/utilities/configure_web.dart';
import 'environments/api.dart';
import 'main.reflectable.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized(); // For SharedPreferences
  initializeReflectable(); // For Reflection (ResponseModels)
  configureApp(); // For Web Url Path (Discards #)
  DevelopmentMode(); // For SSL Configuration. Don't Use Production Mode

  runApp(App());
}

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: "ArtChitecture FlutterUI",
      theme: lightTheme(context),
      darkTheme: darkTheme(context),
      // highContrastTheme: ,
      // highContrastDarkTheme: ,
      themeMode: ThemeMode.system,
      home: Home(),
    );
  }
}
