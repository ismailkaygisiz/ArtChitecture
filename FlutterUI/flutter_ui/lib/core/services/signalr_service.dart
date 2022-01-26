import 'package:flutter_ui/environments/api.dart';
import 'package:signalr_netcore/hub_connection.dart';
import 'package:signalr_netcore/hub_connection_builder.dart';

class SignalRService {
  late HubConnection _hubConnection;

  Future<void> start(String hubUrl) async {
    _hubConnection = HubConnectionBuilder()
        .withUrl(Environments.BASE_URL + hubUrl)
        .withAutomaticReconnect(
      retryDelays: [
        1000,
        1000,
        1000,
        1000,
        5000,
        5000,
        10000,
        50000,
      ],
    ).build();

    await _hubConnection.start();
  }

  Future<void> startManually(HubConnection hubConnection) async {
    _hubConnection = hubConnection;
    await _hubConnection.start();
  }

  HubConnection getHubConnection() {
    return _hubConnection;
  }

  Future<Object?> invoke(String methodName, List<Object> args) async {
    return await _hubConnection.invoke(methodName, args: args);
  }

  void on(String methodName, MethodInvocationFunc method) {
    _hubConnection.on(methodName, method);
  }
}
