import 'package:flutter/material.dart';

import 'loginComponent.dart';

class LoginUI extends StatefulWidget {
  @override
  _LoginUIState createState() => _LoginUIState();
}

class _LoginUIState extends State<LoginUI> with LoginComponent {
  @override
  void initState() {
    super.initState();
    super.getAllUsers();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Hello World"),
      ),
      body: users == null
          ? Center(
              child: Text("Null"),
            )
          : ListView.separated(
              padding: const EdgeInsets.all(8),
              itemCount: users.length,
              itemBuilder: (BuildContext context, int index) {
                return GestureDetector(
                  onTap: () {
                    print(users[index].id);
                  },
                  child: Container(
                    height: 50,
                    color: Colors.greenAccent,
                    child: Center(
                      child: Text(
                        'Kullanıcının Adı : ${users[index].firstName}',
                      ),
                    ),
                  ),
                );
              },
              separatorBuilder: (BuildContext context, int index) =>
                  const Divider(),
            ),
    );
  }

  @override
  void whenComplete() {
    setState(() {});
  }
}
