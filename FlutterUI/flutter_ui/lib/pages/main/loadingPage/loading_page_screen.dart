import 'package:flutter/material.dart';
import 'package:flutter_ui/components/platform_progress_indicator.dart';
import 'package:flutter_ui/pages/main/loadingPage/loading_page_component.dart';

class LoadingPageScreen extends StatelessWidget with LoadingPageComponent {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Center(
          child: SingleChildScrollView(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                PlatformProgressIndicator(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  @override
  void whenComplete() {
    print("Completed");
  }
}
