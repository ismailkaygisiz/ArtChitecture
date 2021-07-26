import 'package:flutter_ui/core/utilities/service.dart';
import 'package:flutter_ui/environments/api.dart';
import 'package:signalr_netcore/hub_connection.dart';
import 'package:signalr_netcore/hub_connection_builder.dart';

class SignalRService extends Service {
  HubConnection _hubConnection;

  Future<void> start(String hubUrl) async {
    _hubConnection = HubConnectionBuilder().withUrl(IMAGE_URL + hubUrl).build();
    await _hubConnection.start();
  }

  Future<void> startManually(HubConnection hubConnection) async {
    _hubConnection = hubConnection;
    await _hubConnection.start();
  }

  HubConnection getHubConnection() {
    return _hubConnection;
  }

  Future<Object> invoke(String methodName, List<Object> args) async {
    final result = await _hubConnection.invoke(methodName, args: args);
    return result;
  }

  void on(String methodName, MethodInvocationFunc method) {
    _hubConnection.on(methodName, method);
  }
}
