import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_ui/core/utilities/current_platform.dart';

class PlatformProgressIndicator extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    if (CurrentPlatform.isIOS()) {
      return CupertinoActivityIndicator();
    } else {
      return CircularProgressIndicator();
    }
  }
}
