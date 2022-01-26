export interface RefreshTokenModel {
  refreshTokenId: number;
  userId: number;
  clientId: string;
  clientName: string;
  tokenValue: string;
  refreshTokenValue: string;
  refreshTokenEndDate: Date;
}
