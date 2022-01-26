import 'package:flutter/material.dart';

/// You can add custom Widget for device size
class Responsive extends StatelessWidget {
  final Widget? mobile;
  final Widget? mobileLarge;
  final Widget? tablet;
  final Widget? desktop;

  const Responsive({
    Key? key,
    this.mobile,
    this.tablet,
    this.desktop,
    this.mobileLarge,
  }) : super(key: key);

  static Size getDeviceSize(BuildContext context) =>
      MediaQuery.of(context).size;

  static bool isMobile(BuildContext context) =>
      MediaQuery.of(context).size.width <= 500;

  static bool isMobileLarge(BuildContext context) =>
      MediaQuery.of(context).size.width >= 500 &&
      MediaQuery.of(context).size.width <= 700;

  static bool isTablet(BuildContext context) =>
      MediaQuery.of(context).size.width >= 700 &&
      MediaQuery.of(context).size.width < 1024;

  static bool isDesktop(BuildContext context) =>
      MediaQuery.of(context).size.width >= 1024;

  @override
  Widget build(BuildContext context) {
    if (Responsive.isDesktop(context) && desktop != null) return desktop!;

    if (Responsive.isTablet(context) && tablet != null) return tablet!;

    if (Responsive.isMobileLarge(context) && mobileLarge != null) {
      return mobileLarge!;
    }

    if (mobile == null) throw Exception("Mobile was null");

    return mobile!;
  }
}
