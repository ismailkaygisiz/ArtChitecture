import 'package:flutter/material.dart';
import 'package:flutter_ui/utilities/theme.dart';
import 'package:get/get.dart';
import 'package:get_storage/get_storage.dart';

import 'environments/api.dart';
import 'home.dart';
import 'main.reflectable.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized(); // For SharedPreferences
  initializeReflectable(); // For Reflection (ResponseModels)
  await GetStorage.init(); // For GetStorage
  DevelopmentMode(); // For SSL Configuration. Don't Use Production Mode

  runApp(App());
}

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
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
