import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { imageUrl } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private hubConnection: HubConnection;
  constructor() {}

  start(url: string): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(imageUrl + url)
      .build();
    this.hubConnection.start();
  }

  startManually(hubConnection: HubConnection): void {
    this.hubConnection = hubConnection;
    this.hubConnection.start();
  }

  getHubConnection(): HubConnection {
    return this.hubConnection;
  }

  invoke(methodName: string, args: any[]): Promise<any> {
    return this.hubConnection.invoke(methodName, args);
  }

  on(methodName: string, method: (...args: any[]) => void): void {
    this.hubConnection.on(methodName, method);
  }
}
