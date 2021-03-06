import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { baseUrl } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private _hubConnection: HubConnection;

  async start(url: string): Promise<void> {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(baseUrl + url)
      .withAutomaticReconnect([
        1000, 2000, 2000, 2000, 5000, 5000, 10000, 50000,
      ])
      .build();

    await this._hubConnection.start();
  }

  async startManually(hubConnection: HubConnection): Promise<void> {
    this._hubConnection = hubConnection;
    await this._hubConnection.start();
  }

  getHubConnection(): HubConnection {
    return this._hubConnection;
  }

  async invoke(methodName: string, args: any[]): Promise<any> {
    return await this._hubConnection.invoke(methodName, args);
  }

  on(methodName: string, method: (...args: any[]) => void): void {
    this._hubConnection.on(methodName, method);
  }
}
