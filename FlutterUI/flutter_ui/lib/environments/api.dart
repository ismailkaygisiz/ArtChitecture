import 'dart:io';

/// Translates
Map? translates;

class Environments {
  /// API url.
  /// Example "https://api.example.com/api"
  static const String API_URL =
      "https://localhost:5001/api/"; // Your IP Address for Development  // For Mobile 192.168.1.33 // For Web and Desktop localhost

  /// Base url.
  /// Example "https://api.example.com/"
  static const String BASE_URL =
      "https://localhost:5001/"; // Your IP Address for Development  // For Mobile 192.168.1.33 // For Web and Desktop localhost

  /// Base url for images.
  /// Example "https://api.example.com"
  static const String BASE_URL_FOR_IMAGE =
      "https://localhost:5001/"; // Your IP Address for Development  // For Mobile 192.168.1.33 // For Web and Desktop localhost

  /// Your Client Name
  /// Example "Flutter"
  static const String CLIENT_NAME = "Flutter";
}

class _DevelopmentModeHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}

/// Development Mode For Http Requests
/// Don't Use This in Production Mode
class DevelopmentMode {
  DevelopmentMode() {
    HttpOverrides.global = _DevelopmentModeHttpOverrides();
  }
}
