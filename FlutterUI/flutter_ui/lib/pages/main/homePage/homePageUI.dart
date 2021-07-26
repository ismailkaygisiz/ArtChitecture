import 'package:flutter/material.dart';
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
            "Hello World",
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
                "Welcome to ArtChitecture",
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
                        child: Text("Click Me"),
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
                "Value : $value",
                style: TextStyle(color: Colors.black54, fontSize: 20),
              ),
            ],
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _handleFloatingActionButton,
        child: Text(
          "Reset",
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
