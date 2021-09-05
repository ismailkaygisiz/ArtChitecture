import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:flutter_ui/components/platform_progress_indicator.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:flutter_ui/pages/main/homePage/home_page_component.dart';

class HomePageScreen extends StatefulWidget {
  @override
  _HomePageScreenState createState() => _HomePageScreenState();
}

class _HomePageScreenState extends State<HomePageScreen>
    with HomePageComponent {
  int value = 0;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          translates!["Hello_World_Key"],
          style: TextStyle(
            fontSize: 30,
          ),
        ),
        centerTitle: true,
      ),

      //

      body: SafeArea(
        child: Center(
          child: SingleChildScrollView(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                buildFlutterIconSvg(),
                SizedBox(height: MediaQuery.of(context).size.height * 0.1),
                buildWelcomeText(),
                Padding(
                  padding: const EdgeInsets.all(30.0),
                  child: buildIncreaseButton(),
                ),
                const SizedBox(height: 15),
                buildValueText(),
              ],
            ),
          ),
        ),
      ),
      floatingActionButton: buildResetButton(),
    );
  }

  Widget buildFlutterIconSvg() {
    return SvgPicture.asset(
      "assets/icon.svg",
      placeholderBuilder: (context) => PlatformProgressIndicator(),
    );
  }

  Widget buildValueText() {
    return Text("${translates!["Value_Key"]} : $value");
  }

  Widget buildWelcomeText() {
    return Text(
      translates!["Welcome_Key"] ?? "",
      style: TextStyle(
        fontSize: 25,
      ),
    );
  }

  Widget buildIncreaseButton() {
    return ElevatedButton(
      onPressed: _handleIncreaseButton,
      child: Text(translates!["Increment_Key"]),
      style: ButtonStyle(
        shape: MaterialStateProperty.all<RoundedRectangleBorder>(
          RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(18.0),
          ),
        ),
      ),
    );
  }

  Widget buildResetButton() {
    return FloatingActionButton(
      onPressed: _handleResetButton,
      child: Text(
        translates!["Reset_Key"],
      ),
    );
  }

  void _handleIncreaseButton() {
    if (mounted)
      setState(() {
        value++;
      });
  }

  void _handleResetButton() {
    if (mounted)
      setState(() {
        value = 0;
      });
  }

  @override
  void whenComplete() {
    if (mounted) setState(() {});
  }
}
