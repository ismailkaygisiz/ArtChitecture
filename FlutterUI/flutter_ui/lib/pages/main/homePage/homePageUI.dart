import 'package:flutter/material.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:flutter_ui/pages/main/homePage/homePageComponent.dart';

class HomePageUI extends StatefulWidget {
  const HomePageUI({Key key}) : super(key: key);

  @override
  _HomePageUIState createState() => _HomePageUIState();
}

class _HomePageUIState extends State<HomePageUI> with HomePageComponent {
  int value = 0;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Center(
          child: Text(
            TRANSLATES["Hello_World_Key"],
            style: TextStyle(
              color: Colors.black54,
              fontSize: 30,
            ),
          ),
        ),
      ),
      body: SafeArea(
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                TRANSLATES["Welcome_Key"],
                style: TextStyle(
                  color: Colors.teal,
                  fontSize: 25,
                ),
              ),
              Row(
                children: [
                  Expanded(
                    child: Padding(
                      padding: const EdgeInsets.all(30.0),
                      child: ElevatedButton(
                        onPressed: _handleTextButton,
                        child: Text(TRANSLATES["Increment_Key"]),
                        style: ButtonStyle(
                          shape:
                              MaterialStateProperty.all<RoundedRectangleBorder>(
                            RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(18.0),
                            ),
                          ),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
              Text(
                "${TRANSLATES["Value_Key"]} : $value",
                style: TextStyle(color: Colors.black54, fontSize: 20),
              ),
            ],
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _handleFloatingActionButton,
        child: Text(
          TRANSLATES["Reset_Key"],
        ),
      ),
    );
  }

  void _handleTextButton() {
    setState(() {
      value++;
    });
  }

  void _handleFloatingActionButton() {
    setState(() {
      value = 0;
    });
  }

  @override
  void whenComplete() {
    setState(() {});
  }
}
