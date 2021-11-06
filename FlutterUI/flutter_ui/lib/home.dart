import 'package:flutter/material.dart';
import 'package:flutter_ui/core/utilities/responsive_design.dart';
import 'package:flutter_ui/pages/main/homePage/home_page_screen.dart';
import 'package:flutter_ui/pages/main/loadingPage/loading_page_screen.dart';

import 'core/utilities/current_platform.dart';
import 'core/utilities/dependency_resolver.dart';
import 'environments/api.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  String? _lang;

  @override
  void initState() {
    super.initState();

    //

    print("Platform Name : ${CurrentPlatform.getPlatform()}");
    print("Platform Locale Name : ${CurrentPlatform.getLocaleName()}\n\n");

    print("Android : ${CurrentPlatform.isAndroid()}");
    print("IOS : ${CurrentPlatform.isIOS()}");
    print("Windows : ${CurrentPlatform.isWindows()}");
    print("MacOs : ${CurrentPlatform.isMacOS()}");
    print("Linux : ${CurrentPlatform.isLinux()}");
    print("Fuchsia : ${CurrentPlatform.isFuchsia()}");
    print("Web : ${CurrentPlatform.isWeb()}");

    //

    _setRefreshTokenEvents();
    _setLang();
    _getTranslates();
  }

  @override
  Widget build(BuildContext context) {
    _translateControl();

    print("Screen Width : ${ResponsiveDesign.getDeviceSize(context).width}");
    print("Screen Height : ${ResponsiveDesign.getDeviceSize(context).height}");

    // print("Desktop : ${Responsive.isDesktop(context)}");
    // print("Tablet : ${Responsive.isTablet(context)}");
    // print("MobileLarge : ${Responsive.isMobileLarge(context)}");
    // print("Mobile : ${Responsive.isMobile(context)}");

    /// "return translates != null ? YourCustomHomeScreen() : YourCustomLoadingScreen();"
    /// If you don't want to use translates you can use "return YourCustomHomePageScreen();"
    return translates != null ? HomePageScreen() : LoadingPageScreen();
  }

  // This area for necessary private methods

  ///
  ///
  ///
  ///
  ///
  ///

  /// Sets [refreshTokenEvents] in [authService] for [HttpInterceptor]
  void _setRefreshTokenEvents() {
    authService.setRefreshTokenEvents(
      refreshTokenFailedEvent: // It's Works When Token Refresh Operation On Failed
          () => print("Failed"),
      refreshTokenSucceedEvent: // It's Works When Token Refresh Operation On Succeed
          (token) => print("Succeed, Token Expiration : ${token?.expiration}"),
    );
  }

  /// It controls translates
  /// If [lang] in session equals null it runs [_getTranslates]
  Future<void> _translateControl() async {
    var lang = await sessionService.get("lang");
    if (_lang != lang) _getTranslates();
  }

  /// Sets [translates] in [Environments]
  Future<void> _getTranslates() async {
    var lang = await sessionService.get("lang");
    _lang = lang;

    Map? _translates = await translateService.getTranslates(lang);
    if (mounted) setState(() => translates = _translates?["data"]);
  }

  /// Changes default language if [lang] in session returns null
  Future<void> _setLang() async {
    var lang = await sessionService.get("lang");
    if (lang == null)
      sessionService.set("lang", CurrentPlatform.getLocaleName());
  }
}
