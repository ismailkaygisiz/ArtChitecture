import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

/// You can get the current platform name and locale name
/// You can add custom Widget for current platform
class CurrentPlatform extends StatelessWidget {
  final Widget? android;
  final Widget? ios;
  final Widget? windows;
  final Widget? macOs;
  final Widget? linux;
  final Widget? web;
  final Widget? fuchsia;

  CurrentPlatform({
    this.android,
    this.ios,
    this.windows,
    this.macOs,
    this.linux,
    this.web,
    this.fuchsia,
  });

  static String getLocaleName() {
    if (isWeb()) return "en-US";

    return Platform.localeName.replaceAll("_", "-");
  }

  static String getPlatform() {
    try {
      if (Platform.isAndroid) return PlatformName.ANDROID;
      if (Platform.isIOS) return PlatformName.IOS;
      if (Platform.isWindows) return PlatformName.WINDOWS;
      if (Platform.isMacOS) return PlatformName.MACOS;
      if (Platform.isLinux) return PlatformName.LINUX;
      if (Platform.isFuchsia) return PlatformName.FUCHSIA;

      return PlatformName.WEB;
    } catch (err) {
      return PlatformName.WEB;
    }
  }

  static bool isAndroid() {
    return getPlatform() == "android";
  }

  static bool isIOS() {
    return getPlatform() == "ios";
  }

  static bool isWindows() {
    return getPlatform() == "windows";
  }

  static bool isMacOS() {
    return getPlatform() == "macOs";
  }

  static bool isLinux() {
    return getPlatform() == "linux";
  }

  static bool isFuchsia() {
    return getPlatform() == "fuchsia";
  }

  static bool isWeb() {
    return getPlatform() == "web";
  }

  @override
  Widget build(BuildContext context) {
    switch (getPlatform()) {
      case PlatformName.ANDROID:
        if (android != null) return android!;
        throw Exception("Android was null");
      case PlatformName.IOS:
        if (ios != null) return ios!;
        throw Exception("IOS was null");
      case PlatformName.WINDOWS:
        if (windows != null) return windows!;
        throw Exception("Windows was null");
      case PlatformName.MACOS:
        if (macOs != null) return macOs!;
        throw Exception("MacOs was null");
      case PlatformName.LINUX:
        if (linux != null) return linux!;
        throw Exception("Linux was null");
      case PlatformName.FUCHSIA:
        if (fuchsia != null) return fuchsia!;
        throw Exception("Fuchsia was null");

      default:
        throw Exception("");
    }
  }
}

class PlatformName {
  static const ANDROID = "android";
  static const IOS = "ios";
  static const WINDOWS = "windows";
  static const MACOS = "macOs";
  static const LINUX = "linux";
  static const FUCHSIA = "fuchsia";
  static const WEB = "web";
}
